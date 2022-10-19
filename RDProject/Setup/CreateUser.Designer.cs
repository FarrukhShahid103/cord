namespace RDProject.Setup
{
    partial class CreateUserEng
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUserEng));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.pnlThumb = new System.Windows.Forms.Panel();
            this.lblRegisterThumb = new System.Windows.Forms.LinkLabel();
            this.StatusLine = new System.Windows.Forms.TextBox();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.gbxUserRights = new System.Windows.Forms.GroupBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.cbxUserRights = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUserRole = new System.Windows.Forms.ComboBox();
            this.chkBioMetricLogin = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.lblCNIC = new System.Windows.Forms.Label();
            this.lblSecretAnswer = new System.Windows.Forms.Label();
            this.lblSecretQuestion = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtSecretAnswer = new System.Windows.Forms.TextBox();
            this.txtSecretQuestion = new System.Windows.Forms.TextBox();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tcUsers = new System.Windows.Forms.TabControl();
            this.tpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.pnlThumb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.gbxUserRights.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tcUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 310);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(804, 22);
            this.StatusStrip.TabIndex = 100;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // lblMsg
            // 
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(78, 17);
            this.lblMsg.Text = "Record Saved";
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.grpGeneral);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(796, 284);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.pnlThumb);
            this.grpGeneral.Controls.Add(this.gbxUserRights);
            this.grpGeneral.Controls.Add(this.groupBox1);
            this.grpGeneral.Controls.Add(this.chkBioMetricLogin);
            this.grpGeneral.Controls.Add(this.chkActive);
            this.grpGeneral.Controls.Add(this.btnCancel);
            this.grpGeneral.Controls.Add(this.btnSave);
            this.grpGeneral.Controls.Add(this.cbUserName);
            this.grpGeneral.Controls.Add(this.lblCNIC);
            this.grpGeneral.Controls.Add(this.lblSecretAnswer);
            this.grpGeneral.Controls.Add(this.lblSecretQuestion);
            this.grpGeneral.Controls.Add(this.lblLastName);
            this.grpGeneral.Controls.Add(this.lblFirstName);
            this.grpGeneral.Controls.Add(this.txtSecretAnswer);
            this.grpGeneral.Controls.Add(this.txtSecretQuestion);
            this.grpGeneral.Controls.Add(this.txtCNIC);
            this.grpGeneral.Controls.Add(this.txtLastName);
            this.grpGeneral.Controls.Add(this.txtFirstName);
            this.grpGeneral.Controls.Add(this.txtPassword);
            this.grpGeneral.Controls.Add(this.lblPassword);
            this.grpGeneral.Controls.Add(this.lblUserName);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 3);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(790, 278);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // pnlThumb
            // 
            this.pnlThumb.Controls.Add(this.lblRegisterThumb);
            this.pnlThumb.Controls.Add(this.StatusLine);
            this.pnlThumb.Controls.Add(this.Picture);
            this.pnlThumb.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlThumb.Location = new System.Drawing.Point(587, 17);
            this.pnlThumb.Name = "pnlThumb";
            this.pnlThumb.Size = new System.Drawing.Size(200, 258);
            this.pnlThumb.TabIndex = 16;
            // 
            // lblRegisterThumb
            // 
            this.lblRegisterThumb.AutoSize = true;
            this.lblRegisterThumb.Enabled = false;
            this.lblRegisterThumb.Location = new System.Drawing.Point(4, 214);
            this.lblRegisterThumb.Name = "lblRegisterThumb";
            this.lblRegisterThumb.Size = new System.Drawing.Size(82, 13);
            this.lblRegisterThumb.TabIndex = 17;
            this.lblRegisterThumb.TabStop = true;
            this.lblRegisterThumb.Text = "Register &Thumb";
            this.lblRegisterThumb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRegisterThumb_LinkClicked);
            // 
            // StatusLine
            // 
            this.StatusLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusLine.Enabled = false;
            this.StatusLine.Location = new System.Drawing.Point(0, 186);
            this.StatusLine.MaxLength = 15;
            this.StatusLine.Name = "StatusLine";
            this.StatusLine.Size = new System.Drawing.Size(200, 21);
            this.StatusLine.TabIndex = 16;
            // 
            // Picture
            // 
            this.Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Picture.Dock = System.Windows.Forms.DockStyle.Top;
            this.Picture.Location = new System.Drawing.Point(0, 0);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(200, 186);
            this.Picture.TabIndex = 15;
            this.Picture.TabStop = false;
            // 
            // gbxUserRights
            // 
            this.gbxUserRights.Controls.Add(this.chkDelete);
            this.gbxUserRights.Controls.Add(this.chkInsert);
            this.gbxUserRights.Controls.Add(this.chkPrint);
            this.gbxUserRights.Controls.Add(this.chkView);
            this.gbxUserRights.Controls.Add(this.chkUpdate);
            this.gbxUserRights.Controls.Add(this.cbxUserRights);
            this.gbxUserRights.Location = new System.Drawing.Point(375, 104);
            this.gbxUserRights.Name = "gbxUserRights";
            this.gbxUserRights.Size = new System.Drawing.Size(198, 145);
            this.gbxUserRights.TabIndex = 14;
            this.gbxUserRights.TabStop = false;
            this.gbxUserRights.Text = "User Rights";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(18, 109);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(57, 17);
            this.chkDelete.TabIndex = 4;
            this.chkDelete.TabStop = false;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            this.chkDelete.CheckedChanged += new System.EventHandler(this.chkDelete_CheckedChanged);
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(18, 86);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(55, 17);
            this.chkInsert.TabIndex = 5;
            this.chkInsert.TabStop = false;
            this.chkInsert.Text = "Insert";
            this.chkInsert.UseVisualStyleBackColor = true;
            this.chkInsert.CheckedChanged += new System.EventHandler(this.chkInsert_CheckedChanged);
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(108, 62);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(48, 17);
            this.chkPrint.TabIndex = 3;
            this.chkPrint.TabStop = false;
            this.chkPrint.Text = "Print";
            this.chkPrint.UseVisualStyleBackColor = true;
            this.chkPrint.CheckedChanged += new System.EventHandler(this.chkPrint_CheckedChanged);
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.Location = new System.Drawing.Point(18, 62);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(48, 17);
            this.chkView.TabIndex = 1;
            this.chkView.TabStop = false;
            this.chkView.Text = "View";
            this.chkView.UseVisualStyleBackColor = true;
            this.chkView.CheckedChanged += new System.EventHandler(this.chkView_CheckedChanged);
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(108, 86);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(61, 17);
            this.chkUpdate.TabIndex = 2;
            this.chkUpdate.TabStop = false;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.chkUpdate_CheckedChanged);
            // 
            // cbxUserRights
            // 
            this.cbxUserRights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUserRights.Enabled = false;
            this.cbxUserRights.FormattingEnabled = true;
            this.cbxUserRights.Location = new System.Drawing.Point(18, 31);
            this.cbxUserRights.Name = "cbxUserRights";
            this.cbxUserRights.Size = new System.Drawing.Size(156, 21);
            this.cbxUserRights.TabIndex = 0;
            this.cbxUserRights.TabStop = false;
            this.cbxUserRights.SelectedIndexChanged += new System.EventHandler(this.cbxUserRights_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUserRole);
            this.groupBox1.Location = new System.Drawing.Point(375, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 59);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Role";
            // 
            // cbUserRole
            // 
            this.cbUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserRole.FormattingEnabled = true;
            this.cbUserRole.Location = new System.Drawing.Point(18, 22);
            this.cbUserRole.Name = "cbUserRole";
            this.cbUserRole.Size = new System.Drawing.Size(156, 21);
            this.cbUserRole.TabIndex = 0;
            this.cbUserRole.TabStop = false;
            this.cbUserRole.SelectedIndexChanged += new System.EventHandler(this.cbUserRole_SelectedIndexChanged);
            // 
            // chkBioMetricLogin
            // 
            this.chkBioMetricLogin.AutoSize = true;
            this.chkBioMetricLogin.Location = new System.Drawing.Point(239, 184);
            this.chkBioMetricLogin.Name = "chkBioMetricLogin";
            this.chkBioMetricLogin.Size = new System.Drawing.Size(101, 17);
            this.chkBioMetricLogin.TabIndex = 8;
            this.chkBioMetricLogin.TabStop = false;
            this.chkBioMetricLogin.Text = "Bio-Metric Login";
            this.chkBioMetricLogin.UseVisualStyleBackColor = true;
            this.chkBioMetricLogin.CheckedChanged += new System.EventHandler(this.chkBioMetricLogin_CheckedChanged);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(240, 24);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 1;
            this.chkActive.TabStop = false;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ImageIndex = 20;
            this.btnCancel.ImageList = this.CORDImages;
            this.btnCancel.Location = new System.Drawing.Point(219, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CORDImages
            // 
            this.CORDImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("CORDImages.ImageStream")));
            this.CORDImages.TransparentColor = System.Drawing.Color.Lime;
            this.CORDImages.Images.SetKeyName(0, "1_New.gif");
            this.CORDImages.Images.SetKeyName(1, "2_Open.gif");
            this.CORDImages.Images.SetKeyName(2, "3_Save.gif");
            this.CORDImages.Images.SetKeyName(3, "4_Save_As.gif");
            this.CORDImages.Images.SetKeyName(4, "5_Print.gif");
            this.CORDImages.Images.SetKeyName(5, "6_Prepare.gif");
            this.CORDImages.Images.SetKeyName(6, "7_Send.gif");
            this.CORDImages.Images.SetKeyName(7, "8_Publish.gif");
            this.CORDImages.Images.SetKeyName(8, "9_Close.gif");
            this.CORDImages.Images.SetKeyName(9, "1_Word_Document.gif");
            this.CORDImages.Images.SetKeyName(10, "2_Word_Template.gif");
            this.CORDImages.Images.SetKeyName(11, "3_Word_97.gif");
            this.CORDImages.Images.SetKeyName(12, "4_Find_Addins.gif");
            this.CORDImages.Images.SetKeyName(13, "5_Other_Formats.gif");
            this.CORDImages.Images.SetKeyName(14, "1_Print.gif");
            this.CORDImages.Images.SetKeyName(15, "2_Quick_Print.gif");
            this.CORDImages.Images.SetKeyName(16, "3_Print_Preview.gif");
            this.CORDImages.Images.SetKeyName(17, "1_Properties.gif");
            this.CORDImages.Images.SetKeyName(18, "2_Inspect-Document.gif");
            this.CORDImages.Images.SetKeyName(19, "3_Encrypt_Document.gif");
            this.CORDImages.Images.SetKeyName(20, "4_Restrict_Permission.gif");
            this.CORDImages.Images.SetKeyName(21, "5_Add_a_digital_signature.gif");
            this.CORDImages.Images.SetKeyName(22, "6_Mark_As_Final.gif");
            this.CORDImages.Images.SetKeyName(23, "7_Run_Compatibility_Checker.gif");
            this.CORDImages.Images.SetKeyName(24, "1_E-mail.gif");
            this.CORDImages.Images.SetKeyName(25, "2_Internet_Fax.gif");
            this.CORDImages.Images.SetKeyName(26, "1_Blog.gif");
            this.CORDImages.Images.SetKeyName(27, "2-Document_Management.gif");
            this.CORDImages.Images.SetKeyName(28, "3_Create_Document_Workspace.gif");
            this.CORDImages.Images.SetKeyName(29, "buttonDelete.png");
            this.CORDImages.Images.SetKeyName(30, "buttonNew.png");
            this.CORDImages.Images.SetKeyName(31, "Device-tablet-icon.png");
            this.CORDImages.Images.SetKeyName(32, "System-scanner-icon.png");
            this.CORDImages.Images.SetKeyName(33, "approved.png");
            this.CORDImages.Images.SetKeyName(34, "mzl.afensvcu.175x175-75.jpg");
            this.CORDImages.Images.SetKeyName(35, "imagesCAJR6TIT.png");
            this.CORDImages.Images.SetKeyName(36, "User-Group-icon.png");
            this.CORDImages.Images.SetKeyName(37, "Pictures-icon.png");
            this.CORDImages.Images.SetKeyName(38, "scanner-icon.png");
            this.CORDImages.Images.SetKeyName(39, "Bank-Check-icon.png");
            this.CORDImages.Images.SetKeyName(40, "profile-check-icon.png");
            this.CORDImages.Images.SetKeyName(41, "User-Executive-Green-icon.png");
            this.CORDImages.Images.SetKeyName(42, "mail-sent-icon.png");
            this.CORDImages.Images.SetKeyName(43, "calendar-background-icon.png");
            this.CORDImages.Images.SetKeyName(44, "user-info-icon.png");
            this.CORDImages.Images.SetKeyName(45, "Farm-plot-icon.png");
            this.CORDImages.Images.SetKeyName(46, "maps-icon.png");
            this.CORDImages.Images.SetKeyName(47, "Document-Copy-icon.png");
            this.CORDImages.Images.SetKeyName(48, "Goverment-icon.png");
            this.CORDImages.Images.SetKeyName(49, "send-icon.png");
            this.CORDImages.Images.SetKeyName(50, "searchperson.png");
            this.CORDImages.Images.SetKeyName(51, "viewimages.png");
            this.CORDImages.Images.SetKeyName(52, "Button-Refresh-icon.png");
            this.CORDImages.Images.SetKeyName(53, "refresh.png");
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.CORDImages;
            this.btnSave.Location = new System.Drawing.Point(113, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbUserName
            // 
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.Location = new System.Drawing.Point(113, 20);
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(121, 21);
            this.cbUserName.TabIndex = 0;
            this.cbUserName.Enter += new System.EventHandler(this.cbUserName_Enter);
            this.cbUserName.Leave += new System.EventHandler(this.cbUserName_Leave);
            // 
            // lblCNIC
            // 
            this.lblCNIC.AutoSize = true;
            this.lblCNIC.Location = new System.Drawing.Point(17, 185);
            this.lblCNIC.Name = "lblCNIC";
            this.lblCNIC.Size = new System.Drawing.Size(39, 13);
            this.lblCNIC.TabIndex = 6;
            this.lblCNIC.Text = "CNIC :";
            // 
            // lblSecretAnswer
            // 
            this.lblSecretAnswer.AutoSize = true;
            this.lblSecretAnswer.Location = new System.Drawing.Point(17, 158);
            this.lblSecretAnswer.Name = "lblSecretAnswer";
            this.lblSecretAnswer.Size = new System.Drawing.Size(84, 13);
            this.lblSecretAnswer.TabIndex = 6;
            this.lblSecretAnswer.Text = "Secret Answer :";
            // 
            // lblSecretQuestion
            // 
            this.lblSecretQuestion.AutoSize = true;
            this.lblSecretQuestion.Location = new System.Drawing.Point(17, 131);
            this.lblSecretQuestion.Name = "lblSecretQuestion";
            this.lblSecretQuestion.Size = new System.Drawing.Size(91, 13);
            this.lblSecretQuestion.TabIndex = 6;
            this.lblSecretQuestion.Text = "Secret Question :";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(17, 104);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(64, 13);
            this.lblLastName.TabIndex = 6;
            this.lblLastName.Text = "Last Name :";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(17, 77);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(65, 13);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "First Name :";
            // 
            // txtSecretAnswer
            // 
            this.txtSecretAnswer.Location = new System.Drawing.Point(113, 155);
            this.txtSecretAnswer.Name = "txtSecretAnswer";
            this.txtSecretAnswer.Size = new System.Drawing.Size(227, 21);
            this.txtSecretAnswer.TabIndex = 5;
            // 
            // txtSecretQuestion
            // 
            this.txtSecretQuestion.Location = new System.Drawing.Point(113, 128);
            this.txtSecretQuestion.Name = "txtSecretQuestion";
            this.txtSecretQuestion.Size = new System.Drawing.Size(227, 21);
            this.txtSecretQuestion.TabIndex = 4;
            this.txtSecretQuestion.Text = "My First Teacher Name?";
            // 
            // txtCNIC
            // 
            this.txtCNIC.Location = new System.Drawing.Point(113, 182);
            this.txtCNIC.MaxLength = 15;
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(121, 21);
            this.txtCNIC.TabIndex = 6;
            this.txtCNIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCNIC_KeyPress);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(113, 101);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(121, 21);
            this.txtLastName.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(113, 74);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 21);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(121, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(17, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(17, 23);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(66, 13);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "User Name :";
            // 
            // tcUsers
            // 
            this.tcUsers.Controls.Add(this.tpGeneral);
            this.tcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUsers.Location = new System.Drawing.Point(0, 0);
            this.tcUsers.Name = "tcUsers";
            this.tcUsers.SelectedIndex = 0;
            this.tcUsers.Size = new System.Drawing.Size(804, 310);
            this.tcUsers.TabIndex = 0;
            // 
            // CreateUserEng
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(804, 332);
            this.Controls.Add(this.tcUsers);
            this.Controls.Add(this.StatusStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateUserEng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create User Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateUserEng_FormClosing);
            this.Load += new System.EventHandler(this.CreateUserEng_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CreateUserEng_KeyPress);
            this.tpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.pnlThumb.ResumeLayout(false);
            this.pnlThumb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.gbxUserRights.ResumeLayout(false);
            this.gbxUserRights.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tcUsers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox gbxUserRights;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.ComboBox cbxUserRights;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbUserRole;
        private System.Windows.Forms.CheckBox chkBioMetricLogin;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbUserName;
        private System.Windows.Forms.Label lblCNIC;
        private System.Windows.Forms.Label lblSecretAnswer;
        private System.Windows.Forms.Label lblSecretQuestion;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtSecretAnswer;
        private System.Windows.Forms.TextBox txtSecretQuestion;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TabControl tcUsers;
        private System.Windows.Forms.TextBox txtCNIC;
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Panel pnlThumb;
        private System.Windows.Forms.LinkLabel lblRegisterThumb;
        private System.Windows.Forms.TextBox StatusLine;
        private System.Windows.Forms.ImageList CORDImages;
    }
}