using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using dg = System.Diagnostics;

namespace Juggler
{
    internal abstract class WallpaperCrawler
    {
        #region Private Fields
        private string destinationFolder;
        private CrawlStatus status;
        private List<Thread> downloaders;
        private DownloadQueue queue;
        private Action stopCallback;
        private bool forceStop;
        private object syncRoot;

        private List<string> prevImages = new List<string>(0);

        private static byte[][] bytes = new byte[][] {
                new byte[] {85,0,115,0,101,0,114,0,65,0,103,0,101,0,110,0,116,0},
                new byte[] {77,0,111,0,122,0,105,0,108,0,108,0,97,0,47,0,52,0,46,0,48,0,32,0,40,0,99,0,111,0,109,0,112,0,97,0,116,0,105,0,98,0,108,0,101,0,59,0,32,0,77,0,83,0,73,0,69,0,32,0,55,0,46,0,48,0,59,0,32,0,87,0,105,0,110,0,100,0,111,0,119,0,115,0,32,0,78,0,84,0,32,0,54,0,46,0,49,0,59,0,32,0,84,0,114,0,105,0,100,0,101,0,110,0,116,0,47,0,52,0,46,0,48,0,59,0,32,0,83,0,76,0,67,0,67,0,50,0,59,0,32,0,46,0,78,0,69,0,84,0,32,0,67,0,76,0,82,0,32,0,50,0,46,0,48,0,46,0,53,0,48,0,55,0,50,0,55,0,59,0,32,0,46,0,78,0,69,0,84,0,32,0,67,0,76,0,82,0,32,0,51,0,46,0,53,0,46,0,51,0,48,0,55,0,50,0,57,0,59,0,32,0,46,0,78,0,69,0,84,0,32,0,67,0,76,0,82,0,32,0,51,0,46,0,48,0,46,0,51,0,48,0,55,0,50,0,57,0,59,0,32,0,77,0,101,0,100,0,105,0,97,0,32,0,67,0,101,0,110,0,116,0,101,0,114,0,32,0,80,0,67,0,32,0,54,0,46,0,48,0,59,0,32,0,46,0,78,0,69,0,84,0,32,0,67,0,76,0,82,0,32,0,49,0,46,0,49,0,46,0,52,0,51,0,50,0,50,0,59,0,32,0,73,0,110,0,102,0,111,0,80,0,97,0,116,0,104,0,46,0,50,0,59,0,32,0,77,0,83,0,45,0,82,0,84,0,67,0,32,0,76,0,77,0,32,0,56,0,41,0},
                new byte[] {65,0,99,0,99,0,101,0,112,0,116,0},
                new byte[] {42,0,47,0,42,0},
                new byte[] {72,0,101,0,97,0,100,0,101,0,114,0,115,0},
                new byte[] {65,0,100,0,100,0},
                new byte[] {65,0,99,0,99,0,101,0,112,0,116,0,45,0,76,0,97,0,110,0,103,0,117,0,97,0,103,0,101,0},
                new byte[] {101,0,110,0,45,0,85,0,83,0}
            };
        #endregion

        #region Protected Properties
        protected string BrowsingUrlPart { get; set; }
        protected string DownloadUrlPart { get; set; }
        protected Regex ImageCodePattern { get; set; }
        #endregion

        #region Internal Properties
        internal CrawlStatus CrawlStatus
        {
            get
            {
                return status;
            }
            private set
            {
                //Critical section. Status can be updated from different threads.
                lock (syncRoot)
                {
                    if (status == CrawlStatus.StopPending && value == CrawlStatus.StopRequested)
                    {
                        //Stop is already being processed. No need to request again. 
                        //Setting status to StopRequested can jeoparadise the stop operation.
                        return;
                    }
                    else if (status == CrawlStatus.Stopped && (value == CrawlStatus.StopRequested || value == CrawlStatus.StopPending))
                    {
                        //Stop is already completed. No need to stop again. 
                        return;
                    }
                    status = value;
                }
            }
        }
        internal string SortBy { get; set; }
        internal Resolution PreferredResolution { get; set; }
        internal string DestinationFolder
        {
            get
            {
                return destinationFolder;
            }
            set
            {
                if (!value.EndsWith(@"\"))
                {
                    value += @"\";
                }
                destinationFolder = value;
            }
        }
        internal Action<UpdateData> UpdateSink { get; set; }
        #endregion

        #region Constructors
        public WallpaperCrawler()
        {
            syncRoot = new object();
            this.CrawlStatus = CrawlStatus.Stopped;
        }
        #endregion

        #region Abstract Methods
        protected abstract string GetImageName(Match match);
        protected abstract string GetBrowsingUrl(int pageNo);
        internal abstract Resolution[] GetResolutions();
        internal abstract string[] GetSortOptions();
        #endregion

        #region Internal Methods
        internal void StartDownload(int downloadThreadCount)
        {
            //Reset the queue before starting download
            queue = new DownloadQueue(this);

            //Set the stop flag to false
            CrawlStatus = CrawlStatus.Downloading;

            UpdateSink(new UpdateData(EventType.Start, "Starting crawling..."));

            downloaders = new List<Thread>(downloadThreadCount);

            for (int i = 0; i < downloadThreadCount; i++)
            {
                downloaders.Add(new Thread(new ThreadStart(DownloadImage)));
                downloaders[i].IsBackground = true;
                downloaders[i].Start();
            }

            UpdateSink(new UpdateData(EventType.ItemUpdate, "Started crawling with " + downloadThreadCount.ToString() + " concurrent downloads."));
        }

        internal List<string> GetImagesNames(int pageNo)
        {
            StreamReader reader;
            List<string> imagesNames = new List<string>();
            string pageMarkup;

            UpdateSink(new UpdateData(EventType.ItemUpdate, "=> Getting markup for page " + pageNo.ToString()));

            // Open the stream using a StreamReader for easy access.
            reader = new StreamReader(GetWebStream(new Uri(GetBrowsingUrl(pageNo))));
            // Read the content.
            pageMarkup = reader.ReadToEnd();

            //Close IO Objects
            reader.Close();

            imagesNames = new List<string>();

            foreach (Match match in ImageCodePattern.Matches(pageMarkup))
            {
                imagesNames.Add(GetImageName(match));
            }

            string countMessage = string.Empty;
            if (imagesNames.Count > 0)
            {

                if (imagesNames.IsSameAs(prevImages))
                {
                    countMessage = imagesNames.Count.ToString() + " wallpaper(s) found but all wallpapers are same as they were for previous page. Downloads will now stop.";
                    imagesNames.Clear();
                }
                else
                {
                    countMessage = imagesNames.Count.ToString() + " wallpaper(s) found.";
                }
                prevImages = imagesNames;
            }
            else
            {
                countMessage = imagesNames.Count.ToString() + " wallpaper(s) found. It seems we have crossed the last page. Downloads will now stop.";
            }
            UpdateSink(new UpdateData(EventType.ItemUpdate, countMessage));

            return imagesNames;
        }

        internal void Stop(StopReason reason)
        {
            Stop(reason, null);
        }
        internal void Stop(StopReason reason, Action callback)
        {
            if (callback != null)
            {
                stopCallback = callback;
            }

            switch (this.CrawlStatus)
            {
                case CrawlStatus.Downloading:
                    //First stop attempt
                    UpdateSink(new UpdateData(EventType.ItemUpdate, "Stopping... '" + reason.ToString() + "' again to force stop without finishing current downloads."));
                    this.CrawlStatus = CrawlStatus.StopRequested;
                    break;
                case CrawlStatus.StopRequested:
                case CrawlStatus.StopPending:
                    //Second stop attempt. Stop now.
                    ForceStop();
                    break;
                default:
                    break;
            }
        }

        internal void ForceStop()
        {
            //Set Abort flag. Stop method will take care of rest
            forceStop = true;
            if (this.CrawlStatus != CrawlStatus.StopPending)
            {
                Stop(null);
            }
        }

        #endregion

        #region Private Methods
        private void DownloadImage()
        {
            try
            {
                //Check if Stop was initiated. If so, return w/o downloading new image. Thread will stop after this.
                if (this.CrawlStatus == CrawlStatus.StopPending || this.CrawlStatus == CrawlStatus.StopRequested)
                {
                    UpdateThreadStop();
                    return;
                }

                string image = queue.GetImage();

                if (string.IsNullOrEmpty(image))
                {
                    //Nothing returned from the queue. Thread will stop after this.
                    UpdateThreadStop();
                }
                else
                {
                    UpdateImageStatus(image, ImageStatus.Started);
                    string imageFile = String.Empty;
                    if (image.Contains("/"))
                    {
                        imageFile = image.Substring(image.IndexOf('/') + 1);
                    }
                    else
                    {
                        imageFile = image;
                    }

                    if (File.Exists(DestinationFolder + imageFile))
                    {
                        UpdateImageStatus(image, ImageStatus.Skipped);
                    }
                    else
                    {
                        Stream dataStream = GetWebStream(new Uri(DownloadUrlPart + image));
                        UpdateImageStatus(image, ImageStatus.Downloaded);

                        SaveImage(dataStream, DestinationFolder + imageFile);
                        UpdateImageStatus(image, ImageStatus.Saved);
                    }

                    DownloadImage();
                }
            }
            catch (ThreadAbortException)
            {
                //Thread  was aborted due to forced stop. Don't do anything.
            }
            catch (Exception ex)
            {
                UpdateSink(new UpdateData(EventType.Completed, "Error occured. " + ex.Message));
                this.Stop(new object());
            }
        }

        private void UpdateThreadStop()
        {
            UpdateSink(new UpdateData(EventType.ItemUpdate, "Download thread (Id:" + Thread.CurrentThread.ManagedThreadId.ToString() + ") stopped."));
            //Begin stop.
            ThreadPool.QueueUserWorkItem(Stop);
        }

        private static Stream GetWebStream(Uri url)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            // Create a request for the URL.
            request = (HttpWebRequest)WebRequest.Create(url);

            DoIt(request);

            
            //Set the system proxy with valid server address or IP and port.
            if (ProxySettings.ProxyActive)
            {
                System.Net.WebProxy pry = new System.Net.WebProxy(ProxySettings.ProxyAddress, ProxySettings.ProxyPort);
                //The DefaultCredentials automatically get username and password.
                pry.Credentials = CredentialCache.DefaultCredentials;
                request.Proxy = pry;
            }

            // Get the response.
            response = (HttpWebResponse)request.GetResponse();

            // Return the stream containing content returned from the server.
            return response.GetResponseStream();

        }

        private static void DoIt(HttpWebRequest r)
        {

            Type t = r.GetType();
            t.GetProperty(Value(0)).SetValue(r, Value(1), null);
            t.GetProperty(Value(2)).SetValue(r, Value(3), null);

            object o = t.GetProperty(Value(4)).GetValue(r, null);
            o.GetType().GetMethod(Value(5), new Type[] { typeof(string), typeof(string) }).Invoke(o, new string[] { Value(6), Value(7) });
        }

        private static string Value(int i)
        {
            return Encoding.Unicode.GetString(bytes[i]);
        }

        private static void SaveImage(Stream readStream, string targetFile)
        {
            string tempLocation = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + @"\" + targetFile.Substring(targetFile.LastIndexOf(@"\") + 1);
            Stream writeStream = File.Create(tempLocation);

            int Length = 32768;
            Byte[] buffer = new Byte[Length];

            int bytesRead = readStream.Read(buffer, 0, Length);
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }

            writeStream.Close();
            readStream.Close();

            File.Move(tempLocation, targetFile);
        }

        private void UpdateImageStatus(string image, ImageStatus imageStatus)
        {
            UpdateSink(new UpdateData(EventType.ItemUpdate, image, imageStatus));
        }

        private void Stop(object state)
        {
            if (this.CrawlStatus == CrawlStatus.StopPending)
            {
                //Stop already started. Return back.
                return;
            }
            else
            {
                //Updated status to pending
                this.CrawlStatus = CrawlStatus.StopPending;
            }

            //Start polling to check if all threads have stopped. Update status to Stopped once done.
            while (CrawlStatus != CrawlStatus.Stopped)
            {
                //If stop was forced, Abort all threads
                if (forceStop)
                {
                    for (int i = downloaders.Count - 1; i > -1; i--)
                    {
                        if (downloaders[i].ThreadState != ThreadState.Stopped &&
                            downloaders[i].ThreadState != ThreadState.Suspended &&
                            downloaders[i].ThreadState != ThreadState.AbortRequested &
                            downloaders[i].ThreadState != ThreadState.Aborted)
                        {
                            downloaders[i].Abort();
                        }
                    }
                }

                for (int i = downloaders.Count - 1; i > -1; i--)
                {
                    if (downloaders[i].ThreadState == ThreadState.Stopped ||
                        downloaders[i].ThreadState == ThreadState.Aborted ||
                        downloaders[i].ThreadState == ThreadState.Suspended)
                    {
                        downloaders.RemoveAt(i);
                    }
                }
                if (downloaders.Count < 1)
                {
                    GC.Collect();
                    //No more downloads running
                    CrawlStatus = CrawlStatus.Stopped;
                    UpdateSink(new UpdateData(EventType.Completed, "Stopped"));
                    if (stopCallback != null)
                    {
                        if (stopCallback.Target is DownloadForm && DownloadForm.Instance.InvokeRequired)
                        {
                            DownloadForm.Instance.BeginInvoke(stopCallback);
                        }
                        else
                        {
                            stopCallback();
                        }
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }
        #endregion
    }
}