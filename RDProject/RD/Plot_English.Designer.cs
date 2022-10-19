namespace RDProject.RD
{
    partial class Plot_English
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plot_English));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new System.Windows.Forms.Button();
            this.CORDImages = new System.Windows.Forms.ImageList(this.components);
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlCommands = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.txtKhasraNo = new System.Windows.Forms.TextBox();
            this.lblKhasraNo = new System.Windows.Forms.Label();
            this.txtPlotNo = new System.Windows.Forms.TextBox();
            this.lblplotNo = new System.Windows.Forms.Label();
            this.txtSouth = new System.Windows.Forms.TextBox();
            this.txtNorth = new System.Windows.Forms.TextBox();
            this.txtWest = new System.Windows.Forms.TextBox();
            this.lblHiddenPlotId = new System.Windows.Forms.Label();
            this.lblSouth = new System.Windows.Forms.Label();
            this.txtEast = new System.Windows.Forms.TextBox();
            this.lblNorth = new System.Windows.Forms.Label();
            this.lblWest = new System.Windows.Forms.Label();
            this.lblEast = new System.Windows.Forms.Label();
            this.pnlAreaTransfer = new System.Windows.Forms.Panel();
            this.lblPlotDimensionsDetail = new System.Windows.Forms.Label();
            this.Msg = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdPlot = new System.Windows.Forms.DataGridView();
            this.PlotIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlotNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EastCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WestCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NorthCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SouthCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhasraNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLeft.SuspendLayout();
            this.pnlCommands.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.pnlAreaTransfer.SuspendLayout();
            this.Msg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnDelete.ImageIndex = 29;
            this.btnDelete.ImageList = this.CORDImages;
            this.btnDelete.Location = new System.Drawing.Point(181, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 53);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.pnlCommands);
            this.pnlLeft.Controls.Add(this.pnlFields);
            this.pnlLeft.Controls.Add(this.pnlAreaTransfer);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(283, 512);
            this.pnlLeft.TabIndex = 67;
            // 
            // pnlCommands
            // 
            this.pnlCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommands.Controls.Add(this.btnDelete);
            this.pnlCommands.Controls.Add(this.btnSave);
            this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommands.Location = new System.Drawing.Point(0, 457);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Size = new System.Drawing.Size(283, 55);
            this.pnlCommands.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.CORDImages;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 53);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlFields
            // 
            this.pnlFields.Controls.Add(this.txtKhasraNo);
            this.pnlFields.Controls.Add(this.lblKhasraNo);
            this.pnlFields.Controls.Add(this.txtPlotNo);
            this.pnlFields.Controls.Add(this.lblplotNo);
            this.pnlFields.Controls.Add(this.txtSouth);
            this.pnlFields.Controls.Add(this.txtNorth);
            this.pnlFields.Controls.Add(this.txtWest);
            this.pnlFields.Controls.Add(this.lblHiddenPlotId);
            this.pnlFields.Controls.Add(this.lblSouth);
            this.pnlFields.Controls.Add(this.txtEast);
            this.pnlFields.Controls.Add(this.lblNorth);
            this.pnlFields.Controls.Add(this.lblWest);
            this.pnlFields.Controls.Add(this.lblEast);
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFields.Location = new System.Drawing.Point(0, 55);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(283, 337);
            this.pnlFields.TabIndex = 6;
            // 
            // txtKhasraNo
            // 
            this.txtKhasraNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtKhasraNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtKhasraNo.Location = new System.Drawing.Point(96, 293);
            this.txtKhasraNo.Name = "txtKhasraNo";
            this.txtKhasraNo.Size = new System.Drawing.Size(168, 27);
            this.txtKhasraNo.TabIndex = 5;
            // 
            // lblKhasraNo
            // 
            this.lblKhasraNo.AutoSize = true;
            this.lblKhasraNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhasraNo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblKhasraNo.Location = new System.Drawing.Point(29, 294);
            this.lblKhasraNo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblKhasraNo.Name = "lblKhasraNo";
            this.lblKhasraNo.Size = new System.Drawing.Size(63, 13);
            this.lblKhasraNo.TabIndex = 54;
            this.lblKhasraNo.Text = "Khasra No :";
            // 
            // txtPlotNo
            // 
            this.txtPlotNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtPlotNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPlotNo.Location = new System.Drawing.Point(96, 8);
            this.txtPlotNo.Name = "txtPlotNo";
            this.txtPlotNo.Size = new System.Drawing.Size(168, 27);
            this.txtPlotNo.TabIndex = 0;
            // 
            // lblplotNo
            // 
            this.lblplotNo.AutoSize = true;
            this.lblplotNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblplotNo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblplotNo.Location = new System.Drawing.Point(29, 16);
            this.lblplotNo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblplotNo.Name = "lblplotNo";
            this.lblplotNo.Size = new System.Drawing.Size(48, 13);
            this.lblplotNo.TabIndex = 54;
            this.lblplotNo.Text = "Plot No :";
            // 
            // txtSouth
            // 
            this.txtSouth.BackColor = System.Drawing.SystemColors.Window;
            this.txtSouth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSouth.Location = new System.Drawing.Point(96, 230);
            this.txtSouth.Multiline = true;
            this.txtSouth.Name = "txtSouth";
            this.txtSouth.Size = new System.Drawing.Size(168, 57);
            this.txtSouth.TabIndex = 4;
            // 
            // txtNorth
            // 
            this.txtNorth.BackColor = System.Drawing.SystemColors.Window;
            this.txtNorth.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtNorth.Location = new System.Drawing.Point(96, 167);
            this.txtNorth.Multiline = true;
            this.txtNorth.Name = "txtNorth";
            this.txtNorth.Size = new System.Drawing.Size(168, 57);
            this.txtNorth.TabIndex = 3;
            // 
            // txtWest
            // 
            this.txtWest.BackColor = System.Drawing.SystemColors.Window;
            this.txtWest.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtWest.Location = new System.Drawing.Point(96, 104);
            this.txtWest.Multiline = true;
            this.txtWest.Name = "txtWest";
            this.txtWest.Size = new System.Drawing.Size(168, 57);
            this.txtWest.TabIndex = 2;
            // 
            // lblHiddenPlotId
            // 
            this.lblHiddenPlotId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHiddenPlotId.AutoSize = true;
            this.lblHiddenPlotId.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiddenPlotId.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHiddenPlotId.Location = new System.Drawing.Point(29, 281);
            this.lblHiddenPlotId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHiddenPlotId.Name = "lblHiddenPlotId";
            this.lblHiddenPlotId.Size = new System.Drawing.Size(0, 13);
            this.lblHiddenPlotId.TabIndex = 60;
            this.lblHiddenPlotId.Visible = false;
            // 
            // lblSouth
            // 
            this.lblSouth.AutoSize = true;
            this.lblSouth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSouth.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSouth.Location = new System.Drawing.Point(29, 230);
            this.lblSouth.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSouth.Name = "lblSouth";
            this.lblSouth.Size = new System.Drawing.Size(42, 13);
            this.lblSouth.TabIndex = 60;
            this.lblSouth.Text = "South :";
            // 
            // txtEast
            // 
            this.txtEast.BackColor = System.Drawing.SystemColors.Window;
            this.txtEast.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtEast.Location = new System.Drawing.Point(96, 41);
            this.txtEast.Multiline = true;
            this.txtEast.Name = "txtEast";
            this.txtEast.Size = new System.Drawing.Size(168, 57);
            this.txtEast.TabIndex = 1;
            // 
            // lblNorth
            // 
            this.lblNorth.AutoSize = true;
            this.lblNorth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorth.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNorth.Location = new System.Drawing.Point(29, 167);
            this.lblNorth.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNorth.Name = "lblNorth";
            this.lblNorth.Size = new System.Drawing.Size(41, 13);
            this.lblNorth.TabIndex = 59;
            this.lblNorth.Text = "North :";
            // 
            // lblWest
            // 
            this.lblWest.AutoSize = true;
            this.lblWest.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWest.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblWest.Location = new System.Drawing.Point(29, 104);
            this.lblWest.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWest.Name = "lblWest";
            this.lblWest.Size = new System.Drawing.Size(39, 13);
            this.lblWest.TabIndex = 58;
            this.lblWest.Text = "West :";
            // 
            // lblEast
            // 
            this.lblEast.AutoSize = true;
            this.lblEast.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEast.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblEast.Location = new System.Drawing.Point(29, 41);
            this.lblEast.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEast.Name = "lblEast";
            this.lblEast.Size = new System.Drawing.Size(35, 13);
            this.lblEast.TabIndex = 57;
            this.lblEast.Text = "East :";
            // 
            // pnlAreaTransfer
            // 
            this.pnlAreaTransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAreaTransfer.Controls.Add(this.lblPlotDimensionsDetail);
            this.pnlAreaTransfer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAreaTransfer.Location = new System.Drawing.Point(0, 0);
            this.pnlAreaTransfer.Name = "pnlAreaTransfer";
            this.pnlAreaTransfer.Size = new System.Drawing.Size(283, 55);
            this.pnlAreaTransfer.TabIndex = 0;
            // 
            // lblPlotDimensionsDetail
            // 
            this.lblPlotDimensionsDetail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlotDimensionsDetail.AutoSize = true;
            this.lblPlotDimensionsDetail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlotDimensionsDetail.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPlotDimensionsDetail.Location = new System.Drawing.Point(11, 19);
            this.lblPlotDimensionsDetail.Name = "lblPlotDimensionsDetail";
            this.lblPlotDimensionsDetail.Size = new System.Drawing.Size(202, 19);
            this.lblPlotDimensionsDetail.TabIndex = 1;
            this.lblPlotDimensionsDetail.Text = "Plots Dimensions Detail";
            // 
            // Msg
            // 
            this.Msg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg,
            this.toolStripStatusLabel1});
            this.Msg.Location = new System.Drawing.Point(0, 512);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(1016, 22);
            this.Msg.TabIndex = 66;
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
            // grdPlot
            // 
            this.grdPlot.AllowUserToAddRows = false;
            this.grdPlot.AllowUserToDeleteRows = false;
            this.grdPlot.AllowUserToResizeColumns = false;
            this.grdPlot.AllowUserToResizeRows = false;
            this.grdPlot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPlot.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.grdPlot.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grdPlot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdPlot.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPlot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPlot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlotIdCol,
            this.PlotNoCol,
            this.EastCol,
            this.WestCol,
            this.NorthCol,
            this.SouthCol,
            this.KhasraNoCol});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPlot.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPlot.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdPlot.EnableHeadersVisualStyles = false;
            this.grdPlot.GridColor = System.Drawing.Color.Black;
            this.grdPlot.Location = new System.Drawing.Point(283, 0);
            this.grdPlot.MultiSelect = false;
            this.grdPlot.Name = "grdPlot";
            this.grdPlot.ReadOnly = true;
            this.grdPlot.RowHeadersVisible = false;
            this.grdPlot.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdPlot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPlot.Size = new System.Drawing.Size(733, 512);
            this.grdPlot.StandardTab = true;
            this.grdPlot.TabIndex = 69;
            this.grdPlot.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPlot_CellDoubleClick);
            // 
            // PlotIdCol
            // 
            this.PlotIdCol.HeaderText = "PlotID";
            this.PlotIdCol.Name = "PlotIdCol";
            this.PlotIdCol.ReadOnly = true;
            this.PlotIdCol.Visible = false;
            // 
            // PlotNoCol
            // 
            this.PlotNoCol.HeaderText = "Plot No";
            this.PlotNoCol.Name = "PlotNoCol";
            this.PlotNoCol.ReadOnly = true;
            // 
            // EastCol
            // 
            this.EastCol.HeaderText = "East";
            this.EastCol.Name = "EastCol";
            this.EastCol.ReadOnly = true;
            // 
            // WestCol
            // 
            this.WestCol.HeaderText = "West";
            this.WestCol.Name = "WestCol";
            this.WestCol.ReadOnly = true;
            // 
            // NorthCol
            // 
            this.NorthCol.HeaderText = "North";
            this.NorthCol.Name = "NorthCol";
            this.NorthCol.ReadOnly = true;
            // 
            // SouthCol
            // 
            this.SouthCol.HeaderText = "South";
            this.SouthCol.Name = "SouthCol";
            this.SouthCol.ReadOnly = true;
            // 
            // KhasraNoCol
            // 
            this.KhasraNoCol.HeaderText = "Khasra No";
            this.KhasraNoCol.Name = "KhasraNoCol";
            this.KhasraNoCol.ReadOnly = true;
            // 
            // Plot_English
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 534);
            this.Controls.Add(this.grdPlot);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.Msg);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Plot_English";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plots";
            this.Load += new System.EventHandler(this.Plot_English_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Plot_English_KeyPress);
            this.pnlLeft.ResumeLayout(false);
            this.pnlCommands.ResumeLayout(false);
            this.pnlFields.ResumeLayout(false);
            this.pnlFields.PerformLayout();
            this.pnlAreaTransfer.ResumeLayout(false);
            this.pnlAreaTransfer.PerformLayout();
            this.Msg.ResumeLayout(false);
            this.Msg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList CORDImages;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlCommands;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.TextBox txtPlotNo;
        private System.Windows.Forms.Label lblplotNo;
        private System.Windows.Forms.TextBox txtSouth;
        private System.Windows.Forms.TextBox txtNorth;
        private System.Windows.Forms.TextBox txtWest;
        private System.Windows.Forms.Label lblSouth;
        private System.Windows.Forms.TextBox txtEast;
        private System.Windows.Forms.Label lblNorth;
        private System.Windows.Forms.Label lblWest;
        private System.Windows.Forms.Label lblEast;
        private System.Windows.Forms.Panel pnlAreaTransfer;
        private System.Windows.Forms.Label lblPlotDimensionsDetail;
        private System.Windows.Forms.StatusStrip Msg;
        public System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtKhasraNo;
        private System.Windows.Forms.Label lblKhasraNo;
        private System.Windows.Forms.Label lblHiddenPlotId;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView grdPlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlotIdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlotNoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn EastCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn WestCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NorthCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SouthCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhasraNoCol;
    }
}