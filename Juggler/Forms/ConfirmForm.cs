using System;
using System.ComponentModel;
using System.Windows.Forms;
using Juggler.Properties;

namespace Juggler
{
    public partial class ConfirmForm : Form
    {
        private static Timer ticker;
        private bool allowClosing;

        public ConfirmForm()
        {
            InitializeComponent();
            timeRemainingLabel.Text = Settings.Default.ConfirmDuration.ToString();

            ticker = new Timer();
            ticker.Interval = 10;
            ticker.Tick += new EventHandler(FadeIn_Tick);
            ticker.Enabled = true;

            this.Closed +=
                delegate
                {
                    Program.SetIconText();
                };
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = !allowClosing;
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
        private void FadeIn_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.01;
            }
            else
            {
                ticker.Enabled = false;
                ticker.Tick -= new EventHandler(FadeIn_Tick);
                ticker.Tick += new EventHandler(Timeout_Tick);

                int timeRemaining;
                timeRemaining = Settings.Default.ConfirmDuration;
                timeRemainingLabel.Text = timeRemaining.ToString();
                timeRemainingProgressBar.Maximum = 20 * timeRemaining;
                ticker.Interval = 50;

                ticker.Enabled = true;
            }
        }

        private void Timeout_Tick(object sender, EventArgs e)
        {
            timeRemainingProgressBar.Value += 1;

            if (timeRemainingProgressBar.Value % 20 == 0)
            {
                timeRemainingLabel.Text = (Settings.Default.ConfirmDuration - timeRemainingProgressBar.Value / 20).ToString();
            }

            if (timeRemainingProgressBar.Value == timeRemainingProgressBar.Maximum)
            {
                ChangeNow();
            }
        }

        private void changeNowLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChangeNow();
            }
        }

        private void cancelLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cancel();
            }
        }

        private void ChangeNow()
        {
            Cancel();
            Program.ChangeWallpaper();
        }

        private void Cancel()
        {
            allowClosing = true;
            ticker.Enabled = false;
            this.Close();
        }
    }
}
