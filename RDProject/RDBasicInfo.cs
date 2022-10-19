using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Dosadi.EZTwain;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using RDProject.Properties;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Threading;
using RDProject.ResourceCulture;


namespace RDProject
{
    public partial class RDBasicInfoForm : Telerik.WinControls.UI.ShapedForm
    {
        public RDBasicInfoForm()
        {
            InitializeComponent();
        }

        bool NewRecord = true;
        Guid RegistryID = new Guid();
        bool ScanIT = false;
        public bool isLoading = false;

        private string[] comboItems = new string[] { "گواھان","مشتری ", "بائع" }; 

        private void RDBasicInfoForm_Load(object sender, EventArgs e)
        {

            grdPerson.AllowAddNewRow = true;
            grdPerson.AutoSizeRows = true;
            txtRegistryNo.Enabled = true;
            if (isLoading == false)
            {
                ((GridViewComboBoxColumn)grdPerson.Columns[0]).DataSource = this.comboItems;
                grdPerson.Columns[0].Width = 100;
                grdPerson.Columns[0].FieldName = "colStatus";

                txtRegistryNo.Focus();
                txtRegistryNo.SelectAll();
            }
            lblUserName.Text = "   صارف کا نام :" + Variables.UserName;

            if (Variables.Role == 1)
            {
                radLabel1.Text = "   صارف کا کردار : سروس سنٹر افیشل";
                btnFard.Visible = false;
            }
            else if (Variables.Role == 2)
            {
                radLabel1.Text = "   صارف کا کردار : سب رجسٹرار";
                btnFard.Visible = true;
                btnFard.Enabled = true;
            }

            
            txtDate.Text = DateTime.Today.ToString("M/dd/yyyy");

            if (Variables.Role == (int)Variables.Roles.SCO)
            {
                pnlROButtons.Visible = false;
                pnlSCOButtons.Visible = true;
                dwPerson.Show();
                radPanel6.Enabled = true;
                btnNewEntry.Visible = true;
            }
            else if (Variables.Role != (int)Variables.Roles.SCO)
            {
                pnlROButtons.Visible = true;
                pnlSCOButtons.Visible = false;
                dwPerson.Show();
                radPanel6.Enabled = false;
                pnlROButtons.Enabled = true;
                btnNewEntry.Visible = false;
                grdPerson.AllowAddNewRow = false;
            }

            //this.reportViewer1.RefreshReport();
        }
        private void LoadColumnsComboBox() 
        {
        }
        void SetDefaultValues()
        {

            PdfViewer.Visible = false;
            RegistryID = new Guid();
            grdPerson.Rows.Clear();
            grdPerson.RowCount = 0;
            grdPerson2.Rows.Clear();
            grdPerson2.RowCount = 0;
            ScanIT = false;
            twPersons.Hide();
            twScanning.Hide();
            dwPerson.Show();
            txtRegistryNo.SelectAll();
            txtDate.Text = DateTime.Today.ToString("M/dd/yyyy");
            txtRegistryNo.Clear();
            txtAmount.Text = "0";
            txtKhewatNo.Clear();
            txtKhatuniNumber.Clear();
            txtQatah.Clear();
            txtMuntalka.Clear();
            txtRaqba.Clear();
            txtEast.Clear();
            txtWest.Clear();
            txtNorth.Clear();
            txtSouth.Clear();
            txtZillah.Clear();
            txtTehsil.Clear();
            txtMauza.Clear();
            txtDocumentNumber.Clear();
            txtBahiNumber.Clear();
            txtJildNumber.Clear();
            txtSubRegistrar.Clear();

            ddlRegistryType.SelectedIndex = 0;
            NewRecord = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void txtRegistryNo_Enter(object sender, EventArgs e)
        {
            SetDefaultValues();            
            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            string sql = "SELECT MAX((registry_no)) + 1 AS MaxID FROM rd.RegistryOperations";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            IDataReader reader = db.ExecuteReader(dbCommand);
            while (reader.Read())
            {
                txtRegistryNo.Text = reader["MaxID"].ToString();
            }
            reader.Close();

        }

        public int GetRegistryStage(string strRegistryNo)
        {
            
            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            string sql = "SELECT registery_stage FROM rd.RegistryOperations WHERE registry_no=@registryNo";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "@RegistryNO", DbType.String, strRegistryNo);
            IDataReader reader = db.ExecuteReader(dbCommand);
            int stage;
            stage = 0;
            while (reader.Read())
            {
               stage = Convert.ToInt16( reader["registery_stage"].ToString());
               
            }
            
            reader.Close();
            return stage;
            
        }

        public void txtRegistryNo_Leave(object sender, EventArgs e)
        {

            if (Convert.ToInt16(Variables.registryNo) > 0)
                txtRegistryNo.Text = Variables.registryNo;
            
            txtRegistryNo.Enabled = false;
            if (txtRegistryNo.Text == string.Empty)
            {
                MessageBox.Show("Registery no. is missing ...");
                txtRegistryNo.Enabled = true;
                txtRegistryNo.Focus();
                return;
            }

            int iRegistryStage = GetRegistryStage(txtRegistryNo.Text);
            if (iRegistryStage > 1)
            {
                twScanning.Show();
            }
            else
            {
                twScanning.Hide();
            }



            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            string sql = "SELECT ";
            sql = sql + "registry_id, registry_no, registry_type, registry_decision_date, bay_muqaam, measure, amount, khewat_no, khatuni_no, Qitta, Hissa_muntiqala,";
            sql = sql + "raqba_bamutabiq_hissa, east, west, north, south, dist_name, tehsil_name, mauza_name, doc_number, bahi_no, jild_no, Musadiqa_sub_registrar FROM rd.RegistryOperations ";
            sql = sql + " WHERE registry_no = @RegistryNo";

            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "@RegistryNO", DbType.String, txtRegistryNo.Text);
            IDataReader reader = db.ExecuteReader(dbCommand);

            lblMessage.Text = "نیا ریکارڈ";

            while (reader.Read())
            {
                NewRecord = false;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
                lblMessage.Text = "ریکارڈ مل گیا ھے۔";
                RegistryID = (Guid)reader["registry_id"];
                txtRegistryNo.Text = reader["registry_no"].ToString();
                ddlRegistryType.Text = reader["registry_type"].ToString();
                txtDate.Text = reader["registry_decision_date"].ToString();
                txtDate.Text = DateTime.Parse(txtDate.Text).ToShortDateString();
                //txtDate.Text = DateTime.Today.ToString("M/dd/yyyy");

                txtAmount.Text = reader["amount"].ToString();
                txtKhewatNo.Text = reader["khewat_no"].ToString();
                txtKhatuniNumber.Text = reader["khatuni_no"].ToString();
                txtQatah.Text = reader["Qitta"].ToString();
                txtMuntalka.Text = reader["Hissa_muntiqala"].ToString();
                txtRaqba.Text = reader["raqba_bamutabiq_hissa"].ToString();
                txtEast.Text = reader["east"].ToString();
                txtWest.Text = reader["west"].ToString();
                txtNorth.Text = reader["north"].ToString();
                txtSouth.Text = reader["south"].ToString();
                txtZillah.Text = reader["dist_name"].ToString();
                txtTehsil.Text = reader["tehsil_name"].ToString();
                txtMauza.Text = reader["mauza_name"].ToString();
                txtDocumentNumber.Text = reader["doc_number"].ToString();
                txtBahiNumber.Text = reader["bahi_no"].ToString();
                txtJildNumber.Text = reader["jild_no"].ToString();
                txtSubRegistrar.Text = reader["Musadiqa_sub_registrar"].ToString();
            }
            reader.Close();
            if (NewRecord == false)
            {
                BindPersons();
                //BindPersons2();
                Select_Pdf();
                PdfViewer.Visible = true;
            }
            btnSave.Enabled = true;
        }

        private void RDBasicInfoForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyChar == (char)27)
            {
                if (txtRegistryNo.Focused)
                {
                    this.Close();
                }
                else
                {
                    txtRegistryNo.Enabled = true;
                    txtRegistryNo.Focus();
                    return;
                }
            }
        }

        private void ScanFile()
        {
            try
            {
                string filename = Application.StartupPath + "\\temp.pdf";
                if (File.Exists(filename))
                {
                    PdfViewer.LoadDocument(filename);
                }
                return;
                EZTwain.LogFile(1);
                EZTwain.SetHideUI(true);
                EZTwain.SetPixelType(2);
                EZTwain.SetResolution(150);
                int status = -101;

                File.Delete(filename);

                if (EZTwain.IsAvailable())
                {
                    if (EZTwain.OpenDefaultSource())
                    {
                        EZTwain.SetIndicators(true);
                        status = EZTwain.AcquireMultipageFile(IntPtr.Zero, filename);
                    }
                    else
                    {
                        EZTwain.SelectImageSource(IntPtr.Zero);
                        status = EZTwain.AcquireMultipageFile(IntPtr.Zero, filename);

                    }
                    if (EZTwain.LastErrorCode() != 0)
                    {
                    }
                }
                else
                {
                    MessageBox.Show("EZTwain is not Installed");
                }

                if (status == 0)
                {
                    EZTwain.CloseSource();
                    if (File.Exists(filename))
                    {
                        PdfViewer.LoadDocument(filename);
                    }

                }
                else
                {
                    //Close();
                    //System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception exp)
            {
                EZTwain.SetMultiTransfer(false);
                EZTwain.CloseSource();
            }

        }


        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            dwPerson.Focus();
            this.grdPerson.CurrentRow = this.grdPerson.MasterView.TableAddNewRow;
            this.grdPerson.BeginEdit();
            this.grdPerson.Columns[0].IsCurrent = true;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanIT = true;
            radDock.ActivateWindow(twScanning);
            PdfViewer.Visible = true;
            ScanFile();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            int registryStage = GetRegistryStage(txtRegistryNo.Text);
            if (registryStage == 2)
            {
                //if (MessageBox.Show("رجسٹری سکین کر لی ھے، رجسٹری بر مہر لگا دی ھے۔", "رجسٹریشن ڈیڈز", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return;
                //}
                DiscForm obj = new DiscForm();
                obj.ShowDialog();
            }

            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            if (NewRecord == true)
            {
                Guid gID = Guid.NewGuid();
                RegistryID = gID;
                string sql;
                sql = "insert into rd.RegistryOperations";
                sql = sql + "(registry_id, registry_no, registry_type, registry_decision_date, bay_muqaam, measure, amount, khewat_no, khatuni_no, Qitta, Hissa_muntiqala,";
                sql = sql + "raqba_bamutabiq_hissa, east, west, north, south, dist_name, tehsil_name, mauza_name, doc_number, bahi_no, jild_no, Musadiqa_sub_registrar, registery_stage )";
                sql = sql + "values (@registryID, @registryNo, @registryType, @date, @BayMuqaam, @measure, @amount, @khewatNo, @khatuniNo, @Qitta, @hissamuntiqala,";
                sql = sql + "@raqba, @east, @west, @north, @shouth, @district, @tehsil, @mauza, @docNumber, @bahiNo, @jildNo, @Registrar, @registerystage)";

                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                string RegistryNo = txtRegistryNo.Text;
                string RegistryType = ddlRegistryType.Text;
                DateTime Date = Convert.ToDateTime(txtDate.Text);
                string BayMuqam = string.Empty;
                string Measure = string.Empty;
                string Amount = txtAmount.Text;
                string KhewatNo = txtKhewatNo.Text;
                string khatuniNo = txtKhatuniNumber.Text;
                string Qitta = txtQatah.Text;
                string Muntiqala = txtMuntalka.Text;
                string Raqba = txtRaqba.Text;
                string East = txtEast.Text;
                string West = txtWest.Text;
                string North = txtNorth.Text;
                string South = txtSouth.Text;
                string District = txtZillah.Text;
                string Tehsil = txtTehsil.Text;
                string Mauza = txtMauza.Text;
                string DocNo = txtDocumentNumber.Text;
                string BahiNo = txtBahiNumber.Text;
                string JildNo = txtJildNumber.Text;
                string Registrar = txtSubRegistrar.Text;

                db.AddInParameter(dbCommand, "@RegistryID", DbType.Guid, gID);
                db.AddInParameter(dbCommand, "@RegistryNo", DbType.String, RegistryNo);
                db.AddInParameter(dbCommand, "@RegistryType", DbType.String, RegistryType);
                db.AddInParameter(dbCommand, "@date", DbType.DateTime, Date);
                db.AddInParameter(dbCommand, "@BayMuqaam", DbType.String, BayMuqam);
                db.AddInParameter(dbCommand, "@Measure", DbType.String, Measure);
                db.AddInParameter(dbCommand, "@Amount", DbType.String, Amount);
                db.AddInParameter(dbCommand, "@khewatNo", DbType.String, KhewatNo);
                db.AddInParameter(dbCommand, "@khatuniNo", DbType.String, khatuniNo);
                db.AddInParameter(dbCommand, "@Qitta", DbType.String, Qitta);
                db.AddInParameter(dbCommand, "@hissamuntiqala", DbType.String, Muntiqala);
                db.AddInParameter(dbCommand, "@raqba", DbType.String, Raqba);
                db.AddInParameter(dbCommand, "@east", DbType.String, East);
                db.AddInParameter(dbCommand, "@west", DbType.String, West);
                db.AddInParameter(dbCommand, "@north", DbType.String, North);
                db.AddInParameter(dbCommand, "@shouth", DbType.String, South);
                db.AddInParameter(dbCommand, "@district", DbType.String, District);
                db.AddInParameter(dbCommand, "@tehsil", DbType.String, Tehsil);
                db.AddInParameter(dbCommand, "@mauza", DbType.String, Mauza);
                db.AddInParameter(dbCommand, "@docNumber", DbType.String, DocNo);
                db.AddInParameter(dbCommand, "@bahiNo", DbType.String, BahiNo);
                db.AddInParameter(dbCommand, "@jildNo", DbType.String, JildNo);
                db.AddInParameter(dbCommand, "@Registrar", DbType.String, Registrar);

                
                if (registryStage == 2)
                {
                    db.AddInParameter(dbCommand, "@registerystage", DbType.Int32, 4);
                }
                else
                {

                    db.AddInParameter(dbCommand, "@registerystage", DbType.Int32, Variables.Role);
                }
                try
                {
                    db.ExecuteNonQuery(dbCommand);
                    Save_Pdf();
                    lblMessage.Text = "!رجسٹری سب رجسٹرار کو بیجی جا چکی ھے";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "!مسٰلہ";
                }
            }
            else
            {

                string sql = "Update rd.RegistryOperations ";
                sql = sql + "SET registry_type=@registrytype,  bay_muqaam=@baymuqaam, registry_decision_date=@date, measure=@Measure, Amount=@Amount, ";
                sql = sql + "khewat_no=@khewatno, khatuni_no=@khatuniNo, Qitta=@qitta, Hissa_muntiqala=@muntiqala, ";
                sql = sql + "raqba_bamutabiq_hissa=@raqba, east=@east, west=@west, north=@north, south=@south, dist_name=@district, tehsil_name=@tehsil, ";
                sql = sql + "mauza_name=@mauza, doc_number=@docNumber, bahi_no=@bahino, jild_no=@jildno, Musadiqa_sub_registrar=@registrar, registery_stage=@registerystage ";
                sql = sql + "WHERE registry_id=@RegistryID";

                DbCommand dbCommand = db.GetSqlStringCommand(sql);


                string RegistryNo = txtRegistryNo.Text;
                string RegistryType = ddlRegistryType.Text;
                DateTime Date = Convert.ToDateTime(txtDate.Text);
                string BayMuqam = string.Empty;
                string Measure = string.Empty;
                string Amount = txtAmount.Text;
                string KhewatNo = txtKhewatNo.Text;
                string khatuniNo = txtKhatuniNumber.Text;
                string Qitta = txtQatah.Text;
                string Muntiqala = txtMuntalka.Text;
                string Raqba = txtRaqba.Text;
                string East = txtEast.Text;
                string West = txtWest.Text;
                string North = txtNorth.Text;
                string South = txtSouth.Text;
                string District = txtZillah.Text;
                string Tehsil = txtTehsil.Text;
                string Mauza = txtMauza.Text;
                string DocNo = txtDocumentNumber.Text;
                string BahiNo = txtBahiNumber.Text;
                string JildNo = txtJildNumber.Text;
                string Registrar = txtSubRegistrar.Text;
                db.AddInParameter(dbCommand, "@RegistryID", DbType.Guid, RegistryID);
                db.AddInParameter(dbCommand, "@RegistryNo", DbType.String, RegistryNo);
                db.AddInParameter(dbCommand, "@RegistryType", DbType.String, RegistryType);
                db.AddInParameter(dbCommand, "@date", DbType.DateTime, Date);
                db.AddInParameter(dbCommand, "@BayMuqaam", DbType.String, BayMuqam);
                db.AddInParameter(dbCommand, "@Measure", DbType.String, Measure);
                db.AddInParameter(dbCommand, "@Amount", DbType.String, Amount);
                db.AddInParameter(dbCommand, "@khewatNo", DbType.String, KhewatNo);
                db.AddInParameter(dbCommand, "@khatuniNo", DbType.String, khatuniNo);
                db.AddInParameter(dbCommand, "@Qitta", DbType.String, Qitta);
                db.AddInParameter(dbCommand, "@muntiqala", DbType.String, Muntiqala);
                db.AddInParameter(dbCommand, "@raqba", DbType.String, Raqba);
                db.AddInParameter(dbCommand, "@east", DbType.String, East);
                db.AddInParameter(dbCommand, "@west", DbType.String, West);
                db.AddInParameter(dbCommand, "@north", DbType.String, North);
                db.AddInParameter(dbCommand, "@south", DbType.String, South);
                db.AddInParameter(dbCommand, "@district", DbType.String, District);
                db.AddInParameter(dbCommand, "@tehsil", DbType.String, Tehsil);
                db.AddInParameter(dbCommand, "@mauza", DbType.String, Mauza);
                db.AddInParameter(dbCommand, "@docNumber", DbType.String, DocNo);
                db.AddInParameter(dbCommand, "@bahiNo", DbType.String, BahiNo);
                db.AddInParameter(dbCommand, "@jildNo", DbType.String, JildNo);
                db.AddInParameter(dbCommand, "@Registrar", DbType.String, Registrar);
                if (registryStage == 2)
                {
                    db.AddInParameter(dbCommand, "@registerystage", DbType.Int32, 4);
                }
                else
                {

                    db.AddInParameter(dbCommand, "@registerystage", DbType.Int32, Variables.Role);
                }


                try
                {
                    int result = db.ExecuteNonQuery(dbCommand);
                    if (result > 0)
                    {

                        Save_Pdf();
                        lblMessage.Text = "!رکارڈ تبدیل حوگیا ھے";
//                        txtRegistryNo.Enabled = true;
                        //txtRegistryNo.Focus();
                    }
                    else
                    {
                        lblMessage.Text = "!مسٰلہ";
                        txtRegistryNo.Enabled = true;
                        txtRegistryNo.Focus();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "!مسٰلہ";
                }
            }

            string sqlPI = "DELETE from rd.propertyinfo WHERE registry_id = @RegistryID";
            DbCommand cmdPI = db.GetSqlStringCommand(sqlPI);
            db.AddInParameter(cmdPI, "@RegistryID", DbType.Guid, RegistryID);
            db.ExecuteNonQuery(cmdPI);

            string sqlPerson = "DELETE FROM rd.RegistryPerson WHERE registry_id = @RegistryID";
            DbCommand cmdPerson = db.GetSqlStringCommand(sqlPerson);
            db.AddInParameter(cmdPerson, "@RegistryID", DbType.Guid, RegistryID);
            db.ExecuteNonQuery(cmdPerson);

            if (grdPerson.RowCount > 0)
            {
                for (int i = 0; i < grdPerson.RowCount; i++)
                {
                    Guid gPersonID = Guid.NewGuid();
                    string Party_Type = Convert.ToString(grdPerson.Rows[i].Cells[0].Value);
                    string Name = Convert.ToString(grdPerson.Rows[i].Cells[1].Value);
                    string Relation = Convert.ToString(grdPerson.Rows[i].Cells[2].Value);
                    string LName = Convert.ToString(grdPerson.Rows[i].Cells[3].Value);
                    string Caste = Convert.ToString(grdPerson.Rows[i].Cells[4].Value);
                    string NIC = Convert.ToString(grdPerson.Rows[i].Cells[5].Value);


                    string SqlPerson = "Insert into rd.RegistryPerson (Party_Type, registryperson_id, registry_id, person_id, relation, first_name, last_name, nic, caste_name, person_status) Values(@PartyType, @RegistryPersonId, @RegistryId, @PersonId, @Relation, @firstname, @lastname, @Nic, @CasteName, @PersonStatus)";
                    DbCommand CmdPerson = db.GetSqlStringCommand(SqlPerson);

                    db.AddInParameter(CmdPerson, "@RegistryID", DbType.Guid, RegistryID);
                    db.AddInParameter(CmdPerson, "@PartyType", DbType.String, Party_Type);
                    db.AddInParameter(CmdPerson, "@RegistryPersonId", DbType.Guid, gPersonID);
                    db.AddInParameter(CmdPerson, "@PersonId", DbType.Guid, gPersonID);
                    db.AddInParameter(CmdPerson, "@Relation", DbType.String, Relation);
                    db.AddInParameter(CmdPerson, "@PersonStatus", DbType.Int16, 0);

                    db.AddInParameter(CmdPerson, "@firstname", DbType.String, Name);
                    db.AddInParameter(CmdPerson, "@lastname", DbType.String, LName);
                    db.AddInParameter(CmdPerson, "@Address", DbType.String, string.Empty);
                    db.AddInParameter(CmdPerson, "@CasteName", DbType.String, Caste);
                    db.AddInParameter(CmdPerson, "@NIC", DbType.String, NIC);
                    try
                    {
                        db.ExecuteNonQuery(CmdPerson);
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "!مسٰلہ";
                        return;
                    }
                }
                txtRegistryNo.Enabled = true;
                txtRegistryNo.Focus();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            string sqlPI = "DELETE from rd.propertyinfo WHERE registry_id = @RegistryID";
            DbCommand cmdPI = db.GetSqlStringCommand(sqlPI);
            db.AddInParameter(cmdPI, "@RegistryID", DbType.Guid, RegistryID);
            db.ExecuteNonQuery(cmdPI);

            string sqlPerson = "DELETE FROM rd.RegistryPerson WHERE registry_id = @RegistryID";
            DbCommand cmdPerson = db.GetSqlStringCommand(sqlPerson);
            db.AddInParameter(cmdPerson, "@RegistryID", DbType.Guid, RegistryID);
            db.ExecuteNonQuery(cmdPerson);

            string sqlPdf = "DELETE FROM rd.RegistryImages WHERE registry_id = @RegistryID";
            DbCommand cmdPDF = db.GetSqlStringCommand(sqlPdf);
            db.AddInParameter(cmdPDF, "@RegistryID", DbType.Guid, RegistryID);
            db.ExecuteNonQuery(cmdPDF);


            string sql = "DELETE FROM rd.RegistryOperations WHERE registry_no = @RegistryNo";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "@RegistryNo", DbType.String, txtRegistryNo.Text);
            try
            {
                int result = db.ExecuteNonQuery(dbCommand);
                if (result > 0)
                {
                    lblMessage.Text = "!ریکارڈ حزف حوگیا ھے۔";
                    txtRegistryNo.Enabled = true;
                    txtRegistryNo.Focus();

                }
                else
                {
                    lblMessage.Text = "!مسٰلہ";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "!مسٰلہ";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        void BindPersons()
        {
            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            string sql = "SELECT Party_Type, m.registry_id, m.registry_no, person_id, person_status, person_pic, first_name, last_name, address, nic, m.user_id, relation, caste_name FROM rd.RegistryOperations m INNER JOIN rd.RegistryPerson d ON m.registry_id = d.registry_id where m.registry_no = @RegistryNo";

            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@RegistryNo", DbType.String, txtRegistryNo.Text);
            try
            {
                DataSet ds = db.ExecuteDataSet(cmd);
                int rc = ds.Tables[0].Rows.Count;
                for (int i = 0; i < rc; i++)
                {
                    grdPerson.Rows.AddNew();
                    grdPerson.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i].ItemArray[0]; // type
                    grdPerson.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i].ItemArray[6]; // name
                    grdPerson.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i].ItemArray[7]; // sarparasat
                    grdPerson.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i].ItemArray[11]; // rishta
                    grdPerson.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i].ItemArray[12]; // qoap
                    grdPerson.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i].ItemArray[9]; // nic                    
                    grdPerson.Rows[i].Cells[9].Value = ds.Tables[0].Rows[i].ItemArray[2]; // personID
                }
            }
            catch (Exception ex)
            {

            }
        }

        void BindPersons2()
        {
            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            string sql = "SELECT m.registry_id, m.registry_no, person_id, person_status, person_pic, first_name, last_name, address, nic, m.user_id, relation_id, caste_name FROM rd.RegistryOperations m INNER JOIN rd.RegistryPerson d ON m.registry_id = d.registry_id where m.registry_no = @RegistryNo";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@RegistryNo", DbType.String, txtRegistryNo.Text);
            try
            {
                DataSet ds = db.ExecuteDataSet(cmd);
                int rc = ds.Tables[0].Rows.Count;
                for (int i = 0; i < rc; i++)
                {
                    grdPerson2.Rows.AddNew();
                    grdPerson2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i].ItemArray[5]; // name
                    grdPerson2.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i].ItemArray[7]; // sarparasat
                    grdPerson2.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i].ItemArray[6]; // rishta
                    grdPerson2.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i].ItemArray[11]; // qoap
                    grdPerson2.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i].ItemArray[8]; // nic
//                    grdPerson.Rows[i].Cells[6].Value = ds.Tables[0].Rows[i].ItemArray[10]; // person_pic
                    grdPerson2.Rows[i].Cells[9].Value = ds.Tables[0].Rows[i].ItemArray[2]; // personID
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Save_Pdf()
        {
            if (ScanIT == false) return;            
            string filename = Application.StartupPath + "\\temp.pdf";
            if (NewRecord == true)
            {
                Database db = DatabaseFactory.CreateDatabase("ConnStr");
                string Query = "insert into rd.RegistryImages(registryImages_id, registry_id, image_file) values (@RegistryImagesID, @RegistryID, @PdfFile)";
                DbCommand cmd = db.GetSqlStringCommand(Query);
                db.AddInParameter(cmd, "@RegistryImagesID", DbType.Guid, Guid.NewGuid());
                db.AddInParameter(cmd, "@RegistryID", DbType.Guid, RegistryID);
                db.AddInParameter(cmd, "PdfFile", DbType.Binary, System.IO.File.ReadAllBytes(filename));
                db.ExecuteNonQuery(cmd);
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase("ConnStr");
                string Query = "Update rd.RegistryImages SET image_file=@PdfFile WHERE registry_id=@RegistryID";
                DbCommand cmd = db.GetSqlStringCommand(Query);
                db.AddInParameter(cmd, "@RegistryID", DbType.Guid, RegistryID);
                db.AddInParameter(cmd, "PdfFile", DbType.Binary, System.IO.File.ReadAllBytes(filename));
                db.ExecuteNonQuery(cmd);
            }


        }

        protected void Select_Pdf()
        {

            string filename = Application.StartupPath + "\\1.pdf";
            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            string sql = "SELECT image_file FROM  rd.RegistryImages WHERE registry_id=@RegistryID";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "@RegistryID", DbType.Guid, RegistryID);
            byte[] buffer = (byte[])db.ExecuteScalar(dbCommand);
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                fs.Dispose();
                PdfViewer.LoadDocument(filename);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Variables.IsLoged = false;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptForm obj = new AcceptForm();
            obj.RegistryNo = txtRegistryNo.Text;
            obj.txtremarks.Visible = false;
            obj.lblRemarks.Visible = false;
            obj.ShowDialog();
        }

        private void btnNotAccept_Click(object sender, EventArgs e)
        {
            AcceptForm obj = new AcceptForm();
            obj.RegistryNo = txtRegistryNo.Text;
            obj.txtremarks.Visible = true;
            obj.lblRemarks.Visible = true;

            obj.ShowDialog();
        }

        private void grdPerson_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gCommand = (sender as GridCommandCellElement);
            if (gCommand.ColumnIndex == 7)
            {
                ScanPicture obj = new ScanPicture();
                obj.btnClose.Visible = true;
                obj.btnSave.Visible = true;
                obj.ShowDialog();
            }
            if (gCommand.ColumnIndex == 8)
            {
                ScanPicture obj = new ScanPicture();
                obj.btnClose.Visible = true;
                obj.btnSave.Visible = false;
                obj.ShowDialog();
            }

        }

        private void grdPerson2_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gCommand = (sender as GridCommandCellElement);
            if (gCommand.ColumnIndex == 7)
            {
                ScanPicture obj = new ScanPicture();
                obj.ShowDialog();
            }
            if (gCommand.ColumnIndex == 8)
            {
                ScanPicture obj = new ScanPicture();
                obj.ShowDialog();
            }

        }
    }
}
