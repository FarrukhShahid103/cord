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

namespace RDProject.RD
{
    public partial class ScanImages_English : Form
    {
        public Guid registryId;

        List<eRegistryImages> oeListRegistryImages = null;

        private int _numberPreviewImages = 100;
        private int _imageSize = 50;
        private int _currentStartImageIndex = 0;
        private int _currentEndImageIndex = 0;

        public ScanImages_English()
        {
            InitializeComponent();
        }

        private void getImages()
        {
            eRegistryImages oeRegistryImages = new eRegistryImages();
            bRegistryImages obRegistryImages = new bRegistryImages();
            oeListRegistryImages = new List<eRegistryImages>();
            oeRegistryImages.Registry_id = registryId;
            oeListRegistryImages = obRegistryImages.getRegistryImages(oeRegistryImages, "", "", 0, int.MaxValue);
            if (oeListRegistryImages != null && oeListRegistryImages.Count > 0)
            {
                if (_numberPreviewImages == 1)
                {
                    _currentStartImageIndex = 0;
                    _currentEndImageIndex = 1;
                }
                else
                {
                    _currentEndImageIndex = _currentStartImageIndex + _numberPreviewImages - 1;
                }
                LoadImages();
            }

            
        }

        private void LoadImages()
        {
            try
            {
                if (oeListRegistryImages == null)
                {
                    return;
                }

                if (this.WindowState == FormWindowState.Minimized)
                {
                    return;
                }

                grdScanningImages.Rows.Clear();
                grdScanningImages.Columns.Clear();

                int numColumnsForWidth = (grdScanningImages.Width - 10) / (_imageSize + 20);
                int numRows = 0;

                int numImagesRequired = 0;

                if (_currentEndImageIndex > oeListRegistryImages.Count)
                {
                    // Are we requesting to display more images than we actually have? If so then reduce
                    if (_currentStartImageIndex == 0)
                    {
                        numImagesRequired = oeListRegistryImages.Count;
                    }
                    else
                    {
                        numImagesRequired = (_currentEndImageIndex - _currentStartImageIndex) - (_currentEndImageIndex - oeListRegistryImages.Count);
                    }
                }
                else
                {
                    // Calculated the number of rows we will need for normal use
                    numImagesRequired = _currentEndImageIndex - _currentStartImageIndex;
                }

                numRows = numImagesRequired / numColumnsForWidth;

                // Do we have a an overfill for a row
                if (numImagesRequired % numColumnsForWidth > 0)
                {
                    numRows += 1;
                }

                // Catch when we have less images than the maximum number of columns for the DataGridView width
                if (numImagesRequired < numColumnsForWidth)
                {
                    numColumnsForWidth = numImagesRequired;
                }

                int numGeneratedCells = numRows * numColumnsForWidth;

                // Dynamically create the columns
                for (int index = 0; index < numColumnsForWidth; index++)
                {
                    DataGridViewImageColumn dataGridViewColumn = new DataGridViewImageColumn();

                    grdScanningImages.Columns.Add(dataGridViewColumn);
                    grdScanningImages.Columns[index].Width = _imageSize + 20;
                }

                // Create the rows
                for (int index = 0; index < numRows; index++)
                {
                    grdScanningImages.Rows.Add();
                    grdScanningImages.Rows[index].Height = _imageSize + 20;
                }

                int columnIndex = 0;
                int rowIndex = 0;

                for (int index = _currentStartImageIndex; index < _currentStartImageIndex + numImagesRequired; index++)
                {
                    // Load the image from the file and add to the DataGridView
                    byte[] data = (byte[])oeListRegistryImages[index].Image_file;
                    MemoryStream ms = new MemoryStream(data);
                    Image x = Image.FromStream(ms);
                    //Image x = (Bitmap)((new ImageConverter()).ConvertFrom(oeListRegistryImages[index].Image_file));
                    Image image = ResizeImage(x, _imageSize, _imageSize, false);
                    grdScanningImages.Rows[rowIndex].Cells[columnIndex].Value = image;
                    //grdScanningImages.Rows[rowIndex].Cells[columnIndex].ToolTipText = Path.GetFileName(_files[index]);

                    // Have we reached the end column? if so then start on the next row
                    if (columnIndex == numColumnsForWidth - 1)
                    {
                        rowIndex++;
                        columnIndex = 0;
                    }
                    else
                    {
                        columnIndex++;
                    }
                }

                // Blank the unused cells
                if (numGeneratedCells > numImagesRequired)
                {
                    for (int index = 0; index < numGeneratedCells - numImagesRequired; index++)
                    {
                        DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
                        dataGridViewCellStyle.NullValue = null;
                        dataGridViewCellStyle.Tag = "BLANK";
                        grdScanningImages.Rows[rowIndex].Cells[columnIndex + index].Style = dataGridViewCellStyle;
                    }
                }

                //if (_currentStartImageIndex == 0)
                //{
                //    btnPreviousImages.Enabled = false;
                //}
                //else
                //{
                //    btnPreviousImages.Enabled = true;
                //}

                //if (_currentEndImageIndex < _files.Count)
                //{
                //    btnNextImages.Enabled = true;
                //}
                //else
                //{
                //    btnNextImages.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void byteArrayToImage(byte[] byteArrayIn)
        {
            //System.Drawing.Image newImage;
            //string strFileName = GetTempFolderName() + "yourfilename.gif";
            //if (byteArrayIn != null)
            //{
            //    using (MemoryStream stream = new MemoryStream(byteArrayIn))
            //    {
            //        newImage = System.Drawing.Image.FromStream(stream);
            //        newImage.Save(strFileName);
            //        img.Attributes.Add("src", strFileName);
            //    }
            //    lblMessage.Text = "The image conversion was successful.";
            //}
            //else
            //{
            //    Response.Write("No image data found!");
            //}
        }

        private Image ResizeImage(Image file, int width, int height, bool onlyResizeIfWider)
        {
            using (file)
            {
                // Prevent using images internal thumbnail
                file.RotateFlip(RotateFlipType.Rotate180FlipNone);
                file.RotateFlip(RotateFlipType.Rotate180FlipNone);

                if (onlyResizeIfWider == true)
                {
                    if (file.Width <= width)
                    {
                        width = file.Width;
                    }
                }

                int newHeight = file.Height * width / file.Width;
                if (newHeight > height)
                {
                    // Resize with height instead
                    width = file.Width * height / file.Height;
                    newHeight = height;
                }

                Image NewImage = file.GetThumbnailImage(width, newHeight, null, IntPtr.Zero);

                return NewImage;
            }
        }

        private void fillColumnScanningGrid()
        {
            DataGridViewTextBoxColumn dgvRegistryImageId = new DataGridViewTextBoxColumn();
            dgvRegistryImageId.Name = "colRegistryImageId";
            dgvRegistryImageId.Visible = false;
            grdScanningImages.Columns.Add(dgvRegistryImageId);

            DataGridViewImageColumn dgvImageFile = new DataGridViewImageColumn();
            dgvImageFile.HeaderText = "Image";
            dgvImageFile.Name = "colImageFile";
            grdScanningImages.Columns.Add(dgvImageFile);

        }

        private void ScanImages_English_Load(object sender, EventArgs e)
        {
            getImages();
            //fillColumnScanningGrid();
            //getAllScanningImageWithRegId();
            cbxNoOfImage.SelectedIndex = 0;

            int numImages = 0;
            if (int.TryParse(cbxNoOfImage.Items[cbxNoOfImage.SelectedIndex].ToString(), out numImages) == true)
            {
                _numberPreviewImages = numImages;

                if (_numberPreviewImages == 1)
                {
                    _currentStartImageIndex = 0;
                    _currentEndImageIndex = 1;
                }
                else
                {
                    _currentEndImageIndex = _currentStartImageIndex + _numberPreviewImages - 1;
                }
            }
            
        }

        private void getAllScanningImageWithRegId()
        {
            eRegistryImages oeRegistryImages = new eRegistryImages();
            bRegistryImages obRegistryImages = new bRegistryImages();
            List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
            oeRegistryImages.Registry_id = registryId;
            oeListRegistryImages = obRegistryImages.getRegistryImages(oeRegistryImages, "", "", 0, int.MaxValue);
            if (oeListRegistryImages != null && oeListRegistryImages.Count > 0)
            {
                for (int i = 0; i < oeListRegistryImages.Count; i++)
                {
                    grdScanningImages.Rows.Add();
                    grdScanningImages.Rows[grdScanningImages.Rows.Count - 1].Cells["colRegistryImageId"].Value = oeListRegistryImages[i].RegistryImages_id;
                    grdScanningImages.Rows[grdScanningImages.Rows.Count - 1].Cells["colImageFile"].Value = oeListRegistryImages[i].Image_file;
                    grdScanningImages.Rows[grdScanningImages.Rows.Count - 1].Height = 150;
                }
            }
        }

        private void grdScanningImages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdScanningImages.Rows.Count > 0)
            {
                Guid RegistryImageId = ValidateFields.GetSafeGuid(grdScanningImages.Rows[e.RowIndex].Cells["colRegistryImageId"].Value);
                if (RegistryImageId != Guid.Empty)
                {
                    ScanningForm_English obj = new ScanningForm_English();
                    obj.registryImageId = RegistryImageId;
                    obj.NewRecord = false;
                    obj.ShowDialog();
                }
            }
        }

        private void cbxNoOfImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNoOfImage.SelectedIndex == -1)
            {
                return;
            }
            int numImages = 0;
            if (int.TryParse(cbxNoOfImage.Items[cbxNoOfImage.SelectedIndex].ToString(), out numImages) == true)
            {
                _numberPreviewImages = numImages;
                _currentStartImageIndex = 0;
                _currentEndImageIndex = _currentStartImageIndex + _numberPreviewImages;
                this.LoadImages();
            }
        }
    }
}
