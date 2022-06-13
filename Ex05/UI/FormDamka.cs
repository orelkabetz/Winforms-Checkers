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
        private Button[,] m_ButtonsArray;
        Game m_game;
        private ShapeWrapper m_playerTurn;
        private ShapeWrapper m_previousTurn;
        public FormDamka(int i_BoardSize, string i_PlayerOneName, string i_PlayerTwoName, int i_NumOfPlayers)
        {
            m_BoardSize = i_BoardSize;
            m_PlayerOneName = i_PlayerOneName;
            m_PlayerTwoName = i_PlayerTwoName;
            m_NumOfPlayers = i_NumOfPlayers;
            m_ButtonsArray = new Button[m_BoardSize, m_BoardSize];
            m_game = new Game(i_BoardSize, i_PlayerOneName, i_PlayerTwoName);

            InitializeComponent();
            Start();
        }

        private void Start()
        {
            intializeGameStateBoard(m_BoardSize);
            InitializeBoard();
            printBoard();
        }

        private void InitializeBoard()
        {
            SetSize();
            setLabels();
            setButtons();
        }

        private void setButtons()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_ButtonsArray[i, j] = new Button();
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
                    m_ButtonsArray[i, j].Width = width;
                    m_ButtonsArray[i, j].Height = height;
                    m_ButtonsArray[i, j].Top = (i * height) + topMargin;
                    m_ButtonsArray[i, j].Left = (j * width) + margin;
                    this.Controls.Add(m_ButtonsArray[i, j]);
                }
            }
        }

        private void setLabels()
        {
            labelName1.Text = m_PlayerOneName + ":";
            labelName2.Text = m_PlayerTwoName + ":";
        }

        private void SetSize()
        {
            int formWidth = m_BoardSize * width + margin * 2;
            int formHeight = m_BoardSize * height + margin + topMargin;

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

        public void ShowBoard(object[] printableArray , ShapeWrapper i_playarTurn)
        {
            int printableArrayCounter = 0;

            enableCurrentPlayerButtons(i_playarTurn);

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (printableArray[printableArrayCounter].ToString() == i_playarTurn.getShapeChar().ToString())
                    {
                        m_ButtonsArray[i, j].Enabled = true;

                    }
                    else
                    {
                        m_ButtonsArray[i, j].Enabled = false;
                    }
                    m_ButtonsArray[i, j].Text = printableArray[printableArrayCounter].ToString();
                    m_ButtonsArray[i, j].Font = new Font(m_ButtonsArray[i, j].Font, FontStyle.Bold);
                    m_ButtonsArray[i, j].Click += (sender, EventArgs)=> { FormDamka_Click(sender, EventArgs, i, j); };
                    printableArrayCounter++;
                }
            }
        }

        public void FormDamka_Click(object sender, EventArgs e, int i_i, int i_j)
        {
            Button clickedButton = sender as Button;
            //MessageBox.Show(button.Text);
            TurnPlaying(clickedButton.Text, i_i, i_j);

        }

        private void TurnPlaying(string text, int i_i, int i_j)
        {
            if (text != "")
            {

            }
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

            ShowBoard(printableArray, m_game.currentState.playerTurn);
        }

        public object[] CreatePrintableArray()
        {
            const int maxSize = 10;
            // object[] o_printableArray = new object[m_messages.BoardSize * m_messages.BoardSize];
            object[] o_printableArray = new object[maxSize * maxSize]; // need to define MAX
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    o_printableArray[i * m_BoardSize + j] = m_game.currentState.BoardArray[i, j].Shape.getShapeChar();
                }
            }
            return o_printableArray;
        }

    }
}
