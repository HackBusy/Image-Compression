using Image_And_Video_Compression.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_And_Video_Compression
{
    public partial class ImageCompression : Form
    {
        public ImageCompression()
        {
            InitializeComponent();

            this.addImageLabel.DragDrop += new DragEventHandler(label1_DragDrop);
            this.addImageLabel.DragEnter += new DragEventHandler(label1_DragEnter);
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            } else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            s[0].Contains(".png ");
            loadImage(s[0]);
        }

        private void loadImage(string filename)
        {
            this.InputImage.Image = Image.FromFile(filename);
            this.InputImage.Name = filename;
            this.InputImage.SizeMode = PictureBoxSizeMode.Zoom;
            this.addImageLabel.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            String input;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select an Image";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Image File(*.img)|*.img| JPG File(*.JPG)|*.JPG| PNG file(*.png)|*.png";
            openFileDialog.FilterIndex = 15;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                input = openFileDialog.FileName;
                loadImage(input);
            }
            else
            {
                input = "";
            }

        }
    }
}
