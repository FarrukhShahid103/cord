namespace RDProject.RD
{
    partial class Person_Urdu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Person_Urdu));
            this.Msg = new System.Windows.Forms.StatusStrip();
            this.pnlPersons = new System.Windows.Forms.Panel();
            this.lblPersons = new System.Windows.Forms.Label();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.pbPerson = new System.Windows.Forms.PictureBox();            
            this.cbBuyerSeller = new System.Windows.Forms.ComboBox();
            this.cbCaste = new System.Windows.Forms.ComboBox();
            this.txtCNIC = new System.Windows.Forms.MaskedTextBox();
            this.lstAddress = new System.Windows.Forms.ListBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblBuyerSeller = new System.Windows.Forms.Label();
            this.lblCaste = new System.Windows.Forms.Label();
            this.lblCNIC = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.chkBlock = new System.Windows.Forms.CheckBox();
            this.chkDepartment = new System.Windows.Forms.CheckBox();
            this.chkGovt = new System.Windows.Forms.CheckBox();
            this.grdPersons = new System.Windows.Forms.DataGridView();
            this.pnlPersons.SuspendLayout();
            this.pnlFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerson)).BeginInit(); 
            ((System.ComponentModel.ISupportInitialize)(this.grdPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // Msg
            // 
            this.Msg.Font = new System.Drawing.Font("Nafees Nastaleeq", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg.Location = new System.Drawing.Point(0, 686);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(743, 22);
            this.Msg.TabIndex = 9;
            this.Msg.Text = "statusStrip1";
            // 
            // pnlPersons
            // 
            this.pnlPersons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.pnlPersons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPersons.Controls.Add(this.lblPersons);
            this.pnlPersons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPersons.Location = new System.Drawing.Point(0, 0);
            this.pnlPersons.Name = "pnlPersons";
            this.pnlPersons.Size = new System.Drawing.Size(743, 55);
            this.pnlPersons.TabIndex = 10;
            // 
            // lblPersons
            // 
            this.lblPersons.AutoSize = true;
            this.lblPersons.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPersons.Font = new System.Drawing.Font("Nafees Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersons.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPersons.Location = new System.Drawing.Point(474, 0);
            this.lblPersons.Name = "lblPersons";
            this.lblPersons.Size = new System.Drawing.Size(267, 45);
            this.lblPersons.TabIndex = 1;
            this.lblPersons.Text = "خریدار / بیچنے والے کے بارے میں معلومات";
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
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnDelete.ImageIndex = 29;
            this.btnDelete.ImageList = this.CORDImages;
            this.btnDelete.Location = new System.Drawing.Point(467, 357);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 53);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "خارج کریں";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.CORDImages;
            this.btnSave.Location = new System.Drawing.Point(573, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 53);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "محفوظ کریں";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // pnlFields
            // 
            this.pnlFields.AutoSize = true;
            this.pnlFields.BackColor = System.Drawing.Color.White;
            this.pnlFields.Controls.Add(this.btnDelete);
            this.pnlFields.Controls.Add(this.pbPerson);
            this.pnlFields.Controls.Add(this.btnSave);
            //this.pnlFields.Controls.Add(this.cbBuyerSeller);
            this.pnlFields.Controls.Add(this.cbCaste);
            this.pnlFields.Controls.Add(this.txtCNIC);
            this.pnlFields.Controls.Add(this.lstAddress);
            this.pnlFields.Controls.Add(this.txtLastName);
            this.pnlFields.Controls.Add(this.lblBuyerSeller);
            this.pnlFields.Controls.Add(this.lblCaste);
            this.pnlFields.Controls.Add(this.lblCNIC);
            this.pnlFields.Controls.Add(this.lblAddress);
            this.pnlFields.Controls.Add(this.lblLastName);
            this.pnlFields.Controls.Add(this.txtFirstName);
            this.pnlFields.Controls.Add(this.lblFirstName);
            this.pnlFields.Controls.Add(this.chkBlock);
            this.pnlFields.Controls.Add(this.chkDepartment);
            this.pnlFields.Controls.Add(this.chkGovt);
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFields.Location = new System.Drawing.Point(0, 55);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(743, 413);
            this.pnlFields.TabIndex = 11;
            // 
            // pbPerson
            // 
            this.pbPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPerson.Location = new System.Drawing.Point(164, 19);
            this.pbPerson.Name = "pbPerson";
            this.pbPerson.Size = new System.Drawing.Size(179, 149);
            this.pbPerson.TabIndex = 105;
            this.pbPerson.TabStop = false;
            // 
            // FingerPrint
            // 
          
            // 
            // cbBuyerSeller
            // 
            this.cbBuyerSeller.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbBuyerSeller.BackColor = System.Drawing.SystemColors.Window;
            this.cbBuyerSeller.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbBuyerSeller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuyerSeller.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBuyerSeller.FormattingEnabled = true;
            this.cbBuyerSeller.Location = new System.Drawing.Point(475, 193);
            this.cbBuyerSeller.Name = "cbBuyerSeller";
            this.cbBuyerSeller.Size = new System.Drawing.Size(170, 38);
            this.cbBuyerSeller.TabIndex = 97;
            // 
            // cbCaste
            // 
            this.cbCaste.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbCaste.BackColor = System.Drawing.SystemColors.Window;
            this.cbCaste.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbCaste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaste.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCaste.FormattingEnabled = true;
            this.cbCaste.Location = new System.Drawing.Point(475, 148);
            this.cbCaste.Name = "cbCaste";
            this.cbCaste.Size = new System.Drawing.Size(170, 38);
            this.cbCaste.TabIndex = 96;
            // 
            // txtCNIC
            // 
            this.txtCNIC.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCNIC.Location = new System.Drawing.Point(475, 105);
            this.txtCNIC.Mask = "00000-0000000-0";
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(170, 37);
            this.txtCNIC.TabIndex = 95;
            // 
            // lstAddress
            // 
            this.lstAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstAddress.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAddress.FormattingEnabled = true;
            this.lstAddress.ItemHeight = 31;
            this.lstAddress.Location = new System.Drawing.Point(347, 238);
            this.lstAddress.Name = "lstAddress";
            this.lstAddress.Size = new System.Drawing.Size(298, 95);
            this.lstAddress.TabIndex = 94;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLastName.BackColor = System.Drawing.SystemColors.Window;
            this.txtLastName.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(474, 62);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(171, 37);
            this.txtLastName.TabIndex = 93;
            // 
            // lblBuyerSeller
            // 
            this.lblBuyerSeller.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBuyerSeller.AutoSize = true;
            this.lblBuyerSeller.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerSeller.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblBuyerSeller.Location = new System.Drawing.Point(663, 197);
            this.lblBuyerSeller.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBuyerSeller.Name = "lblBuyerSeller";
            this.lblBuyerSeller.Size = new System.Drawing.Size(65, 31);
            this.lblBuyerSeller.TabIndex = 98;
            this.lblBuyerSeller.Text = "بایع ۔ مشتری";
            // 
            // lblCaste
            // 
            this.lblCaste.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaste.AutoSize = true;
            this.lblCaste.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaste.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCaste.Location = new System.Drawing.Point(687, 152);
            this.lblCaste.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCaste.Name = "lblCaste";
            this.lblCaste.Size = new System.Drawing.Size(41, 31);
            this.lblCaste.TabIndex = 99;
            this.lblCaste.Text = "ذات :";
            // 
            // lblCNIC
            // 
            this.lblCNIC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCNIC.AutoSize = true;
            this.lblCNIC.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNIC.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCNIC.Location = new System.Drawing.Point(655, 108);
            this.lblCNIC.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCNIC.Name = "lblCNIC";
            this.lblCNIC.Size = new System.Drawing.Size(73, 31);
            this.lblCNIC.TabIndex = 100;
            this.lblCNIC.Text = "شناختی کارڈ نمبر :";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAddress.Location = new System.Drawing.Point(676, 270);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(52, 31);
            this.lblAddress.TabIndex = 101;
            this.lblAddress.Text = "مکمل پتہ :";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblLastName.Location = new System.Drawing.Point(680, 65);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(48, 31);
            this.lblLastName.TabIndex = 102;
            this.lblLastName.Text = "ولدیت :";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFirstName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFirstName.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(475, 19);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(170, 37);
            this.txtFirstName.TabIndex = 92;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblFirstName.Location = new System.Drawing.Point(696, 22);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(32, 31);
            this.lblFirstName.TabIndex = 103;
            this.lblFirstName.Text = "نام :";
            // 
            // chkBlock
            // 
            this.chkBlock.AutoSize = true;
            this.chkBlock.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBlock.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkBlock.Location = new System.Drawing.Point(164, 174);
            this.chkBlock.Name = "chkBlock";
            this.chkBlock.Size = new System.Drawing.Size(52, 35);
            this.chkBlock.TabIndex = 83;
            this.chkBlock.Text = "بلاک";
            this.chkBlock.UseVisualStyleBackColor = true;
            // 
            // chkDepartment
            // 
            this.chkDepartment.AutoSize = true;
            this.chkDepartment.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDepartment.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkDepartment.Location = new System.Drawing.Point(222, 174);
            this.chkDepartment.Name = "chkDepartment";
            this.chkDepartment.Size = new System.Drawing.Size(53, 35);
            this.chkDepartment.TabIndex = 82;
            this.chkDepartment.Text = "محکمہ";
            this.chkDepartment.UseVisualStyleBackColor = true;
            // 
            // chkGovt
            // 
            this.chkGovt.AutoSize = true;
            this.chkGovt.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGovt.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkGovt.Location = new System.Drawing.Point(281, 174);
            this.chkGovt.Name = "chkGovt";
            this.chkGovt.Size = new System.Drawing.Size(62, 35);
            this.chkGovt.TabIndex = 81;
            this.chkGovt.Text = "حکومت";
            this.chkGovt.UseVisualStyleBackColor = true;
            // 
            // grdPersons
            // 
            this.grdPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPersons.Location = new System.Drawing.Point(0, 468);
            this.grdPersons.Name = "grdPersons";
            this.grdPersons.Size = new System.Drawing.Size(743, 218);
            this.grdPersons.TabIndex = 13;
            // 
            // Person_Urdu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(743, 708);
            this.Controls.Add(this.grdPersons);
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.pnlPersons);
            this.Controls.Add(this.Msg);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nafees Nastaleeq", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Person_Urdu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "بایع مشتری";
            this.pnlPersons.ResumeLayout(false);
            this.pnlPersons.PerformLayout();
            this.pnlFields.ResumeLayout(false);
            this.pnlFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip Msg;
        private System.Windows.Forms.Panel pnlPersons;
        private System.Windows.Forms.Label lblPersons;
        private System.Windows.Forms.ImageList CORDImages;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.CheckBox chkBlock;
        private System.Windows.Forms.CheckBox chkDepartment;
        private System.Windows.Forms.CheckBox chkGovt;
        private System.Windows.Forms.DataGridView grdPersons;
        private System.Windows.Forms.PictureBox pbPerson;        
        private System.Windows.Forms.ComboBox cbBuyerSeller;
        private System.Windows.Forms.ComboBox cbCaste;
        private System.Windows.Forms.MaskedTextBox txtCNIC;
        private System.Windows.Forms.ListBox lstAddress;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblBuyerSeller;
        private System.Windows.Forms.Label lblCaste;
        private System.Windows.Forms.Label lblCNIC;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
    }
}