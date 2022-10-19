namespace RDProject
{
    partial class AcceptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcceptForm));
            this.radTitleBar = new Telerik.WinControls.UI.RadTitleBar();
            this.roundRectShapeTitle = new Telerik.WinControls.RoundRectShape(this.components);
            this.roundRectShapeForm = new Telerik.WinControls.RoundRectShape(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.radPanel = new Telerik.WinControls.UI.RadPanel();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.menuImages = new System.Windows.Forms.ImageList(this.components);
            this.btnVerify = new Telerik.WinControls.UI.RadButton();
            this.desertTheme = new Telerik.WinControls.Themes.DesertTheme();
            this.txtremarks = new Telerik.WinControls.UI.RadTextBox();
            this.lblRemarks = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel)).BeginInit();
            this.radPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRemarks)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar
            // 
            this.radTitleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radTitleBar.Location = new System.Drawing.Point(1, 1);
            this.radTitleBar.Name = "radTitleBar";
            // 
            // 
            // 
            this.radTitleBar.RootElement.ApplyShapeToControl = true;
            this.radTitleBar.RootElement.Shape = this.roundRectShapeTitle;
            this.radTitleBar.Size = new System.Drawing.Size(429, 23);
            this.radTitleBar.TabIndex = 0;
            this.radTitleBar.TabStop = false;
            this.radTitleBar.Text = "AcceptForm";
            // 
            // roundRectShapeTitle
            // 
            this.roundRectShapeTitle.BottomLeftRounded = false;
            this.roundRectShapeTitle.BottomRightRounded = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Image = global::RDProject.Properties.Resources.index;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(431, 146);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // radPanel
            // 
            this.radPanel.Controls.Add(this.btnClose);
            this.radPanel.Controls.Add(this.btnVerify);
            this.radPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel.Location = new System.Drawing.Point(0, 255);
            this.radPanel.Name = "radPanel";
            this.radPanel.Size = new System.Drawing.Size(431, 53);
            this.radPanel.TabIndex = 2;
            this.radPanel.ThemeName = "Desert";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Font = new System.Drawing.Font("Nafees Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnClose.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.ImageIndex = 20;
            this.btnClose.ImageList = this.menuImages;
            this.btnClose.Location = new System.Drawing.Point(350, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 39);
            this.btnClose.TabIndex = 40;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "بند کریں";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.Visible = false;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).ImageIndex = 20;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClose.GetChildAt(0))).Text = "بند کریں";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnClose.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // menuImages
            // 
            this.menuImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuImages.ImageStream")));
            this.menuImages.TransparentColor = System.Drawing.Color.Lime;
            this.menuImages.Images.SetKeyName(0, "1_New.gif");
            this.menuImages.Images.SetKeyName(1, "2_Open.gif");
            this.menuImages.Images.SetKeyName(2, "3_Save.gif");
            this.menuImages.Images.SetKeyName(3, "4_Save_As.gif");
            this.menuImages.Images.SetKeyName(4, "5_Print.gif");
            this.menuImages.Images.SetKeyName(5, "6_Prepare.gif");
            this.menuImages.Images.SetKeyName(6, "7_Send.gif");
            this.menuImages.Images.SetKeyName(7, "8_Publish.gif");
            this.menuImages.Images.SetKeyName(8, "9_Close.gif");
            this.menuImages.Images.SetKeyName(9, "1_Word_Document.gif");
            this.menuImages.Images.SetKeyName(10, "2_Word_Template.gif");
            this.menuImages.Images.SetKeyName(11, "3_Word_97.gif");
            this.menuImages.Images.SetKeyName(12, "4_Find_Addins.gif");
            this.menuImages.Images.SetKeyName(13, "5_Other_Formats.gif");
            this.menuImages.Images.SetKeyName(14, "1_Print.gif");
            this.menuImages.Images.SetKeyName(15, "2_Quick_Print.gif");
            this.menuImages.Images.SetKeyName(16, "3_Print_Preview.gif");
            this.menuImages.Images.SetKeyName(17, "1_Properties.gif");
            this.menuImages.Images.SetKeyName(18, "2_Inspect-Document.gif");
            this.menuImages.Images.SetKeyName(19, "3_Encrypt_Document.gif");
            this.menuImages.Images.SetKeyName(20, "4_Restrict_Permission.gif");
            this.menuImages.Images.SetKeyName(21, "5_Add_a_digital_signature.gif");
            this.menuImages.Images.SetKeyName(22, "6_Mark_As_Final.gif");
            this.menuImages.Images.SetKeyName(23, "7_Run_Compatibility_Checker.gif");
            this.menuImages.Images.SetKeyName(24, "1_E-mail.gif");
            this.menuImages.Images.SetKeyName(25, "2_Internet_Fax.gif");
            this.menuImages.Images.SetKeyName(26, "1_Blog.gif");
            this.menuImages.Images.SetKeyName(27, "2-Document_Management.gif");
            this.menuImages.Images.SetKeyName(28, "3_Create_Document_Workspace.gif");
            this.menuImages.Images.SetKeyName(29, "buttonDelete.png");
            this.menuImages.Images.SetKeyName(30, "buttonNew.png");
            this.menuImages.Images.SetKeyName(31, "Device-tablet-icon.png");
            this.menuImages.Images.SetKeyName(32, "System-scanner-icon.png");
            // 
            // btnVerify
            // 
            this.btnVerify.AutoSize = true;
            this.btnVerify.BackColor = System.Drawing.Color.Transparent;
            this.btnVerify.Font = new System.Drawing.Font("Nafees Nastaleeq", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnVerify.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerify.ImageIndex = 22;
            this.btnVerify.ImageList = this.menuImages;
            this.btnVerify.Location = new System.Drawing.Point(156, 6);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(102, 39);
            this.btnVerify.TabIndex = 38;
            this.btnVerify.TabStop = false;
            this.btnVerify.Text = "تصد یق کریں";
            this.btnVerify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerify.ThemeName = "Desert";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnVerify.GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnVerify.GetChildAt(0))).ImageIndex = 22;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnVerify.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnVerify.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnVerify.GetChildAt(0))).Text = "تصد یق کریں";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnVerify.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnVerify.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnVerify.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnVerify.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnVerify.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnVerify.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnVerify.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // txtremarks
            // 
            this.txtremarks.AutoSize = false;
            this.txtremarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtremarks.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremarks.Location = new System.Drawing.Point(0, 146);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtremarks.Size = new System.Drawing.Size(390, 109);
            this.txtremarks.TabIndex = 32;
            this.txtremarks.TabStop = false;
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.Color.Transparent;
            this.lblRemarks.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRemarks.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblRemarks.Location = new System.Drawing.Point(390, 146);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRemarks.Size = new System.Drawing.Size(41, 33);
            this.lblRemarks.TabIndex = 33;
            this.lblRemarks.Text = "ریمارکس :";
            this.lblRemarks.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lblRemarks.ThemeName = "RadLabelTheme";
            // 
            // AcceptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(431, 308);
            this.Controls.Add(this.txtremarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.radPanel);
            this.Controls.Add(this.radTitleBar);
            this.DoubleBuffered = true;
            this.Name = "AcceptForm";
            this.Shape = this.roundRectShapeForm;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AcceptForm";
            this.ThemeName = "Desert";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AcceptForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel)).EndInit();
            this.radPanel.ResumeLayout(false);
            this.radPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRemarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar;
        private Telerik.WinControls.RoundRectShape roundRectShapeForm;
        private Telerik.WinControls.RoundRectShape roundRectShapeTitle;
        private System.Windows.Forms.PictureBox pictureBox;
        private Telerik.WinControls.UI.RadPanel radPanel;
        private Telerik.WinControls.UI.RadButton btnVerify;
        private Telerik.WinControls.Themes.DesertTheme desertTheme;
        private System.Windows.Forms.ImageList menuImages;
        public Telerik.WinControls.UI.RadButton btnClose;
        public Telerik.WinControls.UI.RadTextBox txtremarks;
        public Telerik.WinControls.UI.RadLabel lblRemarks;
    }
}
