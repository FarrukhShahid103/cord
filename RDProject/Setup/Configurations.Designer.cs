namespace RDProject.Setup
{
    partial class Configurations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configurations));
            this.lblMauza = new System.Windows.Forms.Label();
            this.cbxMauza = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cbxTehsil = new System.Windows.Forms.ComboBox();
            this.cbxDistrict = new System.Windows.Forms.ComboBox();
            this.pnlBasicInfo = new System.Windows.Forms.Panel();
            this.lblBasicInfo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkIsTown = new System.Windows.Forms.CheckBox();
            this.chkIsBioMatric = new System.Windows.Forms.CheckBox();
            this.cbxTown = new System.Windows.Forms.ComboBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.chkScanningFromApp = new System.Windows.Forms.CheckBox();
            this.pnlBasicInfo.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMauza
            // 
            this.lblMauza.AutoSize = true;
            this.lblMauza.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMauza.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMauza.Location = new System.Drawing.Point(68, 166);
            this.lblMauza.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMauza.Name = "lblMauza";
            this.lblMauza.Size = new System.Drawing.Size(42, 13);
            this.lblMauza.TabIndex = 55;
            this.lblMauza.Text = "Mauza:";
            // 
            // cbxMauza
            // 
            this.cbxMauza.BackColor = System.Drawing.SystemColors.Window;
            this.cbxMauza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMauza.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMauza.FormattingEnabled = true;
            this.cbxMauza.Location = new System.Drawing.Point(153, 163);
            this.cbxMauza.Name = "cbxMauza";
            this.cbxMauza.Size = new System.Drawing.Size(177, 21);
            this.cbxMauza.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(68, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Tehsil :";
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDistrict.Location = new System.Drawing.Point(68, 85);
            this.lblDistrict.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(47, 13);
            this.lblDistrict.TabIndex = 53;
            this.lblDistrict.Text = "District :";
            // 
            // cbxTehsil
            // 
            this.cbxTehsil.BackColor = System.Drawing.SystemColors.Window;
            this.cbxTehsil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTehsil.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTehsil.FormattingEnabled = true;
            this.cbxTehsil.Location = new System.Drawing.Point(153, 109);
            this.cbxTehsil.Name = "cbxTehsil";
            this.cbxTehsil.Size = new System.Drawing.Size(177, 21);
            this.cbxTehsil.TabIndex = 51;
            this.cbxTehsil.SelectedIndexChanged += new System.EventHandler(this.cbxTehsil_SelectedIndexChanged);
            // 
            // cbxDistrict
            // 
            this.cbxDistrict.BackColor = System.Drawing.SystemColors.Window;
            this.cbxDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDistrict.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDistrict.FormattingEnabled = true;
            this.cbxDistrict.Location = new System.Drawing.Point(153, 82);
            this.cbxDistrict.Name = "cbxDistrict";
            this.cbxDistrict.Size = new System.Drawing.Size(177, 21);
            this.cbxDistrict.TabIndex = 50;
            this.cbxDistrict.SelectedIndexChanged += new System.EventHandler(this.cbxDistrict_SelectedIndexChanged);
            // 
            // pnlBasicInfo
            // 
            this.pnlBasicInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.pnlBasicInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBasicInfo.Controls.Add(this.lblBasicInfo);
            this.pnlBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBasicInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlBasicInfo.Name = "pnlBasicInfo";
            this.pnlBasicInfo.Size = new System.Drawing.Size(456, 55);
            this.pnlBasicInfo.TabIndex = 56;
            // 
            // lblBasicInfo
            // 
            this.lblBasicInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBasicInfo.AutoSize = true;
            this.lblBasicInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicInfo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblBasicInfo.Location = new System.Drawing.Point(12, 17);
            this.lblBasicInfo.Name = "lblBasicInfo";
            this.lblBasicInfo.Size = new System.Drawing.Size(184, 19);
            this.lblBasicInfo.TabIndex = 1;
            this.lblBasicInfo.Text = "Configuration Setting";
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.CORDImages;
            this.btnSave.Location = new System.Drawing.Point(153, 242);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 43);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageIndex = 20;
            this.btnCancel.ImageList = this.CORDImages;
            this.btnCancel.Location = new System.Drawing.Point(241, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 43);
            this.btnCancel.TabIndex = 58;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 301);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(456, 22);
            this.statusStrip1.TabIndex = 60;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMsg
            // 
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // chkIsTown
            // 
            this.chkIsTown.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkIsTown.Location = new System.Drawing.Point(153, 190);
            this.chkIsTown.Name = "chkIsTown";
            this.chkIsTown.Size = new System.Drawing.Size(74, 17);
            this.chkIsTown.TabIndex = 61;
            this.chkIsTown.Text = "Is Town";
            this.chkIsTown.UseVisualStyleBackColor = true;
            // 
            // chkIsBioMatric
            // 
            this.chkIsBioMatric.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkIsBioMatric.Location = new System.Drawing.Point(249, 190);
            this.chkIsBioMatric.Name = "chkIsBioMatric";
            this.chkIsBioMatric.Size = new System.Drawing.Size(81, 17);
            this.chkIsBioMatric.TabIndex = 61;
            this.chkIsBioMatric.Text = "Is Biometric";
            this.chkIsBioMatric.UseVisualStyleBackColor = true;
            // 
            // cbxTown
            // 
            this.cbxTown.BackColor = System.Drawing.SystemColors.Window;
            this.cbxTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTown.FormattingEnabled = true;
            this.cbxTown.Location = new System.Drawing.Point(153, 136);
            this.cbxTown.Name = "cbxTown";
            this.cbxTown.Size = new System.Drawing.Size(177, 21);
            this.cbxTown.TabIndex = 51;
            this.cbxTown.SelectedIndexChanged += new System.EventHandler(this.cbxTown_SelectedIndexChanged);
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTown.Location = new System.Drawing.Point(68, 139);
            this.lblTown.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(40, 13);
            this.lblTown.TabIndex = 54;
            this.lblTown.Text = "Town :";
            // 
            // chkScanningFromApp
            // 
            this.chkScanningFromApp.AutoSize = true;
            this.chkScanningFromApp.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkScanningFromApp.Location = new System.Drawing.Point(153, 213);
            this.chkScanningFromApp.Name = "chkScanningFromApp";
            this.chkScanningFromApp.Size = new System.Drawing.Size(151, 17);
            this.chkScanningFromApp.TabIndex = 61;
            this.chkScanningFromApp.Text = "Scanning From Application";
            this.chkScanningFromApp.UseVisualStyleBackColor = true;
            // 
            // Configurations
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(456, 323);
            this.Controls.Add(this.chkScanningFromApp);
            this.Controls.Add(this.chkIsBioMatric);
            this.Controls.Add(this.chkIsTown);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlBasicInfo);
            this.Controls.Add(this.lblMauza);
            this.Controls.Add(this.cbxMauza);
            this.Controls.Add(this.lblTown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDistrict);
            this.Controls.Add(this.cbxTown);
            this.Controls.Add(this.cbxTehsil);
            this.Controls.Add(this.cbxDistrict);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Configurations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurations";
            this.Load += new System.EventHandler(this.Configurations_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Configurations_KeyPress);
            this.pnlBasicInfo.ResumeLayout(false);
            this.pnlBasicInfo.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMauza;
        private System.Windows.Forms.ComboBox cbxMauza;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbxTehsil;
        private System.Windows.Forms.ComboBox cbxDistrict;
        private System.Windows.Forms.Panel pnlBasicInfo;
        private System.Windows.Forms.Label lblBasicInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private System.Windows.Forms.CheckBox chkIsTown;
        private System.Windows.Forms.CheckBox chkIsBioMatric;
        private System.Windows.Forms.ComboBox cbxTown;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.ImageList CORDImages;
        private System.Windows.Forms.CheckBox chkScanningFromApp;
    }
}