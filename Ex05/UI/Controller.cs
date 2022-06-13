using System;
using Ex05.Logic;
using Ex02.ConsoleUtils;

using Ex05.UI;

namespace Ex05.UI
{ 
    public class Controller
    {
        Game m_game;
        private ShapeWrapper m_playerTurn;
        private ShapeWrapper m_previousTurn;
        private FormGameSettings m_FormGameSettings;
        private FormDamka m_FormDamka;

        public Controller()
        {
            m_FormGameSettings = new FormGameSettings();
            m_FormGameSettings.ShowDialog();
        }

        public void Run()
        {
            if (m_FormGameSettings.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                m_FormDamka = new FormDamka
                (m_FormGameSettings.BoardSize, m_FormGameSettings.PlayerOneName,
                m_FormGameSettings.PlayerTwoName, m_FormGameSettings.OneOrTwoPlayers);

                m_FormDamka.ShowDialog();
            }
        }

        //public void RunOld() // Maybe should be static and not object referenced
        //{
        //    bool io_finished = false;
        //    bool io_keepPlaying = true;
        //    string o_moveString;

        //    if (m_FormGameSettings.DialogResult == System.Windows.Forms.DialogResult.OK)
        //    {
        //        CreateNewGame(m_FormGameSettings.BoardSize, m_FormGameSettings.PlayerOneName, m_FormGameSettings.PlayerTwoName);
        //        m_FormDamka = new FormDamka
        //        (m_FormGameSettings.BoardSize, m_FormGameSettings.PlayerOneName,
        //        m_FormGameSettings.PlayerTwoName, m_FormGameSettings.OneOrTwoPlayers);



        //        //int[,] enables = scan();

        //        while (!io_finished)
        //        {
        //            //turn 1
        //            printBoard();

        //            onButtonClick += m_FormDamka.FormDamka_Click;

        //            turnPlaying(ref io_finished, ref io_keepPlaying);
        //            if (io_finished)
        //            {
        //                if (m_playerTurn.getShapeChar() == 'X')
        //                {
        //                    m_messages.DisplayWinner(m_playerTurn, m_game.currentState.xScore);
        //                }
        //                else
        //                {
        //                    m_messages.DisplayWinner(m_playerTurn, m_game.currentState.oScore);
        //                }
        //                if (m_messages.CheckRestartGame())
        //                {
        //                    io_finished = false;
        //                    io_keepPlaying = true;
        //                    restartGame();
        //                    continue;
        //                }
        //                break;
        //            }
        //            //between turn 1 and turn 2
        //            switchTurn();
        //            //init keepPlaying to true before turn 2
        //            io_keepPlaying = true;

        //            //turn 2
        //            m_messages.DisplayTurn(m_game.currentState.playerTurn, m_previousTurn);
        //            if (m_messages.OneOrTwoPlayers == 2)
        //            {
        //                turnPlaying(ref io_finished, ref io_keepPlaying);
        //            }
        //            else
        //            {
        //                m_game.MakeComputerTurn(ref io_finished, ref io_keepPlaying, out o_moveString);
        //                m_messages.CurrentMove = o_moveString;
        //                printBoard();
        //            }
        //            // finished turn 1 and turn 2 
        //            //init keepPlaying to true before turn 1
        //            io_keepPlaying = true;
        //            switchTurn();
        //            if (io_finished)
        //            {
        //                if (m_playerTurn.getShapeChar() == 'X')
        //                {
        //                    m_messages.DisplayWinner(m_playerTurn, m_game.currentState.xScore);
        //                }
        //                else
        //                {
        //                    m_messages.DisplayWinner(m_playerTurn, m_game.currentState.oScore);
        //                }
        //                if (m_messages.CheckRestartGame())
        //                {
        //                    io_finished = false;
        //                    io_keepPlaying = true;
        //                    restartGame();
        //                    continue;
        //                }
        //            }
        //        }
        //    }


        //}

        //private void restartGame()
        //{
        //    m_messages.Restart();
        //    System.Threading.Thread.Sleep(2000);
        //    // init the board to initial state
        //    intializeBoard(m_messages.BoardSize);
        //    printBoard();
        //}


        private void turnPlaying(ref bool io_finished, ref bool io_keepPlaying)
        {
            bool moveIlegal;
            bool quit = true;
            while (io_keepPlaying)
            {
                // is there eating before move
                io_keepPlaying = m_game.currentState.IsEatingPossible();
                setUserMove();
                io_finished = checkIfUserQuit();
                if (io_finished)
                {
                    m_game.currentState.CheckGameOver(quit);
                    switchTurn();
                    if (m_playerTurn.getShapeChar() == 'X')
                    {
                        m_messages.DisplayWinner(m_playerTurn, m_game.currentState.xScore);
                    }
                    else
                    {
                        m_messages.DisplayWinner(m_playerTurn, m_game.currentState.oScore);
                    }
                    if (m_messages.CheckRestartGame())
                    {
                        io_finished = false;
                        io_keepPlaying = true;
                        switchTurn();
                        restartGame();
                        m_messages.DisplayTurn(m_game.currentState.playerTurn, m_previousTurn);
                        continue;
                    }
                    break;
                }
                moveIlegal = m_game.MakeMove(m_messages.CurrentMove, m_playerTurn);
                printBoard();
                if (!moveIlegal)
                {
                    m_messages.PrintInvalidLogicInput();
                    io_keepPlaying = true;
                    continue;
                }
                // is there eating after move
                if (io_keepPlaying)
                {
                    io_keepPlaying = m_game.currentState.IsEatingPossible();
                    m_messages.PrintExtraTurn();
                }
            }
            // Check if the game has ended
            if (m_messages.CurrentMove == "Q")
            {
                io_finished = m_game.currentState.CheckGameOver(quit);
            }
            else
            {
                io_finished = m_game.currentState.CheckGameOver(!quit);
            }
        }

        //private bool checkIfUserQuit()
        //{
        //    if ((m_messages.CurrentMove == "Q")|| (m_messages.CurrentMove == "q"))
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        //private void setUserMove()
        //{

        //    m_messages.CurrentMove = Console.ReadLine();
        //    if (!isUserMoveValid(m_messages.CurrentMove))
        //    {
        //        while (!isUserMoveValid(m_messages.CurrentMove))
        //        {
        //            Screen.Clear();
        //            printBoard();
        //            System.Console.SetCursorPosition(0, m_messages.BoardSize+2);
        //            m_messages.PrintInvalidInput();
        //            m_messages.CurrentMove = Console.ReadLine();
        //        }
        //    }
        //}

        //private bool isUserMoveValid(string move) //Not finished!!
        //{
        //    // string
        //    if (m_messages.CurrentMove == "Q")
        //    {
        //        return true;
        //    }
        //    else if (m_messages.CurrentMove.Length != 5)
        //    {
        //        m_messages.PrintInvalidInput();
        //        return false;
        //    }
        //    else if (m_messages.CurrentMove[2] != '>')
        //    {
        //        m_messages.PrintInvalidInput();
        //        return false;
        //    }
        //    else if ((m_messages.CurrentMove[0] < 'A') || (m_messages.CurrentMove[0] > m_messages.BoardSize + 'A'))
        //    {
        //        m_messages.PrintInvalidInput();
        //        return false;
        //    }
        //    else if ((m_messages.CurrentMove[3] < 'A') || (m_messages.CurrentMove[3] > m_messages.BoardSize + 'A'))
        //    {
        //        m_messages.PrintInvalidInput();
        //        return false;
        //    }
        //    else if ((m_messages.CurrentMove[1] < 'a') || (m_messages.CurrentMove[1] > m_messages.BoardSize + 'a'))
        //    {
        //        m_messages.PrintInvalidInput();
        //        return false;
        //    }
        //    else if ((m_messages.CurrentMove[4] < 'a') || (m_messages.CurrentMove[4] > m_messages.BoardSize + 'a'))
        //    {
        //        m_messages.PrintInvalidInput();
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private void switchTurn()
        //{
        //    if (m_playerTurn.getShapeChar() == 'X')
        //    {
        //        m_previousTurn =  new ShapeWrapper(m_playerTurn.getShapeChar());
        //        m_playerTurn.Shape = ShapeWrapper.eShape.O;
        //    }
        //    else
        //    {
        //        m_previousTurn = new ShapeWrapper(m_playerTurn.getShapeChar());
        //        m_playerTurn.Shape = ShapeWrapper.eShape.X;
        //    }
        //    m_game.currentState.SwitchTurn();
        //}
    }
}



