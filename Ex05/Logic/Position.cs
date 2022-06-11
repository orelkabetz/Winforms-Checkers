using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.Logic
{
    public class Position
    {
        private int m_row;
        private int m_col;

        public Position(int row, int col)
        {
            m_row = row;
            m_col = col;
        }

        public int Row
        {
            get { return m_row; }
            set { m_row = value; }
        }

        public int Col
        {
            get { return m_col; }
            set { m_col = value; }
        }
    }
}
