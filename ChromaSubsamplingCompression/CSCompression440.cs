using System.Drawing;

namespace ChromaSubsamplingCompression
{
    class CSCompression440 : ChromaSubsampling
    {
        YCbCr m_YCbCrCompressed440;
        YCbCr m_YCbCrDecompressed440;
        public Bitmap m_CompressedImage;

        public CSCompression440(string i_FilePath) : base(i_FilePath)
        {
            // 1/2 vertical resolution, full horizontal resolution
            m_YCbCrCompressed440 = new YCbCr(m_OriginalImage.Width, m_OriginalImage.Height, 1, 2); 
            m_YCbCrCompressed440.Y = m_YCbCrOriginalMap.Y;
            // full vertical resolution, full horizontal resolution
            m_YCbCrDecompressed440 = new YCbCr(m_OriginalImage.Width, m_OriginalImage.Height, 1, 1); 
            m_YCbCrDecompressed440.Y = m_YCbCrOriginalMap.Y;
            m_CompressedImage = new Bitmap(m_OriginalImage.Width, m_OriginalImage.Height);

            compression();
            decompression();
            ConvertYCbCrToRGB();
        }

        protected override void compression()
        {
            for (int x = 0; x < m_YCbCrCompressed440.Cb.GetLength(0); x++)
            {
                for (int y = 0; y < m_YCbCrCompressed440.Cb.GetLength(1); y++)
                {
                    // Average the 2x1 block of chroma values
                    m_YCbCrCompressed440.Cb[x, y] = (byte)(
                        (m_YCbCrOriginalMap.Cb[x, y * 2] +
                         m_YCbCrOriginalMap.Cb[x, y * 2 + 1]) / 2);

                    m_YCbCrCompressed440.Cr[x, y] = (byte)(
                        (m_YCbCrOriginalMap.Cr[x, y * 2] +
                         m_YCbCrOriginalMap.Cr[x, y * 2 + 1]) / 2);
                }
            }
        }

        protected override void decompression()
        {
            for (int x = 0; x < m_YCbCrCompressed440.Cb.GetLength(0); x++)
            {
                for (int y = 0; y < m_YCbCrCompressed440.Cb.GetLength(1); y++)
                {
                    // Replicate each subsampled chroma value to the 2x1 block in the decompressed array
                    m_YCbCrDecompressed440.Cb[x, y * 2] = m_YCbCrCompressed440.Cb[x, y];
                    m_YCbCrDecompressed440.Cb[x, y * 2 + 1] = m_YCbCrCompressed440.Cb[x, y];

                    m_YCbCrDecompressed440.Cr[x, y * 2] = m_YCbCrCompressed440.Cr[x, y];
                    m_YCbCrDecompressed440.Cr[x, y * 2 + 1] = m_YCbCrCompressed440.Cr[x, y];
                }
            }
        }

        protected override void ConvertYCbCrToRGB()
        {
            for (int x = 0; x < m_YCbCrDecompressed440.Y.GetLength(0); x++)
            {
                for (int y = 0; y < m_YCbCrDecompressed440.Y.GetLength(1); y++)
                {
                    // Convert YCbCr to RGB
                    int yValue = m_YCbCrDecompressed440.Y[x, y];
                    int cbValue = m_YCbCrDecompressed440.Cb[x, y] - 128;
                    int crValue = m_YCbCrDecompressed440.Cr[x, y] - 128;

                    int rValue = (int)(yValue + (1.402 * crValue));
                    int gValue = (int)(yValue - (0.344136 * cbValue) - (0.714136 * crValue));
                    int bValue = (int)(yValue + (1.772 * cbValue));

                    rValue = RGBNormalize(rValue, 0, 255);
                    gValue = RGBNormalize(gValue, 0, 255);
                    bValue = RGBNormalize(bValue, 0, 255);

                    Color pixelColor = Color.FromArgb(rValue, gValue, bValue);
                    m_CompressedImage.SetPixel(x, y, pixelColor);
                }
            }
        }
    }
}
