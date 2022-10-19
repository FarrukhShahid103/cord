using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dosadi.EZTwain;
using System.IO;
using RD.EL;
using RD.BLL;

namespace RDProject.RD
{
    public partial class ScanningForm_English : Form
    {
        public Guid Registry_ID;
        public bool NewRecord;
        public Guid registryImageId;
        public bool scanView;

        public ScanningForm_English()
        {
            InitializeComponent();
        }
        
        private void ScanFile()
        {
            try
            {
                string filename = Application.StartupPath + "\\temp.pdf";
                //if (File.Exists(filename))
                //{
                //    PdfViewer.LoadDocument(filename);
                //}
                //return;
                EZTwain.LogFile(1);
                EZTwain.SetHideUI(true);
                EZTwain.SetPixelType(2);
                EZTwain.SetResolution(150);
                int status = -101;
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

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
                    lblMsg.Text = "EZTwait is not installed";
                }

                if (status == 0)
                {
                   // EZTwain.CloseSource();
                    if (File.Exists(filename))
                    {
                        if (Registry_ID != Guid.Empty)
                        {
                            eRegistryImages oeRegistryImages = new eRegistryImages();
                            bRegistryImages obRegistryImages = new bRegistryImages();
                            updatedNewEntryInfo info = new updatedNewEntryInfo();
                            oeRegistryImages.RegistryImages_id = Guid.NewGuid();
                            oeRegistryImages.Registry_id = Registry_ID;
                            oeRegistryImages.Access_datetime = DateTime.Now;
                            oeRegistryImages.Image_file = System.IO.File.ReadAllBytes(filename);
                            oeRegistryImages.Image_file_path = "";
                            oeRegistryImages.Imagetype_id = "";
                            oeRegistryImages.User_id = Variables.UserId;

                            info = obRegistryImages.insertRegistryImages(oeRegistryImages);
                            if (info.Success)
                            {
                                lblMsg.Text = "Document is scanned; successfully inserted";
                            }
                            else
                            {
                                lblMsg.Text = "Error.";
                            }

                            axAcroPDF1.LoadFile(filename);
                        }
                        else
                        {
                            lblMsg.Text = "Scanning is complete but Document not inserted";
                        }
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
                lblMsg.Text = "Exception: " + exp.Message.ToString();
            }
        }

        protected void Save_Pdf()
        {
            eRegistryImages oeRegistryImages = new eRegistryImages();
            List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
            bRegistryImages obRegistryImages = new bRegistryImages();
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            string filename = Application.StartupPath + "\\temp.pdf";
            if (oeListRegistryImages != null && oeListRegistryImages.Count > 0)
            {

                if (oeListRegistryImages[0].Image_file != null)
                {
                    Image x = (Bitmap)((new ImageConverter()).ConvertFrom(oeListRegistryImages[0].Image_file));
                    MemoryStream ms = new MemoryStream(oeListRegistryImages[0].Image_file, 0, oeListRegistryImages[0].Image_file.Length);
                    ms.Write(oeListRegistryImages[0].Image_file, 0, oeListRegistryImages[0].Image_file.Length);
                    //axAcroPDF1.LoadFile(ms);
                }
            }
            else
            {
                oeRegistryImages.RegistryImages_id = Guid.NewGuid();
                oeRegistryImages.Registry_id = Registry_ID;
                oeListRegistryImages = obRegistryImages.getRegistryImages(oeRegistryImages, "", "", 0, int.MaxValue);
                oeRegistryImages.Access_datetime = DateTime.Now;
                oeRegistryImages.Image_file = System.IO.File.ReadAllBytes(filename);
                oeRegistryImages.Image_file_path = "";
                oeRegistryImages.Imagetype_id = "";
                oeRegistryImages.User_id = Variables.UserId;

                info = obRegistryImages.insertRegistryImages(oeRegistryImages);
                if (info.Success)
                {
                    lblMsg.Text = "Document is scanned; successfully inserted";
                }
                else
                {
                    lblMsg.Text = "Error.";
                }
            }
        }

        protected void Select_Pdf()
        {
            string filename = Application.StartupPath + "\\Temp.pdf";
            eRegistryImages oeRegistryImages = new eRegistryImages();
            bRegistryImages obRegistryImages = new bRegistryImages();
            List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
            oeRegistryImages.Registry_id = Registry_ID;
            oeListRegistryImages = obRegistryImages.getRegistryImages(oeRegistryImages, "", "", 0, int.MaxValue);
            if (oeListRegistryImages != null && oeListRegistryImages.Count > 0)
            {
                NewRecord = false;
                byte[] buffer = (byte[])oeListRegistryImages[0].Image_file;
                FileStream fStream = new FileStream(filename, FileMode.Create);
                fStream.Write(buffer, 0, buffer.Length);
                fStream.Close();
                fStream.Dispose();                
                if (filename != null)
                {
                    axAcroPDF1.LoadFile(filename);
                }
            }
            NewRecord = true;
        }
        
        private void ScanningForm_English_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ScanningForm_English_Load(object sender, EventArgs e)
        {
            if (NewRecord)
            {
                ScanFile();
            }
            else
            {
                Select_Pdf();
            }
        }
    }
}

