using System.Drawing;

namespace Image_And_Video_Compression
{
    class CSCompression440 : ChromaSubsampling
    {
        YCbCr m_YCbCrCompressed440;
        YCbCr m_YCbCrDecompressed440;
        Bitmap m_CompressedImage;

        public CSCompression440(string i_FilePath) : base(i_FilePath)
        {
            // 1/2 vertical resolution, full horizontal resolution
            m_YCbCrCompressed440 = new YCbCr(m_OriginalImage.Height, m_OriginalImage.Width, 2, 1); 
            m_YCbCrCompressed440.Y = m_YCbCrOriginalMap.Y;
            // full vertical resolution, full horizontal resolution
            m_YCbCrDecompressed440 = new YCbCr(m_OriginalImage.Height, m_OriginalImage.Width, 1, 1); 
            m_YCbCrDecompressed440.Y = m_YCbCrOriginalMap.Y;
            m_CompressedImage = new Bitmap(m_OriginalImage.Height, m_OriginalImage.Width);

            compression();
            decompression();
            ConvertYCbCrToRGB();
        }

        protected override void compression()
        {
            for (int y = 0; y < m_YCbCrCompressed440.Cb.GetLength(0); y++)
            {
                for (int x = 0; x < m_YCbCrCompressed440.Cb.GetLength(1); x++)
                {
                    // Average the 2x1 block of chroma values
                    m_YCbCrCompressed440.Cb[y, x] = (byte)(
                        (m_YCbCrOriginalMap.Cb[y * 2, x] +
                         m_YCbCrOriginalMap.Cb[y * 2 + 1, x]) / 2);

                    m_YCbCrCompressed440.Cr[y, x] = (byte)(
                        (m_YCbCrOriginalMap.Cr[y * 2, x] +
                         m_YCbCrOriginalMap.Cr[y * 2 + 1, x]) / 2);
                }
            }
        }

        protected override void decompression()
        {
            for (int y = 0; y < m_YCbCrCompressed440.Cb.GetLength(0); y++)
            {
                for (int x = 0; x < m_YCbCrCompressed440.Cb.GetLength(1); x++)
                {
                    // Replicate each subsampled chroma value to the 2x1 block in the decompressed array
                    m_YCbCrDecompressed440.Cb[y * 2, x] = m_YCbCrCompressed440.Cb[x, y];
                    m_YCbCrDecompressed440.Cb[y * 2 + 1, x] = m_YCbCrCompressed440.Cb[x, y];

                    m_YCbCrDecompressed440.Cr[y * 2, x] = m_YCbCrCompressed440.Cr[x, y];
                    m_YCbCrDecompressed440.Cr[y * 2 + 1, x] = m_YCbCrCompressed440.Cr[x, y];
                }
            }
        }

        protected override void ConvertYCbCrToRGB()
        {
            for (int y = 0; y < m_YCbCrDecompressed440.Cb.GetLength(0); y++)
            {
                for (int x = 0; x < m_YCbCrDecompressed440.Cb.GetLength(1); x++)
                {
                    // Convert YCbCr to RGB
                    int yValue = m_YCbCrDecompressed440.Y[y, x];
                    int cbValue = m_YCbCrDecompressed440.Cb[y, x] - 128;
                    int crValue = m_YCbCrDecompressed440.Cr[y, x] - 128;

                    int rValue = (int)(yValue + 1.402 * crValue);
                    int gValue = (int)(yValue - 0.344136 * cbValue - 0.714136 * crValue);
                    int bValue = (int)(yValue + 1.772 * cbValue);

                    rValue = RGBNormalize(rValue, 0, 255);
                    gValue = RGBNormalize(rValue, 0, 255);
                    bValue = RGBNormalize(rValue, 0, 255);

                    Color pixelColor = Color.FromArgb(rValue, gValue, bValue);
                    m_CompressedImage.SetPixel(x, y, pixelColor);
                }
            }
        }
    }
}
