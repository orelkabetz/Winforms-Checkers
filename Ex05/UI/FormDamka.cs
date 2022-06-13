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
        private ButtonCheckers[,] m_ButtonsArray;
        private string m_currentMove;
        //private string m_previousMove;
        public FormDamka(int i_BoardSize, string i_PlayerOneName, string i_PlayerTwoName, int i_NumOfPlayers)
        {
            m_BoardSize = i_BoardSize;
            m_PlayerOneName = i_PlayerOneName;
            m_PlayerTwoName = i_PlayerTwoName;
            m_NumOfPlayers = i_NumOfPlayers;
            m_ButtonsArray = new ButtonCheckers[m_BoardSize, m_BoardSize];

            InitializeComponent();
            Start();
        }

        private void Start()
        {
            InitializeBoard();
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
                        if((i != 0))
                        {
                            if ((j != 0) && (j != m_BoardSize - 1))
                            {
                                if ((m_ButtonsArray[i - 1, j + 1].Text == " ") || (m_ButtonsArray[i - 1, j - 1].Text == " "))
                                {
                                    m_ButtonsArray[i, j].Enabled = true;
                                }
                                else
                                {
                                    m_ButtonsArray[i, j].Enabled = false;
                                }
                            }
                            else if (j == 0)
                            {
                                if (m_ButtonsArray[i - 1, j + 1].Text == " ")
                                {
                                    m_ButtonsArray[i, j].Enabled = true;
                                }
                                else
                                {
                                    m_ButtonsArray[i, j].Enabled = false;
                                }
                            }
                            else if (j == m_BoardSize - 1)
                            {
                                if (m_ButtonsArray[i - 1, j - 1].Text == " ")
                                {
                                    m_ButtonsArray[i, j].Enabled = true;
                                }
                                else
                                {
                                    m_ButtonsArray[i, j].Enabled = false;
                                }
                            }

                        }
                        //m_ButtonsArray[i, j].Enabled = true;
                    }
                    else
                    {
                        m_ButtonsArray[i, j].Enabled = false;
                    }
                    m_ButtonsArray[i, j].Text = printableArray[printableArrayCounter].ToString();
                    m_ButtonsArray[i, j].Font = new Font(m_ButtonsArray[i, j].Font, FontStyle.Bold);
                    m_ButtonsArray[i, j].Click += FormDamka_Click;
                    printableArrayCounter++;
                }
            }
            this.Refresh();
        }

        public void FormDamka_Click(object sender, EventArgs e)
        {
            ButtonCheckers clickedButton = sender as ButtonCheckers;
            m_currentMove += convertIndexToPosition(clickedButton.row, clickedButton.col);
            m_currentMove += '>';
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
    }
}
