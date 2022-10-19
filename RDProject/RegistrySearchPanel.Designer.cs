namespace RDProject
{
    partial class RegistrySearchPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrySearchPanel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.cbxTehsil = new System.Windows.Forms.ComboBox();
            this.chkTokenNo = new System.Windows.Forms.CheckBox();
            this.chkMauza = new System.Windows.Forms.CheckBox();
            this.cbxRegisteryType = new System.Windows.Forms.ComboBox();
            this.chkTehsil = new System.Windows.Forms.CheckBox();
            this.cbxDistrict = new System.Windows.Forms.ComboBox();
            this.chkDistrict = new System.Windows.Forms.CheckBox();
            this.chkRegistryType = new System.Windows.Forms.CheckBox();
            this.cbxMauza = new System.Windows.Forms.ComboBox();
            this.RegistryDatePicker = new System.Windows.Forms.DateTimePicker();
            this.txtTokenNo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DgvRegistry = new System.Windows.Forms.DataGridView();
            this.RegistryIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TokenNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisteryTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistrictCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TehsilCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MauzaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.SearchStrip = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRegistry)).BeginInit();
            this.SearchStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDate);
            this.groupBox1.Controls.Add(this.cbxTehsil);
            this.groupBox1.Controls.Add(this.chkTokenNo);
            this.groupBox1.Controls.Add(this.chkMauza);
            this.groupBox1.Controls.Add(this.cbxRegisteryType);
            this.groupBox1.Controls.Add(this.chkTehsil);
            this.groupBox1.Controls.Add(this.cbxDistrict);
            this.groupBox1.Controls.Add(this.chkDistrict);
            this.groupBox1.Controls.Add(this.chkRegistryType);
            this.groupBox1.Controls.Add(this.cbxMauza);
            this.groupBox1.Controls.Add(this.RegistryDatePicker);
            this.groupBox1.Controls.Add(this.txtTokenNo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkDate.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkDate.Location = new System.Drawing.Point(340, 24);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(53, 17);
            this.chkDate.TabIndex = 2;
            this.chkDate.Text = "Date:";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // cbxTehsil
            // 
            this.cbxTehsil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTehsil.Enabled = false;
            this.cbxTehsil.FormattingEnabled = true;
            this.cbxTehsil.Location = new System.Drawing.Point(118, 86);
            this.cbxTehsil.Name = "cbxTehsil";
            this.cbxTehsil.Size = new System.Drawing.Size(123, 21);
            this.cbxTehsil.TabIndex = 9;
            this.cbxTehsil.SelectedIndexChanged += new System.EventHandler(this.cbxDistrict_SelectedIndexChanged);
            // 
            // chkTokenNo
            // 
            this.chkTokenNo.AutoSize = true;
            this.chkTokenNo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkTokenNo.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkTokenNo.Location = new System.Drawing.Point(13, 24);
            this.chkTokenNo.Name = "chkTokenNo";
            this.chkTokenNo.Size = new System.Drawing.Size(106, 17);
            this.chkTokenNo.TabIndex = 0;
            this.chkTokenNo.Text = "Dastaweez No. :";
            this.chkTokenNo.UseVisualStyleBackColor = true;
            this.chkTokenNo.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // chkMauza
            // 
            this.chkMauza.AutoSize = true;
            this.chkMauza.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkMauza.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkMauza.Location = new System.Drawing.Point(340, 88);
            this.chkMauza.Name = "chkMauza";
            this.chkMauza.Size = new System.Drawing.Size(61, 17);
            this.chkMauza.TabIndex = 10;
            this.chkMauza.Text = "Mauza:";
            this.chkMauza.UseVisualStyleBackColor = true;
            this.chkMauza.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // cbxRegisteryType
            // 
            this.cbxRegisteryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRegisteryType.Enabled = false;
            this.cbxRegisteryType.FormattingEnabled = true;
            this.cbxRegisteryType.Location = new System.Drawing.Point(120, 52);
            this.cbxRegisteryType.Name = "cbxRegisteryType";
            this.cbxRegisteryType.Size = new System.Drawing.Size(121, 21);
            this.cbxRegisteryType.TabIndex = 5;
            // 
            // chkTehsil
            // 
            this.chkTehsil.AutoSize = true;
            this.chkTehsil.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkTehsil.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkTehsil.Location = new System.Drawing.Point(13, 88);
            this.chkTehsil.Name = "chkTehsil";
            this.chkTehsil.Size = new System.Drawing.Size(57, 17);
            this.chkTehsil.TabIndex = 8;
            this.chkTehsil.Text = "Tehsil:";
            this.chkTehsil.UseVisualStyleBackColor = true;
            this.chkTehsil.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // cbxDistrict
            // 
            this.cbxDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDistrict.Enabled = false;
            this.cbxDistrict.FormattingEnabled = true;
            this.cbxDistrict.Location = new System.Drawing.Point(419, 52);
            this.cbxDistrict.Name = "cbxDistrict";
            this.cbxDistrict.Size = new System.Drawing.Size(123, 21);
            this.cbxDistrict.TabIndex = 7;
            this.cbxDistrict.SelectedIndexChanged += new System.EventHandler(this.cbxDistrict_SelectedIndexChanged);
            // 
            // chkDistrict
            // 
            this.chkDistrict.AutoSize = true;
            this.chkDistrict.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkDistrict.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkDistrict.Location = new System.Drawing.Point(339, 56);
            this.chkDistrict.Name = "chkDistrict";
            this.chkDistrict.Size = new System.Drawing.Size(63, 17);
            this.chkDistrict.TabIndex = 6;
            this.chkDistrict.Text = "District:";
            this.chkDistrict.UseVisualStyleBackColor = true;
            this.chkDistrict.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // chkRegistryType
            // 
            this.chkRegistryType.AutoSize = true;
            this.chkRegistryType.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkRegistryType.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkRegistryType.Location = new System.Drawing.Point(13, 56);
            this.chkRegistryType.Name = "chkRegistryType";
            this.chkRegistryType.Size = new System.Drawing.Size(97, 17);
            this.chkRegistryType.TabIndex = 4;
            this.chkRegistryType.Text = "Registry Type:";
            this.chkRegistryType.UseVisualStyleBackColor = true;
            this.chkRegistryType.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // cbxMauza
            // 
            this.cbxMauza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMauza.Enabled = false;
            this.cbxMauza.FormattingEnabled = true;
            this.cbxMauza.Location = new System.Drawing.Point(419, 86);
            this.cbxMauza.Name = "cbxMauza";
            this.cbxMauza.Size = new System.Drawing.Size(123, 21);
            this.cbxMauza.TabIndex = 11;
            // 
            // RegistryDatePicker
            // 
            this.RegistryDatePicker.CustomFormat = "dd/MM/yyyy";
            this.RegistryDatePicker.Enabled = false;
            this.RegistryDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RegistryDatePicker.Location = new System.Drawing.Point(420, 18);
            this.RegistryDatePicker.Name = "RegistryDatePicker";
            this.RegistryDatePicker.Size = new System.Drawing.Size(122, 21);
            this.RegistryDatePicker.TabIndex = 3;
            // 
            // txtTokenNo
            // 
            this.txtTokenNo.Enabled = false;
            this.txtTokenNo.Location = new System.Drawing.Point(120, 21);
            this.txtTokenNo.Name = "txtTokenNo";
            this.txtTokenNo.Size = new System.Drawing.Size(121, 21);
            this.txtTokenNo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 122);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(581, 46);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.ImageIndex = 16;
            this.btnSearch.ImageList = this.CORDImages;
            this.btnSearch.Location = new System.Drawing.Point(250, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 46);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DgvRegistry);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Location = new System.Drawing.Point(0, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 396);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // DgvRegistry
            // 
            this.DgvRegistry.AllowUserToAddRows = false;
            this.DgvRegistry.AllowUserToDeleteRows = false;
            this.DgvRegistry.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvRegistry.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvRegistry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRegistry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvRegistry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRegistry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegistryIdCol,
            this.TokenNoCol,
            this.colDate,
            this.RegisteryTypeCol,
            this.DistrictCol,
            this.TehsilCol,
            this.MauzaCol});
            this.DgvRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvRegistry.EnableHeadersVisualStyles = false;
            this.DgvRegistry.Location = new System.Drawing.Point(3, 17);
            this.DgvRegistry.Name = "DgvRegistry";
            this.DgvRegistry.ReadOnly = true;
            this.DgvRegistry.RowHeadersVisible = false;
            this.DgvRegistry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRegistry.Size = new System.Drawing.Size(575, 376);
            this.DgvRegistry.TabIndex = 0;
            // 
            // RegistryIdCol
            // 
            this.RegistryIdCol.HeaderText = "RegistryID";
            this.RegistryIdCol.Name = "RegistryIdCol";
            this.RegistryIdCol.ReadOnly = true;
            this.RegistryIdCol.Visible = false;
            // 
            // TokenNoCol
            // 
            this.TokenNoCol.HeaderText = "Token No";
            this.TokenNoCol.Name = "TokenNoCol";
            this.TokenNoCol.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // RegisteryTypeCol
            // 
            this.RegisteryTypeCol.HeaderText = "Registry Type";
            this.RegisteryTypeCol.Name = "RegisteryTypeCol";
            this.RegisteryTypeCol.ReadOnly = true;
            // 
            // DistrictCol
            // 
            this.DistrictCol.HeaderText = "District";
            this.DistrictCol.Name = "DistrictCol";
            this.DistrictCol.ReadOnly = true;
            // 
            // TehsilCol
            // 
            this.TehsilCol.HeaderText = "Tehsil";
            this.TehsilCol.Name = "TehsilCol";
            this.TehsilCol.ReadOnly = true;
            // 
            // MauzaCol
            // 
            this.MauzaCol.HeaderText = "Mauza";
            this.MauzaCol.Name = "MauzaCol";
            this.MauzaCol.ReadOnly = true;
            // 
            // MsgStatus
            // 
            this.MsgStatus.Name = "MsgStatus";
            this.MsgStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // SearchStrip
            // 
            this.SearchStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsgStatus});
            this.SearchStrip.Location = new System.Drawing.Point(0, 564);
            this.SearchStrip.Name = "SearchStrip";
            this.SearchStrip.Size = new System.Drawing.Size(581, 22);
            this.SearchStrip.TabIndex = 3;
            this.SearchStrip.Text = "statusStrip1";
            // 
            // RegistrySearchPanel
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 586);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SearchStrip);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "RegistrySearchPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registry Search Panel";
            this.Load += new System.EventHandler(this.RegistrySearchPanel_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RegistrySearchPanel_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRegistry)).EndInit();
            this.SearchStrip.ResumeLayout(false);
            this.SearchStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTokenNo;
        private System.Windows.Forms.DateTimePicker RegistryDatePicker;
        private System.Windows.Forms.ComboBox cbxTehsil;
        private System.Windows.Forms.ComboBox cbxMauza;
        private System.Windows.Forms.ComboBox cbxDistrict;
        private System.Windows.Forms.ComboBox cbxRegisteryType;
        private System.Windows.Forms.CheckBox chkMauza;
        private System.Windows.Forms.CheckBox chkTehsil;
        private System.Windows.Forms.CheckBox chkDistrict;
        private System.Windows.Forms.CheckBox chkRegistryType;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkTokenNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DgvRegistry;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ImageList CORDImages;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegistryIdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokenNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisteryTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistrictCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TehsilCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MauzaCol;
        private System.Windows.Forms.ToolStripStatusLabel MsgStatus;
        private System.Windows.Forms.StatusStrip SearchStrip;
    }
}