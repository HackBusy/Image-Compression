using System.Drawing;

namespace ChromaSubsamplingCompression
{
    abstract class ChromaSubsampling
    {
        protected Bitmap m_OriginalImage;
        protected YCbCr m_YCbCrOriginalMap;

        public ChromaSubsampling(string i_FilePath)
        {
            m_OriginalImage = new Bitmap(i_FilePath);
            m_YCbCrOriginalMap = new YCbCr(m_OriginalImage.Width, m_OriginalImage.Height, 1, 1); // full vertical resolution, full horizontal resolution

            ConvertRGBtoYCbCr();
        }

        private void ConvertRGBtoYCbCr()
        {
            byte red;
            byte green;
            byte blue;
            Color imagePixel;

            for (int x = 0; x < m_OriginalImage.Width; x++)
            {
                for (int y = 0; y < m_OriginalImage.Height; y++)
                {
                    imagePixel = m_OriginalImage.GetPixel(x, y);
                    red = imagePixel.R;
                    green = imagePixel.G;
                    blue = imagePixel.B;

                    // Convert RGB values to YCbCr
                    m_YCbCrOriginalMap.Y[x, y] = (byte)((0.299 * red) + (0.587 * green) + (0.114 * blue));
                    m_YCbCrOriginalMap.Cb[x, y] = (byte)(128 - (0.168736 * red) - (0.331264 * green) + (0.5 * blue));
                    m_YCbCrOriginalMap.Cr[x, y] = (byte)(128 + (0.5 * red) - (0.418688 * green) - (0.081312 * blue));
                }
            }
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

        protected abstract void compression();

        protected abstract void decompression();

        protected abstract void ConvertYCbCrToRGB();
    }
}
