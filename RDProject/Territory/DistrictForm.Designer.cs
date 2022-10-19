namespace RDProject.Territory
{
    partial class frmDistrictSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDistrictSetup));
            this.ssDistrict = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlDistrict = new System.Windows.Forms.Panel();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.lblCaptionEng = new System.Windows.Forms.Label();
            this.grdDistrict = new System.Windows.Forms.DataGridView();
            this.col_DistrictID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DistrictName_Eng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DistrictName_Urd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.ssDistrict.SuspendLayout();
            this.pnlDistrict.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDistrict)).BeginInit();
            this.SuspendLayout();
            // 
            // ssDistrict
            // 
            this.ssDistrict.BackColor = System.Drawing.SystemColors.Info;
            this.ssDistrict.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.ssDistrict.Location = new System.Drawing.Point(0, 345);
            this.ssDistrict.Name = "ssDistrict";
            this.ssDistrict.Size = new System.Drawing.Size(674, 22);
            this.ssDistrict.TabIndex = 0;
            this.ssDistrict.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 17);
            this.lblStatus.Text = "Record Saved";
            // 
            // pnlDistrict
            // 
            this.pnlDistrict.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDistrict.Controls.Add(this.btnDeleteRecord);
            this.pnlDistrict.Controls.Add(this.btnAddRecord);
            this.pnlDistrict.Controls.Add(this.lblCaptionEng);
            this.pnlDistrict.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDistrict.Location = new System.Drawing.Point(0, 0);
            this.pnlDistrict.Name = "pnlDistrict";
            this.pnlDistrict.Size = new System.Drawing.Size(674, 60);
            this.pnlDistrict.TabIndex = 1;
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteRecord.FlatAppearance.BorderSize = 0;
            this.btnDeleteRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDeleteRecord.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnDeleteRecord.ImageIndex = 29;
            this.btnDeleteRecord.ImageList = this.CORDImages;
            this.btnDeleteRecord.Location = new System.Drawing.Point(532, 0);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(142, 60);
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
            this.btnAddRecord.FlatAppearance.BorderSize = 0;
            this.btnAddRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddRecord.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnAddRecord.ImageIndex = 0;
            this.btnAddRecord.ImageList = this.CORDImages;
            this.btnAddRecord.Location = new System.Drawing.Point(0, 0);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(142, 60);
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
            this.lblCaptionEng.Location = new System.Drawing.Point(253, 15);
            this.lblCaptionEng.Name = "lblCaptionEng";
            this.lblCaptionEng.Size = new System.Drawing.Size(169, 31);
            this.lblCaptionEng.TabIndex = 2;
            this.lblCaptionEng.Text = "District (ضلع) - Form";
            // 
            // grdDistrict
            // 
            this.grdDistrict.AllowUserToAddRows = false;
            this.grdDistrict.AllowUserToDeleteRows = false;
            this.grdDistrict.AllowUserToResizeColumns = false;
            this.grdDistrict.AllowUserToResizeRows = false;
            this.grdDistrict.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdDistrict.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.grdDistrict.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grdDistrict.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDistrict.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDistrict.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDistrict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDistrict.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_DistrictID,
            this.col_DistrictName_Eng,
            this.col_DistrictName_Urd});
            this.grdDistrict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDistrict.EnableHeadersVisualStyles = false;
            this.grdDistrict.GridColor = System.Drawing.Color.Black;
            this.grdDistrict.Location = new System.Drawing.Point(0, 60);
            this.grdDistrict.MultiSelect = false;
            this.grdDistrict.Name = "grdDistrict";
            this.grdDistrict.RowHeadersVisible = false;
            this.grdDistrict.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDistrict.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdDistrict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdDistrict.Size = new System.Drawing.Size(674, 285);
            this.grdDistrict.StandardTab = true;
            this.grdDistrict.TabIndex = 4;
            this.grdDistrict.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdDistrict_RowValidating);
            this.grdDistrict.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDistrict_KeyDown);
            // 
            // col_DistrictID
            // 
            this.col_DistrictID.HeaderText = "DistrictID";
            this.col_DistrictID.Name = "col_DistrictID";
            this.col_DistrictID.Visible = false;
            // 
            // col_DistrictName_Eng
            // 
            this.col_DistrictName_Eng.HeaderText = "District Name";
            this.col_DistrictName_Eng.Name = "col_DistrictName_Eng";
            // 
            // col_DistrictName_Urd
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nafees Nastaleeq", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_DistrictName_Urd.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_DistrictName_Urd.HeaderText = "ضلع کا نام";
            this.col_DistrictName_Urd.Name = "col_DistrictName_Urd";
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
            // frmDistrictSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 367);
            this.Controls.Add(this.grdDistrict);
            this.Controls.Add(this.pnlDistrict);
            this.Controls.Add(this.ssDistrict);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDistrictSetup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "District Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDistrictSetup_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDistrictSetup_FormClosed);
            this.Load += new System.EventHandler(this.DistrictForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmDistrictSetup_KeyPress);
            this.ssDistrict.ResumeLayout(false);
            this.ssDistrict.PerformLayout();
            this.pnlDistrict.ResumeLayout(false);
            this.pnlDistrict.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDistrict)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssDistrict;
        private System.Windows.Forms.Panel pnlDistrict;
        private System.Windows.Forms.Label lblCaptionEng;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.DataGridView grdDistrict;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DistrictID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DistrictName_Eng;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DistrictName_Urd;
        private System.Windows.Forms.ImageList CORDImages;
    }
}