﻿using System.Drawing;

namespace ChromaSubsamplingCompression
{
    class CSCompression411 : ChromaSubsampling
    {
        YCbCr m_YCbCrCompressed411;
        YCbCr m_YCbCrDecompressed411;
        public Bitmap m_CompressedImage;

        public CSCompression411(string i_FilePath) : base(i_FilePath)
        {
            // full vertical resolution, 1/4 horizontal resolution
            m_YCbCrCompressed411 = new YCbCr(m_OriginalImage.Width, m_OriginalImage.Height, 4, 1); 
            m_YCbCrCompressed411.Y = m_YCbCrOriginalMap.Y;
            // full vertical resolution, full horizontal resolution
            m_YCbCrDecompressed411 = new YCbCr(m_OriginalImage.Width, m_OriginalImage.Height, 1, 1); 
            m_YCbCrDecompressed411.Y = m_YCbCrOriginalMap.Y;
            m_CompressedImage = new Bitmap(m_OriginalImage.Width, m_OriginalImage.Height);

            compression();
            decompression();
            ConvertYCbCrToRGB();
        }

        protected override void compression()
        {
            for (int x = 0; x < m_YCbCrCompressed411.Cb.GetLength(0); x++)
            {
                for (int y = 0; y < m_YCbCrCompressed411.Cb.GetLength(1); y++)
                {
                    // Average the 1x4 block of chroma values
                    m_YCbCrCompressed411.Cb[x, y] = (byte)(
                        (m_YCbCrOriginalMap.Cb[x * 4, y] +
                         m_YCbCrOriginalMap.Cb[x * 4 + 1, y] +
                         m_YCbCrOriginalMap.Cb[x * 4 + 2, y] +
                         m_YCbCrOriginalMap.Cb[x * 4 + 3, y]) / 4);

                    m_YCbCrCompressed411.Cr[x, y] = (byte)(
                        (m_YCbCrOriginalMap.Cr[x * 4, y] +
                         m_YCbCrOriginalMap.Cr[x * 4 + 1, y] +
                         m_YCbCrOriginalMap.Cr[x * 4 + 2, y] +
                         m_YCbCrOriginalMap.Cr[x * 4 + 3, y]) / 4);
                }
            }
        }

        protected override void decompression()
        {
            for (int x = 0; x < m_YCbCrCompressed411.Cb.GetLength(0); x++)
            {
                for (int y = 0; y < m_YCbCrCompressed411.Cb.GetLength(1); y++)
                {
                    // Replicate each subsampled chroma value to the 1x4 block in the decompressed array
                    m_YCbCrDecompressed411.Cb[x * 4, y] = m_YCbCrCompressed411.Cb[x, y];
                    m_YCbCrDecompressed411.Cb[x * 4 + 1, y] = m_YCbCrCompressed411.Cb[x, y];
                    m_YCbCrDecompressed411.Cb[x * 4 + 2, y] = m_YCbCrCompressed411.Cb[x, y];
                    m_YCbCrDecompressed411.Cb[x * 4 + 3, y] = m_YCbCrCompressed411.Cb[x, y];

                    m_YCbCrDecompressed411.Cr[x * 4, y] = m_YCbCrCompressed411.Cr[x, y];
                    m_YCbCrDecompressed411.Cr[x * 4 + 1, y] = m_YCbCrCompressed411.Cr[x, y];
                    m_YCbCrDecompressed411.Cr[x * 4 + 2, y] = m_YCbCrCompressed411.Cr[x, y];
                    m_YCbCrDecompressed411.Cr[x * 4 + 3, y] = m_YCbCrCompressed411.Cr[x, y];
                }
            }
        }

        protected override void ConvertYCbCrToRGB()
        {
            for (int x = 0; x < m_YCbCrDecompressed411.Y.GetLength(0); x++)
            {
                for (int y = 0; y < m_YCbCrDecompressed411.Y.GetLength(1); y++)
                {
                    // Convert YCbCr to RGB
                    int yValue = m_YCbCrDecompressed411.Y[x, y];
                    int cbValue = m_YCbCrDecompressed411.Cb[x, y] - 128;
                    int crValue = m_YCbCrDecompressed411.Cr[x, y] - 128;

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
