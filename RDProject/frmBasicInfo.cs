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
using RDProject.GenClass;
using RD.EL;

namespace RDProject
{
    public partial class frm_BasicInfo : Form
    {
        bool NewRecord = true;
        Guid RegistryID = new Guid();
        bool ScanIT = false;
        public bool isLoading = false;

        private string[] comboItems = new string[] { "گواھان", "مشتری ", "بائع" }; 

        public frm_BasicInfo()
        {
            InitializeComponent();
            clsCulture.Localize(this, frm_Main.language);
        }

        private void frmBasicInfo_Load(object sender, EventArgs e)
        {
            //grdPerson.AllowAddNewRow = true;
            //grdPerson.AutoSizeRows = true;
            txtRegistryNo.Enabled = true;
            if (isLoading == false)
            {
                //((GridViewComboBoxColumn)grdPerson.Columns[0]).DataSource = this.comboItems;
                //grdPerson.Columns[0].Width = 100;
                //grdPerson.Columns[0].FieldName = "colStatus";
                txtRegistryNo.Focus();
                txtRegistryNo.SelectAll();
            }

            dtpDate.Value = DateTime.Today;

            if (Variables.Role == (int)Variables.Roles.SCO)
            {
                pnl1.Visible = false;
                pnlSCOButtons.Visible = true;
                tabControl.Show();
                //radPanel6.Enabled = true;
                btnNewEntry.Visible = true;
            }
            else if (Variables.Role != (int)Variables.Roles.SCO)
            {
                pnl1.Visible = true;
                pnlSCOButtons.Visible = false;
                tabControl.Show();
                //radPanel6.Enabled = false;
                pnl1.Enabled = true;
                btnNewEntry.Visible = false;
                //grdPerson.AllowAddNewRow = false;
            }


            DataGridViewTextBoxColumn dgvStatus = new DataGridViewTextBoxColumn();
            //dgvStatus.HeaderText = "بایٰع / مشتری";
            dgvStatus.HeaderText = clsCulture.GetLocalizedString("dgvStatusColMushtari", frm_Main.language);
            dgvStatus.Name = "colStatus";
            grdPerson.Columns.Add(dgvStatus);

            DataGridViewTextBoxColumn dgvName = new DataGridViewTextBoxColumn();
            //dgvName.HeaderText = "ںام";
            dgvName.HeaderText = clsCulture.GetLocalizedString("dgvStatusColName", frm_Main.language);
            dgvName.Name = "colName";
            grdPerson.Columns.Add(dgvName);

            DataGridViewTextBoxColumn dgvRelation = new DataGridViewTextBoxColumn();
            //dgvRelation.HeaderText = "رشتہ";
            dgvRelation.HeaderText = clsCulture.GetLocalizedString("dgvStatusColRelation", frm_Main.language);
            dgvRelation.Name = "colRelation";
            grdPerson.Columns.Add(dgvRelation);

            DataGridViewTextBoxColumn dgvFatherName = new DataGridViewTextBoxColumn();
            //dgvFatherName.HeaderText = "سرپرست";
            dgvFatherName.HeaderText = clsCulture.GetLocalizedString("dgvStatusColFatherName", frm_Main.language);
            dgvFatherName.Name = "colFatherName";
            grdPerson.Columns.Add(dgvFatherName);

            DataGridViewTextBoxColumn dgvCaste = new DataGridViewTextBoxColumn();
            //dgvCaste.HeaderText = "قوم";
            dgvCaste.HeaderText = clsCulture.GetLocalizedString("dgvStatusColCaste", frm_Main.language);
            dgvCaste.Name = "colCaste";
            grdPerson.Columns.Add(dgvCaste);

            DataGridViewTextBoxColumn dgvCNIC = new DataGridViewTextBoxColumn();
            //dgvCNIC.HeaderText = "شناختی کارڈ";
            dgvCNIC.HeaderText = clsCulture.GetLocalizedString("dgvStatusColCNIC", frm_Main.language);
            dgvCNIC.Name = "colCNIC";
            grdPerson.Columns.Add(dgvCNIC);

            DataGridViewButtonColumn dgvVarify = new DataGridViewButtonColumn();
            dgvVarify.HeaderText = "-";
            dgvVarify.Name = "colVarify";
            dgvVarify.ToolTipText = "تصد یق";
            dgvVarify.Text = "تصد یق";
            grdPerson.Columns.Add(dgvVarify);

            DataGridViewTextBoxColumn dgvPhoto = new DataGridViewTextBoxColumn();
            //dgvPhoto.HeaderText = "Picture";
            dgvPhoto.HeaderText = clsCulture.GetLocalizedString("dgvStatusColPhoto", frm_Main.language);
            dgvPhoto.Name = "colPhoto";
            grdPerson.Columns.Add(dgvPhoto);

            DataGridViewButtonColumn dgvTP = new DataGridViewButtonColumn();
            dgvTP.HeaderText = ".";
            dgvTP.Name = "colTP";
            dgvTP.ToolTipText = "تصویر اتاریں";
            grdPerson.Columns.Add(dgvTP);

            DataGridViewButtonColumn dgvVP = new DataGridViewButtonColumn();
            dgvVP.HeaderText = "--";
            dgvVP.Name = "colVP";
            dgvVP.ToolTipText = "تصویر دیکھیں";
            grdPerson.Columns.Add(dgvVP);

            DataGridViewTextBoxColumn dgvPersonId = new DataGridViewTextBoxColumn();
            dgvPersonId.HeaderText = "personID";
            dgvPersonId.Name = "colPersonId";
            dgvPersonId.Visible = false;
            grdPerson.Columns.Add(dgvPersonId);

            this.rpvScanning.RefreshReport();
            this.rpvScanning.RefreshReport();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (checkEmptyField())
            {
                AcceptForm obj = new AcceptForm();
                obj.RegistryNo = txtRegistryNo.Text;
                obj.txtremarks.Visible = false;
                obj.lblRemarks.Visible = false;
                obj.ShowDialog();
            }
        }

        private void btnNotAccept_Click(object sender, EventArgs e)
        {
            AcceptForm obj = new AcceptForm();
            obj.RegistryNo = txtRegistryNo.Text;
            obj.txtremarks.Visible = true;
            obj.lblRemarks.Visible = true;

            obj.ShowDialog();
        }

        private void controlEmptyBackColor(Control objCon)
        {
            objCon.BackColor = Color.Pink;
        }
        private void controlNormalBackColor(Control objCon)
        {
            objCon.BackColor = Color.FromArgb(233, 240, 249);
        }

        private bool checkEmptyField()
        {
            bool nEmpty = true;
            if (string.IsNullOrEmpty(txtRegistryNo.Text))
            {
                nEmpty = false;
                txtRegistryNo.Focus();
                controlEmptyBackColor(txtRegistryNo);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtRegistryNo);
            }

            if (ddlRegistryType.SelectedItem.ToString() == string.Empty)
            {
                nEmpty = false;
                ddlRegistryType.Focus();
                controlEmptyBackColor(ddlRegistryType);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(ddlRegistryType);
            }

            if (string.IsNullOrEmpty(txtZillah.Text))
            {
                nEmpty = false;
                txtZillah.Focus();
                controlEmptyBackColor(txtZillah);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtZillah);
            }

            if (string.IsNullOrEmpty(txtTehsil.Text))
            {
                nEmpty = false;
                txtTehsil.Focus();
                controlEmptyBackColor(txtTehsil);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtTehsil);
            }

            if (string.IsNullOrEmpty(txtMauza.Text))
            {
                nEmpty = false;
                txtMauza.Focus();
                controlEmptyBackColor(txtMauza);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtMauza);
            }

            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                nEmpty = false;
                txtAmount.Focus();
                controlEmptyBackColor(txtAmount);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtAmount);
            }

            if (string.IsNullOrEmpty(txtDocumentNumber.Text))
            {
                nEmpty = false;
                txtDocumentNumber.Focus();
                controlEmptyBackColor(txtDocumentNumber);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtDocumentNumber);
            }

            if (string.IsNullOrEmpty(txtBahiNumber.Text))
            {
                nEmpty = false;
                txtBahiNumber.Focus();
                controlEmptyBackColor(txtBahiNumber);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtBahiNumber);
            }

            if (string.IsNullOrEmpty(txtJildNumber.Text))
            {
                nEmpty = false;
                txtJildNumber.Focus();
                controlEmptyBackColor(txtJildNumber);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtJildNumber);
            }


            if (string.IsNullOrEmpty(txtKhewatNo.Text))
            {
                nEmpty = false;
                txtKhewatNo.Focus();
                controlEmptyBackColor(txtKhewatNo);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtKhewatNo);
            }


            if (string.IsNullOrEmpty(txtKhatuniNumber.Text))
            {
                nEmpty = false;
                txtKhatuniNumber.Focus();
                controlEmptyBackColor(txtKhatuniNumber);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtKhatuniNumber);
            }


            if (string.IsNullOrEmpty(txtQatah.Text))
            {
                nEmpty = false;
                txtQatah.Focus();
                controlEmptyBackColor(txtQatah);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtQatah);
            }


            if (string.IsNullOrEmpty(txtMuntalka.Text))
            {
                nEmpty = false;
                txtMuntalka.Focus();
                controlEmptyBackColor(txtMuntalka);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtMuntalka);
            }


            if (string.IsNullOrEmpty(txtRaqba.Text))
            {
                nEmpty = false;
                txtRaqba.Focus();
                controlEmptyBackColor(txtRaqba);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtRaqba);
            }


            if (string.IsNullOrEmpty(txtEast.Text))
            {
                nEmpty = false;
                txtEast.Focus();
                controlEmptyBackColor(txtEast);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtEast);
            }


            if (string.IsNullOrEmpty(txtWest.Text))
            {
                nEmpty = false;
                txtWest.Focus();
                controlEmptyBackColor(txtWest);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtWest);
            }


            if (string.IsNullOrEmpty(txtNorth.Text))
            {
                nEmpty = false;
                txtNorth.Focus();
                controlEmptyBackColor(txtNorth);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtNorth);
            }


            if (string.IsNullOrEmpty(txtSubRegistrar.Text))
            {
                nEmpty = false;
                txtSouth.Focus();
                controlEmptyBackColor(txtSouth);
                return nEmpty;
            }
            else
            {
                controlNormalBackColor(txtSubRegistrar);
            }


            return nEmpty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int registryStage = GetRegistryStage(txtRegistryNo.Text);
            if (registryStage == 2)
            {
                if (MessageBox.Show("رجسٹری سکین کر لی ھے، رجسٹری بر مہر لگا دی ھے۔", "رجسٹریشن ڈیڈز", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                DiscForm obj = new DiscForm();
                obj.ShowDialog();
            }

            if (checkEmptyField())
            {
                eRegistryOperations objRegOperation = new eRegistryOperations();
                Guid regId = Guid.NewGuid();
                objRegOperation.Registry_id = regId;
                //objRegOperation.Mauza_id = 
                //objRegOperation.Service_centre_id = 
                //objRegOperation.Fard_id = 
                //objRegOperation.Khasra_id = 
                //objRegOperation.Subregistrar_id = 
                //objRegOperation.Registery_stage = 
                //objRegOperation.Registry_type_id = 
                //objRegOperation.Registry_no = 
                //objRegOperation.Bahi_no = 
                //objRegOperation.Jild_no = 
                //objRegOperation.Doc_number = 
                //objRegOperation.Registry_fee = 
                //objRegOperation.Tma_fee = 
                //objRegOperation.District_council_fee = 
                //objRegOperation.Challan_fee = 
                //objRegOperation.Selling_price = 
                //objRegOperation.Amount = 
                //objRegOperation.East = 
                //objRegOperation.West = 
                //objRegOperation.North = 
                //objRegOperation.South = 
                //objRegOperation.Remarks = 
                //objRegOperation.User_id = 
                //objRegOperation.Access_datetime = 


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
                    DateTime Date = dtpDate.Value;// Convert.ToDateTime(txtDate.Text);
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
                    DateTime Date = dtpDate.Value;
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

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            twPersons.Focus();
            this.grdPerson.Rows.Add();
            //this.grdPerson.BeginEdit();
            //this.grdPerson.Columns[0].IsCurrent = true;
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
                //PdfViewer.LoadDocument(filename);
            }
            catch (Exception ex)
            {

            }
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
                stage = Convert.ToInt16(reader["registery_stage"].ToString());

            }
            reader.Close();
            return stage;
        }
       
        private void grdPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        public void txtRegistryNo_Leave(object sender, EventArgs e)
        {
            if (Variables.registryNo != string.Empty)
            {
                if (Convert.ToInt16(Variables.registryNo) > 0)
                    txtRegistryNo.Text = Variables.registryNo;
            }

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
                //dtpDate.Value = (DataTable)reader["registry_decision_date"];
                //txtDate.Text = reader["registry_decision_date"].ToString();
                //txtDate.Text = DateTime.Parse(txtDate.Text).ToShortDateString();
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
                //PdfViewer.Visible = true;
            }
            btnSave.Enabled = true;
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
                    grdPerson.Rows.Add();
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

        void SetDefaultValues()
        {
            RegistryID = new Guid();
            grdPerson.Rows.Clear();
            ScanIT = false;
            twScanning.Hide();
            txtRegistryNo.SelectAll();
            dtpDate.Value = DateTime.Today;
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

            if (ddlRegistryType.Items.Count > 0)
            {
                ddlRegistryType.SelectedIndex = 0;
            }
            NewRecord = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void ScanFile()
        {
            try
            {
                string filename = Application.StartupPath + "\\temp.pdf";
                if (File.Exists(filename))
                {
                    //PdfViewer.LoadDocument(filename);
                    rpvScanning.LocalReport.ReportPath = filename;
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
                        //acPDF.src = filename;
                        //PdfViewer.LoadDocument(filename);
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

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanIT = true;
            //radDock.ActivateWindow(twScanning);
            //PdfViewer.Visible = true;
            ScanFile();
        }

        private void tbl_SCOButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
