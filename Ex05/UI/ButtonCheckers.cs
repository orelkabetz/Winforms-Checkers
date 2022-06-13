using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ex05.UI
{
    public class ButtonCheckers : Button
    {
        public ButtonCheckers(int i_row, int i_col)
        {
            row = i_row;
            col = i_col;
        }
        public int row
        { get; }
        public int col
        { get; }
    }
}
