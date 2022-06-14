using System;
using Ex05.Logic;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.UI
{
    public class OldController
    {
        Game m_game;
        private ShapeWrapper m_playerTurn;
        private ShapeWrapper m_previousTurn;
        private FormGameSettings m_FormGameSettings;
        private FormDamka m_FormDamka;

        public OldController()
        {
            m_playerTurn = new ShapeWrapper('X');
            m_previousTurn = new ShapeWrapper('O');
            m_FormGameSettings = new FormGameSettings();
        }

        public void Run() // Maybe should be static and not object referenced
        {
            bool io_finished = false;
            bool io_keepPlaying = true;
            //string o_moveString;
            m_FormGameSettings.ShowDialog();

            CreateNewGame(m_FormGameSettings.BoardSize, m_FormGameSettings.PlayerOneName, m_FormGameSettings.PlayerTwoName);

            m_FormDamka = new FormDamka
                (m_FormGameSettings.BoardSize, m_FormGameSettings.PlayerOneName,
                m_FormGameSettings.PlayerTwoName, m_FormGameSettings.OneOrTwoPlayers);
            printBoard();

            while (!io_finished)
            {
                //turn 1
                m_FormDamka.ShowDialog();

                m_game.currentState.BoardArray[0, 1] = new Piece(new ShapeWrapper('X'));


                turnPlaying(ref io_finished, ref io_keepPlaying);
                if (io_finished)
                {
                    if (m_playerTurn.getShapeChar() == 'X')
                    {
                        //m_messages.DisplayWinner(m_playerTurn, m_game.currentState.xScore);
                    }
                    else
                    {
                       // m_messages.DisplayWinner(m_playerTurn, m_game.currentState.oScore);
                    }
                    //if (m_messages.CheckRestartGame())
                    //{
                        io_finished = false;
                        io_keepPlaying = true;
                        restartGame();
                        continue;
                   // }
                    //break;
                }
                //between turn 1 and turn 2
                switchTurn();
                //init keepPlaying to true before turn 2
                io_keepPlaying = true;

                //turn 2
                //m_messages.DisplayTurn(m_game.currentState.playerTurn, m_previousTurn);
                //if (m_messages.OneOrTwoPlayers == 2)
                //{
                    turnPlaying(ref io_finished, ref io_keepPlaying);
                //}
                //else
                //{
                //    m_game.MakeComputerTurn(ref io_finished, ref io_keepPlaying, out o_moveString);
                //    //m_messages.CurrentMove = o_moveString;
                //    printBoard();
                //}
                // finished turn 1 and turn 2 
                //init keepPlaying to true before turn 1
                io_keepPlaying = true;
                switchTurn();
                if (io_finished)
                {
                    if (m_playerTurn.getShapeChar() == 'X')
                    {
                       // m_messages.DisplayWinner(m_playerTurn, m_game.currentState.xScore);
                    }
                    else
                    {
                       // m_messages.DisplayWinner(m_playerTurn, m_game.currentState.oScore);
                    }
                  //  if (m_messages.CheckRestartGame())
                   // {
                        io_finished = false;
                        io_keepPlaying = true;
                        restartGame();
                        continue;
                    //}
                }
            }
        }

        private void restartGame()
        {
            //m_messages.Restart();
            System.Threading.Thread.Sleep(2000);
            // init the board to initial state
           // intializeBoard(m_messages.BoardSize);
            printBoard();
        }

        private void turnPlaying(ref bool io_finished, ref bool io_keepPlaying)
        {
            //bool moveIlegal;
            bool quit = true;
            while (io_keepPlaying)
            {
                // is there eating before move
                io_keepPlaying = m_game.currentState.IsEatingPossible();
                setUserMove();
                //io_finished = checkIfUserQuit();
                if (io_finished)
                {
                    m_game.currentState.CheckGameOver(quit);
                    switchTurn();
                    if (m_playerTurn.getShapeChar() == 'X')
                    {
                       // m_messages.DisplayWinner(m_playerTurn, m_game.currentState.xScore);
                    }
                    else
                    {
                       // m_messages.DisplayWinner(m_playerTurn, m_game.currentState.oScore);
                    }
                   // if (m_messages.CheckRestartGame())
                   // {
                        io_finished = false;
                        io_keepPlaying = true;
                        switchTurn();
                        restartGame();
                     //   m_messages.DisplayTurn(m_game.currentState.playerTurn, m_previousTurn);
                        continue;
                  //  }
                   // break;
                }
               // moveIlegal = m_game.MakeMove(m_messages.CurrentMove, m_playerTurn);
                printBoard();
               // if (!moveIlegal)
               // {
                  //  m_messages.PrintInvalidLogicInput();
                    io_keepPlaying = true;
                    continue;
             //   }
                // is there eating after move
                //if (io_keepPlaying)
                //{
                //    io_keepPlaying = m_game.currentState.IsEatingPossible();
                ////    m_messages.PrintExtraTurn();
                //}
            }
            // Check if the game has ended
          //  if (m_messages.CurrentMove == "Q")
          //  {
                io_finished = m_game.currentState.CheckGameOver(quit);
          //  }
           // else
            {
                io_finished = m_game.currentState.CheckGameOver(!quit);
            }
        }

        //private bool checkIfUserQuit()
        //{
        //  //  if ((m_messages.CurrentMove == "Q") || (m_messages.CurrentMove == "q"))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public void CreateNewGame(int boardSize, string playerOneName, string playerTwoName)
        {
            m_game = new Game(boardSize, playerOneName, playerTwoName);
            intializeGameStateBoard(boardSize);
        }

        private void intializeGameStateBoard(int boardSize)
        {
            genereateOPieces(boardSize);
            generateEPieces(boardSize);
            genereateXPieces(boardSize);
        }

        private void genereateOPieces(int boardSize)
        {
            for (int i = 0; i < (boardSize / 2) - 1; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            m_game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                        }
                        else
                        {
                            m_game.currentState.BoardArray[i, j] = generateNewOPiece();
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            m_game.currentState.BoardArray[i, j] = generateNewOPiece();
                        }
                        else
                        {
                            m_game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                        }

                    }
                }
            }
        }

        private Piece generateNewOPiece()
        {
            return new Piece(new ShapeWrapper('O'));
        }

        private void generateEPieces(int boardSize)
        {
            for (int i = (boardSize / 2) - 1; i < (boardSize / 2) + 1; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    m_game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                }
            }
        }

        private Piece generateNewEmptyPiece()
        {
            return new Piece(new ShapeWrapper(' '));
        }

        private void genereateXPieces(int boardSize)
        {
            for (int i = (boardSize / 2) + 1; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            m_game.currentState.BoardArray[i, j] = generateNewXPiece();
                        }
                        else
                        {
                            m_game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            m_game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                        }
                        else
                        {
                            m_game.currentState.BoardArray[i, j] = generateNewXPiece();
                        }

                    }
                }
            }
        }

        private Piece generateNewXPiece()
        {
            return new Piece(new ShapeWrapper('X'));
        }

        private void printBoard()
        {
            object[] printableArray = CreatePrintableArray();
            m_FormDamka.ShowBoard(printableArray, m_game.currentState.playerTurn);
        }

        public object[] CreatePrintableArray()
        {
            const int maxSize = 10;
            // object[] o_printableArray = new object[m_messages.BoardSize * m_messages.BoardSize];
            object[] o_printableArray = new object[maxSize * maxSize]; // need to define MAX
            for (int i = 0; i < m_FormGameSettings.BoardSize; i++)
            {
                for (int j = 0; j < m_FormGameSettings.BoardSize; j++)
                {
                    o_printableArray[i * m_FormGameSettings.BoardSize + j] = m_game.currentState.BoardArray[i, j].Shape.getShapeChar();
                }
            }
            return o_printableArray;
        }

        private void setUserMove()
        {
            if (!isUserMoveValid(m_FormDamka.CurrentMove))
            {
                while (!isUserMoveValid(m_FormDamka.CurrentMove))
                {
                    //Screen.Clear();
                    printBoard();
                    //System.Console.SetCursorPosition(0, m_FormDamka.BoardSize + 2);
                    //m_messages.PrintInvalidInput();
                    //m_messages.CurrentMove = Console.ReadLine();
                }
            }
        }

        private bool isUserMoveValid(string move) //Not finished!!
        {
            if (m_FormDamka.CurrentMove == "Q")
            {
                return true;
            }
            else if (m_FormDamka.CurrentMove.Length != 5)
            {
                //m_messages.PrintInvalidInput();
                return false;
            }
            else if (m_FormDamka.CurrentMove[2] != '>')
            {
                //m_messages.PrintInvalidInput();
                return false;
            }
            else if ((m_FormDamka.CurrentMove[0] < 'A') || (m_FormDamka.CurrentMove[0] > m_FormGameSettings.BoardSize + 'A'))
            {
                //m_messages.PrintInvalidInput();
                return false;
            }
            else if ((m_FormDamka.CurrentMove[3] < 'A') || (m_FormDamka.CurrentMove[3] > m_FormGameSettings.BoardSize + 'A'))
            {
                //m_messages.PrintInvalidInput();
                return false;
            }
            else if ((m_FormDamka.CurrentMove[1] < 'a') || (m_FormDamka.CurrentMove[1] > m_FormGameSettings.BoardSize + 'a'))
            {
                //m_messages.PrintInvalidInput();
                return false;
            }
            else if ((m_FormDamka.CurrentMove[4] < 'a') || (m_FormDamka.CurrentMove[4] > m_FormGameSettings.BoardSize + 'a'))
            {
                //m_messages.PrintInvalidInput();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void switchTurn()
        {
            if (m_playerTurn.getShapeChar() == 'X')
            {
                m_previousTurn = new ShapeWrapper(m_playerTurn.getShapeChar());
                m_playerTurn.Shape = ShapeWrapper.eShape.O;
            }
            else
            {
                m_previousTurn = new ShapeWrapper(m_playerTurn.getShapeChar());
                m_playerTurn.Shape = ShapeWrapper.eShape.X;
            }
            m_game.currentState.SwitchTurn();
        }
    }
}
