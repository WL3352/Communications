using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCommunication
{
    public partial class frmPopups : Form
    {
        string name;
        public frmPopups()
        {
            InitializeComponent();
        }
        public frmPopups(string name)
        {
            InitializeComponent();
            this.name = name;
            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - 265;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - 124;
            Point p = new Point(x, y);
            this.PointToScreen(p);
            this.Location = p;
        }

        private void frmPopups_Load(object sender, EventArgs e)
        {
            lbMsg.Text = this.name;
        }
    }
}
