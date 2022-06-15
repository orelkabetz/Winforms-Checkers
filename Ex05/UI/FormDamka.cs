﻿using Ex05.Logic;
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
        Game m_game;
        private ButtonCheckers[,] m_ButtonsArray;
        //private Label[,] m_LabelsArray;
        private ButtonCheckers m_StartButton;
        private ButtonCheckers m_EndButton;
        private string m_currentMove;
        private ShapeWrapper m_playerTurn;
        private bool m_Finished = false;
        private bool m_KeepPlaying = true;

        public string CurrentMove
        {
            get { return m_currentMove; }
        }
        //private string m_previousMove;
        public FormDamka(Settings settings)
        {
            m_BoardSize = settings.BoardSize;
            m_PlayerOneName = settings.PlayerOneName;
            m_PlayerTwoName = settings.PlayerTwoName;
            m_NumOfPlayers = settings.OneOrTwoPlayers;
            m_currentMove = "";
            m_ButtonsArray = new ButtonCheckers[m_BoardSize, m_BoardSize];
            m_playerTurn = new ShapeWrapper('X');

            InitializeComponent();
            Start();
        }

        private void Start()
        {
            InitializeVisualBoard();
            CreateNewGame(m_BoardSize, m_PlayerOneName, m_PlayerTwoName);
            printBoard();
        }

        private void InitializeVisualBoard()
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
                    m_ButtonsArray[i, j].Width = width;
                    m_ButtonsArray[i, j].Height = height;
                    m_ButtonsArray[i, j].Top = (i * height) + topMargin;
                    m_ButtonsArray[i, j].Left = (j * width) + margin;
                    m_ButtonsArray[i, j].Click += FormDamkaButton_Click;

                    //m_ButtonsArray[i,j].MouseHover += (sender, e) => { m_ButtonsArray[i, j].ForeColor = System.Drawing.Color.Azure; };
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

                    printableArrayCounter++;
                }
            }
            //this.Refresh();
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
                m_currentMove += convertIndexToPosition(m_StartButton.row, m_StartButton.col);
                m_currentMove += '>';
                m_currentMove += convertIndexToPosition(m_EndButton.row, m_EndButton.col);
                m_StartButton = null;
                m_EndButton = null;
                turnPlaying();
            }    
        }

        private void turnPlaying()
        {
            bool moveIlegal;
            bool quit = true;
            bool keepPlaying = true;
            while (keepPlaying)
            {
                // is there eating before move
                keepPlaying = m_game.currentState.IsEatingPossible();
                if (m_Finished)
                {
                    m_game.currentState.CheckGameOver(quit);
                    switchTurn();
                    //if (m_playerTurn.getShapeChar() == 'X')
                    //{
                    //    //m_messages.DisplayWinner(m_playerTurn, m_game.currentState.xScore);
                    //}
                    //else
                    //{
                    //    //m_messages.DisplayWinner(m_playerTurn, m_game.currentState.oScore);
                    //}
                    //if (m_messages.CheckRestartGame())
                    //{
                    //    io_finished = false;
                    //    io_keepPlaying = true;
                    //    switchTurn();
                    //    restartGame();
                    //    m_messages.DisplayTurn(m_game.currentState.playe rTurn, m_previousTurn);
                    //    continue;
                    //}
                    break;
                }
                moveIlegal = m_game.MakeMove(CurrentMove, m_playerTurn);
                printBoard();
                if (!moveIlegal)
                {
                    m_currentMove = "";
                    m_StartButton = null;
                    m_EndButton = null;
                    MessageBox.Show("Ilegel Move!");
                    //m_messages.PrintInvalidLogicInput();
                    keepPlaying = true;
                    return ;
                }
                // is there eating after move
                if (keepPlaying)
                {
                    m_currentMove = "";
                    m_StartButton = null;
                    m_EndButton = null;
                    keepPlaying = m_game.currentState.IsEatingPossible();
                    if (keepPlaying)
                    {
                        switchTurn();
                        MessageBox.Show("You have another Turn!");
                    }
                }
            }
            // Check if the game has ended
            switchTurn();
            m_currentMove = "";
            printBoard();
            m_Finished = m_game.currentState.CheckGameOver(!quit);
        }

        private void switchTurn()
        {
            if (m_playerTurn.getShapeChar() == 'X')
            {
                m_playerTurn.Shape = ShapeWrapper.eShape.O;
            }
            else
            {
                m_playerTurn.Shape = ShapeWrapper.eShape.X;
            }
            m_game.currentState.SwitchTurn();
        }

        private void enbaleAllButtons()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_ButtonsArray[i, j].Enabled = true;
                }
            }
        }

        private string convertIndexToPosition(int row, int col)
        {
            string resultPosition = "";
            resultPosition += Convert.ToChar((col + 'A'));
            resultPosition += Convert.ToChar((row + 'a'));

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

        private void labelPlayer1_Click(object sender, EventArgs e)
        {

        }
    }
}
