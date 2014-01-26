namespace Juggler {
    partial class DownloadForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.statusListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resolutionComboBox = new System.Windows.Forms.ComboBox();
            this.sortComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveToDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saveToComboBox = new System.Windows.Forms.ComboBox();
            this.closeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.startLinkLabel = new System.Windows.Forms.LinkLabel();
            this.stopLinkLabel = new System.Windows.Forms.LinkLabel();
            this.threadCountComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusListBox
            // 
            this.statusListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusListBox.FormattingEnabled = true;
            this.statusListBox.ItemHeight = 14;
            this.statusListBox.Location = new System.Drawing.Point(14, 100);
            this.statusListBox.Name = "statusListBox";
            this.statusListBox.Size = new System.Drawing.Size(791, 396);
            this.statusListBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Resolution:";
            // 
            // resolutionComboBox
            // 
            this.resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolutionComboBox.DropDownWidth = 200;
            this.resolutionComboBox.FormattingEnabled = true;
            this.resolutionComboBox.Location = new System.Drawing.Point(292, 13);
            this.resolutionComboBox.Name = "resolutionComboBox";
            this.resolutionComboBox.Size = new System.Drawing.Size(149, 24);
            this.resolutionComboBox.TabIndex = 8;
            this.resolutionComboBox.SelectedIndexChanged += new System.EventHandler(this.resolutionComboBox_SelectedIndexChanged);
            // 
            // sortComboBox
            // 
            this.sortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortComboBox.FormattingEnabled = true;
            this.sortComboBox.Location = new System.Drawing.Point(505, 12);
            this.sortComboBox.Name = "sortComboBox";
            this.sortComboBox.Size = new System.Drawing.Size(87, 24);
            this.sortComboBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sort By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Save To:";
            // 
            // saveToDialog
            // 
            this.saveToDialog.Description = "Select a folder to save Wallpapers to:";
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceComboBox.FormattingEnabled = true;
            this.sourceComboBox.Items.AddRange(new object[] {
            "InterfaceLIFT",
            "WallpaperStock"});
            this.sourceComboBox.Location = new System.Drawing.Point(77, 12);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(132, 24);
            this.sourceComboBox.TabIndex = 15;
            this.sourceComboBox.SelectedIndexChanged += new System.EventHandler(this.sourceComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Source";
            // 
            // saveToComboBox
            // 
            this.saveToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saveToComboBox.FormattingEnabled = true;
            this.saveToComboBox.Location = new System.Drawing.Point(77, 44);
            this.saveToComboBox.Name = "saveToComboBox";
            this.saveToComboBox.Size = new System.Drawing.Size(728, 24);
            this.saveToComboBox.TabIndex = 16;
            this.saveToComboBox.SelectedIndexChanged += new System.EventHandler(this.saveToComboBox_SelectedIndexChanged);
            // 
            // closeLinkLabel
            // 
            this.closeLinkLabel.AutoSize = true;
            this.closeLinkLabel.Location = new System.Drawing.Point(768, 76);
            this.closeLinkLabel.Name = "closeLinkLabel";
            this.closeLinkLabel.Size = new System.Drawing.Size(39, 16);
            this.closeLinkLabel.TabIndex = 18;
            this.closeLinkLabel.TabStop = true;
            this.closeLinkLabel.Text = "Close";
            this.closeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.closeLinkLabel_LinkClicked);
            // 
            // startLinkLabel
            // 
            this.startLinkLabel.AutoSize = true;
            this.startLinkLabel.Location = new System.Drawing.Point(672, 76);
            this.startLinkLabel.Name = "startLinkLabel";
            this.startLinkLabel.Size = new System.Drawing.Size(36, 16);
            this.startLinkLabel.TabIndex = 17;
            this.startLinkLabel.TabStop = true;
            this.startLinkLabel.Text = "Start";
            this.startLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.startLinkLabel_LinkClicked);
            // 
            // stopLinkLabel
            // 
            this.stopLinkLabel.AutoSize = true;
            this.stopLinkLabel.Enabled = false;
            this.stopLinkLabel.Location = new System.Drawing.Point(720, 76);
            this.stopLinkLabel.Name = "stopLinkLabel";
            this.stopLinkLabel.Size = new System.Drawing.Size(34, 16);
            this.stopLinkLabel.TabIndex = 19;
            this.stopLinkLabel.TabStop = true;
            this.stopLinkLabel.Text = "Stop";
            this.stopLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.stopLinkLabel_LinkClicked);
            // 
            // threadCountComboBox
            // 
            this.threadCountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.threadCountComboBox.FormattingEnabled = true;
            this.threadCountComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.threadCountComboBox.Location = new System.Drawing.Point(747, 12);
            this.threadCountComboBox.MaxLength = 2;
            this.threadCountComboBox.Name = "threadCountComboBox";
            this.threadCountComboBox.Size = new System.Drawing.Size(58, 24);
            this.threadCountComboBox.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Concurrent Downloads:";
            // 
            // DownloadForm
            // 
            this.AcceptButton = this.startLinkLabel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeLinkLabel;
            this.ClientSize = new System.Drawing.Size(819, 517);
            this.Controls.Add(this.threadCountComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stopLinkLabel);
            this.Controls.Add(this.closeLinkLabel);
            this.Controls.Add(this.startLinkLabel);
            this.Controls.Add(this.saveToComboBox);
            this.Controls.Add(this.sourceComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sortComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resolutionComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusListBox);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "DownloadForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Download Wallpapers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox statusListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox resolutionComboBox;
        private System.Windows.Forms.ComboBox sortComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog saveToDialog;
        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox saveToComboBox;
        private System.Windows.Forms.LinkLabel closeLinkLabel;
        private System.Windows.Forms.LinkLabel startLinkLabel;
        private System.Windows.Forms.LinkLabel stopLinkLabel;
        private System.Windows.Forms.ComboBox threadCountComboBox;
        private System.Windows.Forms.Label label2;
    }
}

