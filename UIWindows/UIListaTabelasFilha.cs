using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using BO;

namespace UIWindows
{
    public partial class UIListaTabelasFilha : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public List<string> lTabelas;
        public UIListaTabelasFilha(string nmTabPai, TabelasBO objbo)
        {
            InitializeComponent();

            kryptonDataGridView1.DataSource = objbo.GetListaTabFilha(nmTabPai);
        }

        private void kryptonDataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                lTabelas = new List<string>();

                foreach (DataGridViewRow item in kryptonDataGridView1.SelectedRows)
                {
                    lTabelas.Add(item.Cells[1].Value.ToString());
                }

                this.Close();
            }
        }

    }
}