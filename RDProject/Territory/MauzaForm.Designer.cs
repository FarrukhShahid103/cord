namespace RDProject.Territory
{
    partial class MauzaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MauzaForm));
            this.pnlMauza = new System.Windows.Forms.Panel();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.lblCaptionEng = new System.Windows.Forms.Label();
            this.ssDistrict = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAreaFormat = new System.Windows.Forms.ComboBox();
            this.cbxTown = new System.Windows.Forms.ComboBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.cbxTehsil = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDistrict_English = new System.Windows.Forms.ComboBox();
            this.lblDistrict_English = new System.Windows.Forms.Label();
            this.grdMauza = new System.Windows.Forms.DataGridView();
            this.colMauzaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMauzaNameEng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMauzaNameUrd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.pnlMauza.SuspendLayout();
            this.ssDistrict.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMauza)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMauza
            // 
            this.pnlMauza.BackColor = System.Drawing.SystemColors.Window;
            this.pnlMauza.Controls.Add(this.btnDeleteRecord);
            this.pnlMauza.Controls.Add(this.btnAddRecord);
            this.pnlMauza.Controls.Add(this.lblCaptionEng);
            this.pnlMauza.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMauza.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMauza.Location = new System.Drawing.Point(0, 0);
            this.pnlMauza.Name = "pnlMauza";
            this.pnlMauza.Size = new System.Drawing.Size(754, 60);
            this.pnlMauza.TabIndex = 3;
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteRecord.Enabled = false;
            this.btnDeleteRecord.FlatAppearance.BorderSize = 0;
            this.btnDeleteRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDeleteRecord.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnDeleteRecord.ImageIndex = 29;
            this.btnDeleteRecord.ImageList = this.CORDImages;
            this.btnDeleteRecord.Location = new System.Drawing.Point(632, 0);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(122, 60);
            this.btnDeleteRecord.TabIndex = 4;
            this.btnDeleteRecord.TabStop = false;
            this.btnDeleteRecord.Text = "&Delete Record";
            this.btnDeleteRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddRecord.Enabled = false;
            this.btnAddRecord.FlatAppearance.BorderSize = 0;
            this.btnAddRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddRecord.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnAddRecord.ImageIndex = 0;
            this.btnAddRecord.ImageList = this.CORDImages;
            this.btnAddRecord.Location = new System.Drawing.Point(0, 0);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(120, 60);
            this.btnAddRecord.TabIndex = 3;
            this.btnAddRecord.TabStop = false;
            this.btnAddRecord.Text = "&New Record";
            this.btnAddRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // lblCaptionEng
            // 
            this.lblCaptionEng.AutoSize = true;
            this.lblCaptionEng.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionEng.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCaptionEng.Location = new System.Drawing.Point(280, 12);
            this.lblCaptionEng.Name = "lblCaptionEng";
            this.lblCaptionEng.Size = new System.Drawing.Size(173, 31);
            this.lblCaptionEng.TabIndex = 2;
            this.lblCaptionEng.Text = "Mauza (موضع) - Form";
            // 
            // ssDistrict
            // 
            this.ssDistrict.BackColor = System.Drawing.SystemColors.Info;
            this.ssDistrict.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.ssDistrict.Location = new System.Drawing.Point(0, 381);
            this.ssDistrict.Name = "ssDistrict";
            this.ssDistrict.Size = new System.Drawing.Size(754, 22);
            this.ssDistrict.TabIndex = 6;
            this.ssDistrict.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 17);
            this.lblStatus.Text = "Record Saved";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxAreaFormat);
            this.panel1.Controls.Add(this.cbxTown);
            this.panel1.Controls.Add(this.lblTown);
            this.panel1.Controls.Add(this.cbxTehsil);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbDistrict_English);
            this.panel1.Controls.Add(this.lblDistrict_English);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 77);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(11, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Area Format :";
            // 
            // cbxAreaFormat
            // 
            this.cbxAreaFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAreaFormat.FormattingEnabled = true;
            this.cbxAreaFormat.Items.AddRange(new object[] {
            "ایکڑ",
            "مرلہ-کنال",
            "فٹ-مرلہ-کنال",
            "سرسائی-مرلہ-کنال",
            "گز-مرلہ-کنال"});
            this.cbxAreaFormat.Location = new System.Drawing.Point(118, 46);
            this.cbxAreaFormat.Name = "cbxAreaFormat";
            this.cbxAreaFormat.Size = new System.Drawing.Size(121, 21);
            this.cbxAreaFormat.TabIndex = 6;
            // 
            // cbxTown
            // 
            this.cbxTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTown.FormattingEnabled = true;
            this.cbxTown.Location = new System.Drawing.Point(555, 16);
            this.cbxTown.Name = "cbxTown";
            this.cbxTown.Size = new System.Drawing.Size(166, 24);
            this.cbxTown.TabIndex = 5;
            this.cbxTown.SelectedIndexChanged += new System.EventHandler(this.cbxTown_SelectedIndexChanged);
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTown.Location = new System.Drawing.Point(493, 19);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(49, 16);
            this.lblTown.TabIndex = 4;
            this.lblTown.Text = "Town :";
            // 
            // cbxTehsil
            // 
            this.cbxTehsil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTehsil.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTehsil.FormattingEnabled = true;
            this.cbxTehsil.Location = new System.Drawing.Point(316, 16);
            this.cbxTehsil.Name = "cbxTehsil";
            this.cbxTehsil.Size = new System.Drawing.Size(166, 24);
            this.cbxTehsil.TabIndex = 5;
            this.cbxTehsil.SelectedIndexChanged += new System.EventHandler(this.cbxTehsil_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(254, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tehsil :";
            // 
            // cbDistrict_English
            // 
            this.cbDistrict_English.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDistrict_English.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDistrict_English.FormattingEnabled = true;
            this.cbDistrict_English.Location = new System.Drawing.Point(73, 16);
            this.cbDistrict_English.Name = "cbDistrict_English";
            this.cbDistrict_English.Size = new System.Drawing.Size(166, 24);
            this.cbDistrict_English.TabIndex = 3;
            this.cbDistrict_English.SelectedIndexChanged += new System.EventHandler(this.cbDistrict_English_SelectedIndexChanged);
            // 
            // lblDistrict_English
            // 
            this.lblDistrict_English.AutoSize = true;
            this.lblDistrict_English.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict_English.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDistrict_English.Location = new System.Drawing.Point(11, 19);
            this.lblDistrict_English.Name = "lblDistrict_English";
            this.lblDistrict_English.Size = new System.Drawing.Size(56, 16);
            this.lblDistrict_English.TabIndex = 2;
            this.lblDistrict_English.Text = "District :";
            // 
            // grdMauza
            // 
            this.grdMauza.AllowUserToAddRows = false;
            this.grdMauza.AllowUserToDeleteRows = false;
            this.grdMauza.AllowUserToResizeColumns = false;
            this.grdMauza.AllowUserToResizeRows = false;
            this.grdMauza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdMauza.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.grdMauza.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grdMauza.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdMauza.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMauza.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMauza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMauza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMauzaId,
            this.colMauzaNameEng,
            this.colMauzaNameUrd});
            this.grdMauza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMauza.EnableHeadersVisualStyles = false;
            this.grdMauza.GridColor = System.Drawing.Color.Black;
            this.grdMauza.Location = new System.Drawing.Point(0, 137);
            this.grdMauza.MultiSelect = false;
            this.grdMauza.Name = "grdMauza";
            this.grdMauza.RowHeadersVisible = false;
            this.grdMauza.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdMauza.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdMauza.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdMauza.Size = new System.Drawing.Size(754, 244);
            this.grdMauza.StandardTab = true;
            this.grdMauza.TabIndex = 10;
            this.grdMauza.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdMauza_RowValidating);
            this.grdMauza.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdMauza_KeyDown_1);
            // 
            // colMauzaId
            // 
            this.colMauzaId.HeaderText = "MauzaID";
            this.colMauzaId.Name = "colMauzaId";
            this.colMauzaId.ReadOnly = true;
            this.colMauzaId.Visible = false;
            // 
            // colMauzaNameEng
            // 
            this.colMauzaNameEng.HeaderText = "Mauza Name";
            this.colMauzaNameEng.MinimumWidth = 150;
            this.colMauzaNameEng.Name = "colMauzaNameEng";
            // 
            // colMauzaNameUrd
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nafees Nastaleeq", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMauzaNameUrd.DefaultCellStyle = dataGridViewCellStyle2;
            this.colMauzaNameUrd.HeaderText = "موضع کا نام";
            this.colMauzaNameUrd.MinimumWidth = 150;
            this.colMauzaNameUrd.Name = "colMauzaNameUrd";
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
            // MauzaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 403);
            this.Controls.Add(this.grdMauza);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ssDistrict);
            this.Controls.Add(this.pnlMauza);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MauzaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muaza";
            this.Load += new System.EventHandler(this.MauzaForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MauzaForm_KeyPress);
            this.pnlMauza.ResumeLayout(false);
            this.pnlMauza.PerformLayout();
            this.ssDistrict.ResumeLayout(false);
            this.ssDistrict.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMauza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMauza;
        private System.Windows.Forms.StatusStrip ssDistrict;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Label lblCaptionEng;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbDistrict_English;
        private System.Windows.Forms.Label lblDistrict_English;
        private System.Windows.Forms.ComboBox cbxTehsil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdMauza;
        private System.Windows.Forms.ComboBox cbxAreaFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxTown;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMauzaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMauzaNameEng;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMauzaNameUrd;
        private System.Windows.Forms.ImageList CORDImages;
    }
}