namespace RDProject.RD
{
    partial class ScanImages_English
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanImages_English));
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.cbxNoOfImage = new System.Windows.Forms.ComboBox();
            this.lblNoOfImage = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnScanning = new System.Windows.Forms.Button();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.grdScanningImages = new System.Windows.Forms.DataGridView();
            this.pnlTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScanningImages)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.pnlTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTabs.Controls.Add(this.cbxNoOfImage);
            this.pnlTabs.Controls.Add(this.lblNoOfImage);
            this.pnlTabs.Controls.Add(this.lblMsg);
            this.pnlTabs.Controls.Add(this.btnScanning);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(181, 565);
            this.pnlTabs.TabIndex = 2;
            // 
            // cbxNoOfImage
            // 
            this.cbxNoOfImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxNoOfImage.BackColor = System.Drawing.SystemColors.Window;
            this.cbxNoOfImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNoOfImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNoOfImage.FormattingEnabled = true;
            this.cbxNoOfImage.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25"});
            this.cbxNoOfImage.Location = new System.Drawing.Point(97, 29);
            this.cbxNoOfImage.Name = "cbxNoOfImage";
            this.cbxNoOfImage.Size = new System.Drawing.Size(76, 21);
            this.cbxNoOfImage.TabIndex = 70;
            this.cbxNoOfImage.SelectedIndexChanged += new System.EventHandler(this.cbxNoOfImage_SelectedIndexChanged);
            // 
            // lblNoOfImage
            // 
            this.lblNoOfImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNoOfImage.AutoSize = true;
            this.lblNoOfImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfImage.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNoOfImage.Location = new System.Drawing.Point(14, 32);
            this.lblNoOfImage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNoOfImage.Name = "lblNoOfImage";
            this.lblNoOfImage.Size = new System.Drawing.Size(74, 13);
            this.lblNoOfImage.TabIndex = 69;
            this.lblNoOfImage.Text = "No. of Image:";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMsg.Location = new System.Drawing.Point(179, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lblMsg.Size = new System.Drawing.Size(0, 37);
            this.lblMsg.TabIndex = 6;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnScanning
            // 
            this.btnScanning.FlatAppearance.BorderSize = 0;
            this.btnScanning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanning.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanning.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnScanning.ImageIndex = 32;
            this.btnScanning.ImageList = this.CORDImages;
            this.btnScanning.Location = new System.Drawing.Point(17, 499);
            this.btnScanning.Name = "btnScanning";
            this.btnScanning.Size = new System.Drawing.Size(138, 53);
            this.btnScanning.TabIndex = 0;
            this.btnScanning.Text = "New Scanning";
            this.btnScanning.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnScanning.UseVisualStyleBackColor = true;
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
            // grdScanningImages
            // 
            this.grdScanningImages.AllowUserToAddRows = false;
            this.grdScanningImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdScanningImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdScanningImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdScanningImages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.grdScanningImages.Location = new System.Drawing.Point(181, 0);
            this.grdScanningImages.Name = "grdScanningImages";
            this.grdScanningImages.RowHeadersVisible = false;
            this.grdScanningImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdScanningImages.Size = new System.Drawing.Size(421, 565);
            this.grdScanningImages.TabIndex = 15;
            this.grdScanningImages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdScanningImages_CellDoubleClick);
            // 
            // ScanImages_English
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(602, 565);
            this.Controls.Add(this.grdScanningImages);
            this.Controls.Add(this.pnlTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScanImages_English";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScanImages_English";
            this.Load += new System.EventHandler(this.ScanImages_English_Load);
            this.pnlTabs.ResumeLayout(false);
            this.pnlTabs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScanningImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnScanning;
        private System.Windows.Forms.ImageList CORDImages;
        private System.Windows.Forms.DataGridView grdScanningImages;
        private System.Windows.Forms.Label lblNoOfImage;
        private System.Windows.Forms.ComboBox cbxNoOfImage;
    }
}