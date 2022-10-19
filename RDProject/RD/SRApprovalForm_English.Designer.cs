namespace RDProject.RD
{
    partial class SRApprovalForm_English
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SRApprovalForm_English));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.btnApproved = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.Msg = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.Msg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Picture);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnApproved);
            this.panel1.Controls.Add(this.txtRemarks);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 279);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Picture
            // 
            this.Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Picture.Location = new System.Drawing.Point(13, 13);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(120, 174);
            this.Picture.TabIndex = 19;
            this.Picture.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnClose.ImageIndex = 34;
            this.btnClose.ImageList = this.CORDImages;
            this.btnClose.Location = new System.Drawing.Point(272, 193);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(127, 53);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.CORDImages.Images.SetKeyName(33, "Mimetypes-application-pgp-keys-icon.png");
            this.CORDImages.Images.SetKeyName(34, "Button-Close-icon.png");
            // 
            // btnApproved
            // 
            this.btnApproved.FlatAppearance.BorderSize = 0;
            this.btnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproved.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnApproved.ImageIndex = 22;
            this.btnApproved.ImageList = this.CORDImages;
            this.btnApproved.Location = new System.Drawing.Point(139, 193);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(127, 53);
            this.btnApproved.TabIndex = 18;
            this.btnApproved.Text = "Approved";
            this.btnApproved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(139, 12);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(314, 175);
            this.txtRemarks.TabIndex = 17;
            // 
            // Msg
            // 
            this.Msg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg,
            this.toolStripStatusLabel1});
            this.Msg.Location = new System.Drawing.Point(0, 257);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(465, 22);
            this.Msg.TabIndex = 19;
            this.Msg.Text = "statusStrip1";
            // 
            // lblMsg
            // 
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // SRApprovalForm_English
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(465, 279);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "SRApprovalForm_English";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SRApprovalForm_English";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SRApprovalForm_English_FormClosed);
            this.Load += new System.EventHandler(this.SRApprovalForm_English_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SRApprovalForm_English_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.Msg.ResumeLayout(false);
            this.Msg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList CORDImages;
        private System.Windows.Forms.StatusStrip Msg;
        public System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox Picture;

    }
}