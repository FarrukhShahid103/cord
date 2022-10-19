namespace RDProject
{
    partial class MainURDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainURDForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.menuImages = new System.Windows.Forms.ImageList(this.components);
            this.btnRegistrationDeed = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnInbox = new System.Windows.Forms.ToolStripButton();
            this.btnSetup = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnDistrict = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTehsil = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMauza = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator = new System.Windows.Forms.ToolStripSeparator();
            this.btnCaste = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUrdu = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1029, 100);
            this.pnlMain.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.64849F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.35151F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tableLayoutPanel1.Controls.Add(this.ToolStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1029, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 572);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1029, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // ToolStrip
            // 
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegistrationDeed,
            this.btnInbox,
            this.btnSetup,
            this.btnLanguage});
            this.ToolStrip.Location = new System.Drawing.Point(506, 62);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(523, 38);
            this.ToolStrip.TabIndex = 0;
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
            // btnRegistrationDeed
            // 
            this.btnRegistrationDeed.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrationDeed.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrationDeed.Image")));
            this.btnRegistrationDeed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegistrationDeed.Name = "btnRegistrationDeed";
            this.btnRegistrationDeed.Size = new System.Drawing.Size(89, 35);
            this.btnRegistrationDeed.Text = "رجسٹریشن ڈیڈ";
            // 
            // btnInbox
            // 
            this.btnInbox.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInbox.Image = ((System.Drawing.Image)(resources.GetObject("btnInbox.Image")));
            this.btnInbox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Size = new System.Drawing.Size(66, 35);
            this.btnInbox.Text = "پیغامات";
            // 
            // btnSetup
            // 
            this.btnSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDistrict,
            this.btnTehsil,
            this.btnMauza,
            this.Separator,
            this.btnCaste});
            this.btnSetup.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnSetup.Image")));
            this.btnSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(104, 35);
            this.btnSetup.Text = "سیٹ اپ فارم";
            // 
            // btnDistrict
            // 
            this.btnDistrict.Name = "btnDistrict";
            this.btnDistrict.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.btnDistrict.Size = new System.Drawing.Size(201, 36);
            this.btnDistrict.Text = "ڈسٹرکٹ فارم";
            // 
            // btnTehsil
            // 
            this.btnTehsil.Name = "btnTehsil";
            this.btnTehsil.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.btnTehsil.Size = new System.Drawing.Size(201, 36);
            this.btnTehsil.Text = "تحصیل";
            this.btnTehsil.ToolTipText = "تحصیل";
            // 
            // btnMauza
            // 
            this.btnMauza.Name = "btnMauza";
            this.btnMauza.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.btnMauza.Size = new System.Drawing.Size(201, 36);
            this.btnMauza.Text = "موضع";
            // 
            // Separator
            // 
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(198, 6);
            // 
            // btnCaste
            // 
            this.btnCaste.Name = "btnCaste";
            this.btnCaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.btnCaste.Size = new System.Drawing.Size(201, 36);
            this.btnCaste.Text = "رشتہ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::RDProject.Properties.Resources.main_topbar1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 94);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnLanguage
            // 
            this.btnLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnglish,
            this.btnUrdu});
            this.btnLanguage.Image = ((System.Drawing.Image)(resources.GetObject("btnLanguage.Image")));
            this.btnLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(62, 35);
            this.btnLanguage.Text = "زبان";
            // 
            // btnEnglish
            // 
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(112, 36);
            this.btnEnglish.Text = "انگلش";
            // 
            // btnUrdu
            // 
            this.btnUrdu.Checked = true;
            this.btnUrdu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnUrdu.Name = "btnUrdu";
            this.btnUrdu.Size = new System.Drawing.Size(152, 36);
            this.btnUrdu.Text = "اردو";
            this.btnUrdu.Click += new System.EventHandler(this.btnUrdu_Click);
            // 
            // MainURDForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1029, 594);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "MainURDForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "کمیٹرازیشن رجسٹری ڈیڈ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainURDForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton btnRegistrationDeed;
        private System.Windows.Forms.ToolStripButton btnInbox;
        private System.Windows.Forms.ToolStripDropDownButton btnSetup;
        private System.Windows.Forms.ToolStripMenuItem btnDistrict;
        private System.Windows.Forms.ToolStripMenuItem btnTehsil;
        private System.Windows.Forms.ToolStripMenuItem btnMauza;
        private System.Windows.Forms.ToolStripSeparator Separator;
        private System.Windows.Forms.ToolStripMenuItem btnCaste;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList menuImages;
        private System.Windows.Forms.ToolStripDropDownButton btnLanguage;
        private System.Windows.Forms.ToolStripMenuItem btnEnglish;
        private System.Windows.Forms.ToolStripMenuItem btnUrdu;
    }
}