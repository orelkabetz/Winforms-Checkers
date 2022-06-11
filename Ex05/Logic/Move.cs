using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.Logic
{
    public class Move
    {
        private Position m_startPosition;
        private Position m_endPosition;

        public Move(string move)
        {
            char startCol = move[0];
            char startRow = move[1];
            char endCol = move[3];
            char endRow = move[4];
            m_startPosition = new Position(startRow - 'a', startCol - 'A');
            m_endPosition = new Position(endRow - 'a', endCol - 'A');
        }

        public Move(Position startPosition, Position endPosition)
        {
            m_startPosition = startPosition;
            m_endPosition = endPosition;
        }

        public Position startPosition
        {
            get { return m_startPosition; }
            set { m_startPosition = value; }
        }

        public Position endPosition
        {
            get { return m_endPosition; }
            set { m_endPosition = value; }
        }
    }
}
