using Ex05.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ex05.UI
{
    public partial class FormDamka : Form
    {
        Game m_Game;
        private ButtonCheckers[,] m_ButtonsArray;
        private int m_BoardSize;
        private string m_PlayerOneName;
        private string m_PlayerTwoName;
        private int m_NumOfPlayers;
        private ButtonCheckers m_StartButton;
        private ButtonCheckers m_EndButton;
        private string m_CurrentMove;
        private ShapeWrapper m_PlayerTurn;
        private bool m_Finished = false;
        private int m_xScore = 0;
        private int m_oScore = 0;

        public string CurrentMove
        {
            get { return m_CurrentMove; }
        }
        //private string m_previousMove;
        public FormDamka(Settings i_Settings)
        {
            m_BoardSize = i_Settings.BoardSize;
            m_PlayerOneName = i_Settings.PlayerOneName;
            m_PlayerTwoName = i_Settings.PlayerTwoName;
            m_NumOfPlayers = i_Settings.OneOrTwoPlayers;
            m_CurrentMove = "";
            m_ButtonsArray = new ButtonCheckers[m_BoardSize, m_BoardSize];
            m_PlayerTurn = new ShapeWrapper('X');

            InitializeComponent();
            start();
        }

        private void start()
        {
            initializeVisualBoard();
            createNewGame();
            printBoard();
        }

        private void initializeVisualBoard()
        {
            setSize();
            setLabels();
            setButtons();
        }

        private void setButtons()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_ButtonsArray[i, j] = new ButtonCheckers(i, j);
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            m_ButtonsArray[i, j].Enabled = false;
                            m_ButtonsArray[i, j].BackColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            m_ButtonsArray[i, j].BackColor = System.Drawing.Color.White;
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            m_ButtonsArray[i, j].BackColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            m_ButtonsArray[i, j].Enabled = false;
                            m_ButtonsArray[i, j].BackColor = System.Drawing.Color.Gray;

                        }
                    }
                    m_ButtonsArray[i, j].Width = k_Width;
                    m_ButtonsArray[i, j].Height = k_Height;
                    m_ButtonsArray[i, j].Top = (i * k_Height) + k_TopMargin;
                    m_ButtonsArray[i, j].Left = (j * k_Width) + k_Margin;
                    m_ButtonsArray[i, j].Click += FormDamkaButton_Click;

                    //m_ButtonsArray[i,j].MouseHover += (sender, e) => { m_ButtonsArray[i, j].ForeColor = System.Drawing.Color.Azure; };
                    this.Controls.Add(m_ButtonsArray[i, j]);
                }
            }
        }

        private void setLabels()
        {
            labelName1.Text = m_PlayerOneName + ":";
            if (m_NumOfPlayers == 2)
            {
                labelName2.Text = m_PlayerTwoName + ":";
            }
            else // 1
            {
                labelName2.Text =  "Computer:";

            }
        }

        private void setSize()
        {
            int formWidth = m_BoardSize * k_Width + k_Margin * 2;
            int formHeight = m_BoardSize * k_Height + k_Margin + k_TopMargin;

            if (m_BoardSize == 6)
            {
                this.ClientSize = new System.Drawing.Size(formWidth, formHeight);
            }
            else if (m_BoardSize == 8)
            {
                this.ClientSize = new System.Drawing.Size(formWidth, formHeight);
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(formWidth, formHeight);
            }
        }

        private void createNewGame()
        {
            m_Game = new Game(m_BoardSize, m_PlayerOneName, m_PlayerTwoName);
            intializeGameStateBoard();
        }

        private void intializeGameStateBoard()
        {
            genereateOPieces();
            generateEPieces();
            genereateXPieces();
        }

        private void genereateOPieces()
        {
            for (int i = 0; i < (m_BoardSize / 2) - 1; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            m_Game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                        }
                        else
                        {
                            m_Game.currentState.BoardArray[i, j] = generateNewOPiece();
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            m_Game.currentState.BoardArray[i, j] = generateNewOPiece();
                        }
                        else
                        {
                            m_Game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                        }

                    }
                }
            }
        }

        private Piece generateNewOPiece()
        {
            return new Piece(new ShapeWrapper('O'));
        }

        private void generateEPieces()
        {
            for (int i = (m_BoardSize / 2) - 1; i < (m_BoardSize / 2) + 1; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_Game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                }
            }
        }

        private Piece generateNewEmptyPiece()
        {
            return new Piece(new ShapeWrapper(' '));
        }

        private void genereateXPieces()
        {
            for (int i = (m_BoardSize / 2) + 1; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            m_Game.currentState.BoardArray[i, j] = generateNewXPiece();
                        }
                        else
                        {
                            m_Game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            m_Game.currentState.BoardArray[i, j] = generateNewEmptyPiece();
                        }
                        else
                        {
                            m_Game.currentState.BoardArray[i, j] = generateNewXPiece();
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
            object[] printableArray = createPrintableArray();
            showBoard(printableArray, m_Game.currentState.playerTurn);
        }

        private object[] createPrintableArray()
        {
            const int v_MaxSize = 10;
            // object[] o_printableArray = new object[m_messages.BoardSize * m_messages.BoardSize];
            object[] o_printableArray = new object[v_MaxSize * v_MaxSize]; // need to define MAX
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    o_printableArray[i * m_BoardSize + j] = m_Game.currentState.BoardArray[i, j].Shape.getShapeChar();
                }
            }
            return o_printableArray;
        }

        private void showBoard(object[] i_PrintableArray, ShapeWrapper i_playarTurn)
        {
            int printableArrayCounter = 0;

            enableCurrentPlayerButtons(i_playarTurn);

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (i_playarTurn.getShapeChar() == 'X')
                    {
                        if ((i_PrintableArray[printableArrayCounter].ToString() == "X") || (i_PrintableArray[printableArrayCounter].ToString() == "K"))
                        {
                            m_ButtonsArray[i, j].Enabled = true;
                        }
                        else
                        {
                            m_ButtonsArray[i, j].Enabled = false;
                        }
                    }
                    else // Player O
                    {
                        if ((i_PrintableArray[printableArrayCounter].ToString() == "O") || (i_PrintableArray[printableArrayCounter].ToString() == "U"))
                        {
                            m_ButtonsArray[i, j].Enabled = true;
                        }
                        else
                        {
                            m_ButtonsArray[i, j].Enabled = false;
                        }
                    }
                    m_ButtonsArray[i, j].Text = i_PrintableArray[printableArrayCounter].ToString();
                    m_ButtonsArray[i, j].Font = new Font(m_ButtonsArray[i, j].Font, FontStyle.Bold);

                    printableArrayCounter++;
                }
            }
            this.Refresh();
        }

        public void FormDamkaButton_Click(object sender, EventArgs e)
        {
            ButtonCheckers clickedButton = sender as ButtonCheckers;

            if (m_StartButton == null)
            {
                m_StartButton = clickedButton;
                clickedButton.BackColor = Color.DeepSkyBlue;
                enbaleAllButtons();
            }
            else if (m_EndButton == null)
            {
                m_StartButton.BackColor = Color.White;
                m_EndButton = clickedButton;
                m_CurrentMove += convertIndexToPosition(m_StartButton.Row, m_StartButton.Col);
                m_CurrentMove += '>';
                m_CurrentMove += convertIndexToPosition(m_EndButton.Row, m_EndButton.Col);
                m_StartButton = null;
                m_EndButton = null;
                if (m_PlayerTurn.getShapeChar() == 'X')
                {
                    turnPlaying();
                    this.Refresh();
                }
                if (m_PlayerTurn.getShapeChar() == 'O')
                {
                    if (m_NumOfPlayers == 2)
                    {
                        turnPlaying();
                    }
                    if (checkGameOver())
                    {
                        if (calculateWin())
                            return;
                    }
                    else // 1 player
                    {
                        bool KeepPlaying = true;
                        string o_moveString;

                        m_Game.MakeComputerTurn(ref m_Finished, ref KeepPlaying, out o_moveString);

                        m_CurrentMove = o_moveString;
                        //turnPlaying();

                        switchTurn();
                        m_CurrentMove = "";
                        printBoard();

                    }
                    if (checkGameOver())
                    {
                        calculateWin();
                        return;
                    }
                }
            }
        }

        private bool checkGameOver()
        {
            bool res = true;
            bool xExists = false;
            bool oExists = false;

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (m_ButtonsArray[i, j].Text == "X")
                    {
                        xExists = true;
                    }
                    else if (m_ButtonsArray[i, j].Text == "K")
                    {
                        xExists = true;
                    }
                    else if (m_ButtonsArray[i, j].Text == "O")
                    {
                        oExists = true;
                    }
                    else if (m_ButtonsArray[i, j].Text == "U")
                    {
                        oExists = true;
                    }
                }
            }
            res = (!(xExists) || !(oExists));

            return res;
        }

        private void turnPlaying()
        {
            bool moveIlegal;
            bool isOver = false;
            bool keepPlaying = true;
            while (keepPlaying)
            {
                // is there eating before move
                keepPlaying = m_Game.currentState.IsEatingPossible();

                moveIlegal = m_Game.MakeMove(CurrentMove, m_PlayerTurn);
                printBoard();
                if (!moveIlegal)
                {
                    m_CurrentMove = "";
                    m_StartButton = null;
                    m_EndButton = null;
                    MessageBox.Show("Ilegel Move!");
                    //m_messages.PrintInvalidLogicInput();
                    keepPlaying = true;
                    return;
                }
                // is there eating after move
                if (keepPlaying)
                {
                    m_CurrentMove = "";
                    m_StartButton = null;
                    m_EndButton = null;
                    keepPlaying = m_Game.currentState.IsEatingPossible();
                    if (keepPlaying)
                    {
                        switchTurn();
                        MessageBox.Show("You have another Turn!");
                        break;
                    }
                }
            }
            // Check if the game has ended
            switchTurn();
            m_CurrentMove = "";
            printBoard();
        }

        private bool calculateWin()
        {
            bool isOver = false;
            bool res = false;
            m_Game.currentState.CheckGameOver(!isOver);

            string winnerName;
            
                if (m_Game.currentState.playerTurn.getShapeChar() != 'O')
                {
                    winnerName = m_PlayerTwoName;
                }
                else // 'X'
                {
                    winnerName = m_PlayerOneName;
                }
                DialogResult result = MessageBox.Show(
               string.Format("{0} Won!{1}Another round?", winnerName, Environment.NewLine),
               "Round Over",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Information);

                m_xScore += m_Game.currentState.xScore;
                m_oScore += m_Game.currentState.oScore;
                labelName1.Text = m_PlayerOneName + ":" + m_xScore.ToString();
                labelName2.Text = m_PlayerOneName + ":" + m_oScore.ToString();

                if (result == DialogResult.Yes)
                {
                    restart();
                }
                else
                {
                    this.Close();
                }
                res = true;
                //switchTurn();
            
            return res;
        }

        private void restart()
        {
            createNewGame();
            printBoard();
            m_PlayerTurn = new ShapeWrapper('X');
        }

        private void switchTurn()
        {
            if (m_PlayerTurn.getShapeChar() == 'X')
            {
                m_PlayerTurn.Shape = ShapeWrapper.eShape.O;
            }
            else
            {
                m_PlayerTurn.Shape = ShapeWrapper.eShape.X;
            }
            m_Game.currentState.SwitchTurn();
        }

        private void enbaleAllButtons()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (m_ButtonsArray[i, j].BackColor == Color.White)
                    {
                        m_ButtonsArray[i, j].Enabled = true;
                    }
                }
            }
        }

        private string convertIndexToPosition(int i_Row, int i_Col)
        {
            string resultPosition = "";
            resultPosition += Convert.ToChar((i_Col + 'A'));
            resultPosition += Convert.ToChar((i_Row + 'a'));

            return resultPosition;
        }

        private void enableCurrentPlayerButtons(ShapeWrapper i_playarTurn)
        {
            if (i_playarTurn.getShapeChar() == 'X')
            {
                labelName1.Font = new Font(labelName1.Font, FontStyle.Bold);
                labelPlayer1.Font = new Font(labelPlayer1.Font, FontStyle.Bold);
            }
            else
            {
                labelName2.Font = new Font(labelName2.Font, FontStyle.Bold);
                labelPlayer2.Font = new Font(labelPlayer2.Font, FontStyle.Bold);
            }
        }

    }
}
