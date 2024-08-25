namespace ChromaSubsamplingCompression
{
    class YCbCr
    {
        byte[,] m_Y;
        byte[,] m_Cb;
        byte[,] m_Cr;

        public YCbCr(int i_Width, int i_Height, int i_WidthDivider, int i_HeightDivider)
        {
            m_Y = new byte[i_Width, i_Height];
            m_Cb = new byte[i_Width / i_WidthDivider, i_Height / i_HeightDivider];
            m_Cr = new byte[i_Width / i_WidthDivider, i_Height / i_HeightDivider];
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
