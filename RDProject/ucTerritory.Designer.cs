namespace RDProject
{
    partial class ucTerritory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMauza = new System.Windows.Forms.Label();
            this.cbxMauza = new System.Windows.Forms.ComboBox();
            this.cbxTehsil = new System.Windows.Forms.ComboBox();
            this.lblZillah = new System.Windows.Forms.Label();
            this.lblTehsil = new System.Windows.Forms.Label();
            this.cbxDistrict = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lblMauza, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxMauza, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxTehsil, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblZillah, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTehsil, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxDistrict, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1035, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblMauza
            // 
            this.lblMauza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMauza.AutoSize = true;
            this.lblMauza.Location = new System.Drawing.Point(835, 10);
            this.lblMauza.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMauza.Name = "lblMauza";
            this.lblMauza.Size = new System.Drawing.Size(53, 19);
            this.lblMauza.TabIndex = 3;
            this.lblMauza.Text = "Mauza";
            // 
            // cbxMauza
            // 
            this.cbxMauza.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxMauza.BackColor = System.Drawing.SystemColors.Window;
            this.cbxMauza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMauza.FormattingEnabled = true;
            this.cbxMauza.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxMauza.Location = new System.Drawing.Point(749, 48);
            this.cbxMauza.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cbxMauza.Name = "cbxMauza";
            this.cbxMauza.Size = new System.Drawing.Size(226, 27);
            this.cbxMauza.TabIndex = 0;
            this.cbxMauza.SelectedIndexChanged += new System.EventHandler(this.cbxMauza_SelectedIndexChanged);
            // 
            // cbxTehsil
            // 
            this.cbxTehsil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxTehsil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTehsil.FormattingEnabled = true;
            this.cbxTehsil.Location = new System.Drawing.Point(405, 48);
            this.cbxTehsil.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cbxTehsil.Name = "cbxTehsil";
            this.cbxTehsil.Size = new System.Drawing.Size(222, 27);
            this.cbxTehsil.TabIndex = 2;
            this.cbxTehsil.SelectedIndexChanged += new System.EventHandler(this.cbxTehsil_SelectedIndexChanged);
            // 
            // lblZillah
            // 
            this.lblZillah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblZillah.AutoSize = true;
            this.lblZillah.Location = new System.Drawing.Point(143, 10);
            this.lblZillah.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZillah.Name = "lblZillah";
            this.lblZillah.Size = new System.Drawing.Size(58, 19);
            this.lblZillah.TabIndex = 4;
            this.lblZillah.Text = "District";
            // 
            // lblTehsil
            // 
            this.lblTehsil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTehsil.AutoSize = true;
            this.lblTehsil.Location = new System.Drawing.Point(491, 10);
            this.lblTehsil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTehsil.Name = "lblTehsil";
            this.lblTehsil.Size = new System.Drawing.Size(51, 19);
            this.lblTehsil.TabIndex = 4;
            this.lblTehsil.Text = "Tehsil";
            // 
            // cbxDistrict
            // 
            this.cbxDistrict.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDistrict.FormattingEnabled = true;
            this.cbxDistrict.Location = new System.Drawing.Point(61, 48);
            this.cbxDistrict.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cbxDistrict.Name = "cbxDistrict";
            this.cbxDistrict.Size = new System.Drawing.Size(222, 27);
            this.cbxDistrict.TabIndex = 5;
            this.cbxDistrict.SelectedIndexChanged += new System.EventHandler(this.cbxDistrict_SelectedIndexChanged);
            // 
            // ucTerritory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucTerritory";
            this.Size = new System.Drawing.Size(1035, 100);
            this.Load += new System.EventHandler(this.ucTerritory_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbxMauza;
        private System.Windows.Forms.ComboBox cbxTehsil;
        private System.Windows.Forms.Label lblMauza;
        private System.Windows.Forms.Label lblZillah;
        private System.Windows.Forms.Label lblTehsil;
        private System.Windows.Forms.ComboBox cbxDistrict;

    }
}
