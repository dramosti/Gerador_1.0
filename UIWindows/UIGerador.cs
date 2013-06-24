using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using BO;
using System.IO;
using System.Data.SqlClient;
using Model;

namespace UIWindows
{
    public partial class UIGerador : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private TabelasBO objbo;
        private constraintsBo objConstbo = new constraintsBo();

        public UIGerador()
        {
            InitializeComponent();
        }
        public UIGerador(TabelasBO objbo)
        {
            InitializeComponent();
            this.objbo = objbo;
      
        }

        private void UIGerador_Load(object sender, EventArgs e)
        {
            lbTabelas.DataSource = objbo.GetTabelas();  // Carrega o ListBox com as tabelas do banco selecionado...
            lbTabelas.DisplayMember = "TABLE_NAME";
            lbTabelas.ValueMember = "TABLE_NAME";
        }

        private void btnGerarProc_Click(object sender, EventArgs e)
        {
            txtInsertUpdate.Text = String.Empty;
            txtUpdate.Text = String.Empty;
            txtDelete.Text = String.Empty;
            txtPesquisa.Text = String.Empty;
            txtDuplicar.Text = String.Empty;
            txtViews.Text = String.Empty;

            objbo.setTabela(lbTabelas.ListBox.Text);

            txtInsertUpdate.Text = objbo.GerarInsert_Update_SP();
            txtUpdate.Text = objbo.GerarUpdate_SP();
            txtDelete.Text = objbo.GerarDelete_SP();
            txtPesquisa.Text = objbo.GerarSelect_SP();
            txtDuplicar.Text = objbo.GerarDuplicar_SP();

            txtViews.Text = objbo.GetView(lbTabelas.SelectedValue.ToString());
            txtConstraints.Text = "";

            constraintsModel objConstraints = null;

            foreach (var item in clBoxColunas.CheckedItems)
            {
                objConstraints = new constraintsModel();
                objConstraints.sColumnName = item.ToString();
                objConstraints.sTabela = lbTabelas.SelectedValue.ToString();
                objConstraints.sConstrName = "constr" + "_" + lbTabelas.SelectedValue.ToString() +
                    "_"+item.ToString();
                txtConstraints.Text += objConstbo.MontaScript(objConstr: objConstraints)+Environment.NewLine;
            }
        }

        private bool ProcExiste(string sNameProc)
        {
            try
            {
                if (!objbo.isConectado())
                {
                    objbo.Conectar();
                }

                sNameProc = sNameProc.Replace("[", "");
                sNameProc = sNameProc.Replace("]", "");
                string sQuery = string.Format("select COUNT(*) from SYSOBJECTS where name = '{0}'", sNameProc);
                SqlCommand cmd = new SqlCommand(sQuery, objbo.GetConexao());
                string sTotal = cmd.ExecuteScalar().ToString();

                if (Convert.ToInt32(sTotal) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objbo.CloseConnection();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            if (cbConstraints.Checked)
            {
                if (txtConstraints.Text != "")
                {
                    txtConstraints.Text.Split(';');
                    if (!objbo.isConectado())
                    {
                        objbo.Conectar();
                    }
                    int contador = 0;
                    while (contador < txtConstraints.Text.Split(';').Count())
                    {

                        command = new SqlCommand(txtConstraints.Text.Split(';')[contador], objbo.GetConexao());
                        command.ExecuteNonQuery();
                        pgProgresso.PerformStep();
                        contador++;
                        System.Threading.Thread.Sleep(50);
                    }
                    btnGerarProc_Click(this, null);
                }
            }

            string procInsert = String.Empty;
            string procUpdate = String.Empty;
            string procDelete = String.Empty;
            string procSelect = String.Empty;
            string procCopy = String.Empty;
            string view = String.Empty;

            procInsert = txtInsertUpdate.Text;
            procUpdate = txtUpdate.Text;
            procDelete = txtDelete.Text;
            procSelect = txtPesquisa.Text;
            procCopy = txtDuplicar.Text;
            view = txtViews.Text;

            pgProgresso.Value = 0;
            pgProgresso.Minimum = 0;
            pgProgresso.Maximum = (cbViews.Checked ? +1 : +0) +
                (cbProcedures.Checked ? +5 : +0) + txtConstraints.Text.Count(c => c == ';');
            pgProgresso.Step = 1;

            try
            {
                if (cbProcedures.Checked)
                {
                    string sNameProcInsert = objbo.GetNameProc(TabelasBO.tipoProc.SAVE);
                    if (ProcExiste(sNameProcInsert))
                    {
                        procInsert = procInsert.Replace("CREATE", "ALTER");
                    }
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(50);

                    string sNameProcUpdate = objbo.GetNameProc(TabelasBO.tipoProc.UPDATE);
                    if (ProcExiste(sNameProcUpdate))
                    {
                        procUpdate = procUpdate.Replace("CREATE", "ALTER");
                    }
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(50);

                    string sNameProcDelete = objbo.GetNameProc(TabelasBO.tipoProc.DELETE);
                    if (ProcExiste(sNameProcDelete))
                    {
                        procDelete = procDelete.Replace("CREATE", "ALTER");
                    }
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(50);

                    string sNameProcSelect = objbo.GetNameProc(TabelasBO.tipoProc.SEL);
                    if (ProcExiste(sNameProcSelect))
                    {
                        procSelect = procSelect.Replace("CREATE", "ALTER");
                    }
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(50);

                    string sNameProcCopy = objbo.GetNameProc(TabelasBO.tipoProc.COPY);
                    if (ProcExiste(sNameProcCopy))
                    {
                        procCopy = procCopy.Replace("CREATE", "ALTER");
                    }
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(50);



                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(50);

                    procInsert = procInsert.Replace(";", "");
                    procUpdate = procUpdate.Replace(";", "");
                    procDelete = procDelete.Replace(";", "");
                    procSelect = procSelect.Replace(";", "");
                    procCopy = procCopy.Replace(";", "");

                    if (!objbo.isConectado())
                    {
                        objbo.Conectar();
                    }

                    command = new SqlCommand(procInsert, objbo.GetConexao());
                    command.ExecuteNonQuery();
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(100);

                    command = new SqlCommand(procUpdate, objbo.GetConexao());
                    command.ExecuteNonQuery();
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(100);

                    command = new SqlCommand(procDelete, objbo.GetConexao());
                    command.ExecuteNonQuery();
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(100);

                    command = new SqlCommand(procSelect, objbo.GetConexao());
                    command.ExecuteNonQuery();
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(100);

                    command = new SqlCommand(procCopy, objbo.GetConexao());
                    command.ExecuteNonQuery();
                    pgProgresso.PerformStep();
                    System.Threading.Thread.Sleep(100);
                }

                if (cbViews.Checked)
                {
                    string nmView = objbo.nmView;
                    if (ProcExiste(nmView))
                    {
                        view = view.Replace("CREATE", "ALTER");
                    }

                    if (view != "")
                    {
                        if (!objbo.isConectado())
                        {
                            objbo.Conectar();
                        }
                        command = new SqlCommand(view, objbo.GetConexao());
                        command.ExecuteNonQuery();
                        pgProgresso.PerformStep();
                        System.Threading.Thread.Sleep(100);
                    }
                }


            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(null, "Erro de sintaxe ao executar:  \n\n" + ex.Message, "E R R O", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objbo.CloseConnection();
                pgProgresso.Value = 0;
            }
        }

        private void lbTabelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            clBoxColunas.Items.Clear();
            TabelasBO objTabBo = new TabelasBO();
            List<TabelaModel> lColunas = objTabBo.GetColunasByTabela(lbTabelas.SelectedValue.ToString());
            foreach (TabelaModel item in lColunas.OrderBy(l => l.NomeColuna))
            {
                clBoxColunas.Items.Add(item.NomeColuna);
                if (objConstbo.ConstrExists("constr" + "_" + lbTabelas.SelectedValue.ToString() +
                        "_" + item.NomeColuna))
                {
                    clBoxColunas.SetItemChecked(
                        clBoxColunas.Items.IndexOf(item.NomeColuna), true);
                }
            }
        }

        private void clBoxColunas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }


 

    }
}