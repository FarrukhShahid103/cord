namespace RDProject.RD
{
    partial class DragImage_English
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DragImage_English));
            this.pnlDisplayImage = new System.Windows.Forms.Panel();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnpdf = new System.Windows.Forms.Button();
            this.btnEndEditMode = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cachedrdParties1 = new RDProject.Reports.CachedrdParties();
            this.pnlDisplayImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDisplayImage
            // 
            this.pnlDisplayImage.Controls.Add(this.axAcroPDF1);
            this.pnlDisplayImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayImage.Location = new System.Drawing.Point(0, 62);
            this.pnlDisplayImage.Name = "pnlDisplayImage";
            this.pnlDisplayImage.Size = new System.Drawing.Size(658, 900);
            this.pnlDisplayImage.TabIndex = 1;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(658, 900);
            this.axAcroPDF1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnpdf);
            this.panel1.Controls.Add(this.btnEndEditMode);
            this.panel1.Controls.Add(this.Button1);
            this.panel1.Controls.Add(this.ToolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 62);
            this.panel1.TabIndex = 0;
            // 
            // btnpdf
            // 
            this.btnpdf.Location = new System.Drawing.Point(491, 28);
            this.btnpdf.Name = "btnpdf";
            this.btnpdf.Size = new System.Drawing.Size(75, 23);
            this.btnpdf.TabIndex = 5;
            this.btnpdf.Text = "save pdf";
            this.btnpdf.UseVisualStyleBackColor = true;
            this.btnpdf.Click += new System.EventHandler(this.btnpdf_Click);
            // 
            // btnEndEditMode
            // 
            this.btnEndEditMode.Location = new System.Drawing.Point(120, 33);
            this.btnEndEditMode.Name = "btnEndEditMode";
            this.btnEndEditMode.Size = new System.Drawing.Size(102, 23);
            this.btnEndEditMode.TabIndex = 4;
            this.btnEndEditMode.Text = "&End edit mode";
            this.btnEndEditMode.UseVisualStyleBackColor = true;
            this.btnEndEditMode.Click += new System.EventHandler(this.btnEndEditMode_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(12, 33);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(102, 23);
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Set to Edit mode";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(658, 25);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            this.ToolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1_ItemClicked);
            // 
            // DragImage_English
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 962);
            this.Controls.Add(this.pnlDisplayImage);
            this.Controls.Add(this.panel1);
            this.Name = "DragImage_English";
            this.Text = "DragImage_English";
            this.Load += new System.EventHandler(this.DragImage_English_Load);
            this.pnlDisplayImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDisplayImage;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button btnEndEditMode;
        private System.Windows.Forms.Button btnpdf;
        private Reports.CachedrdParties cachedrdParties1;
    }
}