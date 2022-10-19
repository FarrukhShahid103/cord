namespace RDProject.RD
{
    partial class InboxForm_English
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InboxForm_English));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlState = new System.Windows.Forms.Panel();
            this.chkWaitingForSCI = new System.Windows.Forms.CheckBox();
            this.lblInprogress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.lblRejected = new System.Windows.Forms.Label();
            this.chkFinalize = new System.Windows.Forms.CheckBox();
            this.chkSendToSR = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkFresh = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtTokenNo = new System.Windows.Forms.TextBox();
            this.chkTokenNo = new System.Windows.Forms.CheckBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.txtDastaweezNo = new System.Windows.Forms.TextBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkDastaweezNo = new System.Windows.Forms.CheckBox();
            this.cbxRegisteryType = new System.Windows.Forms.ComboBox();
            this.chkRegistryType = new System.Windows.Forms.CheckBox();
            this.RegistryDatePicker = new System.Windows.Forms.DateTimePicker();
            this.pnlPaging = new System.Windows.Forms.Panel();
            this.btn_Last = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_First = new System.Windows.Forms.Button();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.ddlTotalPages = new System.Windows.Forms.ComboBox();
            this.ddlPageSize = new System.Windows.Forms.ComboBox();
            this.grdInbox = new System.Windows.Forms.DataGridView();
            this.pnlState.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInbox)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlState
            // 
            this.pnlState.Controls.Add(this.chkWaitingForSCI);
            this.pnlState.Controls.Add(this.lblInprogress);
            this.pnlState.Controls.Add(this.label4);
            this.pnlState.Controls.Add(this.label2);
            this.pnlState.Controls.Add(this.lblBlue);
            this.pnlState.Controls.Add(this.lblRejected);
            this.pnlState.Controls.Add(this.chkFinalize);
            this.pnlState.Controls.Add(this.chkSendToSR);
            this.pnlState.Controls.Add(this.chkAll);
            this.pnlState.Controls.Add(this.chkFresh);
            this.pnlState.Controls.Add(this.label3);
            this.pnlState.Controls.Add(this.label1);
            this.pnlState.Controls.Add(this.lblRed);
            this.pnlState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlState.Location = new System.Drawing.Point(0, 612);
            this.pnlState.Name = "pnlState";
            this.pnlState.Size = new System.Drawing.Size(979, 49);
            this.pnlState.TabIndex = 9;
            // 
            // chkWaitingForSCI
            // 
            this.chkWaitingForSCI.AutoSize = true;
            this.chkWaitingForSCI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkWaitingForSCI.ForeColor = System.Drawing.Color.Green;
            this.chkWaitingForSCI.Location = new System.Drawing.Point(398, 16);
            this.chkWaitingForSCI.Name = "chkWaitingForSCI";
            this.chkWaitingForSCI.Size = new System.Drawing.Size(110, 17);
            this.chkWaitingForSCI.TabIndex = 7;
            this.chkWaitingForSCI.Text = "Waiting for SCI";
            this.chkWaitingForSCI.UseVisualStyleBackColor = true;
            this.chkWaitingForSCI.Visible = false;
            this.chkWaitingForSCI.CheckedChanged += new System.EventHandler(this.chkWaitingForSCI_CheckedChanged);
            // 
            // lblInprogress
            // 
            this.lblInprogress.AutoSize = true;
            this.lblInprogress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInprogress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInprogress.Location = new System.Drawing.Point(896, 26);
            this.lblInprogress.Name = "lblInprogress";
            this.lblInprogress.Size = new System.Drawing.Size(72, 13);
            this.lblInprogress.TabIndex = 0;
            this.lblInprogress.Text = "In progress";
            this.lblInprogress.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(802, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Completed";
            this.label4.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(692, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Approve";
            this.label2.Visible = false;
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlue.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblBlue.Location = new System.Drawing.Point(896, 10);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(34, 13);
            this.lblBlue.TabIndex = 0;
            this.lblBlue.Text = "Blue:";
            this.lblBlue.Visible = false;
            // 
            // lblRejected
            // 
            this.lblRejected.AutoSize = true;
            this.lblRejected.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRejected.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRejected.Location = new System.Drawing.Point(600, 26);
            this.lblRejected.Name = "lblRejected";
            this.lblRejected.Size = new System.Drawing.Size(58, 13);
            this.lblRejected.TabIndex = 0;
            this.lblRejected.Text = "Rejected";
            this.lblRejected.Visible = false;
            // 
            // chkFinalize
            // 
            this.chkFinalize.AutoSize = true;
            this.chkFinalize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkFinalize.ForeColor = System.Drawing.Color.Green;
            this.chkFinalize.Location = new System.Drawing.Point(306, 16);
            this.chkFinalize.Name = "chkFinalize";
            this.chkFinalize.Size = new System.Drawing.Size(68, 17);
            this.chkFinalize.TabIndex = 6;
            this.chkFinalize.Text = "Finalize";
            this.chkFinalize.UseVisualStyleBackColor = true;
            this.chkFinalize.CheckedChanged += new System.EventHandler(this.chkFinalize_CheckedChanged);
            // 
            // chkSendToSR
            // 
            this.chkSendToSR.AutoSize = true;
            this.chkSendToSR.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkSendToSR.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkSendToSR.Location = new System.Drawing.Point(194, 16);
            this.chkSendToSR.Name = "chkSendToSR";
            this.chkSendToSR.Size = new System.Drawing.Size(87, 17);
            this.chkSendToSR.TabIndex = 6;
            this.chkSendToSR.Text = "Sent To SR";
            this.chkSendToSR.UseVisualStyleBackColor = true;
            this.chkSendToSR.CheckedChanged += new System.EventHandler(this.chkSendToSR_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkAll.ForeColor = System.Drawing.Color.Black;
            this.chkAll.Location = new System.Drawing.Point(23, 16);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(40, 17);
            this.chkAll.TabIndex = 6;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkFresh
            // 
            this.chkFresh.AutoSize = true;
            this.chkFresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkFresh.ForeColor = System.Drawing.Color.Maroon;
            this.chkFresh.Location = new System.Drawing.Point(94, 16);
            this.chkFresh.Name = "chkFresh";
            this.chkFresh.Size = new System.Drawing.Size(57, 17);
            this.chkFresh.TabIndex = 6;
            this.chkFresh.Text = "Fresh";
            this.chkFresh.UseVisualStyleBackColor = true;
            this.chkFresh.CheckedChanged += new System.EventHandler(this.chkInitialStep_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(802, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gray:";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(692, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Green:";
            this.label1.Visible = false;
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRed.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRed.Location = new System.Drawing.Point(600, 10);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(32, 13);
            this.lblRed.TabIndex = 0;
            this.lblRed.Text = "Red:";
            this.lblRed.Visible = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlSearch.Controls.Add(this.txtTokenNo);
            this.pnlSearch.Controls.Add(this.chkTokenNo);
            this.pnlSearch.Controls.Add(this.btn_Search);
            this.pnlSearch.Controls.Add(this.txtDastaweezNo);
            this.pnlSearch.Controls.Add(this.chkDate);
            this.pnlSearch.Controls.Add(this.chkDastaweezNo);
            this.pnlSearch.Controls.Add(this.cbxRegisteryType);
            this.pnlSearch.Controls.Add(this.chkRegistryType);
            this.pnlSearch.Controls.Add(this.RegistryDatePicker);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(979, 56);
            this.pnlSearch.TabIndex = 11;
            // 
            // txtTokenNo
            // 
            this.txtTokenNo.Enabled = false;
            this.txtTokenNo.Location = new System.Drawing.Point(94, 16);
            this.txtTokenNo.Name = "txtTokenNo";
            this.txtTokenNo.Size = new System.Drawing.Size(136, 21);
            this.txtTokenNo.TabIndex = 14;
            // 
            // chkTokenNo
            // 
            this.chkTokenNo.AutoSize = true;
            this.chkTokenNo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkTokenNo.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkTokenNo.Location = new System.Drawing.Point(8, 18);
            this.chkTokenNo.Name = "chkTokenNo";
            this.chkTokenNo.Size = new System.Drawing.Size(82, 17);
            this.chkTokenNo.TabIndex = 13;
            this.chkTokenNo.Text = "Token No. :";
            this.chkTokenNo.UseVisualStyleBackColor = true;
            this.chkTokenNo.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // btn_Search
            // 
            this.btn_Search.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Search.Enabled = false;
            this.btn_Search.FlatAppearance.BorderSize = 0;
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.SteelBlue;
            this.btn_Search.ImageIndex = 16;
            this.btn_Search.ImageList = this.CORDImages;
            this.btn_Search.Location = new System.Drawing.Point(886, 0);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(93, 56);
            this.btn_Search.TabIndex = 12;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
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
            // 
            // txtDastaweezNo
            // 
            this.txtDastaweezNo.Enabled = false;
            this.txtDastaweezNo.Location = new System.Drawing.Point(341, 16);
            this.txtDastaweezNo.Name = "txtDastaweezNo";
            this.txtDastaweezNo.Size = new System.Drawing.Size(121, 21);
            this.txtDastaweezNo.TabIndex = 11;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkDate.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkDate.Location = new System.Drawing.Point(698, 18);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(53, 17);
            this.chkDate.TabIndex = 10;
            this.chkDate.Text = "Date:";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // chkDastaweezNo
            // 
            this.chkDastaweezNo.AutoSize = true;
            this.chkDastaweezNo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkDastaweezNo.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkDastaweezNo.Location = new System.Drawing.Point(236, 18);
            this.chkDastaweezNo.Name = "chkDastaweezNo";
            this.chkDastaweezNo.Size = new System.Drawing.Size(99, 17);
            this.chkDastaweezNo.TabIndex = 7;
            this.chkDastaweezNo.Text = "Dastaweez No:";
            this.chkDastaweezNo.UseVisualStyleBackColor = true;
            this.chkDastaweezNo.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // cbxRegisteryType
            // 
            this.cbxRegisteryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRegisteryType.Enabled = false;
            this.cbxRegisteryType.FormattingEnabled = true;
            this.cbxRegisteryType.Location = new System.Drawing.Point(571, 16);
            this.cbxRegisteryType.Name = "cbxRegisteryType";
            this.cbxRegisteryType.Size = new System.Drawing.Size(121, 21);
            this.cbxRegisteryType.TabIndex = 9;
            // 
            // chkRegistryType
            // 
            this.chkRegistryType.AutoSize = true;
            this.chkRegistryType.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkRegistryType.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkRegistryType.Location = new System.Drawing.Point(468, 18);
            this.chkRegistryType.Name = "chkRegistryType";
            this.chkRegistryType.Size = new System.Drawing.Size(97, 17);
            this.chkRegistryType.TabIndex = 6;
            this.chkRegistryType.Text = "Registry Type:";
            this.chkRegistryType.UseVisualStyleBackColor = true;
            this.chkRegistryType.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // RegistryDatePicker
            // 
            this.RegistryDatePicker.CustomFormat = "dd/MM/yyyy";
            this.RegistryDatePicker.Enabled = false;
            this.RegistryDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RegistryDatePicker.Location = new System.Drawing.Point(758, 16);
            this.RegistryDatePicker.Name = "RegistryDatePicker";
            this.RegistryDatePicker.Size = new System.Drawing.Size(122, 21);
            this.RegistryDatePicker.TabIndex = 8;
            // 
            // pnlPaging
            // 
            this.pnlPaging.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlPaging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaging.Controls.Add(this.btn_Last);
            this.pnlPaging.Controls.Add(this.btn_Next);
            this.pnlPaging.Controls.Add(this.btn_Back);
            this.pnlPaging.Controls.Add(this.btn_First);
            this.pnlPaging.Controls.Add(this.lblTotalPages);
            this.pnlPaging.Controls.Add(this.lblPageSize);
            this.pnlPaging.Controls.Add(this.ddlTotalPages);
            this.pnlPaging.Controls.Add(this.ddlPageSize);
            this.pnlPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPaging.Location = new System.Drawing.Point(0, 567);
            this.pnlPaging.Name = "pnlPaging";
            this.pnlPaging.Size = new System.Drawing.Size(979, 45);
            this.pnlPaging.TabIndex = 12;
            // 
            // btn_Last
            // 
            this.btn_Last.Image = ((System.Drawing.Image)(resources.GetObject("btn_Last.Image")));
            this.btn_Last.Location = new System.Drawing.Point(509, 12);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(23, 23);
            this.btn_Last.TabIndex = 2;
            this.btn_Last.UseVisualStyleBackColor = true;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Image = ((System.Drawing.Image)(resources.GetObject("btn_Next.Image")));
            this.btn_Next.Location = new System.Drawing.Point(487, 12);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(23, 23);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_Back.Image")));
            this.btn_Back.Location = new System.Drawing.Point(465, 12);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(23, 23);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_First
            // 
            this.btn_First.Image = ((System.Drawing.Image)(resources.GetObject("btn_First.Image")));
            this.btn_First.Location = new System.Drawing.Point(443, 12);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(23, 23);
            this.btn_First.TabIndex = 2;
            this.btn_First.UseVisualStyleBackColor = true;
            this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalPages.Location = new System.Drawing.Point(784, 19);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(63, 13);
            this.lblTotalPages.TabIndex = 1;
            this.lblTotalPages.Text = "Total Pages";
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPageSize.Location = new System.Drawing.Point(24, 17);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(53, 13);
            this.lblPageSize.TabIndex = 1;
            this.lblPageSize.Text = "Page Size";
            // 
            // ddlTotalPages
            // 
            this.ddlTotalPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTotalPages.FormattingEnabled = true;
            this.ddlTotalPages.Location = new System.Drawing.Point(855, 14);
            this.ddlTotalPages.Name = "ddlTotalPages";
            this.ddlTotalPages.Size = new System.Drawing.Size(86, 21);
            this.ddlTotalPages.TabIndex = 0;
            this.ddlTotalPages.SelectedValueChanged += new System.EventHandler(this.ddlTotalPages_SelectedValueChanged);
            // 
            // ddlPageSize
            // 
            this.ddlPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPageSize.FormattingEnabled = true;
            this.ddlPageSize.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100"});
            this.ddlPageSize.Location = new System.Drawing.Point(86, 14);
            this.ddlPageSize.Name = "ddlPageSize";
            this.ddlPageSize.Size = new System.Drawing.Size(85, 21);
            this.ddlPageSize.TabIndex = 0;
            this.ddlPageSize.SelectedValueChanged += new System.EventHandler(this.ddlPageSize_SelectedValueChanged);
            // 
            // grdInbox
            // 
            this.grdInbox.AllowUserToAddRows = false;
            this.grdInbox.AllowUserToDeleteRows = false;
            this.grdInbox.AllowUserToResizeColumns = false;
            this.grdInbox.AllowUserToResizeRows = false;
            this.grdInbox.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.grdInbox.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grdInbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdInbox.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInbox.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdInbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInbox.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdInbox.EnableHeadersVisualStyles = false;
            this.grdInbox.GridColor = System.Drawing.Color.Black;
            this.grdInbox.Location = new System.Drawing.Point(0, 56);
            this.grdInbox.MultiSelect = false;
            this.grdInbox.Name = "grdInbox";
            this.grdInbox.RowHeadersVisible = false;
            this.grdInbox.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdInbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdInbox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdInbox.Size = new System.Drawing.Size(979, 511);
            this.grdInbox.StandardTab = true;
            this.grdInbox.TabIndex = 13;
            this.grdInbox.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInbox_CellClick);
            this.grdInbox.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdInbox_CellFormatting);
            // 
            // InboxForm_English
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 661);
            this.Controls.Add(this.grdInbox);
            this.Controls.Add(this.pnlPaging);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlState);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "InboxForm_English";
            this.Text = "Inbox";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InboxForm_English_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InboxForm_English_KeyPress);
            this.pnlState.ResumeLayout(false);
            this.pnlState.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlPaging.ResumeLayout(false);
            this.pnlPaging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlState;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblRejected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInprogress;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkDastaweezNo;
        private System.Windows.Forms.ComboBox cbxRegisteryType;
        private System.Windows.Forms.CheckBox chkRegistryType;
        private System.Windows.Forms.DateTimePicker RegistryDatePicker;
        private System.Windows.Forms.TextBox txtDastaweezNo;
        private System.Windows.Forms.ImageList CORDImages;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.ComboBox ddlTotalPages;
        private System.Windows.Forms.ComboBox ddlPageSize;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Button btn_Last;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_First;
        private System.Windows.Forms.CheckBox chkFinalize;
        private System.Windows.Forms.CheckBox chkSendToSR;
        private System.Windows.Forms.CheckBox chkFresh;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridView grdInbox;
        private System.Windows.Forms.CheckBox chkWaitingForSCI;
        private System.Windows.Forms.TextBox txtTokenNo;
        private System.Windows.Forms.CheckBox chkTokenNo;
    }
}