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
    public partial class FormGameSettings : Form
    {
        public int BoardSize;
        public Settings Settings
        {
            get { return new Settings(BoardSize, PlayerOneName, PlayerTwoName, OneOrTwoPlayers ); }
        }
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void CheckBoxPlayer2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = true;
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = "[Computer]";
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if(!playersNamesValidation())
            {
                return;
            }
            getBoardSizeFromRadioButtons();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void getBoardSizeFromRadioButtons()
        {
            if (radioButton6.Checked)
            {
                BoardSize = 6;
            }
            else if (radioButton8.Checked)
            {
                BoardSize = 8;
            }
            else // radioButton10.Checked
            {
                BoardSize = 10;
            }
        }

        private bool playersNamesValidation()
        {
            bool res = true;
            if (textBoxPlayer1.Text == "")
            {
                MessageBox.Show("Please enter a Name to player 1!");
                res = false;
            }
            if (textBoxPlayer2.Text == "")
            {
                MessageBox.Show("Please enter a Name to player 2!");
                res = false;
            }
            return res;
        }
    }
}
