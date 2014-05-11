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
    public partial class Kraj : Form
    {
        public Kraj()
        {
            InitializeComponent();
        }

        private void backToMenu_MouseEnter(object sender, EventArgs e)
        {
            backToMenu.ForeColor = Color.White;
        }

        private void backToMenu_MouseLeave(object sender, EventArgs e)
        {
            backToMenu.ForeColor = Color.Black;
        }

        private void backToMenu_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
