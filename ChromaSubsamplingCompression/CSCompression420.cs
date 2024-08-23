using System.Drawing;

namespace Image_And_Video_Compression
{
    class CSCompression420 : ChromaSubsampling
    {
        YCbCr m_YCbCrCompressed420;
        YCbCr m_YCbCrDecompressed420;
        Bitmap m_CompressedImage;

        public CSCompression420(string i_FilePath) : base(i_FilePath)
        {
            // 1/2 vertical resolution, 1/2 horizontal resolution
            m_YCbCrCompressed420 = new YCbCr(m_OriginalImage.Height, m_OriginalImage.Width, 2, 2);
            m_YCbCrCompressed420.Y = m_YCbCrOriginalMap.Y;
            // full vertical resolution, full horizontal resolution
            m_YCbCrDecompressed420 = new YCbCr(m_OriginalImage.Height, m_OriginalImage.Width, 1, 1);
            m_YCbCrDecompressed420.Y = m_YCbCrOriginalMap.Y;
            m_CompressedImage = new Bitmap(m_OriginalImage.Height, m_OriginalImage.Width);

            compression();
            decompression();
            ConvertYCbCrToRGB();
        }

        protected override void compression()
        {
            for (int y = 0; y < m_YCbCrCompressed420.Cb.GetLength(0); y++)
            {
                for (int x = 0; x < m_YCbCrCompressed420.Cb.GetLength(1); x++)
                {
                    // Average the 2x2 block of chroma values
                    m_YCbCrCompressed420.Cb[y, x] = (byte)(
                        (m_YCbCrOriginalMap.Cb[y * 2, x * 2] +
                         m_YCbCrOriginalMap.Cb[y * 2, x * 2 + 1] +
                         m_YCbCrOriginalMap.Cb[y * 2 + 1, x * 2] +
                         m_YCbCrOriginalMap.Cb[y * 2 + 1, x * 2 + 1]) / 4);

                    m_YCbCrCompressed420.Cr[y, x] = (byte)(
                        (m_YCbCrOriginalMap.Cr[y * 2, x * 2] +
                         m_YCbCrOriginalMap.Cr[y * 2, x * 2 + 1] +
                         m_YCbCrOriginalMap.Cr[y * 2 + 1, x * 2] +
                         m_YCbCrOriginalMap.Cr[y * 2 + 1, x * 2 + 1]) / 4);
                }
            }
        }

        protected override void decompression()
        {
            for (int y = 0; y < m_YCbCrCompressed420.Cb.GetLength(0); y++)
            {
                for (int x = 0; x < m_YCbCrCompressed420.Cb.GetLength(1); x++)
                {
                    // Replicate each subsampled chroma value to the 2x2 block in the decompressed array
                    m_YCbCrDecompressed420.Cb[y * 2, x * 2] = m_YCbCrCompressed420.Cb[x, y];
                    m_YCbCrDecompressed420.Cb[y * 2, x * 2 + 1] = m_YCbCrCompressed420.Cb[x, y];
                    m_YCbCrDecompressed420.Cb[y * 2 + 1, x * 2] = m_YCbCrCompressed420.Cb[x, y];
                    m_YCbCrDecompressed420.Cb[y * 2 + 1, x * 2 + 1] = m_YCbCrCompressed420.Cb[x, y];

                    m_YCbCrDecompressed420.Cr[y * 2, x * 2] = m_YCbCrCompressed420.Cr[x, y];
                    m_YCbCrDecompressed420.Cr[y * 2, x * 2 + 1] = m_YCbCrCompressed420.Cr[x, y];
                    m_YCbCrDecompressed420.Cr[y * 2 + 1, x * 2] = m_YCbCrCompressed420.Cr[x, y];
                    m_YCbCrDecompressed420.Cr[y * 2 + 1, x * 2 + 1] = m_YCbCrCompressed420.Cr[x, y];
                }
            }
        }

        protected override void ConvertYCbCrToRGB()
        {
            for (int y = 0; y < m_YCbCrDecompressed420.Cb.GetLength(0); y++)
            {
                for (int x = 0; x < m_YCbCrDecompressed420.Cb.GetLength(1); x++)
                {
                    // Convert YCbCr to RGB
                    int yValue = m_YCbCrDecompressed420.Y[y, x];
                    int cbValue = m_YCbCrDecompressed420.Cb[y, x] - 128;
                    int crValue = m_YCbCrDecompressed420.Cr[y, x] - 128;

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
