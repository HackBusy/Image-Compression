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

        private Button [] compressionButtons;
        private Button saveButton;
        private PictureBox compressedPicture;

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
            this.compressionButtons[0].Click += new EventHandler(this.twoTwoCompressionHandler);
            this.compressionButtons[1].Click += new EventHandler(this.twoTwoCompressionHandler);
            this.compressionButtons[2].Click += new EventHandler(this.twoTwoCompressionHandler);
            this.compressionButtons[3].Click += new EventHandler(this.twoTwoCompressionHandler);
        }

        private void twoTwoCompressionHandler(object sender, EventArgs e)
        {
            this.Controls.Clear();
            fixScreen();
        }

        private void fixScreen()
        {
            this.compressedPicture = new PictureBox();
            this.saveButton = new Button();
            ((ISupportInitialize)(this.compressedPicture)).BeginInit();
            ((ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            //
            // compressedPicture
            //
            this.compressedPicture.Dock = DockStyle.Top;
            this.compressedPicture.Location = new Point(0, 0);
            this.compressedPicture.Size = new Size(1200, 450);
            this.compressedPicture.Margin = new Padding(20);
            this.compressedPicture.TabIndex = 1;
            this.compressedPicture.TabStop = false;
            this.compressedPicture.Image = this.InputImage.Image;
            this.compressedPicture.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // saveButton
            //
            this.saveButton.Location = new Point(250, 485);
            this.saveButton.Size = new Size(100, 30);
            this.saveButton.TabIndex = 0;
            this.saveButton.Name = "SaveButton";
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.InputImage);
            int index = 0;
            foreach(Button button in this.compressionButtons)
            {
                button.Size = new Size(100, 30);
                button.Location = new Point(100 * index++ + 40 * index, 485);
                this.splitContainer1.Panel1.Controls.Add(button);
            }
            //
            // splitContainer1.Panel2
            //
            this.splitContainer1.Panel2.Controls.Add(this.compressedPicture);
            this.splitContainer1.Panel2.Controls.Add((Button)this.saveButton);

            //
            // ImageCompression
            //
            this.splitContainer1.Size = new Size(1204, 855);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.TabIndex = 3;
            this.Controls.Add(splitContainer1);
            ((ISupportInitialize) (this.compressedPicture)).EndInit();
            ((ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            String input = filePath("Image File(*.img)|*.img| PNG file(*.png)|*.png| JPG File(*.JPG)|*.JPG");
            if (input != "" )
            {
                loadImage(input);
            }

        }

        private String filePath(String filter)
        {
            String output;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select an Image";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = filter;
            openFileDialog.FilterIndex = 15;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                output = openFileDialog.FileName;
            }
            else
            {
                output = "";
            }
            return output;
        }
    }
}
