using System.Drawing;
using System.Windows.Forms;

namespace Image_And_Video_Compression
{
    partial class ImageCompression
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addImageLabel = new System.Windows.Forms.Label();
            this.InputImage = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addImageLabel
            // 
            this.addImageLabel.AllowDrop = true;
            this.addImageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addImageLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addImageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addImageLabel.Location = this.InputImage.Location;
            this.addImageLabel.Name = "addImageLabel";
            this.addImageLabel.Size = this.InputImage.Size;
            this.addImageLabel.TabIndex = 2;
            this.addImageLabel.Text = "Upload Image";
            this.addImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addImageLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // InputImage
            // 
            this.InputImage.Location = new System.Drawing.Point(0, 0);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(100, 50);
            this.InputImage.TabIndex = 0;
            this.InputImage.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(150, 100);
            this.splitContainer1.TabIndex = 0;
            // 
            // ImageCompression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1777, 855);
            this.Controls.Add(this.addImageLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ImageCompression";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageCompression";
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label addImageLabel;
        private System.Windows.Forms.PictureBox InputImage;
        private SplitContainer splitContainer1;
    }
}