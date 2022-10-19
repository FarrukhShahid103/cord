using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RD.EL;
using RD.BLL;
using System.Text.RegularExpressions;

namespace RDProject.RD
{
    public partial class Khasra_Urdu : Form
    {
        public Guid Registry_ID;
        public int Registry_No;
        public Guid Khasra_ID;
        private bool NewRecord;



        private string areaValue = string.Empty;
        private string transferedAreaValue = string.Empty;

        public int AreaFormatForExpose;

        private Int64 _acre;
        private Int64 _kanal;
        private Int64 _marla;
        private Int64 _feet;
        private Int64 _sarsai;
        private Int64 _yard;
        private short _feetPerMarla;
        private short _tabIndex;
        private enAreaFormat _areaFormat = enAreaFormat.KanalMarlaFeet;
        private int areaFormatByMauzaId;
        public Guid mauzaId;
        private int feetPerMaralFromMauzaId = 272;
        public enum enAreaFormat
        {
            Acre = 0,
            KanalMarla,
            KanalMarlaFeet,
            KanalMarlaSarsai,
            KanalMarlaYard
        }
        public Khasra_Urdu()
        {
            InitializeComponent();
            fillColumnKhasraGrid();
        }
        private void GetValuesDependOnMauzaId(Guid mauzaid)
        {
            if (mauzaid != null && mauzaid != Guid.Empty)
            {
                eMauza objElMauza = new eMauza();
                objElMauza.Mauza_id = mauzaid;
                bMauza objBlMauza = new bMauza();
                List<eMauza> objListMauza = objBlMauza.getMauza(objElMauza, "", "", 0, 5);
                if (objListMauza.Count > 0)
                {
                    feetPerMaralFromMauzaId = objListMauza[0].Feet_per_marla;
                    areaFormatByMauzaId = objListMauza[0].Area_format;
                    if (areaFormatByMauzaId == 0)
                        _areaFormat = enAreaFormat.Acre;
                    else if (areaFormatByMauzaId == 1)
                        _areaFormat = enAreaFormat.KanalMarla;
                    else if (areaFormatByMauzaId == 2)
                        _areaFormat = enAreaFormat.KanalMarlaFeet;
                    else if (areaFormatByMauzaId == 3)
                        _areaFormat = enAreaFormat.KanalMarlaSarsai;
                    else if (areaFormatByMauzaId == 4)
                        _areaFormat = enAreaFormat.KanalMarlaYard;
                }

            }
        }
        private void fillColumnKhasraGrid()
        {
            DataGridViewTextBoxColumn dgvKhasraId = new DataGridViewTextBoxColumn();
            dgvKhasraId.Name = "colKhasraId";
            dgvKhasraId.Visible = false;
            grdKhasra.Columns.Add(dgvKhasraId);

            DataGridViewTextBoxColumn dgvKhewatNo = new DataGridViewTextBoxColumn();
            dgvKhewatNo.HeaderText = "کھیوٹ نمبر";
            dgvKhewatNo.Name = "colKhewatNo";
            grdKhasra.Columns.Add(dgvKhewatNo);

            DataGridViewTextBoxColumn dgvKhatuniNo = new DataGridViewTextBoxColumn();
            dgvKhatuniNo.HeaderText = "کھتونی نمبر";
            dgvKhatuniNo.Name = "colKhatuniNo";
            grdKhasra.Columns.Add(dgvKhatuniNo);

            DataGridViewTextBoxColumn dgvKhasraNo = new DataGridViewTextBoxColumn();
            dgvKhasraNo.HeaderText = "خسرہ نمبر";
            dgvKhasraNo.Name = "colKhasraNo";
            grdKhasra.Columns.Add(dgvKhasraNo);

            DataGridViewTextBoxColumn dgvKhasraTotalArea = new DataGridViewTextBoxColumn();
            dgvKhasraTotalArea.HeaderText = "خسرہ کل رقبہ";
            dgvKhasraTotalArea.Name = "colKhasraTotalArea";
            grdKhasra.Columns.Add(dgvKhasraTotalArea);

            DataGridViewTextBoxColumn dgvTransferArea = new DataGridViewTextBoxColumn();
            dgvTransferArea.HeaderText = "منتقل رقبہ";
            dgvTransferArea.Name = "colTransferArea";
            grdKhasra.Columns.Add(dgvTransferArea);

            DataGridViewTextBoxColumn dgvKhasraTotalShare = new DataGridViewTextBoxColumn();
            dgvKhasraTotalShare.HeaderText = "کل حصہ";
            dgvKhasraTotalShare.Name = "colKhasraTotalShare";
            grdKhasra.Columns.Add(dgvKhasraTotalShare);

            DataGridViewTextBoxColumn dgvTransferShare = new DataGridViewTextBoxColumn();
            dgvTransferShare.HeaderText = "منتقل حصہ";
            dgvTransferShare.Name = "colTransferShare";
            grdKhasra.Columns.Add(dgvTransferShare);

            DataGridViewTextBoxColumn dgvEast = new DataGridViewTextBoxColumn();
            dgvEast.HeaderText = "مشرق";
            dgvEast.Name = "colEast";
            grdKhasra.Columns.Add(dgvEast);

            DataGridViewTextBoxColumn dgvWest = new DataGridViewTextBoxColumn();
            dgvWest.HeaderText = "مغرب";
            dgvWest.Name = "colWest";
            grdKhasra.Columns.Add(dgvWest);

            DataGridViewTextBoxColumn dgvNorth = new DataGridViewTextBoxColumn();
            dgvNorth.HeaderText = "شمال";
            dgvNorth.Name = "colNorth";
            grdKhasra.Columns.Add(dgvNorth);

            DataGridViewTextBoxColumn dgvSouth = new DataGridViewTextBoxColumn();
            dgvSouth.HeaderText = "جنوب";
            dgvSouth.Name = "colSouth";
            grdKhasra.Columns.Add(dgvSouth);

        }

        protected void SetDefaultValues()
        {
            txtKhasraNo.Clear();
            txtKhasraNo.Clear();
            txtKhatuniNo.Clear();
            txtKhasraNo.Clear();
            txtKhasraTotalArea.Clear();
            txtTransferedArea.Clear();
            txtKhasraTotalShare.Clear();
            txtTransferedShare.Clear();
            txtEast.Clear();
            txtWest.Clear();

            txtNorth.Clear();
            txtSouth.Clear();
            btnSave.Enabled = false;
            btnSave.Text = "&محفوظ";
            btnDelete.Enabled = false;
            NewRecord = true;
            cmbKhasraTotalArea.SelectedIndex = AreaFormatForExpose;
            BindKhasraGrid();
        }

        private void BindKhasraGrid()
        {
            if (grdKhasra.Rows.Count > 0)
            {
                grdKhasra.Rows.Clear();
            }

            eKhasra oeKhasra = new eKhasra();
            oeKhasra.Registry_id = Registry_ID;
            List<eKhasra> oeListKhasra = new List<eKhasra>();
            bKhasra obKhasra = new bKhasra();
            oeListKhasra = obKhasra.getKhasra(oeKhasra, "khasra_no", "", 0, int.MaxValue);


            if (oeListKhasra != null && oeListKhasra.Count > 0)
            {
                for (int i = 0; i < oeListKhasra.Count; i++)
                {
                    grdKhasra.Rows.Add();
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colKhasraId"].Value = oeListKhasra[i].Khasra_id;
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colKhewatNo"].Value = oeListKhasra[i].Khewat_no;
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colkhatuniNo"].Value = oeListKhasra[i].Khatuni_no;
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colKhasraNo"].Value = oeListKhasra[i].Khasra_no;
                    Int64 totalAreaOfKhasra = Convert.ToInt64(oeListKhasra[i].Khasra_total_area);
                    string totalArea = FeetToArea(totalAreaOfKhasra, feetPerMaralFromMauzaId, _areaFormat);
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colKhasraTotalArea"].Value = totalArea;
                    //grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colKhasraTotalArea"].Value = oeListKhasra[i].Khasra_total_area;


                    Int64 totalTransferedAreaOfKhasra = Convert.ToInt64(oeListKhasra[i].Transferred_area);
                    string totalTransferArea = FeetToArea(totalTransferedAreaOfKhasra, feetPerMaralFromMauzaId, _areaFormat);
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colTransferArea"].Value = totalTransferArea;
                    //grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colTransferArea"].Value = oeListKhasra[i].Transferred_area;

                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colKhasraTotalShare"].Value = oeListKhasra[i].Khasra_total_share;
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colTransferShare"].Value = oeListKhasra[i].Transferred_share;
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colEast"].Value = oeListKhasra[i].East;
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colWest"].Value = oeListKhasra[i].West;
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colNorth"].Value = oeListKhasra[i].North;
                    grdKhasra.Rows[grdKhasra.Rows.Count - 1].Cells["colSouth"].Value = oeListKhasra[i].South;

                }
            }

        }

        private void Khasra_Urdu_Load(object sender, EventArgs e)
        {
            GetValuesDependOnMauzaId(mauzaId);
            SetDefaultValues();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValidArea())
            {
                eKhasra oeKhasra = new eKhasra();
                bKhasra obKhasra = new bKhasra();
                updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
                oeKhasra.Registry_id = Registry_ID;
                oeKhasra.Khewat_no = txtKhewatNo.Text;
                oeKhasra.Khatuni_no = txtKhatuniNo.Text;
                oeKhasra.Khasra_no = txtKhasraNo.Text;
                if (txtKhasraTotalArea.Text != string.Empty)
                {
                    string areaToFeet = AreaToFeet(txtKhasraTotalArea.Text, feetPerMaralFromMauzaId);
                    oeKhasra.Khasra_total_area = Convert.ToInt64(areaToFeet);
                }
                else
                {
                    oeKhasra.Khasra_total_area = 0;
                }
                if (txtTransferedArea.Text != string.Empty)
                {
                    string transferedAreaToFeet = AreaToFeet(txtTransferedArea.Text, feetPerMaralFromMauzaId);
                    oeKhasra.Transferred_area = Convert.ToInt64(transferedAreaToFeet);
                }
                else
                {
                    oeKhasra.Transferred_area = 0;
                }
                if (txtKhasraTotalShare.Text != string.Empty)
                {
                    oeKhasra.Khasra_total_share = txtKhasraTotalShare.Text;
                }
                if (txtTransferedShare.Text != string.Empty)
                {
                    oeKhasra.Transferred_share = txtTransferedShare.Text;
                }
                oeKhasra.Khasra_total_share = txtKhasraTotalShare.Text;
                oeKhasra.Transferred_share = txtTransferedShare.Text;
                oeKhasra.East = txtEast.Text;
                oeKhasra.West = txtWest.Text;
                oeKhasra.North = txtNorth.Text;
                oeKhasra.South = txtSouth.Text;
                oeKhasra.User_id = Variables.UserId;
                oeKhasra.Access_date_time = DateTime.Now;
                oeKhasra.Is_active = true;

                if (NewRecord)
                {
                    oeKhasra.Khasra_id = Guid.NewGuid();
                    insertInfo = obKhasra.insertKhasra(oeKhasra);
                    if (insertInfo.Success)
                    {
                        lblMsg.Text = "ریکارڈ محفوظ کر دیاگیا ھے۔";
                        BindKhasraGrid();
                        SetDefaultValues();
                    }
                    else
                    {
                        lblMsg.Text = "مسلہؑ آ گیا ھے۔";
                        SetDefaultValues();
                    }
                }
                else
                {
                    oeKhasra.Khasra_id = Khasra_ID;
                    insertInfo = obKhasra.udpateKhasra(oeKhasra);
                    if (insertInfo.Success)
                    {
                        lblMsg.Text = "ریکارڈ تبدیل کر دیاگیا ھے۔";
                        BindKhasraGrid();
                        SetDefaultValues();
                    }
                    else
                    {
                        lblMsg.Text = "مسلہؑ آ گیا ھے۔";
                        SetDefaultValues();
                    }

                }
            }

        }
        private bool checkValidArea()
        {
            bool isEmpty = true;
            if (txtKhasraTotalArea.Text != string.Empty)
            {
                if (!ValidateArea(txtKhasraTotalArea.Text.Trim()))
                {
                    isEmpty = false;
                    txtKhasraTotalArea.Focus();
                    MessageDisplay("کل رقبہ کا اندراج درست کریں۔", false);
                    return isEmpty;
                }
            }

            if (txtTransferedArea.Text != string.Empty)
            {
                if (!ValidateArea(txtTransferedArea.Text.Trim()))
                {
                    isEmpty = false;
                    txtTransferedArea.Focus();
                    MessageDisplay("منتقلہ رقبہ کا اندراج درست کریں۔", false);
                    return isEmpty;
                }
            }
            if (txtKhasraTotalShare.Text != string.Empty)
            {
                if (!ValidateShare(txtKhasraTotalShare.Text.Trim()))
                {
                    isEmpty = false;
                    txtKhasraTotalShare.Focus();
                    MessageDisplay("کل حصہ کا اندراج درست کریں۔", false);
                    return isEmpty;
                }
            }
            if (txtTransferedShare.Text != string.Empty)
            {
                if (!ValidateShare(txtTransferedShare.Text.Trim()))
                {
                    isEmpty = false;
                    txtTransferedShare.Focus();
                    MessageDisplay("منتقلہ حصہ کا اندراج درست کریں۔", false);
                    return isEmpty;
                }
            }


            return isEmpty;
        }
        private void MessageDisplay(string sMessage, bool isSuccess)
        {
            lblMsg.Text = sMessage;
            if (isSuccess)
                lblMsg.ForeColor = Color.SteelBlue;
            else
            {
                lblMsg.ForeColor = Color.Red;
            }
        }
        private void Khasra_Urdu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (txtKhewatNo.Focused)
                {
                    this.Close();
                }
                else
                {
                    txtKhewatNo.Enabled = true;
                    txtKhewatNo.SelectAll();
                    txtKhewatNo.Focus();
                    SetDefaultValues();
                    return;
                }
            }

        }

        private void grdKhasra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.grdKhasra.RowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 206); //Color.Bisque;
            this.grdKhasra.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 250);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            eKhasra oeKhasra = new eKhasra();
            bKhasra obKhasra = new bKhasra();
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            oeKhasra.Khasra_id = Khasra_ID;
            insertInfo = obKhasra.deleteKhasra(oeKhasra);
            if (insertInfo.Success)
            {
                lblMsg.Text = "ریکارڈ کامیابی کے ساتھ خارج کر دیاگیا ھے۔";
                BindKhasraGrid();
                SetDefaultValues();
            }

        }

        private void grdKhasra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvwCurRow = grdKhasra.Rows[e.RowIndex];
            int rowIndex = e.RowIndex;


            eKhasra oeKhasra = new eKhasra();
            List<eKhasra> oeListKhasra = new List<eKhasra>();
            bKhasra obKhasra = new bKhasra();
            oeKhasra.Khasra_id = ValidateFields.GetSafeGuid(dgvwCurRow.Cells["colKhasraId"].Value);
            oeKhasra.Is_active = true;
            oeListKhasra = obKhasra.getKhasra(oeKhasra, "", "", 0, int.MaxValue);
            if (oeListKhasra != null && oeListKhasra.Count == 1)
            {
                Khasra_ID = oeListKhasra[0].Khasra_id;
                txtKhewatNo.Text = oeListKhasra[0].Khewat_no;
                txtKhatuniNo.Text = oeListKhasra[0].Khatuni_no;
                txtKhasraNo.Text = oeListKhasra[0].Khasra_no;
                //txtKhasraTotalArea.Text = oeListKhasra[0].Khasra_total_area.ToString();
                Int64 totalArea = Convert.ToInt64(oeListKhasra[0].Khasra_total_area.ToString());
                txtKhasraTotalArea.Text = FeetToArea(totalArea, feetPerMaralFromMauzaId, _areaFormat);

                //txtTransferedArea.Text = oeListKhasra[0].Transferred_area.ToString();
                Int64 transferedArea = Convert.ToInt64(oeListKhasra[0].Transferred_area.ToString());
                txtTransferedArea.Text = FeetToArea(transferedArea, feetPerMaralFromMauzaId, _areaFormat);
                txtKhasraTotalShare.Text = oeListKhasra[0].Khasra_total_share;
                txtTransferedShare.Text = oeListKhasra[0].Transferred_share;
                txtEast.Text = oeListKhasra[0].East;
                txtWest.Text = oeListKhasra[0].West;
                txtNorth.Text = oeListKhasra[0].North;
                txtSouth.Text = oeListKhasra[0].South;
                NewRecord = false;
                btnSave.Text = "تبدیل کریں";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;


               
               

            }
        }

        private void txtKhewatNo_Leave(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        #region for area format

        private string FeetToArea(Int64 feet, int feetPerMarla, enAreaFormat format)
        {
            string areaValue = "0";
            double result;
            //double kanal, marla, sarsai, result;

            if (feetPerMarla > 0 && feet > 0)
            {
                switch (format)
                {
                    case enAreaFormat.KanalMarlaFeet:
                        {
                            _kanal = feet / 20 / feetPerMarla;

                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            //_feet = Convert.ToInt64(Math.Round(Convert.ToDouble(_feet) / Convert.ToDouble(feetPerMarla), MidpointRounding.AwayFromZero));

                            //if (_feet == 1)
                            {
                                if (_feet == feetPerMarla)
                                {
                                    _marla = _marla + 1;
                                    _feet = 0;
                                }
                                if (_marla == 20)
                                {
                                    _kanal = _kanal + 1;
                                    _marla = 0;
                                }
                                // _feet = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _feet;
                            break;
                        }
                    case enAreaFormat.KanalMarlaSarsai:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            _sarsai = Convert.ToInt64(Math.Round((_feet / (feetPerMarla / 9.0)), MidpointRounding.AwayFromZero));

                            if (_sarsai == 9)
                            {
                                _marla = _marla + 1;
                                if (_marla == 20)
                                {
                                    _kanal = _kanal + 1;
                                    _marla = 0;
                                }
                                _sarsai = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _sarsai;
                            break;
                        }
                    case enAreaFormat.KanalMarla:
                        {
                            _kanal = feet / 20 / feetPerMarla;

                            _marla = Convert.ToInt64(Math.Round(Math.Round(((Convert.ToDouble(feet) / feetPerMarla) % 20.0), 2), MidpointRounding.AwayFromZero));

                            if (_marla == 20)
                            {
                                _marla = 0;
                                _kanal = _kanal + 1;
                            }
                            areaValue = _kanal + "-" + _marla;
                            break;
                        }
                    case enAreaFormat.Acre:
                        {
                            if (feetPerMarla == 225)
                            {
                                result = Math.Round((feet / 9.65 / 20 / feetPerMarla), MidpointRounding.AwayFromZero);
                                _acre = Convert.ToInt64(result);
                            }
                            else if (feetPerMarla == 272)
                            {
                                result = Math.Round((feet / 8.0 / 20 / feetPerMarla), MidpointRounding.AwayFromZero);
                                _acre = Convert.ToInt64(result);
                            }

                            areaValue = _acre.ToString();
                            break;
                        }

                    case enAreaFormat.KanalMarlaYard:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            _yard = Convert.ToInt64(Math.Round((_feet / 9.07), MidpointRounding.AwayFromZero));

                            if (_yard == Convert.ToInt64(Math.Round((feetPerMarla / 9.07), MidpointRounding.AwayFromZero)))
                            {
                                _marla = _marla + 1;
                                _yard = 0;
                            }
                            if (_marla == 20)
                            {
                                _kanal = _kanal + 1;
                                _marla = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _yard;
                            break;
                        }
                }
            }
            return areaValue;
        }

        private string AreaToFeet(string areaValue, int feetPerMarla)
        {
            string[] values = areaValue.Split('-');
            long Result = 0;
            if (values.GetUpperBound(0) == 2)
            {
                switch ((enAreaFormat)Convert.ToInt64(AreaFormatForExpose))
                {
                    case enAreaFormat.KanalMarlaFeet:
                        {
                            _kanal = Convert.ToInt64(values[0]);
                            _marla = Convert.ToInt64(values[1]);
                            _feet = Convert.ToInt64(values[2]);
                            break;
                        }
                    case enAreaFormat.KanalMarlaSarsai:
                        {
                            _kanal = Convert.ToInt64(values[0]);
                            _marla = Convert.ToInt64(values[1]);
                            _sarsai = Convert.ToInt64(values[2]);
                            _feet = Convert.ToInt64(Math.Round(((feetPerMarla / 9.0) * _sarsai), MidpointRounding.AwayFromZero));
                            break;
                        }
                    // Added by Syed Fareed on April 26, 2012.
                    // yard to feet
                    case enAreaFormat.KanalMarlaYard:
                        {
                            _kanal = Convert.ToInt64(values[0]);
                            _marla = Convert.ToInt64(values[1]);
                            _yard = Convert.ToInt64(values[2]);
                            _feet = Convert.ToInt64(Math.Round((_yard * 9.07), MidpointRounding.AwayFromZero));
                            break;
                        }
                }
            }
            else if (values.GetUpperBound(0) == 1)
            {
                _kanal = Convert.ToInt64(values[0]);
                _marla = Convert.ToInt64(values[1]);
            }
            else if (values.GetUpperBound(0) == 0)
            {
                if (feetPerMarla == 225)
                {
                    Result = Convert.ToInt64(Math.Round((Convert.ToDouble(values[0]) * 9.65 * 20 * feetPerMarla), MidpointRounding.AwayFromZero));
                }
                else if (feetPerMarla == 272)
                {
                    Result = Convert.ToInt64(values[0]) * 8 * 20 * feetPerMarla;
                }
            }

            Result = Result + (_kanal * 20 * feetPerMarla);
            Result = Result + (_marla * feetPerMarla);
            Result = Result + _feet;
            return Convert.ToString(Result);
        }

        #region Properties

        //public string Area
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(areaValue) && areaValue != ddlAreaFormat.Text)
        //        {
        //            return AreaToFeet(areaValue, FeetPerMarla);
        //        }
        //        else
        //            return "0";
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            areaValue = FeetToArea(Convert.ToInt64(value), FeetPerMarla, AreaFormat);
        //        }
        //    }
        //}

        //public string AreaStr
        //{
        //    get
        //    {
        //        return txtTotalArea.Text.Trim();
        //    }
        //    set
        //    {
        //        txtTotalArea.Text = value;
        //    }
        //}

        //public bool IsValidArea
        //{
        //    get
        //    {
        //        return ValidateArea();
        //    }
        //}

        //public bool EnableArea
        //{
        //    set
        //    {
        //        this.txtTotalArea.Enabled = value;
        //    }
        //}

        //public bool ShowAreaFormat
        //{
        //    set
        //    {
        //        this.ddlAreaFormat.Visible = value;
        //    }
        //}

        //public bool ShowAll
        //{
        //    set
        //    {
        //        this.ddlAreaFormat.Visible = value;
        //        this.txtTotalArea.Visible = value;
        //    }
        //}

        //public System.Drawing.Color BackColor
        //{
        //    set
        //    {
        //        this.txtTotalArea.BorderStyle = BorderStyle.FixedSingle;
        //        //txtTotalArea.BorderStyle = BorderStyle.Solid;
        //    }
        //}

        //public bool DefaultFormatOnly
        //{
        //    set
        //    {
        //        this.ddlAreaFormat.Visible = value;
        //    }
        //}

        //public short FeetPerMarla
        //{
        //    set
        //    {
        //        if (value > 0 && value <= short.MaxValue)
        //            _feetPerMarla = value;
        //        else
        //            _feetPerMarla = 0;
        //    }
        //    get
        //    {
        //        return _feetPerMarla;
        //    }
        //}

        //public enAreaFormat AreaFormat
        //{
        //    get
        //    {
        //        return _areaFormat;
        //    }
        //    set
        //    {
        //        _areaFormat = value;
        //        ddlAreaFormat.SelectedIndex = Convert.ToInt32(value);
        //        Variables.SetCue(txtTotalArea, ddlAreaFormat.Text);
        //        _areaFormat = (enAreaFormat)ddlAreaFormat.SelectedIndex;
        //    }
        //}

        //public short TabIndex
        //{
        //    get
        //    {
        //        return _tabIndex;
        //    }
        //    set
        //    {
        //        _tabIndex = value;
        //        txtTotalArea.TabIndex = (short)(value++);
        //        ddlAreaFormat.TabIndex = (short)(value++);

        //    }
        //}

        public string AreaFromFeet(Int64 feet, int feetPerMarla, enAreaFormat format)
        {
            string areaValue = "0";
            double result;
            //double kanal, marla, sarsai, result;

            if (feetPerMarla > 0 && feet > 0)
            {
                switch (format)
                {
                    case enAreaFormat.KanalMarlaFeet:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            //_feet = Convert.ToInt64(Math.Round(Convert.ToDouble(_feet) / Convert.ToDouble(feetPerMarla), MidpointRounding.AwayFromZero));

                            if (_feet == 1)
                            {
                                _marla = _marla + 1;
                                if (_marla == 20)
                                {
                                    _kanal = _kanal + 1;
                                    _marla = 0;
                                }
                                _feet = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _feet;
                            break;
                        }
                    case enAreaFormat.KanalMarlaSarsai:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            _sarsai = Convert.ToInt64(Math.Round((_feet / (feetPerMarla / 9.0)), MidpointRounding.AwayFromZero));

                            if (_sarsai == 9)
                            {
                                _marla = _marla + 1;
                                if (_marla == 20)
                                {
                                    _kanal = _kanal + 1;
                                    _marla = 0;
                                }
                                _sarsai = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _sarsai;
                            break;
                        }
                    case enAreaFormat.KanalMarla:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            //_marla = Convert.ToInt64(Math.Round(((Convert.ToDouble(feet) / feetPerMarla) % 20.0), MidpointRounding.AwayFromZero));
                            _marla = Convert.ToInt64(Math.Round(Math.Round(((Convert.ToDouble(feet) / feetPerMarla) % 20.0), 2), MidpointRounding.AwayFromZero));
                            //_marla = (feet / feetPerMarla) % 20;
                            if (_marla == 20)
                            {
                                _marla = 0;
                                _kanal = _kanal + 1;
                            }
                            areaValue = _kanal + "-" + _marla;
                            break;
                        }
                    case enAreaFormat.Acre:
                        {
                            if (feetPerMarla == 225)
                            {
                                result = Math.Round((feet / 9.65 / 20 / feetPerMarla), MidpointRounding.AwayFromZero);
                                _acre = Convert.ToInt64(result);
                            }
                            else if (feetPerMarla == 272)
                            {
                                result = Math.Round((feet / 8.0 / 20 / feetPerMarla), MidpointRounding.AwayFromZero);
                                _acre = Convert.ToInt64(result);
                            }

                            areaValue = _acre.ToString();
                            break;
                        }
                }
            }
            return areaValue;
        }

        #endregion
        private bool ValidateShare(string Share)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Share, "^[1-9]+[0-9]*[/][1-9]+[0-9]*$");
        }

        #region Utilities Functions

        private bool ValidateArea(string AreaValue)
        {
            if (AreaValue == string.Empty)
            {
                return true;
            }
            else if (Regex.IsMatch(AreaValue, "^[0-9--]*$"))
            {
                switch ((enAreaFormat)Convert.ToInt32(AreaFormatForExpose))
                {
                    case enAreaFormat.KanalMarlaFeet:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^((\d)+(-)(\d)+(-)(\d)+)$");
                        }
                    case enAreaFormat.KanalMarlaSarsai:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^((\d)+(-)(\d)+(-)(\d)+)$");
                        }
                    case enAreaFormat.KanalMarla:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^((\d)+(-)(\d)+)$");
                        }
                    case enAreaFormat.Acre:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^(\d+)$");
                        }
                    case enAreaFormat.KanalMarlaYard:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^((\d)+(-)(\d)+(-)(\d)+)$");
                        }
                }
            }

            return false;
        }


        #endregion

        #endregion
    }
}
