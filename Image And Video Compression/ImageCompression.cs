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

        Button [] compressionButtons;
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

            ((ISupportInitialize)(this.InputImage)).BeginInit();
            this.Controls.Remove(this.addImageLabel);
            this.InputImage.Dock = DockStyle.Top;
            this.InputImage.Location = new Point(0, 0);
            this.InputImage.Margin = new Padding(20);
            this.InputImage.Size = new Size(1777, 450);
            this.InputImage.TabIndex = 1;
            this.InputImage.TabStop = false;
            this.InputImage.Image = Image.FromFile(filename);
            this.InputImage.Name = filename;
            this.InputImage.SizeMode = PictureBoxSizeMode.Zoom;
            generateCompressionButtons();
            this.Controls.Add(this.InputImage);
            ((ISupportInitialize)(this.InputImage)).EndInit();
           
        }

        private void generateCompressionButtons()
        {
            this.compressionButtons = new Button[4];
            for (int i = 0; i < this.compressionButtons.Length; i++)
            {
                this.compressionButtons[i] = new Button();
                int xLocation = (i) * 120 + i * 130;
                this.compressionButtons[i].Location = new Point(120 + xLocation, 485);
                this.compressionButtons[i].Name = "button" + i + 1;
                this.compressionButtons[i].Size = new Size(130, 40);
                this.compressionButtons[i].TabIndex = 0;
                this.compressionButtons[i].UseVisualStyleBackColor = true;
                this.Controls.Add(compressionButtons[i]);
            }
            this.compressionButtons[0].Text = "4:2:2";
            this.compressionButtons[1].Text = "4:4:0";
            this.compressionButtons[2].Text = "4:2:0";
            this.compressionButtons[3].Text = "4:1:1";
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
