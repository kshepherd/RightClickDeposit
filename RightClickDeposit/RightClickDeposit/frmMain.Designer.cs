namespace RightClickDeposit
{
    partial class frmMain
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.lblActionMessage = new System.Windows.Forms.Label();
            this.pictureAction = new System.Windows.Forms.PictureBox();
            this.cmbMime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblChecksum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastModified = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFilePathLabel = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.tabMetadata = new System.Windows.Forms.TabPage();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDCDate = new System.Windows.Forms.Label();
            this.txtDCAbstract = new System.Windows.Forms.TextBox();
            this.lblDCAbstract = new System.Windows.Forms.Label();
            this.chkDublinCore = new System.Windows.Forms.CheckBox();
            this.txtDCCreator = new System.Windows.Forms.TextBox();
            this.lblDCCreator = new System.Windows.Forms.Label();
            this.txtDCTitle = new System.Windows.Forms.TextBox();
            this.lblDCTitle = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depositProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAction)).BeginInit();
            this.tabMetadata.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(270, 219);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 7;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 245);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(442, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel.Text = "Idle";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFile);
            this.tabControl1.Controls.Add(this.tabMetadata);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(418, 186);
            this.tabControl1.TabIndex = 15;
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.lblEndpoint);
            this.tabFile.Controls.Add(this.lblActionMessage);
            this.tabFile.Controls.Add(this.pictureAction);
            this.tabFile.Controls.Add(this.cmbMime);
            this.tabFile.Controls.Add(this.label5);
            this.tabFile.Controls.Add(this.lblChecksum);
            this.tabFile.Controls.Add(this.label4);
            this.tabFile.Controls.Add(this.lblLastModified);
            this.tabFile.Controls.Add(this.label3);
            this.tabFile.Controls.Add(this.lblFileSize);
            this.tabFile.Controls.Add(this.label1);
            this.tabFile.Controls.Add(this.lblFilePathLabel);
            this.tabFile.Controls.Add(this.lblFilePath);
            this.tabFile.Location = new System.Drawing.Point(4, 22);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(410, 160);
            this.tabFile.TabIndex = 0;
            this.tabFile.Text = "File";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(59, 26);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(35, 13);
            this.lblEndpoint.TabIndex = 14;
            this.lblEndpoint.Text = "label6";
            // 
            // lblActionMessage
            // 
            this.lblActionMessage.AutoSize = true;
            this.lblActionMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionMessage.Location = new System.Drawing.Point(59, 13);
            this.lblActionMessage.Name = "lblActionMessage";
            this.lblActionMessage.Size = new System.Drawing.Size(162, 13);
            this.lblActionMessage.TabIndex = 13;
            this.lblActionMessage.Text = "Depositing new resource to";
            this.lblActionMessage.Click += new System.EventHandler(this.label6_Click);
            // 
            // pictureAction
            // 
            this.pictureAction.Image = global::RightClickDeposit.Properties.Resources.repository_96;
            this.pictureAction.Location = new System.Drawing.Point(9, 6);
            this.pictureAction.Name = "pictureAction";
            this.pictureAction.Size = new System.Drawing.Size(44, 43);
            this.pictureAction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAction.TabIndex = 12;
            this.pictureAction.TabStop = false;
            // 
            // cmbMime
            // 
            this.cmbMime.FormattingEnabled = true;
            this.cmbMime.Location = new System.Drawing.Point(110, 135);
            this.cmbMime.Name = "cmbMime";
            this.cmbMime.Size = new System.Drawing.Size(165, 21);
            this.cmbMime.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Content type";
            // 
            // lblChecksum
            // 
            this.lblChecksum.AutoSize = true;
            this.lblChecksum.Location = new System.Drawing.Point(107, 115);
            this.lblChecksum.Name = "lblChecksum";
            this.lblChecksum.Size = new System.Drawing.Size(83, 13);
            this.lblChecksum.TabIndex = 9;
            this.lblChecksum.Text = "MD5 Checksum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "MD5 Checksum";
            // 
            // lblLastModified
            // 
            this.lblLastModified.AutoSize = true;
            this.lblLastModified.Location = new System.Drawing.Point(107, 93);
            this.lblLastModified.Name = "lblLastModified";
            this.lblLastModified.Size = new System.Drawing.Size(69, 13);
            this.lblLastModified.TabIndex = 7;
            this.lblLastModified.Text = "Last modified";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last modified";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(107, 73);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(78, 13);
            this.lblFileSize.TabIndex = 5;
            this.lblFileSize.Text = "File size (bytes)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File size (bytes)";
            // 
            // lblFilePathLabel
            // 
            this.lblFilePathLabel.AutoSize = true;
            this.lblFilePathLabel.Location = new System.Drawing.Point(6, 52);
            this.lblFilePathLabel.Name = "lblFilePathLabel";
            this.lblFilePathLabel.Size = new System.Drawing.Size(47, 13);
            this.lblFilePathLabel.TabIndex = 3;
            this.lblFilePathLabel.Text = "File path";
            this.lblFilePathLabel.Click += new System.EventHandler(this.lblFilePathLabel_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(107, 52);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(47, 13);
            this.lblFilePath.TabIndex = 2;
            this.lblFilePath.Text = "File path";
            // 
            // tabMetadata
            // 
            this.tabMetadata.AutoScroll = true;
            this.tabMetadata.Controls.Add(this.dateTimePicker);
            this.tabMetadata.Controls.Add(this.label2);
            this.tabMetadata.Controls.Add(this.lblDCDate);
            this.tabMetadata.Controls.Add(this.txtDCAbstract);
            this.tabMetadata.Controls.Add(this.lblDCAbstract);
            this.tabMetadata.Controls.Add(this.chkDublinCore);
            this.tabMetadata.Controls.Add(this.txtDCCreator);
            this.tabMetadata.Controls.Add(this.lblDCCreator);
            this.tabMetadata.Controls.Add(this.txtDCTitle);
            this.tabMetadata.Controls.Add(this.lblDCTitle);
            this.tabMetadata.Location = new System.Drawing.Point(4, 22);
            this.tabMetadata.Name = "tabMetadata";
            this.tabMetadata.Padding = new System.Windows.Forms.Padding(3);
            this.tabMetadata.Size = new System.Drawing.Size(410, 160);
            this.tabMetadata.TabIndex = 1;
            this.tabMetadata.Text = "Description";
            this.tabMetadata.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(76, 57);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(231, 20);
            this.dateTimePicker.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "(one per line)";
            // 
            // lblDCDate
            // 
            this.lblDCDate.AutoSize = true;
            this.lblDCDate.Enabled = false;
            this.lblDCDate.Location = new System.Drawing.Point(30, 59);
            this.lblDCDate.Name = "lblDCDate";
            this.lblDCDate.Size = new System.Drawing.Size(30, 13);
            this.lblDCDate.TabIndex = 16;
            this.lblDCDate.Text = "Date";
            // 
            // txtDCAbstract
            // 
            this.txtDCAbstract.Enabled = false;
            this.txtDCAbstract.Location = new System.Drawing.Point(76, 131);
            this.txtDCAbstract.Multiline = true;
            this.txtDCAbstract.Name = "txtDCAbstract";
            this.txtDCAbstract.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDCAbstract.Size = new System.Drawing.Size(313, 129);
            this.txtDCAbstract.TabIndex = 15;
            // 
            // lblDCAbstract
            // 
            this.lblDCAbstract.AutoSize = true;
            this.lblDCAbstract.Enabled = false;
            this.lblDCAbstract.Location = new System.Drawing.Point(11, 131);
            this.lblDCAbstract.Name = "lblDCAbstract";
            this.lblDCAbstract.Size = new System.Drawing.Size(46, 13);
            this.lblDCAbstract.TabIndex = 14;
            this.lblDCAbstract.Text = "Abstract";
            // 
            // chkDublinCore
            // 
            this.chkDublinCore.AutoSize = true;
            this.chkDublinCore.Location = new System.Drawing.Point(78, 10);
            this.chkDublinCore.Name = "chkDublinCore";
            this.chkDublinCore.Size = new System.Drawing.Size(166, 17);
            this.chkDublinCore.TabIndex = 13;
            this.chkDublinCore.Text = "Include Dublin Core metadata";
            this.chkDublinCore.UseVisualStyleBackColor = true;
            this.chkDublinCore.CheckedChanged += new System.EventHandler(this.chkDublinCore_CheckedChanged_1);
            // 
            // txtDCCreator
            // 
            this.txtDCCreator.Enabled = false;
            this.txtDCCreator.Location = new System.Drawing.Point(76, 83);
            this.txtDCCreator.Multiline = true;
            this.txtDCCreator.Name = "txtDCCreator";
            this.txtDCCreator.Size = new System.Drawing.Size(231, 42);
            this.txtDCCreator.TabIndex = 12;
            // 
            // lblDCCreator
            // 
            this.lblDCCreator.AutoSize = true;
            this.lblDCCreator.Enabled = false;
            this.lblDCCreator.Location = new System.Drawing.Point(11, 86);
            this.lblDCCreator.Name = "lblDCCreator";
            this.lblDCCreator.Size = new System.Drawing.Size(46, 13);
            this.lblDCCreator.TabIndex = 11;
            this.lblDCCreator.Text = "Creators";
            // 
            // txtDCTitle
            // 
            this.txtDCTitle.Enabled = false;
            this.txtDCTitle.Location = new System.Drawing.Point(76, 30);
            this.txtDCTitle.Name = "txtDCTitle";
            this.txtDCTitle.Size = new System.Drawing.Size(231, 20);
            this.txtDCTitle.TabIndex = 10;
            // 
            // lblDCTitle
            // 
            this.lblDCTitle.AutoSize = true;
            this.lblDCTitle.Enabled = false;
            this.lblDCTitle.Location = new System.Drawing.Point(30, 33);
            this.lblDCTitle.Name = "lblDCTitle";
            this.lblDCTitle.Size = new System.Drawing.Size(27, 13);
            this.lblDCTitle.TabIndex = 9;
            this.lblDCTitle.Text = "Title";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(351, 219);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 16;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(442, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // chooseFileToolStripMenuItem
            // 
            this.chooseFileToolStripMenuItem.Name = "chooseFileToolStripMenuItem";
            this.chooseFileToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.chooseFileToolStripMenuItem.Text = "Choose file...";
            this.chooseFileToolStripMenuItem.Click += new System.EventHandler(this.chooseFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depositProfilesToolStripMenuItem,
            this.testConnectionToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // depositProfilesToolStripMenuItem
            // 
            this.depositProfilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageProfilesToolStripMenuItem});
            this.depositProfilesToolStripMenuItem.Name = "depositProfilesToolStripMenuItem";
            this.depositProfilesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.depositProfilesToolStripMenuItem.Text = "Deposit profiles";
            this.depositProfilesToolStripMenuItem.Click += new System.EventHandler(this.depositProfilesToolStripMenuItem_Click);
            // 
            // manageProfilesToolStripMenuItem
            // 
            this.manageProfilesToolStripMenuItem.Name = "manageProfilesToolStripMenuItem";
            this.manageProfilesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.manageProfilesToolStripMenuItem.Text = "Manage profiles...";
            this.manageProfilesToolStripMenuItem.Click += new System.EventHandler(this.manageProfilesToolStripMenuItem_Click);
            // 
            // testConnectionToolStripMenuItem
            // 
            this.testConnectionToolStripMenuItem.Name = "testConnectionToolStripMenuItem";
            this.testConnectionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.testConnectionToolStripMenuItem.Text = "Test connection";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 267);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnUpload);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Right-click Deposit";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tabFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAction)).EndInit();
            this.tabMetadata.ResumeLayout(false);
            this.tabMetadata.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.Label lblFilePathLabel;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TabPage tabMetadata;
        private System.Windows.Forms.CheckBox chkDublinCore;
        private System.Windows.Forms.TextBox txtDCCreator;
        private System.Windows.Forms.Label lblDCCreator;
        private System.Windows.Forms.TextBox txtDCTitle;
        private System.Windows.Forms.Label lblDCTitle;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblLastModified;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDCDate;
        private System.Windows.Forms.TextBox txtDCAbstract;
        private System.Windows.Forms.Label lblDCAbstract;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblChecksum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depositProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageProfilesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbMime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblActionMessage;
        private System.Windows.Forms.PictureBox pictureAction;
        private System.Windows.Forms.Label lblEndpoint;
    }
}

