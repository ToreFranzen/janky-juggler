namespace Juggler
{
    partial class ConfirmForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.changeNowLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeRemainingLabel = new System.Windows.Forms.Label();
            this.cancelLinkLabel = new System.Windows.Forms.LinkLabel();
            this.timeRemainingProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // changeNowLinkLabel
            // 
            this.changeNowLinkLabel.AutoSize = true;
            this.changeNowLinkLabel.Location = new System.Drawing.Point(69, 63);
            this.changeNowLinkLabel.Name = "changeNowLinkLabel";
            this.changeNowLinkLabel.Size = new System.Drawing.Size(80, 16);
            this.changeNowLinkLabel.TabIndex = 0;
            this.changeNowLinkLabel.TabStop = true;
            this.changeNowLinkLabel.Text = "Change Now";
            this.changeNowLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.changeNowLinkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Changing wallpaper in ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(165, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "seconds";
            // 
            // timeRemainingLabel
            // 
            this.timeRemainingLabel.BackColor = System.Drawing.SystemColors.Control;
            this.timeRemainingLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeRemainingLabel.Location = new System.Drawing.Point(143, 9);
            this.timeRemainingLabel.Name = "timeRemainingLabel";
            this.timeRemainingLabel.Size = new System.Drawing.Size(24, 16);
            this.timeRemainingLabel.TabIndex = 3;
            this.timeRemainingLabel.Text = "30";
            this.timeRemainingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cancelLinkLabel
            // 
            this.cancelLinkLabel.AutoSize = true;
            this.cancelLinkLabel.Location = new System.Drawing.Point(173, 63);
            this.cancelLinkLabel.Name = "cancelLinkLabel";
            this.cancelLinkLabel.Size = new System.Drawing.Size(46, 16);
            this.cancelLinkLabel.TabIndex = 4;
            this.cancelLinkLabel.TabStop = true;
            this.cancelLinkLabel.Text = "Cancel";
            this.cancelLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cancelLinkLabel_LinkClicked);
            // 
            // timeRemainingProgressBar
            // 
            this.timeRemainingProgressBar.Location = new System.Drawing.Point(12, 35);
            this.timeRemainingProgressBar.Name = "timeRemainingProgressBar";
            this.timeRemainingProgressBar.Size = new System.Drawing.Size(207, 17);
            this.timeRemainingProgressBar.Step = 1;
            this.timeRemainingProgressBar.TabIndex = 5;
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 111);
            this.ControlBox = false;
            this.Controls.Add(this.timeRemainingLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeRemainingProgressBar);
            this.Controls.Add(this.cancelLinkLabel);
            this.Controls.Add(this.changeNowLinkLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Confirm Juggle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel changeNowLinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label timeRemainingLabel;
        private System.Windows.Forms.LinkLabel cancelLinkLabel;
        private System.Windows.Forms.ProgressBar timeRemainingProgressBar;
    }
}