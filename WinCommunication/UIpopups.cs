using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCommunication
{
    public partial class UIpopups : UserControl
    {
        string name;
        public UIpopups(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void UIpopups_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.name;
        }
    }
}
