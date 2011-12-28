namespace RightClickDeposit
{
    partial class frmProfiles
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
            this.txtServiceDocumentUri = new System.Windows.Forms.TextBox();
            this.txtDefaultDepositUri = new System.Windows.Forms.TextBox();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cmbAutoState = new System.Windows.Forms.ComboBox();
            this.cmdMetadata = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listProfile = new System.Windows.Forms.ListView();
            this.txtPassword = new System.Windows.Forms.MaskedTextBox();
            this.chkInRightClick = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPackaging = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOnBehalfOf = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServiceDocumentUri
            // 
            this.txtServiceDocumentUri.Location = new System.Drawing.Point(135, 207);
            this.txtServiceDocumentUri.Name = "txtServiceDocumentUri";
            this.txtServiceDocumentUri.Size = new System.Drawing.Size(264, 20);
            this.txtServiceDocumentUri.TabIndex = 0;
            // 
            // txtDefaultDepositUri
            // 
            this.txtDefaultDepositUri.Location = new System.Drawing.Point(135, 235);
            this.txtDefaultDepositUri.Name = "txtDefaultDepositUri";
            this.txtDefaultDepositUri.Size = new System.Drawing.Size(264, 20);
            this.txtDefaultDepositUri.TabIndex = 1;
            // 
            // txtProfileName
            // 
            this.txtProfileName.Location = new System.Drawing.Point(135, 181);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(264, 20);
            this.txtProfileName.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(73, 289);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(152, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // cmbAutoState
            // 
            this.cmbAutoState.FormattingEnabled = true;
            this.cmbAutoState.Items.AddRange(new object[] {
            "Ask",
            "In Progress",
            "Complete"});
            this.cmbAutoState.Location = new System.Drawing.Point(421, 235);
            this.cmbAutoState.Name = "cmbAutoState";
            this.cmbAutoState.Size = new System.Drawing.Size(121, 21);
            this.cmbAutoState.TabIndex = 5;
            // 
            // cmdMetadata
            // 
            this.cmdMetadata.FormattingEnabled = true;
            this.cmdMetadata.Items.AddRange(new object[] {
            "Optional",
            "Required",
            "Forbidden"});
            this.cmdMetadata.Location = new System.Drawing.Point(421, 290);
            this.cmdMetadata.Name = "cmdMetadata";
            this.cmdMetadata.Size = new System.Drawing.Size(121, 21);
            this.cmdMetadata.TabIndex = 6;
            this.cmdMetadata.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "New profile";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(178, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save profile";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(93, 146);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(79, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load profile";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 184);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 13);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Profile Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Service Document URI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Default Deposit URI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(418, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Allow metadata?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(420, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Set state after deposit?";
            // 
            // listProfile
            // 
            this.listProfile.Location = new System.Drawing.Point(12, 37);
            this.listProfile.Name = "listProfile";
            this.listProfile.Size = new System.Drawing.Size(543, 103);
            this.listProfile.TabIndex = 18;
            this.listProfile.UseCompatibleStateImageBehavior = false;
            this.listProfile.View = System.Windows.Forms.View.SmallIcon;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(299, 290);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 19;
            // 
            // chkInRightClick
            // 
            this.chkInRightClick.AutoSize = true;
            this.chkInRightClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInRightClick.Location = new System.Drawing.Point(423, 180);
            this.chkInRightClick.Name = "chkInRightClick";
            this.chkInRightClick.Size = new System.Drawing.Size(123, 17);
            this.chkInRightClick.TabIndex = 20;
            this.chkInRightClick.Text = "Include in menu?";
            this.chkInRightClick.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(421, 146);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "Update menu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(567, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(269, 146);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete profile";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Default Packaging";
            // 
            // txtPackaging
            // 
            this.txtPackaging.Location = new System.Drawing.Point(135, 263);
            this.txtPackaging.Name = "txtPackaging";
            this.txtPackaging.Size = new System.Drawing.Size(264, 20);
            this.txtPackaging.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 319);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "On Behalf Of";
            // 
            // txtOnBehalfOf
            // 
            this.txtOnBehalfOf.Location = new System.Drawing.Point(87, 315);
            this.txtOnBehalfOf.Name = "txtOnBehalfOf";
            this.txtOnBehalfOf.Size = new System.Drawing.Size(138, 20);
            this.txtOnBehalfOf.TabIndex = 27;
            // 
            // frmProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 341);
            this.Controls.Add(this.txtOnBehalfOf);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPackaging);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.chkInRightClick);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.listProfile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdMetadata);
            this.Controls.Add(this.cmbAutoState);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtProfileName);
            this.Controls.Add(this.txtDefaultDepositUri);
            this.Controls.Add(this.txtServiceDocumentUri);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmProfiles";
            this.Text = "Right-click Deposit Profile Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServiceDocumentUri;
        private System.Windows.Forms.TextBox txtDefaultDepositUri;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ComboBox cmbAutoState;
        private System.Windows.Forms.ComboBox cmdMetadata;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listProfile;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.CheckBox chkInRightClick;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPackaging;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOnBehalfOf;
    }
}