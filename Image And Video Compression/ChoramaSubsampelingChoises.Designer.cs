namespace Image_And_Video_Compression
{
    partial class ChoramaSubsampelingChoises
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
            this.ImageComp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImageComp
            // 
            this.ImageComp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ImageComp.Location = new System.Drawing.Point(120, 120);
            this.ImageComp.Name = "ImageComp";
            this.ImageComp.Size = new System.Drawing.Size(182, 54);
            this.ImageComp.TabIndex = 0;
            this.ImageComp.Text = "Image Compression";
            this.ImageComp.UseVisualStyleBackColor = false;
            this.ImageComp.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChoramaSubsampelingChoises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(429, 470);
            this.Controls.Add(this.ImageComp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChoramaSubsampelingChoises";
            this.Text = "CS Compression";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ImageComp;
    }
}

