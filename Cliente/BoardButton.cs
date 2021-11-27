using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HolaMundo
{
    class BoardButton : Button
    {
        private readonly int index;

        public BoardButton(int index, string text) : base()
        {
            Text = text;
            Size = new Size(150, 100);
            this.index = index;
        }

        public int GetIndex()
        {
            return index;
        }
    }
}
