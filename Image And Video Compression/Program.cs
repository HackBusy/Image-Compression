using System;
using System.Windows.Forms;

namespace Image_Compression
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new CompressionUI());
        }
    }
}
