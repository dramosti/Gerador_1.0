using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BO;
using ComponentFactory.Krypton.Toolkit;

namespace UIWindows
{
    public partial class UIPrincipal : Form
    {
        private TabelasBO objbo;

        public UIPrincipal()
        {
        }


        public UIPrincipal(TabelasBO objbo)
        {
            InitializeComponent();
            this.objbo = objbo;

            toolStripDropDownButton1.Text = objbo.DataBase;
        }

        private void storedProceduresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean ok = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is UIGerador)
                {
                    frm.BringToFront();
                    ok = true;
                }
            }
            if (ok == false)
            {
                UIGerador g = new UIGerador(objbo);
                g.MdiParent = this;
                g.WindowState = FormWindowState.Maximized;
                g.ShowInTaskbar = false;
                g.Show();
            }
            else
            {
                KryptonMessageBox.Show(null, "A Tela de Geração de Procedures já se encontra aberta", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void selecionarDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mudarAConexãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is UIGerador)
                {
                    frm.Close();
                }
            }
            UIConexao uic = new UIConexao();
            uic.ShowDialog();
            objbo = uic.tbo;
            toolStripDropDownButton1.Text = objbo.DataBase;
            if (objbo.DataBase == null)
            {
                Application.Exit();
            }
        }

        private void códigosCSharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean ok = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is UIGeradorCSharp)
                {
                    frm.BringToFront();
                    ok = true;
                }
            }
            if (ok == false)
            {
                UIGeradorCSharp g = new UIGeradorCSharp(objbo);
                g.MdiParent = this;
                g.WindowState = FormWindowState.Maximized;
                g.ShowInTaskbar = false;
                g.Show();
            }
            else
            {
                KryptonMessageBox.Show(null, "A Tela de Geração de Procedures já se encontra aberta", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
