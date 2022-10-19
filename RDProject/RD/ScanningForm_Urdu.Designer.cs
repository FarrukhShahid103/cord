namespace RDProject.RD
{
    partial class ScanningForm_Urdu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanningForm_Urdu));
            this.Msg = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.Msg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // Msg
            // 
            this.Msg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg});
            this.Msg.Location = new System.Drawing.Point(0, 664);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(884, 22);
            this.Msg.TabIndex = 7;
            this.Msg.Text = "statusStrip1";
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Nafees Nastaleeq", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(884, 664);
            this.axAcroPDF1.TabIndex = 9;
            // 
            // ScanningForm_Urdu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 686);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.Msg);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "ScanningForm_Urdu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "سکیننگ";
            this.Load += new System.EventHandler(this.ScanningForm_Urdu_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScanningForm_Urdu_KeyPress);
            this.Msg.ResumeLayout(false);
            this.Msg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip Msg;
        private System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
    }
}