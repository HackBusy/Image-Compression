namespace Image_And_Video_Compression
{
    class YCbCr
    {
        byte[,] m_Y;
        byte[,] m_Cb;
        byte[,] m_Cr;

        public YCbCr(int i_Height, int i_Width, int i_HeightDivider, int i_WidthDivider)
        {
            m_Y = new byte[i_Height, i_Width];
            m_Cb = new byte[i_Height/i_HeightDivider, i_Width/i_WidthDivider];
            m_Cr = new byte[i_Height/i_HeightDivider, i_Width/i_WidthDivider];
        }

        public byte[,] Y
        {
            get
            {
                return m_Y;
            }
            set
            {
                m_Y = value;
            }
        }

        public byte[,] Cb
        {
            get
            {
                return m_Cb;
            }
            set
            {
                m_Cb = value;
            }
        }

        public byte[,] Cr
        {
            get
            {
                return m_Cr;
            }
            set
            {
                m_Cr = value;
            }
        }
    }
}
