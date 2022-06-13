using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex02.ConsoleUtils;

namespace Ex05.UI
{
    public class Messages
    {
        private string m_playerOneName;
        private string m_playerTwoName;
        private int m_boardSize;
        private int m_oneOrTwoPlayers;
        private int m_rounds = 0;
        private string m_currentMove;
        private string m_previousMove;

        public string PlayerOneName
        {
            get { return m_playerOneName; }
            set { m_playerOneName = value; }
        }

        public string PlayerTwoName
        {
            get { return m_playerTwoName; }
            set { m_playerTwoName = value; }
        }

        public int BoardSize
        {
            get { return m_boardSize; }
            set { m_boardSize = value; }
        }

        public int OneOrTwoPlayers
        {
            get { return m_oneOrTwoPlayers; }
            set { m_oneOrTwoPlayers = value; }
        }

        public string CurrentMove
        {
            get { return m_currentMove; }
            set { m_currentMove = value; }
        }

        public string PreviousMove
        {
            get { return m_previousMove; }
            set { m_previousMove = value; }
        }

        public void Start()
        {
            Screen.Clear();
            PrintHello();
            defineSettings();
        }

        public bool CheckRestartGame()
        {
            bool whileFlag = true;
            string userDecision;
            string restart = string.Format(
@"
Would you like to start a new game?
        Y - for yes
        N - for no
");
            Console.WriteLine(restart);
            while (whileFlag)
            {
                userDecision = Console.ReadLine();
                if (userDecision == "Y")
                {
                    return true;
                }
                else if (userDecision == "N")
                {
                    PrintBye();
                    return false;
                }
                else
                {
                    Screen.Clear();
                    Console.WriteLine(restart);
                    continue;
                }
            }
            return false;
        }

        public void PrintHello()
        {
            string hello = string.Format(
@"
    Hello and welocme to:
        # CHECKERS #");
            Console.WriteLine(hello);
        }

        public void DisplayWinner(ShapeWrapper playerTurn, int score)
        {
            string winnerName;
            if (playerTurn.getShapeChar() == 'X')
            {
                winnerName = m_playerOneName;
            }
            else //'O'
            {
                winnerName = m_playerTwoName;
            }
            string winner = string.Format(
@"     The Winner is:
            {0}
     with a score of: {1}"
, winnerName, score);
            Console.WriteLine(winner);
        }

        public void PrintBye()
        {
            Screen.Clear();
            string hello = string.Format(
@"
            Bye Bye!!");
            Console.WriteLine(hello);
        }

        private void defineSettings()
        {
            m_playerOneName = getNameFromUser();
            getSize();
            getOneOrTwoPlayers();
        }

        public void Restart()
        {
            m_rounds++;
            Screen.Clear();
            string restart = string.Format(
@"
      Another round of:
        # CHECKERS #");
            Console.WriteLine(restart);
        }

        private string getNameFromUser()
        {
            bool whileFlag = true; ;
            string name = " ";
        string getNameMessage = string.Format(
@"
    Please Enter Your Name:
");
            Console.WriteLine(getNameMessage);
            System.Console.SetCursorPosition(10, 5);
            while (whileFlag)
            { 
                name = Console.ReadLine();
                if (name.Length >= 20)
                {
                    Console.WriteLine("The name should be up to 20 characters, try again");
                    System.Console.SetCursorPosition(10, 8);
                    continue;
                }
                whileFlag = false;
            }
            return name;
        }

        private void getSize()
        {
            string getSizeMessage = string.Format(
@"
    Please choose the size of the board

                (1)  6x6
                (2)  8x8
                (3) 10x10
");
            Screen.Clear();
            Console.WriteLine(getSizeMessage);
            System.Console.SetCursorPosition(17, 7);
            Int32.TryParse(Console.ReadLine(), out m_boardSize);
            convertChoiceToActualSize();
            return;
        }

        private void convertChoiceToActualSize()
        {
            if (m_boardSize == 1)
            {
                m_boardSize = 6;
            }
            else if (m_boardSize == 2)
            {
                m_boardSize = 8;    
            }
            else if (m_boardSize == 3)
            {
                m_boardSize = 10;
            }    
        }

        private void getOneOrTwoPlayers()
        {
            string getPlayersNumberMessage = string.Format(
@"
    Please choose how many players

            (1)  1 player
            (2)  2 players
");
            Screen.Clear();
            Console.WriteLine(getPlayersNumberMessage);
            System.Console.SetCursorPosition(17, 6);
            Int32.TryParse(Console.ReadLine(), out m_oneOrTwoPlayers);
            if (m_oneOrTwoPlayers == 2)
            {
                Screen.Clear();
                string hiSecondPlayer = string.Format(
@"
        Hi 2nd Player!");
                Console.WriteLine(hiSecondPlayer);
                m_playerTwoName = getNameFromUser();
            }
            else
            {
                m_playerTwoName = "Computer";
            }
            return;
        }

        public void PrintExtraTurn()
        {
            string extraTurn = string.Format(
@"You have extra turn, please play:
");
            Console.WriteLine(extraTurn);
        }

        public void PrintInvalidInput()
        {
            string invalid = string.Format(
@"
This move is not valid!
A valid move should look like this 'Gf>He'
Please try again: ");
            System.Console.SetCursorPosition(0, BoardSize*2+1);
            Console.WriteLine(invalid);
        }

        public void PrintInvalidLogicInput()
        {
            string invalid = string.Format(
@"
This move is not valid!
Please try again: ");
            System.Console.SetCursorPosition(0, BoardSize * 2 + 1);
            Console.WriteLine(invalid);
        }

        public void DisplayTurn(ShapeWrapper playerTurn, ShapeWrapper previousTurn)
        {
           PreviousMove = CurrentMove;
            // Print a message to the user which one's turn, and to make a move
            if ((playerTurn.getShapeChar() == 'X') && (previousTurn.getShapeChar() == 'O'))
            {
                if (m_rounds != 0)
                {
                    if (PreviousMove != "Q")
                    {
                        Console.WriteLine(PlayerTwoName + "'s move was ({0}): " + m_previousMove, previousTurn.getShapeChar());
                    }
                }
                Console.WriteLine(PlayerOneName + "'s turn : ({0})", playerTurn.getShapeChar());
            }
            else if ((playerTurn.getShapeChar() == 'X') && (previousTurn.getShapeChar() == 'X'))
            {
                Console.WriteLine(PlayerOneName + "'s move was ({0}): "+ m_previousMove, previousTurn.getShapeChar());
                Console.WriteLine(PlayerOneName + "'s turn : ({0})", playerTurn.getShapeChar());
            }
            else if ((playerTurn.getShapeChar() == 'O') && (previousTurn.getShapeChar() == 'X'))
            {
                Console.WriteLine(PlayerOneName + "'s move was ({0}): " + m_previousMove, previousTurn.getShapeChar());
                Console.WriteLine(PlayerTwoName + "'s turn ({0}):", playerTurn.getShapeChar());
            }
            else // 'O' && 'O'
            {
                Console.WriteLine(PlayerTwoName + "'s move was ({0}): " + m_previousMove , previousTurn.getShapeChar());
                Console.WriteLine(PlayerTwoName + "'s turn : ({0})", playerTurn.getShapeChar());
            }
        }
    }
}
