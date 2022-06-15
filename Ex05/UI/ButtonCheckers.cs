using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ex05.UI
{
    public class ButtonCheckers : Button
    {
        public ButtonCheckers(int i_Row, int i_Col)
        {
            Row = i_Row;
            Col = i_Col;
        }
        public int Row
        { get; }
        public int Col
        { get; }
    }
}
