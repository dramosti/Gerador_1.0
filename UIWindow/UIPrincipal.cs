using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UIWindow
{
    public partial class UIPrincipal : Form
    {
        public UIPrincipal()
        {
            InitializeComponent();
        }

        private void proceduresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIIGerador g = new UIIGerador();
            g.MdiParent = this;
            g.WindowState = FormWindowState.Maximized;
            g.ShowInTaskbar = false;
            g.Show();
        }
    }
}
