using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RDProject.GenClass;
using RD.BLL;
using RD.EL;
using RD.BLL.Setup;
using RD.BLL;
using RD.BLL.Territory;
using RD.EL.Territory;
using System.Text.RegularExpressions;

namespace RDProject
{
    public partial class frm_BasicInformation : Form
    {
        public static bool isClose = true;
        private int isUpdate = 0;
        eRegistryOperations oeRegistryOperations;
        bRegistryOperations obRegistryOperations;
        eRegistryOperations oeGeneralRegistryOperation = new eRegistryOperations();

        public frm_BasicInformation()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //textBox1.Text = maxRegNo().ToString();
            txtRegistryNo.Text = maxRegNo().ToString();
            loadRegistryType();
            clsCulture.Localize(this, Variables.language);
        }

        private void renderGridColumn()
        {
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
        }

        private void frm_BasicInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClose = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (oeGeneralRegistryOperation.Registry_id != Guid.Empty)
            {

                oeRegistryOperations = new eRegistryOperations();
                obRegistryOperations = new bRegistryOperations();
                oeRegistryOperations.Registry_id = oeGeneralRegistryOperation.Registry_id;
                updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
                deleteInfo = obRegistryOperations.deleteRegistryOperations(oeRegistryOperations);
                if (deleteInfo.Success)
                {
                    MessageBox.Show("Record deleted successfully");
                    resetFields();
                    txtRegistryNo.Text = maxRegNo().ToString();
                }
                else
                {
                    MessageBox.Show("There is some error to delete record");
                    resetFields();
                    txtRegistryNo.Text = maxRegNo().ToString();
                }
            }
            else
            {
                MessageBox.Show("Please enter registry number to delete");
                txtSearchRegistry.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            obRegistryOperations = new bRegistryOperations();
            oeRegistryOperations = new eRegistryOperations();
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (isFieldEmpty())
            {
                if (isUpdate != 0)
                {
                    oeRegistryOperations.Registry_id = oeGeneralRegistryOperation.Registry_id;
                    oeRegistryOperations.Mauza_id = oeGeneralRegistryOperation.Mauza_id;
                    oeRegistryOperations.Service_centre_id = oeGeneralRegistryOperation.Service_centre_id;
                    oeRegistryOperations.Subregistrar_id = oeGeneralRegistryOperation.Subregistrar_id;
                    oeRegistryOperations.Registry_type_id = new Guid(ddlRegistryType.SelectedValue.ToString());
                    oeRegistryOperations.Registry_no = txtRegistryNo.Text.Trim();
                    oeRegistryOperations.Bahi_no = txtBahiNumber.Text.Trim();
                    oeRegistryOperations.Jild_no = txtJildNumber.Text.Trim();
                    oeRegistryOperations.Doc_number = txtDocumentNumber.Text.Trim();
                    oeRegistryOperations.Registry_fee = oeGeneralRegistryOperation.Registry_fee;
                    oeRegistryOperations.Tma_fee = oeGeneralRegistryOperation.Tma_fee;
                    oeRegistryOperations.District_council_fee = oeGeneralRegistryOperation.District_council_fee;
                    oeRegistryOperations.Challan_fee = oeGeneralRegistryOperation.Challan_fee;
                    oeRegistryOperations.Selling_price = oeGeneralRegistryOperation.Selling_price;
                    oeRegistryOperations.Amount = Convert.ToInt32(txtAmount.Text.Trim());
                    oeRegistryOperations.Is_active = oeGeneralRegistryOperation.Is_active;
                    oeRegistryOperations.Remarks = oeGeneralRegistryOperation.Remarks;
                    oeRegistryOperations.User_id = new Guid("8522A212-073D-478F-95DA-D5CA6E6166EE");
                    oeRegistryOperations.Access_datetime = DateTime.Now;
                    insertInfo = obRegistryOperations.udpateRegistryOperations(oeRegistryOperations);
                    if (insertInfo.Success)
                    {

                        MessageBox.Show("Record successfully updated", "Record updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRegistryNo.Text = maxRegNo().ToString();
                        resetFields();
                        isUpdate = 0;
                    }
                    else
                    {
                        MessageBox.Show("Record Not updated", "Record updated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //oeRegistryOperations.Registry_id = Guid.NewGuid();
                    oeRegistryOperations.Mauza_id = new Guid("844965F7-CEEE-4E63-9372-1909BCC6A96B");
                    oeRegistryOperations.Service_centre_id = null;
                    oeRegistryOperations.Subregistrar_id = null;
                    oeRegistryOperations.Registery_stage = 0;
                    oeRegistryOperations.Registry_type_id = new Guid(ddlRegistryType.SelectedValue.ToString());
                    oeRegistryOperations.Registry_no = txtRegistryNo.Text.Trim();
                    oeRegistryOperations.Bahi_no = txtBahiNumber.Text.Trim();
                    oeRegistryOperations.Jild_no = txtJildNumber.Text.Trim();
                    oeRegistryOperations.Doc_number = txtDocumentNumber.Text.Trim();
                    oeRegistryOperations.Registry_fee = null;
                    oeRegistryOperations.Tma_fee = null;
                    oeRegistryOperations.District_council_fee = null;
                    oeRegistryOperations.Challan_fee = null;
                    oeRegistryOperations.Selling_price = null;
                    oeRegistryOperations.Amount = ValidateFields.GetSafeInteger(txtAmount.Text.Trim());
                    oeRegistryOperations.Is_active = true;
                    oeRegistryOperations.Remarks = "";

                    oeRegistryOperations.User_id = new Guid("8522A212-073D-478F-95DA-D5CA6E6166EE");
                    oeRegistryOperations.Access_datetime = DateTime.Now;
                    insertInfo = obRegistryOperations.insertRegistryOperations(oeRegistryOperations);
                    if (insertInfo.Success)
                    {
                        MessageBox.Show("Record successfully entered", "Record Entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRegistryNo.Text = maxRegNo().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Record Not entered", "Record Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool isFieldEmpty()
        {
            bool isEmpty = true;
            if (string.IsNullOrEmpty(txtRegistryNo.Text))
            {
                isEmpty = false;
                txtRegistryNo.Focus();
                controlEmptyBackColor(txtRegistryNo);
                return isEmpty;
            }
            else
            {
                controlNormalBackColor(txtRegistryNo);
            }

            if (ddlRegistryType.SelectedIndex == 0)
            {
                isEmpty = false;
                ddlRegistryType.Focus();
                controlEmptyBackColor(ddlRegistryType);
                return isEmpty;
            }
            else
            {
                controlNormalBackColor(ddlRegistryType);
            }

            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                isEmpty = false;
                txtAmount.Focus();
                controlEmptyBackColor(txtAmount);
                return isEmpty;
            }
            else
            {
                controlNormalBackColor(txtAmount);
            }

            if (string.IsNullOrEmpty(txtDocumentNumber.Text))
            {
                isEmpty = false;
                txtDocumentNumber.Focus();
                controlEmptyBackColor(txtDocumentNumber);
                return isEmpty;
            }
            else
            {
                controlNormalBackColor(txtDocumentNumber);
            }

            if (string.IsNullOrEmpty(txtBahiNumber.Text))
            {
                isEmpty = false;
                txtBahiNumber.Focus();
                controlEmptyBackColor(txtBahiNumber);
                return isEmpty;
            }
            else
            {
                controlNormalBackColor(txtBahiNumber);
            }

            if (string.IsNullOrEmpty(txtJildNumber.Text))
            {
                isEmpty = false;
                txtJildNumber.Focus();
                controlEmptyBackColor(txtJildNumber);
                return isEmpty;
            }
            else
            {
                controlNormalBackColor(txtJildNumber);
            }            

            if (true)
            {
                
            }


            return isEmpty;
        }

        private void controlEmptyBackColor(Control objCon)
        {
            objCon.BackColor = Color.Pink;
        }

        private void controlNormalBackColor(Control objCon)
        {
            objCon.BackColor = Color.FromArgb(233, 240, 249);
        }

        private void frm_BasicInformation_Load(object sender, EventArgs e)
        {
            loadDistrict();
            SCOGridColumns();
            bindSCOInboxGrid();
            txtRegistryNo.Text = maxRegNo().ToString();
            loadRegistryType();
            fillColumnGridOfTransferArea();
            fillColumnGridOfMushtari();
            BindTransferAreaGrid();
            fillCasteComboBox(null);
            BindPersonGrid();
            tabCaption();
        }

        private void tabCaption()
        {

            for (int i = 0; i < tabBasicInformation.TabPages.Count; i++)
			{
                switch (tabBasicInformation.TabPages[i].Name)
                {
                    case "tabMushtari":
                        tabBasicInformation.TabPages[i].Text = clsCulture.GetLocalizedString("tabMushtari", frm_MainMDI.language);
                        break;
                    case "tabTransfer":
                        tabBasicInformation.TabPages[i].Text = clsCulture.GetLocalizedString("tabTransfer", frm_MainMDI.language);
                        break;
                    case "tabScanning":
                        tabBasicInformation.TabPages[i].Text = clsCulture.GetLocalizedString("tabScanning", frm_MainMDI.language);
                        break;
                    case "tabFard":
                        tabBasicInformation.TabPages[i].Text = clsCulture.GetLocalizedString("tabFard", frm_MainMDI.language);
                        break;
                    default:
                        break;
                }
                //tabBasicInformation.TabPages[i].Name = "";
			}
            
        }

        private void BindTransferAreaGrid()
        {
            bKhasra obKhasra = new bKhasra();
            eKhasra oeKhasra = new eKhasra();
            List<eKhasra> oeListKhasra = new List<eKhasra>();
            oeListKhasra = obKhasra.getKhasra(oeKhasra, "", "", 0, int.MaxValue);
            if (oeListKhasra != null && oeListKhasra.Count > 0)
            {                
                for (int i = 0; i < oeListKhasra.Count; i++)
                {                    
                    grdTransferArea.Rows.Add();
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colKhasraId"].Value = oeListKhasra[i].Khasra_id;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colKhewatNo"].Value = oeListKhasra[i].Khewat_no;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colKhatuniNo"].Value = oeListKhasra[i].Khatuni_no;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colKhasraNo"].Value = oeListKhasra[i].Khasra_no;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colKhasraTotalArea"].Value = oeListKhasra[i].Khasra_total_area;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colTransferredArea"].Value = oeListKhasra[i].Transferred_area;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colKhasraTotalShare"].Value = oeListKhasra[i].Khasra_total_share;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colTransferredShare"].Value = oeListKhasra[i].Transferred_share;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colPrintSequenceNo"].Value = oeListKhasra[i].Print_sequence_no;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colIsActive"].Value = oeListKhasra[i].Is_active;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colEast"].Value = oeListKhasra[i].East;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colWest"].Value = oeListKhasra[i].West;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colNorth"].Value = oeListKhasra[i].North;
                    grdTransferArea.Rows[grdTransferArea.Rows.Count - 1].Cells["colSouth"].Value = oeListKhasra[i].South;
                }
            }
        }

        private void BindPersonGrid()
        {
            bPerson obPerson = new bPerson();
            ePerson oePerson = new ePerson();
            List<ePerson> oeListPerson = new List<ePerson>();
            oeListPerson = obPerson.getPerson(oePerson, "", "", 0,int.MaxValue);
            if (oeListPerson != null && oeListPerson.Count > 0)
            {
                for (int i = 0; i < oeListPerson.Count; i++)
                {
                    grdPerson.Rows.Add();
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colPersonId"].Value = oeListPerson[i].Person_id;
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colMauzaId"].Value = oeListPerson[i].Mauza_id;
                    if (frm_MainMDI.language == "en")
                    {
                        grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colFirstNameEng"].Value = oeListPerson[i].First_name_eng.Replace("\0","");
                        grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colLastNameEng"].Value = oeListPerson[i].Last_name_eng.Replace("\0", "");
                        grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colAddressEng"].Value = oeListPerson[i].Address_eng.Replace("\0", "");
                    }
                    else if (frm_MainMDI.language == "ur")
                    {
                        grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colFirstNameUrd"].Value = oeListPerson[i].First_name_urd;
                        grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colLastNameUrd"].Value = oeListPerson[i].Last_name_urd;
                        grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colAddressUrd"].Value = oeListPerson[i].Address_urd;
                    }
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colNIC"].Value = oeListPerson[i].Nic.Replace("\0", "");
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colCaste"].Value = oeListPerson[i].Caste_id;
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colIsGovt"].Value = oeListPerson[i].Is_govt;
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colIsDepartment"].Value = oeListPerson[i].Is_department;
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colIsKashmiri"].Value = oeListPerson[i].Is_kashmiri;
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colThumb"].Value = oeListPerson[i].Thumb;
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colPicPath"].Value = oeListPerson[i].Pic_path.Replace("\0", "");
                }
            }
        }

        private void fillColumnGridOfMushtari()
        {
            DataGridViewTextBoxColumn dgvPersonId = new DataGridViewTextBoxColumn();
            dgvPersonId.Name = "colPersonId";
            dgvPersonId.Visible = false;
            grdPerson.Columns.Add(dgvPersonId);

            DataGridViewTextBoxColumn dgvMauzaId = new DataGridViewTextBoxColumn();
            dgvMauzaId.Name = "colMauzaId";
            dgvMauzaId.Visible = false;
            grdPerson.Columns.Add(dgvMauzaId);

            if (frm_MainMDI.language == "en")
            {
                DataGridViewTextBoxColumn dgvFirstNameEng = new DataGridViewTextBoxColumn();
                dgvFirstNameEng.HeaderText = clsCulture.GetLocalizedString("colFirstName", frm_MainMDI.language);// "First Name (English)";
                dgvFirstNameEng.Name = "colFirstNameEng";
                grdPerson.Columns.Add(dgvFirstNameEng);

                DataGridViewTextBoxColumn dgvLastNameEng = new DataGridViewTextBoxColumn();
                dgvLastNameEng.HeaderText = clsCulture.GetLocalizedString("colLastName", frm_MainMDI.language);// "Last Name (English)";
                dgvLastNameEng.Name = "colLastNameEng";
                grdPerson.Columns.Add(dgvLastNameEng);

                DataGridViewTextBoxColumn dgvAddressEng = new DataGridViewTextBoxColumn();
                dgvAddressEng.HeaderText = clsCulture.GetLocalizedString("colAddress", frm_MainMDI.language);// "Address (English)";
                dgvAddressEng.Name = "colAddressEng";
                grdPerson.Columns.Add(dgvAddressEng);
            }
            else if (frm_MainMDI.language == "ur")
            {
                DataGridViewTextBoxColumn dgvFirstNameUrd = new DataGridViewTextBoxColumn();
                dgvFirstNameUrd.HeaderText = clsCulture.GetLocalizedString("colFirstName", frm_MainMDI.language); //"First Name (Urdu)";
                dgvFirstNameUrd.Name = "colFirstNameUrd";
                grdPerson.Columns.Add(dgvFirstNameUrd);

                DataGridViewTextBoxColumn dgvLastNameUrd = new DataGridViewTextBoxColumn();
                dgvLastNameUrd.HeaderText = clsCulture.GetLocalizedString("colLastName", frm_MainMDI.language); //"Last Name (Urdu)";
                dgvLastNameUrd.Name = "colLastNameUrd";
                grdPerson.Columns.Add(dgvLastNameUrd);

                DataGridViewTextBoxColumn dgvAddressUrd = new DataGridViewTextBoxColumn();
                dgvAddressUrd.HeaderText = clsCulture.GetLocalizedString("colAddress", frm_MainMDI.language);//"Address (Urdu)";
                dgvAddressUrd.Name = "colAddressUrd";
                grdPerson.Columns.Add(dgvAddressUrd);
            }
            DataGridViewTextBoxColumn dgvNIC = new DataGridViewTextBoxColumn();
            dgvNIC.HeaderText = clsCulture.GetLocalizedString("colNIC", frm_MainMDI.language);//"NIC";
            dgvNIC.Name = "colNIC";
            dgvNIC.MaxInputLength = 15;
            grdPerson.Columns.Add(dgvNIC);

            DataGridViewComboBoxColumn dgvCaste = new DataGridViewComboBoxColumn();
            dgvCaste.HeaderText = clsCulture.GetLocalizedString("colCaste", frm_MainMDI.language);//"Caste";
            dgvCaste.Name = "colCaste";
            grdPerson.Columns.Add(dgvCaste);

            DataGridViewCheckBoxColumn dgvIsGovt = new DataGridViewCheckBoxColumn();
            dgvIsGovt.HeaderText = clsCulture.GetLocalizedString("colIsGovt", frm_MainMDI.language);//"Is Govt";
            dgvIsGovt.Name = "colIsGovt";
            grdPerson.Columns.Add(dgvIsGovt);

            DataGridViewCheckBoxColumn dgvIsDepartment = new DataGridViewCheckBoxColumn();
            dgvIsDepartment.HeaderText = clsCulture.GetLocalizedString("colIsDepartment", frm_MainMDI.language);//"Is Department";
            dgvIsDepartment.Name = "colIsDepartment";
            grdPerson.Columns.Add(dgvIsDepartment);

            DataGridViewCheckBoxColumn dgvIsKashmiri = new DataGridViewCheckBoxColumn();
            dgvIsKashmiri.HeaderText = clsCulture.GetLocalizedString("colIsKashmiri", frm_MainMDI.language);//"Is Kashmiri";
            dgvIsKashmiri.Name = "colIsKashmiri";
            grdPerson.Columns.Add(dgvIsKashmiri);

            DataGridViewTextBoxColumn dgvThumb = new DataGridViewTextBoxColumn();
            dgvThumb.HeaderText = clsCulture.GetLocalizedString("colThumb", frm_MainMDI.language);//"Thumb";
            dgvThumb.Name = "colThumb";
            grdPerson.Columns.Add(dgvThumb);

            DataGridViewButtonColumn dgvPicPath = new DataGridViewButtonColumn();
            dgvPicPath.HeaderText = clsCulture.GetLocalizedString("colPicPath", frm_MainMDI.language);//"Picture Path";
            dgvPicPath.Name = "colPicPath";
            grdPerson.Columns.Add(dgvPicPath);

        }

        private void fillColumnGridOfTransferArea()
        {
            DataGridViewTextBoxColumn dgvKhasraId = new DataGridViewTextBoxColumn();
            dgvKhasraId.Name = "colKhasraId";
            dgvKhasraId.Visible = false;
            grdTransferArea.Columns.Add(dgvKhasraId);

            DataGridViewTextBoxColumn dgvKhewatNo = new DataGridViewTextBoxColumn();
            dgvKhewatNo.HeaderText = "Khewat No";
            dgvKhewatNo.Name = "colKhewatNo";
            grdTransferArea.Columns.Add(dgvKhewatNo);

            DataGridViewTextBoxColumn dgvKhatuniNo = new DataGridViewTextBoxColumn();
            dgvKhatuniNo.HeaderText = "Khatuni No";
            dgvKhatuniNo.Name = "colKhatuniNo";
            grdTransferArea.Columns.Add(dgvKhatuniNo);

            DataGridViewTextBoxColumn dgvKhasraNo = new DataGridViewTextBoxColumn();
            dgvKhasraNo.HeaderText = "Khasra No";
            dgvKhasraNo.Name = "colKhasraNo";
            grdTransferArea.Columns.Add(dgvKhasraNo);

            DataGridViewTextBoxColumn dgvKhasraTotalArea = new DataGridViewTextBoxColumn();
            dgvKhasraTotalArea.HeaderText = "Khasra Total Area";
            dgvKhasraTotalArea.Name = "colKhasraTotalArea";
            grdTransferArea.Columns.Add(dgvKhasraTotalArea);

            DataGridViewTextBoxColumn dgvTransferredArea = new DataGridViewTextBoxColumn();
            dgvTransferredArea.HeaderText = "Transferred Area";
            dgvTransferredArea.Name = "colTransferredArea";
            grdTransferArea.Columns.Add(dgvTransferredArea);

            DataGridViewTextBoxColumn dgvKhasraTotalShare = new DataGridViewTextBoxColumn();
            dgvKhasraTotalShare.HeaderText = "Khasra Total Share";
            dgvKhasraTotalShare.Name = "colKhasraTotalShare";
            grdTransferArea.Columns.Add(dgvKhasraTotalShare);

            DataGridViewTextBoxColumn dgvTransferredShare = new DataGridViewTextBoxColumn();
            dgvTransferredShare.HeaderText = "Transferred Share";
            dgvTransferredShare.Name = "colTransferredShare";
            grdTransferArea.Columns.Add(dgvTransferredShare);

            DataGridViewTextBoxColumn dgvPrintSequenceNo = new DataGridViewTextBoxColumn();
            dgvPrintSequenceNo.HeaderText = "Print Sequence No";
            dgvPrintSequenceNo.Name = "colPrintSequenceNo";
            grdTransferArea.Columns.Add(dgvPrintSequenceNo);

            DataGridViewCheckBoxColumn dgvIsActive = new DataGridViewCheckBoxColumn();
            dgvIsActive.HeaderText = "is active";
            dgvIsActive.Name = "colIsActive";
            grdTransferArea.Columns.Add(dgvIsActive);

            DataGridViewTextBoxColumn dgvEast = new DataGridViewTextBoxColumn();
            dgvEast.HeaderText = "East";
            dgvEast.Name = "colEast";
            grdTransferArea.Columns.Add(dgvEast);

            DataGridViewTextBoxColumn dgvWest = new DataGridViewTextBoxColumn();
            dgvWest.HeaderText = "West";
            dgvWest.Name = "colWest";
            grdTransferArea.Columns.Add(dgvWest);

            DataGridViewTextBoxColumn dgvNorth = new DataGridViewTextBoxColumn();
            dgvNorth.HeaderText = "North";
            dgvNorth.Name = "colNorth";
            grdTransferArea.Columns.Add(dgvNorth);

            DataGridViewTextBoxColumn dgvSouth = new DataGridViewTextBoxColumn();
            dgvSouth.HeaderText = "South";
            dgvSouth.Name = "colSouth";
            grdTransferArea.Columns.Add(dgvSouth);

        }

        private int maxRegNo()
        {
            int regNo = -1;
            string strQry = "SELECT ISNULL(MAX(rd.RegistryOperations.registry_no),0) +1 AS MaxReg FROM rd.RegistryOperations";
            bRegistryOperations obRegistryOperations = new bRegistryOperations();
            regNo = obRegistryOperations.maxRegNo(strQry);
            return regNo;
        }

        private void loadRegistryType()
        {
            eRegistryType oeRegistryType = new eRegistryType();
            bRegistryType obRegistryType = new bRegistryType();
            List<eRegistryType> oeListRegistryType = new List<eRegistryType>();
            oeListRegistryType = obRegistryType.getRegistryType(oeRegistryType, "", "", 0, 10);
            if (oeListRegistryType != null && oeListRegistryType.Count > 0)
            {
                ddlRegistryType.ValueMember = "Registry_type_id";
                Common.setSourceLanguage(ddlRegistryType, "Registry_type_description_eng", "Registry_type_description_urd", frm_MainMDI.language);
                ddlRegistryType.DataSource = oeListRegistryType;
            }
        }

        private void txtSearchRegistry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtRegistryNo.Text))
                {
                    string strQry = "SELECT * FROM rd.RegistryOperations WHERE registry_no = '" + txtSearchRegistry.Text.Trim() + "'";
                    bRegistryOperations obRegistryOperations = new bRegistryOperations();
                    List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
                    oeListRegistryOperations = obRegistryOperations.searchRegistryNo(strQry);
                    if (oeListRegistryOperations != null && oeListRegistryOperations.Count == 1)
                    {
                        txtRegistryNo.Text = oeListRegistryOperations[0].Registry_no;
                        ddlRegistryType.SelectedValue = oeListRegistryOperations[0].Registry_type_id;
                        txtAmount.Text = oeListRegistryOperations[0].Amount.ToString();
                        txtDocumentNumber.Text = oeListRegistryOperations[0].Doc_number.ToString();
                        txtBahiNumber.Text = oeListRegistryOperations[0].Bahi_no.ToString();
                        txtJildNumber.Text = oeListRegistryOperations[0].Jild_no.ToString();
                        oeGeneralRegistryOperation = oeListRegistryOperations[0];
                        isUpdate = 1;
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid registry number");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter registry number");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void resetFields()
        {
            txtSearchRegistry.Text = string.Empty;
            txtRegistryNo.Text = maxRegNo().ToString();
            ddlRegistryType.SelectedIndex = 0;
            txtAmount.Text = string.Empty;
            txtDocumentNumber.Text = string.Empty;
            txtBahiNumber.Text = string.Empty;
            txtJildNumber.Text = string.Empty;
            isUpdate = 0;
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            grdTransferArea.Rows.Add();
        }

        private void btnTransferRecordDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (this.grdTransferArea.SelectedCells.Count > 0)
                {
                    eKhasra oelKhasra = new eKhasra();
                    updatedNewEntryInfo info = new updatedNewEntryInfo();
                    DataGridViewRow objR = grdTransferArea.Rows[grdTransferArea.SelectedCells[0].RowIndex];
                    if (objR.Cells["colKhasraId"].Value!= null && objR.Cells["colKhasraId"].Value != "")
                    {
                        oelKhasra.Khasra_id = (Guid)objR.Cells["colKhasraId"].Value;
                        bKhasra obj = new bKhasra();
                        info = obj.deleteKhasra(oelKhasra);
                        if (info.Success)
                        {
                            MessageBox.Show("Record Deleted Successfully.");
                        }
                    }
                    this.grdTransferArea.Rows.RemoveAt(this.grdTransferArea.SelectedCells[0].RowIndex);
                }
            }
        }

        private void grdTransferArea_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string headerText = grdTransferArea.Columns[e.ColumnIndex].HeaderText;
            string KhewatNo = grdTransferArea["colKhewatNo", e.RowIndex].EditedFormattedValue.ToString();
            string KhatuniNo = grdTransferArea["colKhatuniNo", e.RowIndex].EditedFormattedValue.ToString();
            string KhasraNo = grdTransferArea["colKhasraNo", e.RowIndex].EditedFormattedValue.ToString();
            string KhasraTotalArea = grdTransferArea["colKhasraTotalArea", e.RowIndex].EditedFormattedValue.ToString();
            string TransferredArea = grdTransferArea["colTransferredArea", e.RowIndex].EditedFormattedValue.ToString();
            string KhasraTotalShare = grdTransferArea["colKhasraTotalShare", e.RowIndex].EditedFormattedValue.ToString();
            string TransferredShare = grdTransferArea["colTransferredShare", e.RowIndex].EditedFormattedValue.ToString();
            string PrintSequenceNo = grdTransferArea["colPrintSequenceNo", e.RowIndex].EditedFormattedValue.ToString();
            string IsActive = grdTransferArea["colIsActive", e.RowIndex].EditedFormattedValue.ToString();
            string East = grdTransferArea["colEast", e.RowIndex].EditedFormattedValue.ToString();
            string West = grdTransferArea["colWest", e.RowIndex].EditedFormattedValue.ToString();
            string North = grdTransferArea["colNorth", e.RowIndex].EditedFormattedValue.ToString();
            string South = grdTransferArea["colSouth", e.RowIndex].EditedFormattedValue.ToString();
            //if (!headerText.Equals("District Name")) return;

            try
            {
                if (grdTransferArea.IsCurrentRowDirty)
                {
                    updatedNewEntryInfo info = new updatedNewEntryInfo();
                    DataGridViewRow dgvwCurRow = grdTransferArea.Rows[e.RowIndex];
                    eKhasra oelKhasra = new eKhasra();
                    long nLong;
                    int printSeq;
                    bool isAct;
                    //if (string.IsNullOrEmpty(DistrictName_eng))
                    //{
                    //    grdTransferArea.Rows[e.RowIndex].ErrorText = "District Name must not be empty";
                    //    //lblStatus.Text = "District Name must not be empty";
                    //    e.Cancel = true;
                    //    return;
                    //}

                    //if (string.IsNullOrEmpty(DistrictName_urd))
                    //{
                    //    grdTransferArea.Rows[e.RowIndex].ErrorText = "District Name must not be empty";
                    //    //lblStatus.Text = "District Name must not be empty";
                    //    e.Cancel = true;
                    //    return;
                    //}
                    string KhasraId = grdTransferArea["colKhasraId", e.RowIndex].EditedFormattedValue.ToString();
                    if (KhasraId == string.Empty)
                    {
                        
                        dgvwCurRow.Cells["colKhasraId"].Value = Guid.NewGuid();

                        string sTotArea = (string)dgvwCurRow.Cells["colKhasraTotalArea"].Value;                        
                        nLong = (string.IsNullOrEmpty(sTotArea)) ? 0 : Convert.ToInt64(sTotArea);

                        oelKhasra.Khasra_id = (Guid)dgvwCurRow.Cells["colKhasraId"].Value;
                        oelKhasra.Khewat_no = (string)dgvwCurRow.Cells["colKhewatNo"].Value;
                        oelKhasra.Khatuni_no = (string)dgvwCurRow.Cells["colKhatuniNo"].Value;
                        oelKhasra.Khasra_no = (string)dgvwCurRow.Cells["colKhasraNo"].Value;
                        oelKhasra.Khasra_total_area = nLong;
                        sTotArea = (string)dgvwCurRow.Cells["colTransferredArea"].Value;
                        nLong = (string.IsNullOrEmpty(sTotArea)) ? 0 : Convert.ToInt64(sTotArea);
                        oelKhasra.Transferred_area = nLong;
                        oelKhasra.Khasra_total_share = (string)dgvwCurRow.Cells["colKhasraTotalShare"].Value;
                        oelKhasra.Transferred_share = (string)dgvwCurRow.Cells["colTransferredShare"].Value;

                        sTotArea = (string)dgvwCurRow.Cells["colPrintSequenceNo"].Value;
                        printSeq = (string.IsNullOrEmpty(sTotArea)) ? 0 : Convert.ToInt32(sTotArea);

                        oelKhasra.Print_sequence_no = printSeq; // (DBNull.Value.Equals(dgvwCurRow.Cells["colPrintSequenceNo"].Value)) ? 0 : (int)(dgvwCurRow.Cells["colPrintSequenceNo"]).Value;//(int)dgvwCurRow.Cells["colPrintSequenceNo"].Value;

                        sTotArea = (string)dgvwCurRow.Cells["colIsActive"].Value;
                        isAct = (sTotArea == null || sTotArea.ToUpper() == "FALSE") ? false : true;

                        oelKhasra.Is_active = isAct;// (bool)dgvwCurRow.Cells["colIsActive"].Value;
                        oelKhasra.East = (string)dgvwCurRow.Cells["colEast"].Value;
                        oelKhasra.West = (string)dgvwCurRow.Cells["colWest"].Value;
                        oelKhasra.North = (string)dgvwCurRow.Cells["colNorth"].Value;
                        oelKhasra.South = (string)dgvwCurRow.Cells["colSouth"].Value;
                        oelKhasra.User_id = new Guid("8522A212-073D-478F-95DA-D5CA6E6166EE");
                        oelKhasra.Access_date_time = DateTime.Now;
                        bKhasra obj = new bKhasra();
                        info = obj.insertKhasra(oelKhasra);
                        if (info.Success)
                        {
                            //lblStatus.Text = "Record Added Successfully.";
                        }
                    }
                    else
                    {
                        string sTotArea = string.Empty;
                        if (dgvwCurRow.Cells["colKhasraTotalArea"].Value != null)
                        {
                            nLong = (long)dgvwCurRow.Cells["colKhasraTotalArea"].Value;
                            sTotArea = nLong.ToString();
                        }
                        else
                            sTotArea = (string)dgvwCurRow.Cells["colKhasraTotalArea"].Value;
                        nLong = (string.IsNullOrEmpty(sTotArea)) ? 0 : Convert.ToInt64(sTotArea); 

                        oelKhasra.Khasra_id = (Guid)dgvwCurRow.Cells["colKhasraId"].Value;
                        oelKhasra.Khewat_no = (string)dgvwCurRow.Cells["colKhewatNo"].Value;
                        oelKhasra.Khatuni_no = (string)dgvwCurRow.Cells["colKhatuniNo"].Value;
                        oelKhasra.Khasra_no = (string)dgvwCurRow.Cells["colKhasraNo"].Value;
                        oelKhasra.Khasra_total_area = nLong;

                        if (dgvwCurRow.Cells["colTransferredArea"].Value != null)
                        {
                            sTotArea = (string)dgvwCurRow.Cells["colTransferredArea"].Value;
                            sTotArea = nLong.ToString();
                        }
                        else
                            sTotArea = (string)dgvwCurRow.Cells["colTransferredArea"].Value;
                        nLong = (string.IsNullOrEmpty(sTotArea)) ? 0 : Convert.ToInt64(sTotArea);

                        oelKhasra.Transferred_area = nLong;// (long)dgvwCurRow.Cells["colTransferredArea"].Value;
                        oelKhasra.Khasra_total_share = (string)dgvwCurRow.Cells["colKhasraTotalShare"].Value;
                        oelKhasra.Transferred_share = (string)dgvwCurRow.Cells["colTransferredShare"].Value;

                        if (dgvwCurRow.Cells["colPrintSequenceNo"].Value != null)
                        {
                            printSeq = (int)dgvwCurRow.Cells["colPrintSequenceNo"].Value;
                            sTotArea = printSeq.ToString();
                        }
                        else
                            sTotArea = (string)dgvwCurRow.Cells["colPrintSequenceNo"].Value;
                        printSeq = (string.IsNullOrEmpty(sTotArea)) ? 0 : Convert.ToInt32(sTotArea);
                        oelKhasra.Print_sequence_no = printSeq;

                        if (dgvwCurRow.Cells["colIsActive"].Value != null)
                        {
                            isAct = (dgvwCurRow.Cells["colIsActive"].Value == "false") ? false : true;
                            sTotArea = isAct.ToString();
                        }
                        else
                            sTotArea = (string)dgvwCurRow.Cells["colIsActive"].Value;

                        isAct = (sTotArea == null || sTotArea.ToUpper() == "FALSE") ? false : true;

                        oelKhasra.Is_active = isAct;// (bool)dgvwCurRow.Cells["colIsActive"].Value;
                        oelKhasra.East = (string)dgvwCurRow.Cells["colEast"].Value;
                        oelKhasra.West = (string)dgvwCurRow.Cells["colWest"].Value;
                        oelKhasra.North = (string)dgvwCurRow.Cells["colNorth"].Value;
                        oelKhasra.South = (string)dgvwCurRow.Cells["colSouth"].Value;
                        oelKhasra.User_id = new Guid("8522A212-073D-478F-95DA-D5CA6E6166EE");
                        oelKhasra.Access_date_time = DateTime.Now;
                        bKhasra obj = new bKhasra();
                        info = obj.udpateKhasra(oelKhasra);
                        if (info.Success)
                        {
                            //lblStatus.Text = "Record Updated Successfully.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught : " + ex.Message.ToString());
                e.Cancel = true;
                grdTransferArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
            finally
            {

                //lblStatus.Text = string.Empty;
            }
        }
        
        private void grdTransferArea_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.grdTransferArea.RowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 206); //Color.Bisque;
            this.grdTransferArea.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 250);
        }

        private void grdTransferArea_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            grdTransferArea[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(255, 100, 140);
        }

        private void grdPerson_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            grdPerson[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(255, 100, 140);
        }

        private void grdPerson_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.grdPerson.RowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 206); //Color.Bisque;
            this.grdPerson.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 250);
            if (e.ColumnIndex == 11)
            {
                e.Value = clsCulture.GetLocalizedString("displayPic", frm_MainMDI.language);// "Show";
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            grdPerson.Rows.Add();
        }

        private void grdPerson_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (grdPerson.IsCurrentRowDirty)
                {
                    DataGridViewRow dgvwCurRow = grdPerson.Rows[e.RowIndex];
                    int rowIndex = e.RowIndex;
                    insertUpdatePersonGrid(dgvwCurRow, rowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught : " + ex.Message.ToString());
                e.Cancel = true;
                grdPerson.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
            finally
            {
                //lblStatus.Text = string.Empty;
            }
        }

        private void insertUpdatePersonGrid(DataGridViewRow dgvwCurRow, int rowIndex)
        {
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            ePerson oePerson = new ePerson();
            bPerson obj = new bPerson();
            //oePerson.Mauza_id = (Guid)dgvwCurRow.Cells["colMauzaId"].Value;
            oePerson.Mauza_id = new Guid("844965F7-CEEE-4E63-9372-1909BCC6A96B");
            if (frm_MainMDI.language == "en")
            {
                oePerson.First_name_eng = (string)dgvwCurRow.Cells["colFirstNameEng"].Value;
                oePerson.Last_name_eng = (string)dgvwCurRow.Cells["colLastNameEng"].Value;
                oePerson.Address_eng = (string)dgvwCurRow.Cells["colAddressEng"].Value;
            }
            else if (frm_MainMDI.language == "ur")
            {
                oePerson.First_name_urd = (string)dgvwCurRow.Cells["colFirstNameUrd"].Value;
                oePerson.Last_name_urd = (string)dgvwCurRow.Cells["colLastNameUrd"].Value;
                oePerson.Address_urd = (string)dgvwCurRow.Cells["colAddressUrd"].Value;
            }
            oePerson.Nic = ValidateFields.GetSafeString(dgvwCurRow.Cells["colNIC"].Value);
            oePerson.Caste_id = ValidateFields.GetSafeGuid(dgvwCurRow.Cells["colCaste"].Value);
            string sBoolVal = ValidateFields.GetSafeString(dgvwCurRow.Cells["colIsGovt"].Value);
            oePerson.Is_govt = (string.IsNullOrEmpty(sBoolVal) || sBoolVal.ToUpper() == "FALSE") ? false : true;
            sBoolVal = ValidateFields.GetSafeString(dgvwCurRow.Cells["colIsDepartment"].Value);
            oePerson.Is_department = (string.IsNullOrEmpty(sBoolVal) || sBoolVal.ToUpper() == "FALSE") ? false : true;
            sBoolVal = ValidateFields.GetSafeString(dgvwCurRow.Cells["colIsKashmiri"].Value);
            oePerson.Is_kashmiri = (string.IsNullOrEmpty(sBoolVal) || sBoolVal.ToUpper() == "FALSE") ? false : true;
            oePerson.Thumb = ValidateFields.GetSafeByte(dgvwCurRow.Cells["colThumb"].Value);
            oePerson.Pic_path = ValidateFields.GetSafeString(dgvwCurRow.Cells["colPicPath"].Value);
            oePerson.Is_active = true;
            oePerson.User_id = new Guid("8522A212-073D-478F-95DA-D5CA6E6166EE");
            oePerson.Access_date_time = DateTime.Now;
            string PersonId = grdPerson["colPersonId", rowIndex].EditedFormattedValue.ToString();
            if (PersonId == string.Empty)
            {
                dgvwCurRow.Cells["colPersonId"].Value = Guid.NewGuid();
                oePerson.Person_id = (Guid)dgvwCurRow.Cells["colPersonId"].Value;
                info = obj.insertPerson(oePerson);
                if (info.Success)
                {
                    //lblStatus.Text = "Record Added Successfully.";
                }
            }
            else
            {
                oePerson.Person_id = (Guid)dgvwCurRow.Cells["colPersonId"].Value;
                if (frm_MainMDI.language == "en")
                {
                    info = obj.udpatePerson(oePerson, true);
                }
                else if (frm_MainMDI.language == "ur")
                {
                    info = obj.udpatePerson(oePerson, false);
                }

                if (info.Success)
                {
                    MessageBox.Show("Record Updated Successfully.");
                    //lblStatus.Text = "Record Updated Successfully.";
                }
            }
        }

        private void fillCasteComboBox(eCaste objECaste)
        {
            bCaste obCaste = new bCaste();
            eCaste oeCaste = new eCaste();
            List<eCaste> oeListCaste = new List<eCaste>();
            oeListCaste = obCaste.getCaste(oeCaste, "", "", 0, int.MaxValue);
            if (oeListCaste != null && oeListCaste.Count > 0)
            {
                DataGridViewComboBoxColumn col = grdPerson.Columns["colCaste"] as DataGridViewComboBoxColumn;
                col.DataSource = oeListCaste;
                if (objECaste!= null)
                {
                   oeCaste = oeListCaste.Find(x => x.Caste_id == objECaste.Caste_id);
                }                
                if (frm_MainMDI.language == "ur")
                {
                    col.DisplayMember = "caste_name_urd";
                }
                else if (frm_MainMDI.language == "en")
                {
                    col.DisplayMember = "caste_name_eng";
                }
                col.ValueMember = "caste_id";
            }
        }

        private void frm_BasicInformation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                var result = MessageBox.Show("Close?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void grdPerson_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (grdPerson.IsCurrentRowDirty)
            {
                DataGridViewRow dgvwCurRow = grdPerson.Rows[e.RowIndex];
                int rowIndex = e.RowIndex;
                insertUpdatePersonGrid(dgvwCurRow, rowIndex);
            }
        }

        private void tbl_Search_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SCOGridColumns()
        {
            DataGridViewTextBoxColumn dgvRegistryNo = new DataGridViewTextBoxColumn();
            dgvRegistryNo.HeaderText = "Registry No";
            dgvRegistryNo.Name = "colRegistryNo";
            grdSCOInbox.Columns.Add(dgvRegistryNo);

            DataGridViewTextBoxColumn dgvDate = new DataGridViewTextBoxColumn();
            dgvDate.HeaderText = "Date";
            dgvDate.Name = "colDate";
            grdSCOInbox.Columns.Add(dgvDate);

            DataGridViewTextBoxColumn dgvRemarks = new DataGridViewTextBoxColumn();
            dgvRemarks.HeaderText = "Remarks";
            dgvRemarks.Name = "colRemarks";
            grdSCOInbox.Columns.Add(dgvRemarks);

            DataGridViewButtonColumn dgvView = new DataGridViewButtonColumn();
            dgvView.HeaderText = "Display";
            grdSCOInbox.Columns.Add(dgvView);
        }

        private bool isRemarksColumnDisplay()
        {
            bool isDisplay = false;
            if (Variables.roleId == new Guid("0BF53A3C-9385-4D3F-81D2-7BEF64A75507"))   // For SR
            {
                isDisplay = true;
                return isDisplay;
            }
            else if (Variables.roleId == new Guid("5C42EEED-813B-4274-ABCA-CA3D18E445A9"))  // For SCO
            {
                isDisplay = false;
                return isDisplay;
            }
            else if (Variables.roleId == new Guid("A863EE6E-AFF8-4529-BC59-1E6A01BA6AED"))  // For Admin
            {
                isDisplay = false;
                return isDisplay;
            }
            return isDisplay;
        }

        private void grdSCOInbox_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.grdSCOInbox.RowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 206); //Color.Bisque;
            this.grdSCOInbox.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 255, 250);

            if (isRemarksColumnDisplay())
            {
                grdSCOInbox.Columns["colRemarks"].Visible = true;
                if (e.ColumnIndex == 3)
                {
                    e.Value = "View";
                }
            }
            else
            {
                grdSCOInbox.Columns["colRemarks"].Visible = false;
                if (e.ColumnIndex == 3)
                {
                    e.Value = "View";// clsCulture.GetLocalizedString("displayPic", frm_MainMDI.language);// "Show";
                }
            }

        }

        private void bindSCOInboxGrid()
        {
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            bRegistryOperations obRegistryOperations = new bRegistryOperations();
            oeListRegistryOperations = obRegistryOperations.getRegistryOperations(oeRegistryOperations, "", "", 0, int.MaxValue);
            if (oeListRegistryOperations != null && oeListRegistryOperations.Count > 0)
            {
                for (int i = 0; i < oeListRegistryOperations.Count; i++)
                {
                    grdSCOInbox.Rows.Add();
                    grdSCOInbox.Rows[grdSCOInbox.Rows.Count - 1].Cells["colRegistryNo"].Value = oeListRegistryOperations[i].Registry_no;
                    grdSCOInbox.Rows[grdSCOInbox.Rows.Count - 1].Cells["colDate"].Value = oeListRegistryOperations[i].Access_datetime.Date;                    
                }
            }
        }

        private void grdSCOInbox_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (isRemarksColumnDisplay())
            //{
                
            //    if (e.ColumnIndex == 3)
            //    {
            //        Variables.registryNo = (string)grdSCOInbox.Rows[e.RowIndex].Cells[0].Value;

            //        valueGetByRegistryNo(Variables.registryNo);
            //    }
            //}
            //else
            //{
                if (e.ColumnIndex == 3)
                {
                    Variables.registryNo = (string)grdSCOInbox.Rows[e.RowIndex].Cells[0].Value;

                    valueGetByRegistryNo(Variables.registryNo);
                }
            //}
        }

        private void valueGetByRegistryNo(string regNo)
        {
            if (regNo != null)
            {
                eRegistryOperations oeRegistryOperations = new eRegistryOperations();
                List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
                bRegistryOperations obRegistryOperations = new bRegistryOperations();
                oeRegistryOperations.Registry_no = regNo;
                oeListRegistryOperations = obRegistryOperations.getRegistryOperations(oeRegistryOperations, "", "", 0, int.MaxValue);
                if (oeListRegistryOperations != null && oeListRegistryOperations.Count == 1)
                {
                    txtRegistryNo.Text = oeListRegistryOperations[0].Registry_no;
                    dtpDate.Value = oeListRegistryOperations[0].Access_datetime.Date;
                    ddlRegistryType.SelectedValue = oeListRegistryOperations[0].Registry_type_id;
                    txtAmount.Text = oeListRegistryOperations[0].Amount.ToString();
                    txtDocumentNumber.Text = oeListRegistryOperations[0].Doc_number;
                    txtBahiNumber.Text = oeListRegistryOperations[0].Bahi_no;
                    txtJildNumber.Text = oeListRegistryOperations[0].Jild_no;
                }
            }
            else
            {
                resetFields();
            }
        }

        private void setSourceLanguage(ComboBox cComboBox, string sEng, string sUrd, string language)
        {
            if (language == "ur")
            {
                cComboBox.DisplayMember = sUrd;
            }
            else if (language == "en")
            {
                cComboBox.DisplayMember = sEng;
            }
        }

        private void loadDistrict()
        {
            bDistrict obDistrict = new bDistrict();
            List<eDistrict> oeListDistrict = new List<eDistrict>();
            eDistrict oeDistrict = new eDistrict();
            oeListDistrict = obDistrict.GetDistrict(oeDistrict, "", "", 0, int.MaxValue);
            if (oeListDistrict != null && oeListDistrict.Count > 0)
            {
                setSourceLanguage(cbxDistrict, "district_name_eng", "district_name_urd", frm_MainMDI.language);
                cbxDistrict.ValueMember = "district_id";
                cbxDistrict.DataSource = oeListDistrict;
            }
        }

        private void cbxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid DistrictId = new Guid(cbxDistrict.SelectedValue.ToString());
            if (DistrictId != Guid.Empty)
            {
                loadTehsil(DistrictId);
            }
        }

        private void loadTehsil(Guid DistrictId)
        {
            bTehsil obTehsil = new bTehsil();
            List<eTehsil> oeListTehsil = new List<eTehsil>();
            eTehsil oeTehsil = new eTehsil();
            oeTehsil.District_id = DistrictId;
            oeListTehsil = obTehsil.getTehsil(oeTehsil, "", "", 0, int.MaxValue);
            if (oeListTehsil.Count > 0)
            {
                setSourceLanguage(cbxTehsil, "tehsil_name_eng", "tehsil_name_urd", frm_MainMDI.language);
                cbxTehsil.ValueMember = "tehsil_id";
                cbxTehsil.DataSource = oeListTehsil;
            }
            else
            {
                cbxTehsil.DataSource = null;
                cbxTehsil.Items.Clear();
            }
        }
        private void cbxTehsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTehsil.Items.Count > 0)
            {
                Guid TehsilId = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                if (TehsilId != Guid.Empty)
                {
                    loadMauza(TehsilId);
                }
                else
                {
                    cbxMauza.DataSource = null;
                    cbxMauza.Items.Clear();
                }
            }
        }

        private void loadMauza(Guid TehsilId)
        {
            bMauza obMauza = new bMauza();
            List<eMauza> oeListMauza = new List<eMauza>();
            eMauza oeMauza = new eMauza();
            oeMauza.Tehsil_id = TehsilId;
            oeListMauza = obMauza.getMauza(oeMauza, "", "", 0, int.MaxValue);
            if (oeListMauza != null && oeListMauza.Count > 0)
            {
                setSourceLanguage(cbxMauza, "mauza_name_eng", "mauza_name_urd", frm_MainMDI.language);
                cbxMauza.ValueMember = "mauza_id";
            }
            cbxMauza.DataSource = oeListMauza;
            if (oeListMauza.Count == 0)
            {
                cbxMauza.Items.Clear();
            }
        }



        private Int64 _acre;
        private Int64 _kanal;
        private Int64 _marla;
        private Int64 _feet;
        private Int64 _sarsai;
        private Int64 _yard;
        private short _feetPerMarla;
        private short _tabIndex;
        private enAreaFormat _areaFormat;

        public enum enAreaFormat
        {
            Acre = 0,
            KanalMarla,
            KanalMarlaFeet,
            KanalMarlaSarsai,
            KanalMarlaYard
        }

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
                switch ((enAreaFormat)Convert.ToInt64(ddlAreaFormat.Text))
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

        public string Area
        {
            get
            {
                if (!string.IsNullOrEmpty(txtTotalArea.Text.Trim()) && txtTotalArea.Text != ddlAreaFormat.Text)
                {
                    return AreaToFeet(txtTotalArea.Text.Trim(), FeetPerMarla);
                }
                else
                    return "0";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    txtTotalArea.Text = FeetToArea(Convert.ToInt64(value), FeetPerMarla, AreaFormat);
                }
            }
        }

        public string AreaStr
        {
            get
            {
                return txtTotalArea.Text.Trim();
            }
            set
            {
                txtTotalArea.Text = value;
            }
        }

        public bool IsValidArea
        {
            get
            {
                return ValidateArea();
            }
        }

        public bool EnableArea
        {
            set
            {
                this.txtTotalArea.Enabled = value;
            }
        }

        public bool ShowAreaFormat
        {
            set
            {
                this.ddlAreaFormat.Visible = value;
            }
        }

        public bool ShowAll
        {
            set
            {
                this.ddlAreaFormat.Visible = value;
                this.txtTotalArea.Visible = value;
            }
        }

        public System.Drawing.Color BackColor
        {
            set
            {
                this.txtTotalArea.BorderStyle = BorderStyle.FixedSingle;
                //txtTotalArea.BorderStyle = BorderStyle.Solid;
            }
        }

        public bool DefaultFormatOnly
        {
            set
            {
                this.ddlAreaFormat.Visible = value;
            }
        }

        public short FeetPerMarla
        {
            set
            {
                if (value > 0 && value <= short.MaxValue)
                    _feetPerMarla = value;
                else
                    _feetPerMarla = 0;
            }
            get
            {
                return _feetPerMarla;
            }
        }

        public enAreaFormat AreaFormat
        {
            get
            {
                return _areaFormat;
            }
            set
            {
                _areaFormat = value;
                ddlAreaFormat.SelectedIndex = Convert.ToInt32(value);
                txtTotalArea.Text = ddlAreaFormat.Text;
                txtTotalArea.ForeColor = Color.Gray;
            }
        }

        public short TabIndex
        {
            get
            {
                return _tabIndex;
            }
            set
            {
                _tabIndex = value;
                txtTotalArea.TabIndex = (short)(value++);
                ddlAreaFormat.TabIndex = (short)(value++);

            }
        }

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

        #region Utilities Functions

        private bool ValidateArea()
        {
            if (txtTotalArea.Text.Trim() == string.Empty)
            {
                return true;
            }
            else if (Regex.IsMatch(txtTotalArea.Text.Trim(), "^[0-9--]*$"))
            {
                switch ((enAreaFormat)Convert.ToInt32(ddlAreaFormat.Text))
                {
                    case enAreaFormat.KanalMarlaFeet:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(txtTotalArea.Text.Trim(), @"^((\d)+(-)(\d)+(-)(\d)+)$");
                        }
                    case enAreaFormat.KanalMarlaSarsai:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(txtTotalArea.Text.Trim(), @"^((\d)+(-)(\d)+(-)(\d)+)$");
                        }
                    case enAreaFormat.KanalMarla:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(txtTotalArea.Text.Trim(), @"^((\d)+(-)(\d)+)$");
                        }
                    case enAreaFormat.Acre:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(txtTotalArea.Text.Trim(), @"^(\d+)$");
                        }
                    // Added by Syed Fareed on April 26, 2012.
                    // Kanal-Marla-Yard
                    case enAreaFormat.KanalMarlaYard:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(txtTotalArea.Text.Trim(), @"^((\d)+(-)(\d)+(-)(\d)+)$");
                        }
                }
            }

            return false;
        }


        #endregion

        private void ddlAreaFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Variables.SetCue(txtTotalArea, ddlAreaFormat.Text);
            //txtTotalArea.ForeColor = Color.Gray;
            _areaFormat = (enAreaFormat)ddlAreaFormat.SelectedIndex;
            //txtTotalArea.Text = string.Empty;
            //ScriptManager.GetCurrent(Parent.Page).SetFocus((Control)sender);
        }


       

    }
}