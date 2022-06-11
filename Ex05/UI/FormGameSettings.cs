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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
