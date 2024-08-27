using System.Drawing;

namespace ChromaSubsamplingCompression
{
    public abstract class ChromaSubsampling
    {
        protected Bitmap m_OriginalImage;
        protected YCbCr m_YCbCrOriginalMap;
        protected YCbCr m_YCbCrCompressed;
        protected YCbCr m_YCbCrDecompressed;
        protected int m_YWidth;
        protected int m_YHeight;
        protected int m_CrCbWidth;
        protected int m_CrCbHeight;
        protected Bitmap m_DecompressedImage;
        protected Bitmap m_OriginalCb;
        protected Bitmap m_OriginalCr;
        protected Bitmap m_DecompressedCb;
        protected Bitmap m_DecompressedCr;

        protected ChromaSubsampling(string i_FilePath)
        {
            m_OriginalImage = new Bitmap(i_FilePath);
            m_YWidth = m_OriginalImage.Width;
            m_YHeight = m_OriginalImage.Height;
            m_YCbCrOriginalMap = new YCbCr(m_YWidth, m_YHeight, 1, 1); // full vertical resolution, full horizontal resolution
            m_OriginalCb = new Bitmap(m_YWidth, m_YHeight);
            m_OriginalCr = new Bitmap(m_YWidth, m_YHeight);
            m_YCbCrDecompressed = new YCbCr(m_YWidth, m_YHeight, 1, 1); // full vertical resolution, full horizontal resolution
            m_DecompressedImage = new Bitmap(m_YWidth, m_YHeight);
            m_DecompressedCb = new Bitmap(m_YWidth, m_YHeight);
            m_DecompressedCr = new Bitmap(m_YWidth, m_YHeight);


            ConvertRGBtoYCbCr();
        }

        public Bitmap CompressedImage
        {
            get
            {
                return m_DecompressedImage;
            }
        }

        public Bitmap OriginalCb
        {
            get
            {
                return m_OriginalCb;
            }
        }

        public Bitmap OriginalCr
        {
            get
            {
                return m_OriginalCr;
            }
        }

        public Bitmap DecompressedCb
        {
            get
            {
                return m_DecompressedCb;
            }
        }

        public Bitmap DecompressedCr
        {
            get
            {
                return m_DecompressedCr;
            }
        }

        private void ConvertRGBtoYCbCr()
        {
            byte red;
            byte green;
            byte blue;
            Color imagePixel;

            for (int x = 0; x < m_YWidth; x++)
            {
                for (int y = 0; y < m_YHeight; y++)
                {
                    imagePixel = m_OriginalImage.GetPixel(x, y);
                    red = imagePixel.R;
                    green = imagePixel.G;
                    blue = imagePixel.B;

                    // Convert RGB values to YCbCr
                    m_YCbCrOriginalMap.Y[x, y] = (byte)((0.299 * red) + (0.587 * green) + (0.114 * blue));
                    m_YCbCrOriginalMap.Cb[x, y] = (byte)(128 - (0.168736 * red) - (0.331264 * green) + (0.5 * blue));
                    m_YCbCrOriginalMap.Cr[x, y] = (byte)(128 + (0.5 * red) - (0.418688 * green) - (0.081312 * blue));

                    // Save original Cb, Cr values into Bitmap
                    VisualizeCb(x, y);
                    VisualizeCr(x, y);
                }
            }
        }

        private void VisualizeCb(int x, int y)
        {
            int cbValue = m_YCbCrOriginalMap.Cb[x, y];
            Color cbColor = Color.FromArgb(cbValue, cbValue, cbValue);
            m_OriginalCb.SetPixel(x, y, cbColor);
        }

        private void VisualizeCr(int x, int y)
        {
            int crValue = m_YCbCrOriginalMap.Cr[x, y];
            Color crColor = Color.FromArgb(crValue, crValue, crValue);
            m_OriginalCr.SetPixel(x, y, crColor);
        }

        protected int RGBNormalize(int io_RGB, int i_Min, int i_Max)
        {
            if (io_RGB < i_Min)
            {
                io_RGB = i_Min;
            }
            if (io_RGB > i_Max)
            {
                io_RGB = i_Max;
            }
            return io_RGB;
        }

        protected abstract void Compression();

        protected abstract void Decompression();

        protected abstract void ConvertYCbCrToRGB();
    }
}
