using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Fm_main : Form
    {
        public Fm_main()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            Fm_game_place f2 = new Fm_game_place();
            WindowState = FormWindowState.Minimized;
            f2.ShowDialog();
        }
    }
}
