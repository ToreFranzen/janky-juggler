namespace Juggler
{
    partial class PreferencesForm
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
            this.autostartCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.foldersListBox = new System.Windows.Forms.ListBox();
            this.subFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.addLinkLabel = new System.Windows.Forms.LinkLabel();
            this.cancelLinkLabel = new System.Windows.Forms.LinkLabel();
            this.saveLinkLabel = new System.Windows.Forms.LinkLabel();
            this.intervalComboBox = new System.Windows.Forms.ComboBox();
            this.confirmCheckBox = new System.Windows.Forms.CheckBox();
            this.confirmDurationComboBox = new System.Windows.Forms.ComboBox();
            this.positioningComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.proxyCheckBox = new System.Windows.Forms.CheckBox();
            this.proxyAddressTextBox = new System.Windows.Forms.TextBox();
            this.proxyPortTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // autostartCheckBox
            // 
            this.autostartCheckBox.AutoSize = true;
            this.autostartCheckBox.Location = new System.Drawing.Point(19, 160);
            this.autostartCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.autostartCheckBox.Name = "autostartCheckBox";
            this.autostartCheckBox.Size = new System.Drawing.Size(161, 20);
            this.autostartCheckBox.TabIndex = 1;
            this.autostartCheckBox.Text = "Autostart with windows";
            this.autostartCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Change wallpaper every";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeLinkLabel);
            this.groupBox1.Controls.Add(this.foldersListBox);
            this.groupBox1.Controls.Add(this.subFoldersCheckBox);
            this.groupBox1.Controls.Add(this.addLinkLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(483, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Look for wallpapers in";
            // 
            // removeLinkLabel
            // 
            this.removeLinkLabel.AutoSize = true;
            this.removeLinkLabel.Enabled = false;
            this.removeLinkLabel.Location = new System.Drawing.Point(422, 114);
            this.removeLinkLabel.Name = "removeLinkLabel";
            this.removeLinkLabel.Size = new System.Drawing.Size(54, 16);
            this.removeLinkLabel.TabIndex = 2;
            this.removeLinkLabel.TabStop = true;
            this.removeLinkLabel.Text = "Remove";
            this.removeLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // foldersListBox
            // 
            this.foldersListBox.FormattingEnabled = true;
            this.foldersListBox.ItemHeight = 16;
            this.foldersListBox.Location = new System.Drawing.Point(7, 20);
            this.foldersListBox.Name = "foldersListBox";
            this.foldersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.foldersListBox.Size = new System.Drawing.Size(469, 84);
            this.foldersListBox.TabIndex = 0;
            // 
            // subFoldersCheckBox
            // 
            this.subFoldersCheckBox.AutoSize = true;
            this.subFoldersCheckBox.Location = new System.Drawing.Point(7, 112);
            this.subFoldersCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subFoldersCheckBox.Name = "subFoldersCheckBox";
            this.subFoldersCheckBox.Size = new System.Drawing.Size(112, 17);
            this.subFoldersCheckBox.TabIndex = 3;
            this.subFoldersCheckBox.Text = "Include subfolders";
            this.subFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // addLinkLabel
            // 
            this.addLinkLabel.AutoSize = true;
            this.addLinkLabel.Location = new System.Drawing.Point(383, 114);
            this.addLinkLabel.Name = "addLinkLabel";
            this.addLinkLabel.Size = new System.Drawing.Size(30, 16);
            this.addLinkLabel.TabIndex = 1;
            this.addLinkLabel.TabStop = true;
            this.addLinkLabel.Text = "Add";
            this.addLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.addLinkLabel_LinkClicked);
            // 
            // cancelLinkLabel
            // 
            this.cancelLinkLabel.AutoSize = true;
            this.cancelLinkLabel.Location = new System.Drawing.Point(434, 282);
            this.cancelLinkLabel.Name = "cancelLinkLabel";
            this.cancelLinkLabel.Size = new System.Drawing.Size(46, 16);
            this.cancelLinkLabel.TabIndex = 9;
            this.cancelLinkLabel.TabStop = true;
            this.cancelLinkLabel.Text = "Cancel";
            // 
            // saveLinkLabel
            // 
            this.saveLinkLabel.AutoSize = true;
            this.saveLinkLabel.Location = new System.Drawing.Point(380, 281);
            this.saveLinkLabel.Name = "saveLinkLabel";
            this.saveLinkLabel.Size = new System.Drawing.Size(36, 16);
            this.saveLinkLabel.TabIndex = 8;
            this.saveLinkLabel.TabStop = true;
            this.saveLinkLabel.Text = "Save";
            this.saveLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.saveLinkLabel_LinkClicked);
            // 
            // intervalComboBox
            // 
            this.intervalComboBox.FormattingEnabled = true;
            this.intervalComboBox.Items.AddRange(new object[] {
            "30 Mins",
            "1 Hour",
            "1 Hour 30 Mins",
            "2 Hours",
            "2 Hours 30 Mins",
            "4 Hours",
            "12 Hours"});
            this.intervalComboBox.Location = new System.Drawing.Point(164, 187);
            this.intervalComboBox.MaxLength = 25;
            this.intervalComboBox.Name = "intervalComboBox";
            this.intervalComboBox.Size = new System.Drawing.Size(140, 24);
            this.intervalComboBox.TabIndex = 3;
            // 
            // confirmCheckBox
            // 
            this.confirmCheckBox.AutoSize = true;
            this.confirmCheckBox.Location = new System.Drawing.Point(19, 219);
            this.confirmCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.confirmCheckBox.Name = "confirmCheckBox";
            this.confirmCheckBox.Size = new System.Drawing.Size(228, 20);
            this.confirmCheckBox.TabIndex = 4;
            this.confirmCheckBox.Text = "Confirm before changing wallpaper";
            this.confirmCheckBox.UseVisualStyleBackColor = true;
            // 
            // confirmDurationComboBox
            // 
            this.confirmDurationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.confirmDurationComboBox.FormattingEnabled = true;
            this.confirmDurationComboBox.Items.AddRange(new object[] {
            "5",
            "10",
            "30"});
            this.confirmDurationComboBox.Location = new System.Drawing.Point(374, 216);
            this.confirmDurationComboBox.Name = "confirmDurationComboBox";
            this.confirmDurationComboBox.Size = new System.Drawing.Size(42, 24);
            this.confirmDurationComboBox.TabIndex = 5;
            // 
            // positioningComboBox
            // 
            this.positioningComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.positioningComboBox.FormattingEnabled = true;
            this.positioningComboBox.Items.AddRange(new object[] {
            "Fit to screen",
            "Tile",
            "Center"});
            this.positioningComboBox.Location = new System.Drawing.Point(19, 246);
            this.positioningComboBox.Name = "positioningComboBox";
            this.positioningComboBox.Size = new System.Drawing.Size(97, 24);
            this.positioningComboBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "wallpaper when it doesn\'t match screen size.";
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Location = new System.Drawing.Point(208, 160);
            this.activeCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(61, 20);
            this.activeCheckBox.TabIndex = 10;
            this.activeCheckBox.Text = "Active";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "and display popup for              seconds.";
            // 
            // proxyCheckBox
            // 
            this.proxyCheckBox.AutoSize = true;
            this.proxyCheckBox.Location = new System.Drawing.Point(19, 277);
            this.proxyCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.proxyCheckBox.Name = "proxyCheckBox";
            this.proxyCheckBox.Size = new System.Drawing.Size(83, 20);
            this.proxyCheckBox.TabIndex = 12;
            this.proxyCheckBox.Text = "Use Proxy";
            this.proxyCheckBox.UseVisualStyleBackColor = true;
            // 
            // proxyAddressTextBox
            // 
            this.proxyAddressTextBox.Location = new System.Drawing.Point(147, 274);
            this.proxyAddressTextBox.Name = "proxyAddressTextBox";
            this.proxyAddressTextBox.Size = new System.Drawing.Size(100, 23);
            this.proxyAddressTextBox.TabIndex = 13;
            // 
            // proxyPortTextBox
            // 
            this.proxyPortTextBox.Location = new System.Drawing.Point(295, 275);
            this.proxyPortTextBox.Name = "proxyPortTextBox";
            this.proxyPortTextBox.Size = new System.Drawing.Size(60, 23);
            this.proxyPortTextBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Addr:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Port:";
            // 
            // PreferencesForm
            // 
            this.AcceptButton = this.saveLinkLabel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelLinkLabel;
            this.ClientSize = new System.Drawing.Size(514, 313);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.proxyPortTextBox);
            this.Controls.Add(this.proxyAddressTextBox);
            this.Controls.Add(this.proxyCheckBox);
            this.Controls.Add(this.activeCheckBox);
            this.Controls.Add(this.confirmDurationComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.positioningComboBox);
            this.Controls.Add(this.intervalComboBox);
            this.Controls.Add(this.cancelLinkLabel);
            this.Controls.Add(this.saveLinkLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autostartCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.confirmCheckBox);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Juggler Preferences";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox autostartCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox subFoldersCheckBox;
        private System.Windows.Forms.LinkLabel addLinkLabel;
        private System.Windows.Forms.LinkLabel cancelLinkLabel;
        private System.Windows.Forms.LinkLabel saveLinkLabel;
        private System.Windows.Forms.ComboBox intervalComboBox;
        private System.Windows.Forms.CheckBox confirmCheckBox;
        private System.Windows.Forms.ComboBox confirmDurationComboBox;
        private System.Windows.Forms.ComboBox positioningComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox foldersListBox;
        private System.Windows.Forms.LinkLabel removeLinkLabel;
		private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox proxyCheckBox;
        private System.Windows.Forms.TextBox proxyAddressTextBox;
        private System.Windows.Forms.TextBox proxyPortTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}