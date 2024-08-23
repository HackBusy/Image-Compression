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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImageComp
            // 
            this.ImageComp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ImageComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ImageComp.Location = new System.Drawing.Point(85, 103);
            this.ImageComp.Name = "ImageComp";
            this.ImageComp.Size = new System.Drawing.Size(245, 97);
            this.ImageComp.TabIndex = 0;
            this.ImageComp.Text = "Image Compression";
            this.ImageComp.UseVisualStyleBackColor = false;
            this.ImageComp.Click += new System.EventHandler(this.ImageButtonClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Location = new System.Drawing.Point(85, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 97);
            this.button1.TabIndex = 0;
            this.button1.Text = "Video Compression";
            this.button1.UseVisualStyleBackColor = false;
            //this.button1.Click += new System.EventHandler(this.ImageButtonClick);
            // 
            // ChoramaSubsampelingChoises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(429, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ImageComp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChoramaSubsampelingChoises";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CS Compression";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ImageComp;
        private System.Windows.Forms.Button button1;
    }
}

