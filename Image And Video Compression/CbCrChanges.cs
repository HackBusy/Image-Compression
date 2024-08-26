using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Compression
{
    public partial class CbCrChanges : Form
    {
        public CbCrChanges(Image originalB, Image originalR, Image compressedB, Image compressedR)
        {
            InitializeComponent();
            this.originalCb.Image = originalB;
            this.originalCr.Image = originalR;
            this.compressedCb.Image = compressedB;
            this.compressedCr.Image = compressedR;
        }
    }
}
