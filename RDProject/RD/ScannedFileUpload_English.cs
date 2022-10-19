using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using RD.EL;
using RD.BLL;

namespace RDProject.RD
{
    public partial class ScannedFileUpload_English : Form
    {
        public Guid Registry_ID;
        public ScannedFileUpload_English()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
               //fbdBrowsFolder = new FolderBrowserDialog();
                dlgBrowseFile = new OpenFileDialog();
                if (dlgBrowseFile.ShowDialog() == DialogResult.OK)
                {
                    this.txtFolderPath.Text = dlgBrowseFile.FileName;
                    //FileStream fs = new FileStream(fbdBrowsFolder.SelectedPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    if (File.Exists(dlgBrowseFile.FileName))
                    {
                        string[] strExt = dlgBrowseFile.FileName.Split('.');
                        int extLength = strExt.Length;
                        if (strExt.Length > 1)
                        {
                            if (strExt[extLength - 1].ToUpper() == "PDF")
                            {
                                if (Registry_ID != Guid.Empty)
                                {
                                    eRegistryImages oeRegistryImages = new eRegistryImages();
                                    bRegistryImages obRegistryImages = new bRegistryImages();
                                    updatedNewEntryInfo info = new updatedNewEntryInfo();
                                    oeRegistryImages.RegistryImages_id = Guid.NewGuid();
                                    oeRegistryImages.Registry_id = Registry_ID;
                                    oeRegistryImages.Access_datetime = DateTime.Now;
                                    oeRegistryImages.Image_file = System.IO.File.ReadAllBytes(dlgBrowseFile.FileName);
                                    oeRegistryImages.Image_file_path = "";
                                    oeRegistryImages.Imagetype_id = "";
                                    oeRegistryImages.User_id = Variables.UserId;

                                    info = obRegistryImages.insertRegistryImages(oeRegistryImages);
                                    if (info.Success)
                                    {
                                        lblMsg.Text = "Document is successfully inserted";
                                    }
                                    else
                                    {
                                        lblMsg.Text = "Error.";
                                    }
                                    axAcroPDF1.LoadFile(dlgBrowseFile.FileName);
                                }
                                else
                                {
                                    lblMsg.Text = "Registry not exist and Document not inserted";
                                }
                            }
                            else
                            {
                                lblMsg.Text = "Please select PDF file";
                            }
                        }
                    }
                    else
                    {
                        lblMsg.Text = "File not exist";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ScannedFileUpload_English_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
