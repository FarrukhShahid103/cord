namespace RDProject
{
    partial class Inbox
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.grdPerson = new Telerik.WinControls.UI.RadGridView();
            this.officeShape1 = new Telerik.WinControls.UI.OfficeShape();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(1067, 731);
            this.radSplitContainer1.SplitterWidth = 4;
            this.radSplitContainer1.TabIndex = 44;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.grdPerson);
            this.splitPanel2.Location = new System.Drawing.Point(0, 0);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(1067, 731);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            // 
            // grdPerson
            // 
            this.grdPerson.AutoSizeRows = true;
            this.grdPerson.BackColor = System.Drawing.Color.Transparent;
            this.grdPerson.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPerson.EnableKeyMap = true;
            this.grdPerson.Font = new System.Drawing.Font("Nafees Nastaleeq", 9.75F);
            this.grdPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(143)))), ((int)(((byte)(160)))));
            this.grdPerson.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdPerson.Location = new System.Drawing.Point(0, 0);
            // 
            // grdPerson
            // 
            this.grdPerson.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.grdPerson.MasterTemplate.AllowAddNewRow = false;
            this.grdPerson.MasterTemplate.AllowColumnChooser = false;
            this.grdPerson.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.grdPerson.MasterTemplate.AllowColumnReorder = false;
            this.grdPerson.MasterTemplate.AllowColumnResize = false;
            this.grdPerson.MasterTemplate.AllowDeleteRow = false;
            this.grdPerson.MasterTemplate.AllowDragToGroup = false;
            this.grdPerson.MasterTemplate.AllowRowResize = false;
            this.grdPerson.MasterTemplate.AutoGenerateColumns = false;
            this.grdPerson.MasterTemplate.Caption = "Products";
            gridViewDateTimeColumn1.FieldName = "registry_decision_date";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            gridViewDateTimeColumn1.HeaderText = "تاریخ";
            gridViewDateTimeColumn1.Name = "colDate";
            gridViewDateTimeColumn1.Width = 150;
            gridViewComboBoxColumn1.AllowGroup = false;
            gridViewComboBoxColumn1.AllowSort = false;
            gridViewComboBoxColumn1.DisplayMember = "";
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "registry_no";
            gridViewComboBoxColumn1.HeaderText = "رجسٹری نمبر";
            gridViewComboBoxColumn1.Name = "colRegistyno";
            gridViewComboBoxColumn1.Width = 200;
            gridViewCheckBoxColumn1.FieldName = "registery_stage";
            gridViewCheckBoxColumn1.HeaderText = "منور شدی";
            gridViewCheckBoxColumn1.Name = "column2";
            gridViewCommandColumn1.DefaultText = "تفصیل";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Name = "column1";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 150;
            gridViewTextBoxColumn1.FieldName = "reg_status";
            gridViewTextBoxColumn1.HeaderText = "سٹیٹس";
            gridViewTextBoxColumn1.Name = "colStatus۱";
            gridViewTextBoxColumn1.Width = 200;
            gridViewTextBoxColumn2.FieldName = "remarks";
            gridViewTextBoxColumn2.HeaderText = "ریمارکس";
            gridViewTextBoxColumn2.Name = "colRemarks";
            gridViewTextBoxColumn2.Width = 300;
            this.grdPerson.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDateTimeColumn1,
            gridViewComboBoxColumn1,
            gridViewCheckBoxColumn1,
            gridViewCommandColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.grdPerson.MasterTemplate.EnableGrouping = false;
            this.grdPerson.MasterTemplate.EnableSorting = false;
            sortDescriptor1.PropertyName = "colName";
            this.grdPerson.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.grdPerson.Name = "grdPerson";
            this.grdPerson.Padding = new System.Windows.Forms.Padding(1);
            this.grdPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.grdPerson.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.grdPerson.ShowGroupPanel = false;
            this.grdPerson.Size = new System.Drawing.Size(1067, 731);
            this.grdPerson.TabIndex = 44;
            this.grdPerson.TabStop = false;
            this.grdPerson.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.grdPerson_CommandCellClick);
            // 
            // Inbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(90)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(1067, 731);
            this.Controls.Add(this.radSplitContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nafees Nastaleeq", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inbox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Shape = this.officeShape1;
            this.Text = "پیغامات";
            this.ThemeName = "ControlDefault";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inbox_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Inbox_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadGridView grdPerson;
        private Telerik.WinControls.UI.OfficeShape officeShape1;
    }
}
