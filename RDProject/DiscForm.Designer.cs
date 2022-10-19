namespace RDProject
{
    partial class DiscForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblDocumentNumber = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.menuImages = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocumentNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::RDProject.Properties.Resources.disc;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(232, 303);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblDocumentNumber.Font = new System.Drawing.Font("Nafees Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblDocumentNumber.Location = new System.Drawing.Point(317, 114);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDocumentNumber.Size = new System.Drawing.Size(119, 41);
            this.lblDocumentNumber.TabIndex = 68;
            this.lblDocumentNumber.Text = "رجسٹری سکین کر لی ھے";
            this.lblDocumentNumber.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lblDocumentNumber.ThemeName = "RadLabelTheme";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Nafees Nastaleeq", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.radLabel1.Location = new System.Drawing.Point(303, 161);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radLabel1.Size = new System.Drawing.Size(133, 41);
            this.radLabel1.TabIndex = 69;
            this.radLabel1.Text = " رجسٹری بر مہر لگا دی ھے۔";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel1.ThemeName = "RadLabelTheme";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.Red;
            this.radLabel2.Location = new System.Drawing.Point(317, 30);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radLabel2.Size = new System.Drawing.Size(119, 27);
            this.radLabel2.TabIndex = 70;
            this.radLabel2.Text = "DISCLAIMER";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabel2.ThemeName = "RadLabelTheme";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.ImageIndex = 30;
            this.btnSave.ImageList = this.menuImages;
            this.btnSave.Location = new System.Drawing.Point(345, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 36);
            this.btnSave.TabIndex = 71;
            this.btnSave.Text = "OK";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).ImageIndex = 30;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "OK";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
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
            // DiscForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 275);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblDocumentNumber);
            this.Controls.Add(this.pictureBox);
            this.Name = "DiscForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiscForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocumentNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private Telerik.WinControls.UI.RadLabel lblDocumentNumber;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.ImageList menuImages;
    }
}
