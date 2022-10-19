namespace RDProject.Setup
{
    partial class CreateRegistryTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRegistryTypeForm));
            this.Msg = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlCast = new System.Windows.Forms.Panel();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.lblCaptionEng = new System.Windows.Forms.Label();
            this.grdRegistryType = new System.Windows.Forms.DataGridView();
            this.col_RegistryTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RegistryTypeName_Eng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RegistryTypeName_Urd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.Msg.SuspendLayout();
            this.pnlCast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRegistryType)).BeginInit();
            this.SuspendLayout();
            // 
            // Msg
            // 
            this.Msg.BackColor = System.Drawing.SystemColors.Info;
            this.Msg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.Msg.Location = new System.Drawing.Point(0, 356);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(649, 22);
            this.Msg.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 17);
            this.lblStatus.Text = "Record Saved";
            // 
            // pnlCast
            // 
            this.pnlCast.BackColor = System.Drawing.SystemColors.Window;
            this.pnlCast.Controls.Add(this.btnDeleteRecord);
            this.pnlCast.Controls.Add(this.btnAddRecord);
            this.pnlCast.Controls.Add(this.lblCaptionEng);
            this.pnlCast.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCast.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCast.Location = new System.Drawing.Point(0, 0);
            this.pnlCast.Name = "pnlCast";
            this.pnlCast.Size = new System.Drawing.Size(649, 60);
            this.pnlCast.TabIndex = 5;
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
            this.btnDeleteRecord.Location = new System.Drawing.Point(507, 0);
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
            this.lblCaptionEng.Location = new System.Drawing.Point(192, 14);
            this.lblCaptionEng.Name = "lblCaptionEng";
            this.lblCaptionEng.Size = new System.Drawing.Size(254, 31);
            this.lblCaptionEng.TabIndex = 2;
            this.lblCaptionEng.Text = "Registry Type ( قسم رجسٹری ) Form";
            // 
            // grdRegistryType
            // 
            this.grdRegistryType.AllowUserToAddRows = false;
            this.grdRegistryType.AllowUserToDeleteRows = false;
            this.grdRegistryType.AllowUserToResizeColumns = false;
            this.grdRegistryType.AllowUserToResizeRows = false;
            this.grdRegistryType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdRegistryType.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.grdRegistryType.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grdRegistryType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdRegistryType.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRegistryType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdRegistryType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRegistryType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_RegistryTypeID,
            this.col_RegistryTypeName_Eng,
            this.col_RegistryTypeName_Urd});
            this.grdRegistryType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRegistryType.EnableHeadersVisualStyles = false;
            this.grdRegistryType.GridColor = System.Drawing.Color.Black;
            this.grdRegistryType.Location = new System.Drawing.Point(0, 60);
            this.grdRegistryType.MultiSelect = false;
            this.grdRegistryType.Name = "grdRegistryType";
            this.grdRegistryType.RowHeadersVisible = false;
            this.grdRegistryType.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdRegistryType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdRegistryType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdRegistryType.Size = new System.Drawing.Size(649, 296);
            this.grdRegistryType.StandardTab = true;
            this.grdRegistryType.TabIndex = 6;
            this.grdRegistryType.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdRegistryType_RowValidating);
            this.grdRegistryType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdRegistryType_KeyDown);
            // 
            // col_RegistryTypeID
            // 
            this.col_RegistryTypeID.HeaderText = "RegistryTypeID";
            this.col_RegistryTypeID.Name = "col_RegistryTypeID";
            this.col_RegistryTypeID.Visible = false;
            // 
            // col_RegistryTypeName_Eng
            // 
            this.col_RegistryTypeName_Eng.HeaderText = "Registry Type Name";
            this.col_RegistryTypeName_Eng.MinimumWidth = 150;
            this.col_RegistryTypeName_Eng.Name = "col_RegistryTypeName_Eng";
            // 
            // col_RegistryTypeName_Urd
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nafees Nastaleeq", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_RegistryTypeName_Urd.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_RegistryTypeName_Urd.HeaderText = "نام قسم رجسٹری";
            this.col_RegistryTypeName_Urd.MinimumWidth = 150;
            this.col_RegistryTypeName_Urd.Name = "col_RegistryTypeName_Urd";
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
            // CreateRegistryTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 378);
            this.Controls.Add(this.grdRegistryType);
            this.Controls.Add(this.pnlCast);
            this.Controls.Add(this.Msg);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "CreateRegistryTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registry Type Form";
            this.Load += new System.EventHandler(this.CreateRegistryTypeForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CreateRegistryTypeForm_KeyPress);
            this.Msg.ResumeLayout(false);
            this.Msg.PerformLayout();
            this.pnlCast.ResumeLayout(false);
            this.pnlCast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRegistryType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip Msg;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel pnlCast;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Label lblCaptionEng;
        private System.Windows.Forms.DataGridView grdRegistryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RegistryTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RegistryTypeName_Eng;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RegistryTypeName_Urd;
        private System.Windows.Forms.ImageList CORDImages;
    }
}