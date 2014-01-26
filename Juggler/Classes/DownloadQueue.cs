using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juggler
{
    internal class DownloadQueue
    {
        private Queue<string> imageQueue;
        private WallpaperCrawler crawler;
        private int lastPageNo;
        private object syncRoot;
        private bool completedFlag;

        public DownloadQueue(WallpaperCrawler crawler)
        {
            imageQueue = new Queue<string>();
            this.crawler = crawler;
            syncRoot = new object();
        }

        internal string GetImage()
        {
            string imageName = string.Empty;

            lock (syncRoot)
            {
                if (imageQueue.Count < 1 && !completedFlag)
                {
                    //There is no image in the queue. Download the image list.
                    crawler.GetImagesNames(++lastPageNo).ForEach(
                        delegate(string image)
                        {
                            imageQueue.Enqueue(image);
                        }
                    );
                }
                if (imageQueue.Count < 1)
                {
                    //Queue is still empty. Download has completed.
                    completedFlag = true;
                }
                else
                {
                    imageName = imageQueue.Dequeue();
                }
            }
            return imageName;
        }
    }
}
