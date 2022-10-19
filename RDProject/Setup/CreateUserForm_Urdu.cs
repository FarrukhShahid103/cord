using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RD.EL.Users;
using RD.EL;
using RD.BLL;
using System.Reflection;
using System.Collections;

namespace RDProject.Setup
{
    public partial class CreateUserForm_Urdu : Form
    {
        private bool NewReocrd = true;
        private Guid user_id = Guid.Empty;
        List<eForms> oeListForms = new List<eForms>();

        public CreateUserForm_Urdu()
        {
            InitializeComponent();
            fillUserRoleDropDown();
            fillUserRightsDropDown();
        }

        private void CreateUserForm_Urdu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }


            if (e.KeyChar == (char)Keys.Escape)
            {
                if (cbUserName.Focused)
                {
                    this.Close();
                }
                else
                {
                    cbUserName.Enabled = true;
                    cbUserName.Focus();
                    return;
                }
            }
        }

        private void cbUserName_Leave(object sender, EventArgs e)
        {
            if (cbUserName.Text == string.Empty)
            {
                cbUserName.Enabled = true;
                cbUserName.Focus();
                lblMsg.Text = "Username Field must have a value..";
                return;
            }

            NewReocrd = true;
            cbUserName.Enabled = false;

            List<eUsers> oeListUsers = new List<eUsers>();
            eUsers oeUsers = new eUsers();
            bUsers obUsers = new bUsers();
            oeUsers.User_name = cbUserName.Text.Trim();

            oeListUsers = obUsers.getUsers(oeUsers, "", "", 0, int.MaxValue);
            if (oeListUsers != null && oeListUsers.Count > 0)
            {
                eUserRoles oeUserRoles = new eUserRoles();
                oeUserRoles.User_id = oeListUsers[0].User_id;
                List<eUserRoles> oeListUserRoles = new List<eUserRoles>();
                bUserRoles obUserRoles = new bUserRoles();
                oeListUserRoles = obUserRoles.getUserRoles(oeUserRoles, "", "", 0, 100);
                if (oeListUserRoles != null && oeListUserRoles.Count > 0)
                {
                    cbUserRole.SelectedValue = oeListUserRoles[0].Role_id;
                }

                txtFirstName.Text = oeListUsers[0].First_name;
                txtLastName.Text = oeListUsers[0].Last_name;
                txtPassword.Text = oeListUsers[0].User_password;
                txtCNIC.Text = oeListUsers[0].User_nic;
                txtSecretAnswer.Text = oeListUsers[0].Secret_answer;
                txtSecretQuestion.Text = oeListUsers[0].Secret_question;
                chkBioMetricLogin.Checked = ValidateFields.GetSafeBoolean(oeListUsers[0].Is_biomatric);
                chkActive.Checked = ValidateFields.GetSafeBoolean(oeListUsers[0].User_active_status);
                user_id = oeListUsers[0].User_id;
                lblMsg.Text = "صارف نہیں ملا";
                NewReocrd = false;
                btnSave.Text = "تبدیل کریں";
            }
            else
            {
                lblMsg.Text = "";
                NewReocrd = true;
                btnSave.Text = "محفوظ کریں";
            }
            gbxUserRights.Enabled = true;
        }

        private void setDefaultValue()
        {
            txtSecretAnswer.Clear();
            txtPassword.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtCNIC.Clear();
            cbxUserRights.SelectedIndex = 0;
            chkBioMetricLogin.Checked = false;
            chkActive.Checked = true;
            gbxUserRights.Enabled = false;
            checkedFalse();

        }

        private void fillUserRoleDropDown()
        {
            eRole oeRole = new eRole();
            List<eRole> oeListRole = new List<eRole>();
            bRole obRole = new bRole();
            oeListRole = obRole.getRole(oeRole, "", "", 0, int.MaxValue);
            AddItem(oeListRole, typeof(eRole), "Role_id", "Description_urd", "< - چنیں - >");
            if (oeListRole != null && oeListRole.Count > 0)
            {
                cbUserRole.DataSource = oeListRole;
                cbUserRole.DisplayMember = "description_urd";
                cbUserRole.ValueMember = "role_id";
            }
        }

        private void fillUserRightsDropDown()
        {
            eForms oeForms = new eForms();
            bForms obForms = new bForms();
            oeListForms = obForms.getForms(oeForms, "", "", 0, int.MaxValue);
            AddItem(oeListForms, typeof(eForms), "Form_id", "Description_urd", "< - چنیں - >");
            if (oeListForms != null && oeListForms.Count > 0)
            {
                cbxUserRights.DataSource = oeListForms;
                cbxUserRights.DisplayMember = "description_urd";
                cbxUserRights.ValueMember = "form_id";
            }
            if (cbxUserRights.SelectedIndex == 0)
            {
                chkUpdate.Enabled = false;
                chkPrint.Enabled = false;
                chkView.Enabled = false;
                chkDelete.Enabled = false;
                chkInsert.Enabled = false;
            }


        }

        private void AddItem(IList list, Type type, string valueMember, string displayMember, string displayText)
        {
            Object obj = Activator.CreateInstance(type);
            PropertyInfo displayProperty = type.GetProperty(displayMember);
            displayProperty.SetValue(obj, displayText, null);
            PropertyInfo valueProperty = type.GetProperty(valueMember);
            Guid i = new Guid();
            valueProperty.SetValue(obj, i, null);
            list.Insert(0, obj);
        }

        private void CreateUserForm_Urdu_Load(object sender, EventArgs e)
        {
            FillAllUsers();
        }

        private void FillAllUsers()
        {
            List<eUsers> oeListUsers = new List<eUsers>();
            eUsers oeUsers = new eUsers();
            bUsers obUsers = new bUsers();
            oeListUsers = obUsers.getUsers(oeUsers, "", "", 0, int.MaxValue);
            if (oeListUsers != null && oeListUsers.Count > 0)
            {
                cbUserName.DataSource = oeListUsers;
                cbUserName.DisplayMember = "user_name";
                cbUserName.ValueMember = "user_id";
            }

        }


        private void cbUserName_Enter(object sender, EventArgs e)
        {
            setDefaultValue();
        }

        private bool controlValidate()
        {
            bool result = true;
            if (cbUserName.Text.Trim() == string.Empty)
            {
                cbUserName.Focus();
                result = false;
                return result;
            }
            if (txtPassword.Text == string.Empty)
            {
                txtPassword.Focus();
                result = false;
                return result;
            }
            if (txtFirstName.Text == string.Empty)
            {
                txtFirstName.Focus();
                result = false;
                return result;
            }
            if (txtLastName.Text == string.Empty)
            {
                txtLastName.Focus();
                result = false;
                return result;
            }
            if (txtCNIC.Text == string.Empty)
            {
                txtCNIC.Focus();
                result = false;
                return result;
            }
            if (cbUserRole.SelectedIndex == 0)
            {
                cbUserRole.Focus();
                result = false;
                return result;
            }
            return result;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            eUserRights oeUserRights = new eUserRights();
            bUserRights obUserRights = new bUserRights();

            eUserRoles oeUserRoles = new eUserRoles();
            List<eUserRoles> oeListUserRoles = new List<eUserRoles>();
            bUserRoles obUserRoles = new bUserRoles();

            bUsers obUsers = new bUsers();
            eUsers oeUsers = new eUsers();
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            oeUsers.First_name = txtFirstName.Text.Trim();
            oeUsers.Last_name = txtLastName.Text.Trim();
            oeUsers.User_password = txtPassword.Text.Trim();
            oeUsers.Secret_question = txtSecretQuestion.Text.Trim();
            oeUsers.Secret_answer = txtSecretAnswer.Text.Trim();
            oeUsers.User_nic = txtCNIC.Text.Trim();
            oeUsers.User_active_status = chkActive.Checked;
            oeUsers.Is_biomatric = chkBioMetricLogin.Checked;
            oeUsers.Access_datetime = DateTime.Now;
            if (NewReocrd)
            {
                if (controlValidate())
                {
                    oeUsers.User_id = Guid.NewGuid();
                    user_id = oeUsers.User_id;
                    oeUsers.User_name = cbUserName.Text;
                    oeUserRoles.User_roles_id = Guid.NewGuid();
                    oeUserRoles.Role_id = new Guid(cbUserRole.SelectedValue.ToString());
                    oeUserRoles.Access_user_id = Guid.Empty;
                    info = obUsers.insertUserWithRole(oeUsers, oeUserRoles);
                    if (info.Success)
                    {
                        if (oeListForms != null && oeListForms.Count > 0)
                        {
                            for (int i = 1; i < oeListForms.Count; i++)
                            {
                                oeUserRights.User_right_id = Guid.NewGuid();
                                oeUserRights.User_id = user_id;
                                oeUserRights.Form_id = oeListForms[i].Form_id;
                                oeUserRights.Insert_right = chkInsert.Checked;
                                oeUserRights.Print_right = chkPrint.Checked;
                                oeUserRights.Update_right = chkUpdate.Checked;
                                oeUserRights.View_right = chkView.Checked;
                                oeUserRights.Delete_right = chkDelete.Checked;
                                oeUserRights.Access_user_id = Variables.UserId;
                                oeUserRights.Access_datetime = DateTime.Now;
                                info = obUserRights.insertUserRights(oeUserRights);
                            }
                        }

                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "صارف " + cbUserName.Text + " بنایا گیا ہے";
                        cbUserName.Enabled = true;
                        cbUserName.Focus();
                    }
                    else
                    {
                        lblMsg.Text = "صارف نہیں بنایا گیا, " + info.Exception;
                        lblMsg.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                oeUsers.User_id = user_id;
                oeUsers.User_name = cbUserName.Text;

                oeUserRoles.Role_id = new Guid(cbUserRole.SelectedValue.ToString());

                info = obUsers.updateUserWithRole(oeUsers, oeUserRoles);
                if (info.Success)
                {
                    if (oeListForms != null && oeListForms.Count > 0)
                    {
                        for (int i = 1; i < oeListForms.Count; i++)
                        {
                            //oeUserRights.User_right_id = oeUserRoles[();
                            //oeUserRights.User_id = user_id;
                            //oeUserRights.Form_id = oeListForms[i].Form_id;
                            //oeUserRights.Insert_right = chkInsert.Checked;
                            //oeUserRights.Print_right = chkPrint.Checked;
                            //oeUserRights.Update_right = chkUpdate.Checked;
                            //oeUserRights.View_right = chkView.Checked;
                            //oeUserRights.Delete_right = chkDelete.Checked;
                            //oeUserRights.Access_user_id = Variables.UserId;
                            //oeUserRights.Access_datetime = DateTime.Now;
                            //info = obUserRights.insertUserRights(oeUserRights);
                        }
                    }


                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "صارف " + cbUserName.Text + " کا ریکارڈ تبدیل ہو گیا ہے";
                    cbUserName.Enabled = true;
                    cbUserName.Focus();


                    //oeUserRoles.User_id = oeUsers.User_id;
                    //oeListUserRoles = obUserRoles.getUserRoles(oeUserRoles, "", "", 0, int.MaxValue);
                    //if (oeListUserRoles != null && oeListUserRoles.Count == 1)
                    //{
                    //    oeUserRoles.User_roles_id = oeListUserRoles[0].User_roles_id;
                    //    oeUserRoles.Role_id = new Guid(cbUserRole.SelectedValue.ToString());
                    //    oeUserRoles.Access_datetime = DateTime.Now;
                    //    info = obUserRoles.udpateUserRoles(oeUserRoles);
                    //    if (info.Success)
                    //    {
                    //        lblMsg.ForeColor = Color.Green;
                    //        lblMsg.Text = "User " + cbUserName.Text + " updated successfully";
                    //        cbUserName.Enabled = true;
                    //        cbUserName.Focus();
                    //    }
                    //    else
                    //    {
                    //        lblMsg.Text = "User not udpated";
                    //        lblMsg.ForeColor = Color.Red;
                    //    }
                    //}
                }
                else
                {
                    lblMsg.Text = "صارف کا ریکارڈ تبدیل نہیں کیا گیا";
                    lblMsg.ForeColor = Color.Red;
                }
            }
        }

        private void checkedFalse()
        {
            chkView.Checked = false;
            chkPrint.Checked = false;
            chkInsert.Checked = false;
            chkUpdate.Checked = false;
            chkDelete.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void chkDistrictView_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkDistrictPrint_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxUserRights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUserRights.SelectedIndex == 0)
            {
                checkedFalse();
                chkUpdate.Enabled = false;
                chkPrint.Enabled = false;
                chkView.Enabled = false;
                chkDelete.Enabled = false;
                chkInsert.Enabled = false;
            }
            else
            {
                chkUpdate.Enabled = true;
                chkPrint.Enabled = true;
                chkView.Enabled = true;
                chkDelete.Enabled = true;
                chkInsert.Enabled = true;
                eUserRights oeUserRights = new eUserRights();
                List<eUserRights> oeListUserRights = new List<eUserRights>();
                bUserRights obUserRights = new bUserRights();
                oeUserRights.User_id = user_id;
                oeUserRights.Form_id = ValidateFields.GetSafeGuid(cbxUserRights.SelectedValue.ToString());
                oeListUserRights = obUserRights.getUserRights(oeUserRights, "", "", 0, int.MaxValue);
                if (oeListUserRights != null && oeListUserRights.Count == 1)
                {
                    chkView.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].View_right);
                    chkPrint.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].Print_right);
                    chkInsert.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].Insert_right);
                    chkUpdate.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].Update_right);
                    chkDelete.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].Delete_right);
                }
            }
        }

        private void checkBoxStatus()
        {
            eUserRights oeUserRights = new eUserRights();
            List<eUserRights> oeListUserRights = new List<eUserRights>();
            bUserRights obUserRights = new bUserRights();
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            oeUserRights.Form_id = ValidateFields.GetSafeGuid(cbxUserRights.SelectedValue.ToString());
            oeUserRights.User_id = user_id;
            oeListUserRights = obUserRights.getUserRights(oeUserRights, "", "", 0, int.MaxValue);
            if (oeListUserRights != null && oeListUserRights.Count == 1)
            {
                oeUserRights.User_right_id = oeListUserRights[0].User_right_id;
                oeUserRights.View_right = chkView.Checked;
                oeUserRights.Print_right = chkPrint.Checked;
                oeUserRights.Insert_right = chkInsert.Checked;
                oeUserRights.Update_right = chkUpdate.Checked;
                oeUserRights.Delete_right = chkDelete.Checked;
                oeUserRights.Access_datetime = DateTime.Now;
                oeUserRights.Access_user_id = Variables.UserId;
                info = obUserRights.udpateUserRights(oeUserRights);
            }
        }

        private void chkView_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

        private void chkPrint_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

        private void chkInsert_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

    }
}
