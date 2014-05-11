using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheGame
{
    public partial class Izgubi : Form
    {
        public Izgubi()
        {
            InitializeComponent();
        }

        private void backToMenu2_MouseEnter(object sender, EventArgs e)
        {
            backToMenu2.ForeColor = Color.White;
        }

        private void backToMenu2_MouseLeave(object sender, EventArgs e)
        {
            backToMenu2.ForeColor = Color.Black;
        }

        private void backToMenu2_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
