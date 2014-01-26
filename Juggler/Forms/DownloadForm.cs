using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Juggler.Properties;

namespace Juggler
{
    public partial class DownloadForm : Form
    {
        private static DownloadForm instace;
        private int saveToSelectedIndex = -1;
        private string startTime;
        private Dictionary<string, int> statusIndex = new Dictionary<string, int>();
        internal WallpaperCrawler Crawler { get; private set; }

        public static DownloadForm Instance
        {
            get
            {
                if (instace == null)
                {
                    instace = new DownloadForm();
                    //Set instance to null when object gets disposed. This will save us from using non-null but disposed object.
                    instace.Disposed +=
                        delegate
                        {
                            instace = null;
                        };
                }
                return instace;
            }
        }

        private DownloadForm()
        {
            InitializeComponent();

            if (Settings.Default.Folders.Length > 0)
            {
                saveToComboBox.Items.AddRange(Settings.Default.Folders.Split(new char[] { '|' }));
            }
            saveToComboBox.Items.Add("Select new folder...");
            if (saveToComboBox.Items.Count > 1)
            {
                saveToComboBox.SelectedIndex = 0;
            }
            sourceComboBox.SelectedIndex = 0;
            threadCountComboBox.SelectedIndex = 2;
        }

        private void startLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (resolutionComboBox.SelectedIndex < 1)
            {
                MessageBox.Show("Easy tiger! Select a valid wallpaper source.", "Missing Inputs", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (resolutionComboBox.SelectedIndex < 1)
            {
                MessageBox.Show("Easy tiger! Select a resolution you are looking for.", "Missing Inputs", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (saveToComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Easy tiger! Select a folder where the wallpapers should be saved.", "Missing Inputs", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            startTime = DateTime.Now.ToString("HHmmssfff");

            this.Crawler.DestinationFolder = saveToComboBox.SelectedItem.ToString();
            this.Crawler.PreferredResolution = resolutionComboBox.SelectedItem as Resolution;
            this.Crawler.SortBy = sortComboBox.SelectedItem.ToString();
            this.Crawler.UpdateSink = new Action<UpdateData>(HandleUpdate);

            this.Crawler.StartDownload(threadCountComboBox.SelectedIndex + 1);
        }

        internal void HandleUpdate(UpdateData data)
        {
            if (this.InvokeRequired)
            {
                Action<UpdateData> handler = new Action<UpdateData>(UpdateStatus);
                this.BeginInvoke(handler, data);
            }
            else
            {
                UpdateStatus(data);
            }

        }

        private void UpdateStatus(UpdateData data)
        {
            switch (data.EventType)
            {
                case EventType.Start:
                    ToggleUI(false);
                    AddStatusEntry(data.Message);
                    break;
                case EventType.Completed:
                    ToggleUI(true);
                    AddStatusEntry(data.Message);
                    break;
                case EventType.ItemUpdate:
                    if (string.IsNullOrEmpty(data.ImageName))
                    {
                        AddStatusEntry(data.Message);
                    }
                    else
                    {
                        string itemKey = startTime + data.ImageName;
                        string message = string.Format("{0, -60}{1}", data.ImageName.Length > 55 ? data.ImageName.Substring(0, 55) : data.ImageName, GetStatusString(data.ImageStatus));

                        if (statusIndex.ContainsKey(itemKey))
                        {
                            //Enstry already exisits
                            statusListBox.Items[statusIndex[itemKey]] = message;
                        }
                        else
                        {
                            //Add entry and keep index in dictionary
                            statusIndex.Add(itemKey, AddStatusEntry(message));
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private int AddStatusEntry(string message)
        {
            int index = statusListBox.Items.Add(message);
            statusListBox.SelectedIndex = index;
            return index;
        }

        private static string GetStatusString(ImageStatus status)
        {
            string[] statusParts = { "Downloading...", "", "", "" };

            switch (status)
            {
                case ImageStatus.Skipped:
                    statusParts[1] = "Skipped";
                    break;
                case ImageStatus.Downloaded:
                    statusParts[1] = "Done";
                    statusParts[2] = "Saving...";
                    break;
                case ImageStatus.Saved:
                    statusParts[1] = "Done";
                    statusParts[2] = "Saving...";
                    statusParts[3] = "Done";
                    break;
                default:
                    break;
            }
            return string.Format("{0,-16}{1,-6}{2,-11}{3,-6}", statusParts);
        }

        private void ToggleUI(bool enabled)
        {
            startLinkLabel.Enabled = enabled;
            stopLinkLabel.Enabled = !enabled;

            sourceComboBox.Enabled = enabled;
            resolutionComboBox.Enabled = enabled;
            sortComboBox.Enabled = enabled;
            threadCountComboBox.Enabled = enabled;

            saveToComboBox.Enabled = enabled;
        }

        private void stopLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Crawler.Stop(StopReason.Stop);
        }

        private void resolutionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resolution res = resolutionComboBox.SelectedItem as Resolution;
            if (res == null)
            {
                resolutionComboBox.SelectedIndex = 1;
                return;
            }
            else if (res.Height == 0)
            {
                resolutionComboBox.SelectedIndex += 1;
                return;
            }
        }

        private void sourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resolutionComboBox.Items.Clear();
            sortComboBox.Items.Clear();

            switch (sourceComboBox.SelectedIndex)
            {
                case 0:
                    this.Crawler = new InterfaceLiftWallpaperCrawler();
                    break;
                case 1:
                    this.Crawler = new WallpaperStockWallpaperCrawler();
                    break;
                default:
                    return;
            }

            resolutionComboBox.Items.AddRange(this.Crawler.GetResolutions());
            sortComboBox.Items.AddRange(this.Crawler.GetSortOptions());

            //Select the matching resolution
            if (resolutionComboBox.Items.Count > 0)
            {
                int resolutionIndex = resolutionComboBox.FindStringExact(string.Format("{0}x{1}", Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));

                if (resolutionIndex > -1)
                {
                    resolutionComboBox.SelectedIndex = resolutionIndex;
                }
                else
                {
                    resolutionComboBox.SelectedIndex = 0;
                }
            }

            //Select the first sort order
            if (sortComboBox.Items.Count > 0)
            {
                sortComboBox.SelectedIndex = 0;
            }
        }

        private void saveToComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (saveToComboBox.SelectedIndex == saveToComboBox.Items.Count - 1)
            {
                saveToComboBox.SelectedIndex = saveToSelectedIndex > -1 ? saveToSelectedIndex : saveToComboBox.SelectedIndex - 1;
                if (saveToDialog.ShowDialog() == DialogResult.OK)
                {
                    string folder = saveToDialog.SelectedPath;
                    if (!saveToComboBox.Items.Contains(folder))
                    {
                        if (DialogResult.Yes == MessageBox.Show("Do you also want to add this folder as one of the source folders for Juggler?",
                            Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            Settings.Default.Folders += (Settings.Default.Folders.Length > 0 ? "|" : "") + folder;
                            Settings.Default.Save();
                        }
                        saveToComboBox.Items.Insert(saveToComboBox.Items.Count - 1, saveToDialog.SelectedPath);
                        saveToComboBox.SelectedIndex = saveToComboBox.Items.Count - 2;
                    }
                }
            }
            else
            {
                saveToSelectedIndex = saveToComboBox.SelectedIndex;
            }
        }

        private void closeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void DownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
            {
                //Close is initiated by either shutdown or process kill. Force stop.
                this.Crawler.ForceStop();
                return;
            }
            else
            {
                //User is closing the form. If its the first request, corfirm stop
                if (this.Crawler.CrawlStatus == CrawlStatus.Downloading)
                {
                    if (DialogResult.No == MessageBox.Show("Downloads are in progress. Do you want to stop and close wallpaper download window?",
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                if (this.Crawler.CrawlStatus != CrawlStatus.Stopped)
                {
                    //Download is in progress but form is being closed. Stop download process here if stop hasn't been started already.
                    this.Crawler.Stop(StopReason.Close, this.Close);
                    e.Cancel = true;
                }
            }
        }
    }
}