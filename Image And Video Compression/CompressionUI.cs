﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ChromaSubsamplingCompression;

namespace Image_Compression
{
    public partial class CompressionUI : Form
    {

        private Button [] compressionButtons;
        private Button saveButton;
        private Button ShowCompression;
        private Label chooseCompression, compressedLabel, normalLabel;
        private PictureBox compressedPicture;
        private SaveFileDialog saveImage;
        private OpenFileDialog openFileDialog;
        private String inputPath;
        private Bitmap[] diffrentCompression;

        public CompressionUI()
        {
            InitializeComponent();
            this.InitialComponents();
        }

        private void InitialComponents()
        {
            this.addImageLabel.DragDrop += new DragEventHandler(label1_DragDrop);
            this.addImageLabel.DragEnter += new DragEventHandler(label1_DragEnter);
            this.chooseCompression = new Label();
            this.compressedLabel = new Label();
            this.normalLabel = new Label();
            this.saveImage = new SaveFileDialog();
            this.openFileDialog = new OpenFileDialog();
            this.compressedPicture = new PictureBox();
            this.saveButton = new Button();
            this.ShowCompression = new Button();
            this.diffrentCompression = new Bitmap[4]; 
            this.saveButton.Click += new EventHandler(this.saveImageButton);
            this.ShowCompression.Click += new EventHandler(this.showCompressionEvent);
        }

        private void showCompressionEvent(object sender, EventArgs e)
        {
            using (CbCrChanges showChanges = new CbCrChanges(diffrentCompression[0], diffrentCompression[1], diffrentCompression[2], diffrentCompression[3]))
            {
                showChanges.ShowDialog();
            }
        }

        private void add4Photos(Bitmap photo1, Bitmap photo2, Bitmap photo3, Bitmap photo4)
        {
            diffrentCompression[0] = photo1;
            diffrentCompression[1] = photo2;
            diffrentCompression[2] = photo3;
            diffrentCompression[3] = photo4;
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
            if(s[0].Contains(".png") || s[0].Contains(".JPG") || s[0].Contains(".jpg")) {
                loadImage(s[0]);
                inputPath = s[0];
            }
        }

        private void loadImage(string filename)
        {

            ((ISupportInitialize)(this.InputImage)).BeginInit();
            this.Controls.Remove(this.addImageLabel);
            this.InputImage.Dock = DockStyle.Top;
            this.InputImage.Location = new Point(0, 0);
            this.InputImage.Margin = new Padding(20);
            this.InputImage.Size = new Size(1777, 475);
            this.InputImage.TabIndex = 1;
            this.InputImage.TabStop = false;
            this.InputImage.Image = Image.FromFile(filename);
            this.InputImage.Name = filename;
            this.InputImage.SizeMode = PictureBoxSizeMode.CenterImage;
            generateCompressionButtons();
            generateLabels(chooseCompression, "Choose compression", new Size(800, 35), 15f);
            this.Controls.Add(chooseCompression);
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
                this.compressionButtons[i].Location = new Point(120 + xLocation, 520);
                this.compressionButtons[i].Name = "button" + i + 1;
                this.compressionButtons[i].Size = new Size(130, 40);
                this.compressionButtons[i].TabIndex = 0;
                this.compressionButtons[i].UseVisualStyleBackColor = true;
                this.compressionButtons[i].Font = new Font("Microsoft Sans Serif", 15f);
                this.compressionButtons[i].Cursor = Cursors.Hand;
                this.Controls.Add(compressionButtons[i]);
            }
            this.compressionButtons[0].Text = "4:2:2";
            this.compressionButtons[1].Text = "4:4:0";
            this.compressionButtons[2].Text = "4:2:0";
            this.compressionButtons[3].Text = "4:1:1";
            this.compressionButtons[0].Click += new EventHandler(this.twoTwoCompressionHandler);
            this.compressionButtons[1].Click += new EventHandler(this.fourFourCompressionHandler);
            this.compressionButtons[2].Click += new EventHandler(this.TwoZeroCompressionHandler);
            this.compressionButtons[3].Click += new EventHandler(this.oneOneCompressionHandler);
        }

        private void oneOneCompressionHandler(object sender, EventArgs e)
        {
            this.enableAllDisableThisButton(this.compressionButtons, 3);
            CSCompression411 cSCompression411 = new CSCompression411(inputPath);
            Bitmap compressedImg = cSCompression411.CompressedImage;
            add4Photos(cSCompression411.OriginalCb, cSCompression411.OriginalCr, cSCompression411.DecompressedCb, cSCompression411.DecompressedCr);
            this.Controls.Clear();
            fixScreen(compressedImg);
        }

        private void TwoZeroCompressionHandler(object sender, EventArgs e)
        {
            this.enableAllDisableThisButton(this.compressionButtons, 2);
            CSCompression420 cSCompression420 = new CSCompression420(inputPath);
            Bitmap compressedImg = cSCompression420.CompressedImage;
            add4Photos(cSCompression420.OriginalCb, cSCompression420.OriginalCr, cSCompression420.DecompressedCb, cSCompression420.DecompressedCr);
            this.Controls.Clear();
            fixScreen(compressedImg);
        }

        private void fourFourCompressionHandler(object sender, EventArgs e)
        {
            this.enableAllDisableThisButton(this.compressionButtons, 1);
            CSCompression440 cSCompression440 = new CSCompression440(inputPath);
            Bitmap compressedImg = cSCompression440.CompressedImage;
            add4Photos(cSCompression440.OriginalCb, cSCompression440.OriginalCr, cSCompression440.DecompressedCb, cSCompression440.DecompressedCr);
            this.Controls.Clear();
            fixScreen(compressedImg);
        }

        private void twoTwoCompressionHandler(object sender, EventArgs e)
        {
            this.enableAllDisableThisButton(this.compressionButtons, 0);
            CSCompression422 cSCompression422 = new CSCompression422(inputPath);
            Bitmap compressedImg = cSCompression422.CompressedImage;
            add4Photos(cSCompression422.OriginalCb, cSCompression422.OriginalCr, cSCompression422.DecompressedCb, cSCompression422.DecompressedCr);
            this.Controls.Clear();
            fixScreen(compressedImg);
        }

        private void enableAllDisableThisButton(Button[] buttons, int disable)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = true;
            }
            buttons[disable].Enabled = false;
        }

        private void fixScreen(Image compressedImage)
        {
            
            ((ISupportInitialize)(this.compressedPicture)).BeginInit();
            ((ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            //
            // showCompression
            //
            this.ShowCompression.Location = new Point(500, 5);
            this.ShowCompression.Size = new Size(85, 30);
            this.ShowCompression.TabIndex = 0;
            this.ShowCompression.Name = "ShowCompreesion";
            this.ShowCompression.Text = @"CbCr Maps";
            this.ShowCompression.Font = new Font("Microsoft Sans Serif", 10f);
            this.ShowCompression.Cursor = Cursors.Hand;
            this.ShowCompression.UseVisualStyleBackColor = true;
            //
            // compressedPicture
            //
            this.compressedPicture.Dock = DockStyle.Top;
            this.compressedPicture.Location = new Point(0, 0);
            this.compressedPicture.Size = new Size(1200, 450);
            this.compressedPicture.Margin = new Padding(20);
            this.compressedPicture.TabIndex = 1;
            this.compressedPicture.TabStop = false;
            this.compressedPicture.Image = compressedImage;
            this.compressedPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            // 
            // saveButton
            //
            this.saveButton.Location = new Point(225, 520);
            this.saveButton.Size = new Size(100, 30);
            this.saveButton.TabIndex = 0;
            this.saveButton.Name = "SaveButton";
            this.saveButton.Text = "Save";
            this.saveButton.Font = new Font("Microsoft Sans Serif", 15f);
            this.saveButton.Cursor = Cursors.Hand;
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            //
            // Labels
            //
            generateLabels(normalLabel, "Image Before Compression", new Size(800, 35), 15f);
            generateLabels(compressedLabel, "Compressed Image", new Size(800, 35), 15f);
            // 
            // splitContainer1.Panel1
            // 
            this.InputImage.Size = new Size(1777, 450);
            this.splitContainer1.Panel1.Controls.Add(this.chooseCompression);
            this.splitContainer1.Panel1.Controls.Add(this.InputImage);
            this.splitContainer1.Panel1.Controls.Add(this.normalLabel);
            int index = 0;
            foreach(Button button in this.compressionButtons)
            {
                button.Size = new Size(100, 30);
                button.Location = new Point(100 * index++ + 30 * index, 520);
                this.splitContainer1.Panel1.Controls.Add(button);
            }
            //
            // splitContainer1.Panel2
            //
            this.splitContainer1.Panel2.Controls.Add(this.compressedPicture);
            this.splitContainer1.Panel2.Controls.Add((Button)this.saveButton);
            this.splitContainer1.Panel2.Controls.Add(this.compressedLabel);
            //
            // ImageCompression
            //
            this.splitContainer1.Size = new Size(1104, 580);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.TabIndex = 3;
            this.Controls.Add((Button)this.ShowCompression);
            this.Controls.Add(splitContainer1);
            ((ISupportInitialize) (this.compressedPicture)).EndInit();
            ((ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
        }

        private void saveImageButton(object sender, EventArgs e)
        {
            String saveInput = "";
            saveImage.Title = "Save Compressed Image";
            saveImage.InitialDirectory = @"C:\";
            saveImage.Filter = "PNG file(*.png)|*.png";
            saveImage.FilterIndex = 3;
            saveImage.ShowDialog();
            saveInput = saveImage.FileName;
            if (saveInput != "")
            {
                this.compressedPicture.Image.Save(saveInput);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            inputPath = filePath("PNG file(*.png)|*.png| JPG File(*.JPG)|*.JPG", "Select an Image");
            if (inputPath != "" )
            {
                loadImage(inputPath);
            }

        }

        private String filePath(String filter, String title)
        {
            String output;
            openFileDialog.Title = title;
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = filter;
            openFileDialog.FilterIndex = 15;
            openFileDialog.RestoreDirectory = true;
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

        private void generateLabels(Label label, String text, Size size, float fontSize) 
        {
            label.Text = text;
            label.Location = new Point(0, 475);
            label.Size = size;
            label.Font = new Font("Microsoft Sans Serif", fontSize);
            label.TabIndex = 0;
            label.TabStop = false;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Top;
        }
    }
}
