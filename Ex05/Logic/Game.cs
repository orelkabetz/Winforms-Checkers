using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.Logic
{
    public class Game
    {
        private GameState m_currentState;
        public GameState currentState
        {
            get { return m_currentState; }
            set { m_currentState = value; }
        }

        public Game(int boardSize, string playerOneName, string playerTwoName)
        {
            m_currentState = new GameState(boardSize);
        }

        public bool MakeMove(string i_CurrentMove, ShapeWrapper i_PlayerTurn)
        {
            Move currentMove;
            if (m_currentState.playerTurn.getShapeChar() == 'X')
            {
                currentMove = new Move(i_CurrentMove);
            }
            else
            {
                currentMove = new Move(i_CurrentMove);
            }
            if (m_currentState.CheckMove(currentMove))
            {
                m_currentState.PlayMove(currentMove);
                return true;
            }
            return false;
        }

        public void MakeComputerTurn(ref bool io_finished, ref bool io_keepPlaying, out string o_moveString)
        {
            bool quit = true;
            string o_localMoveString = " ";
            while (io_keepPlaying)
            {
                // is there eating before move
                io_keepPlaying = currentState.IsEatingPossible();
                makeComputerMove(out o_localMoveString);
                // is there eating after move
                if (io_keepPlaying)
                {
                    io_keepPlaying = currentState.IsEatingPossible();
                }
            }
            o_moveString = o_localMoveString;
            // Check if the game has ended
            io_finished = false;
        } 
        
        private void makeComputerMove(out string o_moveString)
        {
            Random rand = new Random();
            int index;
            m_currentState.SetAllComputerPossibleMoves();
            if (m_currentState.PossibleComputerEatingMoves.Count != 0)
            {
                index = rand.Next(m_currentState.PossibleComputerEatingMoves.Count);
                m_currentState.PlayMove(m_currentState.PossibleComputerEatingMoves[index]);
                o_moveString = moveToString(m_currentState.PossibleComputerEatingMoves[index]);
            }
            else if (m_currentState.PossibleComputerMoves.Count != 0)
            {
                index = rand.Next(m_currentState.PossibleComputerMoves.Count);
                m_currentState.PlayMove(m_currentState.PossibleComputerMoves[index]);
                o_moveString = moveToString(m_currentState.PossibleComputerMoves[index]);
            }
            else
            {
                o_moveString = "No possible move";
            }
            System.Threading.Thread.Sleep(1000);
                
        }

        private string moveToString(Move i_Move)
        {
            StringBuilder moveString = new StringBuilder();
            moveString.Append(Convert.ToChar(i_Move.startPosition.Col + 'A'));
            moveString.Append(Convert.ToChar(i_Move.startPosition.Row + 'a'));
            moveString.Append('>');
            moveString.Append(Convert.ToChar(i_Move.endPosition.Col + 'A'));
            moveString.Append(Convert.ToChar(i_Move.endPosition.Row + 'a'));
            return moveString.ToString();
        }
    }
}
