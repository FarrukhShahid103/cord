using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.IO;

namespace RDProject
{
    public partial class LoginForm : Telerik.WinControls.UI.ShapedForm
    {
        private static readonly byte[] _key = { 0xA1, 0xF1, 0xA6, 0xBB, 0xA2, 0x5A, 0x37, 0x6F, 0x81, 0x2E, 0x17, 0x41, 0x72, 0x2C, 0x43, 0x27 };
        private static readonly byte[] _initVector = { 0xE1, 0xF1, 0xA6, 0xBB, 0xA9, 0x5B, 0x31, 0x2F, 0x81, 0x2E, 0x17, 0x4C, 0xA2, 0x81, 0x53, 0x61 };
     
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private static string Decrypt(string Value)
        {
            SymmetricAlgorithm mCSP;
            ICryptoTransform ct = null;
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] byt;
            byte[] _result;
            mCSP = new RijndaelManaged();
            try
            {
                mCSP.Key = _key;
                mCSP.IV = _initVector;
                ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
                byt = Convert.FromBase64String(Value);
                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();
                _result = ms.ToArray();
            }
            catch
            {
                _result = null;
            }
            finally
            {
                if (ct != null)
                    ct.Dispose();
                if (ms != null)
                    ms.Dispose();
                if (cs != null)
                    cs.Dispose();
            }
            return ASCIIEncoding.UTF8.GetString(_result);
        }
        private static string Encrypt(string Password)
        {
            if (string.IsNullOrEmpty(Password))
                return string.Empty;
            byte[] Value = Encoding.UTF8.GetBytes(Password);
            SymmetricAlgorithm mCSP = new RijndaelManaged();
            mCSP.Key = _key;
            mCSP.IV = _initVector;
            using (ICryptoTransform ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                    {
                        cs.Write(Value, 0, Value.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public bool ShowLogin()
        {
            try
            {
                ShowDialog();
            }
            catch (Exception ex)
            {
                return true;
                throw;
            }

            if (Variables.IsLoged == true)
                return true;
            else
                return false;
        }

        private static DataTable LookupUser(string Username)
        {
            DataTable result = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            const string query = "Select Password, Role From rd.users (NOLOCK) Where LoginID = @UserName";
            DbCommand dbCommand = db.GetSqlStringCommand(query);
            db.AddInParameter(dbCommand, "@UserName", DbType.String, Username);
            using (IDataReader reader = db.ExecuteReader(dbCommand))
            {
                result.Load(reader);
                Variables.Role = (int)result.Rows[0]["Role"];
            }
            return result;            
        }


        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Variables.IsLoged)
            {
                Variables.IsLoged = false;
                Application.Exit();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Variables.IsLoged = false;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Enter your username", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Enter your password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }

            using (DataTable dt = LookupUser(txtUserName.Text.ToUpper()))
            {
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid username.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                    return;
                }
                else
                {
                    string dbPassword = Convert.ToString(dt.Rows[0]["Password"]);
                    //string appPassword = Encrypt(txtPassword.Text);
                    string appPassword = txtPassword.Text.Trim();
                    if (string.Compare(dbPassword, appPassword) == 0)
                    {
                        Variables.IsLoged = true;
                        Variables.UserName = txtUserName.Text.Trim().ToUpper();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                        return;
                    }
                }
            }
        }
    }
}
