using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05
{
    public class ShapeWrapper
    {
        private eShape m_shape;
        public eShape Shape
        {
            get { return m_shape; }
            set { m_shape = value; }
        }
        public enum eShape
        {
            O = 0,
            U = 1, 
            X = 2,
            K = 3,
            E = 4,
        }
        public ShapeWrapper(char shape)
        {
            switch (shape)
            {
                case 'O':
                    m_shape = eShape.O;
                    break;
                case 'U':
                    m_shape = eShape.U;
                    break;
                case 'X':
                    m_shape = eShape.X;
                    break;
                case 'K':
                    m_shape = eShape.K;
                    break;
                case ' ':
                    m_shape= eShape.E;
                    break;
                default:
                    m_shape = eShape.E;
                    break;
            }
        }
        public char getShapeChar()
        {
            if (m_shape == ShapeWrapper.eShape.O)
            {
                return 'O';
            }
            else if (m_shape == ShapeWrapper.eShape.U)
            {
                return 'U';
            }
            else if (m_shape == ShapeWrapper.eShape.X)
            {
                return 'X';
            }
            else if (m_shape == ShapeWrapper.eShape.K)
            {
                return 'K';
            }
            else
            {
                return ' ';
            }
        }
    }
}
