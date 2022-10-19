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
using System.IO;
using System.Data.OleDb;
using System.Drawing.Printing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;

namespace RDProject.RD
{
    public partial class DragImage_English : Form
    {
        Guid registryId = new Guid("EDCF46E8-011D-4023-9AE5-EFD1DE38EBC5");
        
        private bool Dragging;
        private int mousex;
        private int mousey;

        public DragImage_English()
        {
            InitializeComponent();
        }

        public void getRegistryImage()
        {
            List<PictureBox> pictureBoxList = new List<PictureBox>();
            eRegistryImages oeRegistryImages = new eRegistryImages();
            bRegistryImages obRegistryOmages = new bRegistryImages();
            List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
            oeRegistryImages.Registry_id = registryId;
            oeListRegistryImages = obRegistryOmages.getRegistryImages(oeRegistryImages, "", "", 0, int.MaxValue);
            if (oeListRegistryImages != null && oeListRegistryImages.Count > 0)
            {
                if (oeListRegistryImages[0].Image_file != null)
                {
                    string filename = Application.StartupPath + "\\Temp.pdf";
                    byte[] buffer = (byte[])oeListRegistryImages[0].Image_file;
                    FileStream fStream = new FileStream(filename, FileMode.Create);
                    fStream.Write(buffer, 0, buffer.Length);
                    fStream.Close();
                    fStream.Dispose();
                    if (filename != null)
                    {
                        axAcroPDF1.LoadFile(filename);
                    }

                    ePersonWithRegistry oePersonWithRegistry = new ePersonWithRegistry();
                    eRegistryPerson oeRegistryPerson = new eRegistryPerson();
                    oeRegistryPerson.Registry_id = registryId;
                    bRegistryPerson obRegistryPerson = new bRegistryPerson();
                    List<ePersonWithRegistry> oeListPersonWithRegistry = new List<ePersonWithRegistry>();
                    oeListPersonWithRegistry = obRegistryPerson.getPersonByRegistryId(oeRegistryPerson, "", "", 0, int.MaxValue);
                    if (oeListPersonWithRegistry != null && oeListPersonWithRegistry.Count > 0)
                    {
                        for (int i = 0; i < oeListPersonWithRegistry.Count; i++)
                        {
                            ePerson oePerson = new ePerson();
                            bPerson obPerson = new bPerson();
                            List<ePerson> oeListPerson = new List<ePerson>();
                            oePerson.Person_id = oeListPersonWithRegistry[i].Person_id;
                            oeListPerson = obPerson.getPerson(oePerson, "", "", 0, int.MaxValue);
                            if (oeListPerson != null && oeListPerson.Count > 0)
                            {
                                if (oeListPerson[0].Person_pic != null)
                                {
                                    ToolStripButton toolButton = new ToolStripButton();
                                    System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(oeListPerson[0].Person_pic));
                                    toolButton.Image = x;
                                    toolButton.Tag = i;
                                    ToolStrip1.Items.Add(toolButton);

                                }
                            }
                        }
                    }
                }
                else
                {
                    //pbBackImage.Image = null;
                }
            }
    
        }
        private void CreatePDFFile()
        {
            string filename = Application.StartupPath + "\\Temp.pdf";
            Stream inputPdfStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            var reader = new PdfReader(inputPdfStream);
            Stream outputPdfStream = new FileStream("result.pdf", FileMode.Create, FileAccess.Write, FileShare.None);            
            var stamper = new PdfStamper(reader, outputPdfStream);
            var pdfContentByte = stamper.GetOverContent(1);
            int x = 0; int y = 700;


            ePersonWithRegistry oePersonWithRegistry = new ePersonWithRegistry();
            eRegistryPerson oeRegistryPerson = new eRegistryPerson();
            oeRegistryPerson.Registry_id = registryId;
            bRegistryPerson obRegistryPerson = new bRegistryPerson();
            List<ePersonWithRegistry> oeListPersonWithRegistry = new List<ePersonWithRegistry>();
            oeListPersonWithRegistry = obRegistryPerson.getPersonByRegistryId(oeRegistryPerson, "", "", 0, int.MaxValue);
            if (oeListPersonWithRegistry != null && oeListPersonWithRegistry.Count > 0)
            {
                for (int i = 0; i < oeListPersonWithRegistry.Count; i++)
                {
                    ePerson oePerson = new ePerson();
                    bPerson obPerson = new bPerson();
                    List<ePerson> oeListPerson = new List<ePerson>();
                    oePerson.Person_id = oeListPersonWithRegistry[i].Person_id;
                    oeListPerson = obPerson.getPerson(oePerson, "", "", 0, int.MaxValue);
                    if (oeListPerson != null && oeListPerson.Count > 0)
                    {
                        if (oeListPerson[0].Person_pic != null)
                        {
                            string persongpic = Application.StartupPath + "\\" + oeListPerson[0].Person_id + ".png";
                            byte[] buffer = (byte[])oeListPerson[0].Person_pic;
                            FileStream fStream = new FileStream(persongpic, FileMode.Create);
                            fStream.Write(buffer, 0, buffer.Length);
                            fStream.Close();
                            fStream.Dispose();

                            Stream inputImageStream = new FileStream(persongpic, FileMode.Open, FileAccess.Read, FileShare.Read);
                            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(inputImageStream);
                            image.SetAbsolutePosition(x, y);
                            pdfContentByte.AddImage(image);
                            x = 0; y = 700;
                        }
                    }
                }
                stamper.Close();
            }





            //while (i <= 2) // total images of persons to be loaded
            //{
            //    Stream inputImageStream = new FileStream("C://b.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            //    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(inputImageStream);
            //    image.SetAbsolutePosition(j, k);
            //    pdfContentByte.AddImage(image);
            //    //j = 110; k = 509;
            //    i++;
            //}
            //stamper.Close();

        }


        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            //Set to Edit mode
            ToolStrip1.Visible = true;
            ToolStrip1.BringToFront();
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            System.Drawing.Image returnImage = null;
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = new Bitmap(ms);
                //returnImage = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return returnImage;
        }

        private void DragImage_English_Load(object sender, EventArgs e)
        {
            getRegistryImage();
            //ToolStrip1.Visible = false;
        }
        //http://forums.adobe.com/thread/302171
        private void ToolStrip1_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            //Code to insert a picture
            ToolStrip ToolStrip = (ToolStrip)sender;
            //If it is "End edit mode" then don't insert anything
            PictureBox MyPicturebox = new PictureBox();
            //Add handlers that will move the image on the screen
            MyPicturebox.MouseDown += MyMouseClick;
            MyPicturebox.MouseMove += MyMouseMove;
            MyPicturebox.MouseUp += MyMouseUp;
            //Adding an image and properties for the image
            //axAcroPDF1.Controls.Add(MyPicturebox);
            axAcroPDF1.CreateGraphics();
            this.Controls.Add(MyPicturebox);
            MyPicturebox.Location = new Point(40, 40);
            MyPicturebox.BringToFront();
            MyPicturebox.BackgroundImageLayout = ImageLayout.Stretch;
            //Find out which button is pressed to insert the right image. 
            int TagId = Convert.ToInt32(e.ClickedItem.Tag);
            MyPicturebox.BackgroundImage = ToolStrip.Items[TagId].Image;
            MyPicturebox.Name = ToolStrip.Items[TagId].ToolTipText;

            MyPicturebox.Size = new System.Drawing.Size(70, 70);
            ToolStrip.Invalidate();
        }

        private string FindLastId()
        {
            string Id = null;
            return Id;
        }
        public void MyMouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox ToolStrip = (PictureBox)sender;
            if (ToolStrip1.Visible == true)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this.Cursor = Cursors.Hand;

                    Dragging = true;
                    mousex = -e.X;
                    mousey = -e.Y;
                    int clipleft = this.PointToClient(MousePosition).X - ToolStrip.Location.X;
                    int cliptop = this.PointToClient(MousePosition).Y - ToolStrip.Location.Y;
                    int clipwidth = this.ClientSize.Width - (ToolStrip.Width - clipleft);
                    int clipheight = this.ClientSize.Height - (ToolStrip.Height - cliptop);
                    System.Windows.Forms.Cursor.Clip = this.RectangleToScreen(new System.Drawing.Rectangle(clipleft, cliptop, clipwidth, clipheight));
                    ToolStrip.Invalidate();
                }
            }
        }

        public void MyMouseMove(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox ToolStrip = (PictureBox)sender;
            if (ToolStrip1.Visible == true)
            {
                if (Dragging)
                {
                    Point MPosition = new Point();
                    MPosition = this.PointToClient(MousePosition);
                    MPosition.Offset(mousex, mousey);                    
                    ToolStrip.Location = MPosition;
                }
            }
        }

        private void MyMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox ToolStrip = (PictureBox)sender;
            if (ToolStrip1.Visible == true)
            {
                if (Dragging)
                {

                    Dragging = false;
                    ToolStrip.Invalidate();
                }
                this.Cursor = Cursors.Arrow;
            }
        }

     
        private void btnEndEditMode_Click(object sender, EventArgs e)
        {
            ToolStrip1.Visible = false;

        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            CreatePDFFile();
        }
    }
}
