namespace Image_Compression
{
    partial class CbCrChanges
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.originalCr = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.originalCb = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.compressedCr = new System.Windows.Forms.PictureBox();
            this.compressedCb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalCr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressedCr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressedCb)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.originalCr);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.originalCb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.compressedCr);
            this.splitContainer1.Panel2.Controls.Add(this.compressedCb);
            this.splitContainer1.Size = new System.Drawing.Size(1656, 900);
            this.splitContainer1.SplitterDistance = 850;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Original Cr";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // originalCr
            // 
            this.originalCr.BackColor = System.Drawing.SystemColors.Control;
            this.originalCr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.originalCr.Location = new System.Drawing.Point(0, 451);
            this.originalCr.Name = "originalCr";
            this.originalCr.Size = new System.Drawing.Size(850, 449);
            this.originalCr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.originalCr.TabIndex = 2;
            this.originalCr.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Original Cb";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // originalCb
            // 
            this.originalCb.BackColor = System.Drawing.SystemColors.Control;
            this.originalCb.Dock = System.Windows.Forms.DockStyle.Top;
            this.originalCb.Location = new System.Drawing.Point(0, 0);
            this.originalCb.Name = "originalCb";
            this.originalCb.Size = new System.Drawing.Size(850, 450);
            this.originalCb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.originalCb.TabIndex = 1;
            this.originalCb.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(12, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Compressed Cr";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compressed Cb";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compressedCr
            // 
            this.compressedCr.BackColor = System.Drawing.SystemColors.Control;
            this.compressedCr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.compressedCr.Location = new System.Drawing.Point(0, 451);
            this.compressedCr.Name = "compressedCr";
            this.compressedCr.Size = new System.Drawing.Size(802, 449);
            this.compressedCr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.compressedCr.TabIndex = 3;
            this.compressedCr.TabStop = false;
            // 
            // compressedCb
            // 
            this.compressedCb.BackColor = System.Drawing.SystemColors.Control;
            this.compressedCb.Dock = System.Windows.Forms.DockStyle.Top;
            this.compressedCb.Location = new System.Drawing.Point(0, 0);
            this.compressedCb.Name = "compressedCb";
            this.compressedCb.Size = new System.Drawing.Size(802, 450);
            this.compressedCb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.compressedCb.TabIndex = 2;
            this.compressedCb.TabStop = false;
            // 
            // CbCrChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 900);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "CbCrChanges";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Changes";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalCr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressedCr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressedCb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox originalCr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox originalCb;
        private System.Windows.Forms.PictureBox compressedCr;
        private System.Windows.Forms.PictureBox compressedCb;
        private System.Windows.Forms.Label label4;
    }
}