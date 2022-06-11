using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.Logic
{
    public class Piece
    {
        private ShapeWrapper m_shape;
        private bool m_isKing;

        public Piece(ShapeWrapper shape)
        {
            m_shape = shape;
            m_isKing = false;
        }

        public ShapeWrapper Shape
        {
            get { return m_shape; }
            set { m_shape = value; }
        }

        public bool IsKing
        {
            get { return m_isKing; }
            set { m_isKing = value; }
        }
    }
}
