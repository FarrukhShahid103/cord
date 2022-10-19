using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace RDProject
{
    public partial class AcceptForm : Telerik.WinControls.UI.ShapedForm
    {
        public AcceptForm()
        {
            InitializeComponent();
        }
        public string RegistryNo;
        private void radButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void AcceptForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            if (txtremarks.Visible == false)
            {
                string sql = "Update rd.RegistryOperations ";
                sql = sql + "SET registery_stage=@registerystage, remarks=@remarks, reg_status=@status ";
                sql = sql + "WHERE registry_No=@RegistryNo";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);

                db.AddInParameter(dbCommand, "@RegistryNo", DbType.String, RegistryNo);
                db.AddInParameter(dbCommand, "@registerystage", DbType.Int32, 2);
                db.AddInParameter(dbCommand, "@status", DbType.String, "منظور شدہ۔");
                db.AddInParameter(dbCommand, "@remarks", DbType.String, txtremarks.Text);

                try
                {
                    int result = db.ExecuteNonQuery(dbCommand);
                    if (result > 0)
                    {

                        MessageBox.Show("رجسٹری منظور ھو گی ھے۔");
                    }
                    else
                    {
                        MessageBox.Show("!مسٰلہ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("!مسٰلہ");
                }
            }

            if (txtremarks.Visible == true)
            {

                string sql = "Update rd.RegistryOperations ";
                sql = sql + "SET registery_stage=@registerystage, remarks=@remarks, reg_status=@status ";
                sql = sql + "WHERE registry_No=@RegistryNo";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);

                db.AddInParameter(dbCommand, "@RegistryNo", DbType.String, RegistryNo);
                db.AddInParameter(dbCommand, "@registerystage", DbType.Int32, 2);
                db.AddInParameter(dbCommand, "@status", DbType.String, "غیر منطور شدہ۔");
                db.AddInParameter(dbCommand, "@remarks", DbType.String, txtremarks.Text);
                try
                {
                    int result = db.ExecuteNonQuery(dbCommand);
                    if (result > 0)
                    {

                        MessageBox.Show("رجسٹری نا منظور ھو گی ھے۔");
                    }
                    else
                    {
                        MessageBox.Show("!مسٰلہ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("!مسٰلہ");
                }
            }

            btnVerify.Enabled = false;

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
