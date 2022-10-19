namespace RDProject.Setup
{
    partial class CreateUserForm_Urdu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUserForm_Urdu));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcUsers = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.chkBioMetricLogin = new System.Windows.Forms.CheckBox();            
            this.gbxUserRights = new System.Windows.Forms.GroupBox();
            this.cbxUserRights = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.lblCNIC = new System.Windows.Forms.Label();
            this.lblSecretAnswer = new System.Windows.Forms.Label();
            this.lblSecretQuestion = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtSecretAnswer = new System.Windows.Forms.TextBox();
            this.txtSecretQuestion = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbUserRole = new System.Windows.Forms.ComboBox();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.StatusStrip.SuspendLayout();
            this.tcUsers.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();            
            this.gbxUserRights.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg});
            this.StatusStrip.Location = new System.Drawing.Point(0, 465);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(806, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // lblMsg
            // 
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(120, 17);
            this.lblMsg.Text = "ریکارڈ محفوظ ہو گیا ھے۔";
            // 
            // tcUsers
            // 
            this.tcUsers.Controls.Add(this.tpGeneral);
            this.tcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUsers.Location = new System.Drawing.Point(0, 0);
            this.tcUsers.Name = "tcUsers";
            this.tcUsers.RightToLeftLayout = true;
            this.tcUsers.SelectedIndex = 0;
            this.tcUsers.Size = new System.Drawing.Size(806, 465);
            this.tcUsers.TabIndex = 2;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.grpGeneral);
            this.tpGeneral.Location = new System.Drawing.Point(4, 40);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(798, 421);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "جنرل";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.chkBioMetricLogin);
            this.grpGeneral.Controls.Add(this.groupBox2);
            this.grpGeneral.Controls.Add(this.gbxUserRights);
            this.grpGeneral.Controls.Add(this.btnDelete);
            this.grpGeneral.Controls.Add(this.btnSave);
            this.grpGeneral.Controls.Add(this.chkActive);
            this.grpGeneral.Controls.Add(this.cbUserName);
            this.grpGeneral.Controls.Add(this.lblCNIC);
            this.grpGeneral.Controls.Add(this.lblSecretAnswer);
            this.grpGeneral.Controls.Add(this.lblSecretQuestion);
            this.grpGeneral.Controls.Add(this.lblLastName);
            this.grpGeneral.Controls.Add(this.lblFirstName);
            this.grpGeneral.Controls.Add(this.txtCNIC);
            this.grpGeneral.Controls.Add(this.txtSecretAnswer);
            this.grpGeneral.Controls.Add(this.txtSecretQuestion);
            this.grpGeneral.Controls.Add(this.txtLastName);
            this.grpGeneral.Controls.Add(this.txtFirstName);
            this.grpGeneral.Controls.Add(this.txtPassword);
            this.grpGeneral.Controls.Add(this.lblPassword);
            this.grpGeneral.Controls.Add(this.lblUserName);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 3);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(792, 415);
            this.grpGeneral.TabIndex = 9;
            this.grpGeneral.TabStop = false;
            // 
            // chkBioMetricLogin
            // 
            this.chkBioMetricLogin.AutoSize = true;
            this.chkBioMetricLogin.Location = new System.Drawing.Point(430, 296);
            this.chkBioMetricLogin.Name = "chkBioMetricLogin";
            this.chkBioMetricLogin.Size = new System.Drawing.Size(102, 35);
            this.chkBioMetricLogin.TabIndex = 8;
            this.chkBioMetricLogin.Text = "انگوٹھے کی شناخت";
            this.chkBioMetricLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBioMetricLogin.UseVisualStyleBackColor = true;
            // 
            // FingerPrint
            //            
            // 
            // gbxUserRights
            // 
            //this.gbxUserRights.Controls.Add(this.chkDelete);
            this.gbxUserRights.Controls.Add(this.chkUpdate);
            this.gbxUserRights.Controls.Add(this.chkPrint);
            this.gbxUserRights.Controls.Add(this.chkInsert);
            this.gbxUserRights.Controls.Add(this.chkView);
            this.gbxUserRights.Controls.Add(this.cbxUserRights);
            this.gbxUserRights.Location = new System.Drawing.Point(189, 127);
            this.gbxUserRights.Name = "gbxUserRights";
            this.gbxUserRights.Size = new System.Drawing.Size(219, 224);
            this.gbxUserRights.TabIndex = 16;
            this.gbxUserRights.TabStop = false;
            this.gbxUserRights.Text = "صارف کے حقوق";
            // 
            // cbxUserRights
            // 
            this.cbxUserRights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUserRights.FormattingEnabled = true;
            this.cbxUserRights.Location = new System.Drawing.Point(15, 36);
            this.cbxUserRights.Name = "cbxUserRights";
            this.cbxUserRights.Size = new System.Drawing.Size(198, 39);
            this.cbxUserRights.TabIndex = 0;
            this.cbxUserRights.SelectedIndexChanged += new System.EventHandler(this.cbxUserRights_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ImageIndex = 20;
            this.btnDelete.ImageList = this.CORDImages;
            this.btnDelete.Location = new System.Drawing.Point(479, 357);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "بند کریں\r\n";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.CORDImages;
            this.btnSave.Location = new System.Drawing.Point(586, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "محفوظ کریں";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(479, 38);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(53, 35);
            this.chkActive.TabIndex = 1;
            this.chkActive.Text = "فعال";
            this.chkActive.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // cbUserName
            // 
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.Location = new System.Drawing.Point(538, 36);
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(149, 39);
            this.cbUserName.TabIndex = 0;
            this.cbUserName.Enter += new System.EventHandler(this.cbUserName_Enter);
            this.cbUserName.Leave += new System.EventHandler(this.cbUserName_Leave);
            // 
            // lblCNIC
            // 
            this.lblCNIC.AutoSize = true;
            this.lblCNIC.Location = new System.Drawing.Point(699, 299);
            this.lblCNIC.Name = "lblCNIC";
            this.lblCNIC.Size = new System.Drawing.Size(81, 31);
            this.lblCNIC.TabIndex = 6;
            this.lblCNIC.Text = "شناختی کارڈ کا نمبر :";
            // 
            // lblSecretAnswer
            // 
            this.lblSecretAnswer.AutoSize = true;
            this.lblSecretAnswer.Location = new System.Drawing.Point(690, 256);
            this.lblSecretAnswer.Name = "lblSecretAnswer";
            this.lblSecretAnswer.Size = new System.Drawing.Size(90, 31);
            this.lblSecretAnswer.TabIndex = 6;
            this.lblSecretAnswer.Text = " خفیہ سوال کا جواب :";
            // 
            // lblSecretQuestion
            // 
            this.lblSecretQuestion.AutoSize = true;
            this.lblSecretQuestion.Location = new System.Drawing.Point(724, 213);
            this.lblSecretQuestion.Name = "lblSecretQuestion";
            this.lblSecretQuestion.Size = new System.Drawing.Size(56, 31);
            this.lblSecretQuestion.TabIndex = 6;
            this.lblSecretQuestion.Text = "خفیہ سوال :";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(749, 170);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(31, 31);
            this.lblLastName.TabIndex = 6;
            this.lblLastName.Text = "ولد :";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(748, 127);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(32, 31);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "نام :";
            // 
            // txtSecretAnswer
            // 
            this.txtSecretAnswer.Location = new System.Drawing.Point(480, 253);
            this.txtSecretAnswer.Name = "txtSecretAnswer";
            this.txtSecretAnswer.Size = new System.Drawing.Size(207, 37);
            this.txtSecretAnswer.TabIndex = 6;
            // 
            // txtSecretQuestion
            // 
            this.txtSecretQuestion.Location = new System.Drawing.Point(480, 210);
            this.txtSecretQuestion.Name = "txtSecretQuestion";
            this.txtSecretQuestion.Size = new System.Drawing.Size(207, 37);
            this.txtSecretQuestion.TabIndex = 5;
            this.txtSecretQuestion.Text = "پہلا استاد؟";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(480, 167);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(207, 37);
            this.txtLastName.TabIndex = 4;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(480, 124);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(207, 37);
            this.txtFirstName.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(480, 81);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(207, 37);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(736, 84);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(44, 31);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "خفیہ کوڈ :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(719, 40);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(61, 31);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "نام صارف :";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(138, 171);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(65, 35);
            this.chkDelete.TabIndex = 4;
            this.chkDelete.Text = "خارج کرنا";
            this.chkDelete.UseVisualStyleBackColor = true;
            this.chkDelete.CheckedChanged += new System.EventHandler(this.chkDelete_CheckedChanged);
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(15, 130);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(68, 35);
            this.chkUpdate.TabIndex = 5;
            this.chkUpdate.Text = "تبدیل کرنا";
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.chkUpdate_CheckedChanged);
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(27, 87);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(56, 35);
            this.chkPrint.TabIndex = 3;
            this.chkPrint.Text = "پرنٹ";
            this.chkPrint.UseVisualStyleBackColor = true;
            this.chkPrint.CheckedChanged += new System.EventHandler(this.chkPrint_CheckedChanged);
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(137, 130);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(66, 35);
            this.chkInsert.TabIndex = 1;
            this.chkInsert.Text = "داخل کرنا";
            this.chkInsert.UseVisualStyleBackColor = true;
            this.chkInsert.CheckedChanged += new System.EventHandler(this.chkInsert_CheckedChanged);
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.Location = new System.Drawing.Point(147, 87);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(56, 35);
            this.chkView.TabIndex = 2;
            this.chkView.Text = " رسائی";
            this.chkView.UseVisualStyleBackColor = true;
            this.chkView.CheckedChanged += new System.EventHandler(this.chkView_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbUserRole);
            this.groupBox2.Location = new System.Drawing.Point(189, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 95);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "صارف کا کردار";
            // 
            // cbUserRole
            // 
            this.cbUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserRole.FormattingEnabled = true;
            this.cbUserRole.Location = new System.Drawing.Point(15, 36);
            this.cbUserRole.Name = "cbUserRole";
            this.cbUserRole.Size = new System.Drawing.Size(198, 39);
            this.cbUserRole.TabIndex = 0;
            // 
            // txtCNIC
            // 
            this.txtCNIC.Location = new System.Drawing.Point(538, 296);
            this.txtCNIC.MaxLength = 15;
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(149, 37);
            this.txtCNIC.TabIndex = 6;
            // 
            // CreateUserForm_Urdu
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(806, 487);
            this.Controls.Add(this.tcUsers);
            this.Controls.Add(this.StatusStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateUserForm_Urdu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "صارف کو بنانے کا فارم";
            this.Load += new System.EventHandler(this.CreateUserForm_Urdu_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CreateUserForm_Urdu_KeyPress);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.tcUsers.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.gbxUserRights.ResumeLayout(false);
            this.gbxUserRights.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private System.Windows.Forms.TabControl tcUsers;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.ImageList CORDImages;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ComboBox cbUserName;
        private System.Windows.Forms.Label lblCNIC;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxUserRights;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblSecretAnswer;
        private System.Windows.Forms.Label lblSecretQuestion;
        private System.Windows.Forms.TextBox txtSecretAnswer;
        private System.Windows.Forms.TextBox txtSecretQuestion;        
        private System.Windows.Forms.CheckBox chkBioMetricLogin;
        private System.Windows.Forms.ComboBox cbxUserRights;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbUserRole;
        private System.Windows.Forms.TextBox txtCNIC;
    }
}