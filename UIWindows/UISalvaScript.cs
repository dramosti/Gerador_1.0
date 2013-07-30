using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BO;
using System.IO;
using cMessageBoxCustomizado;
using Model;
using System.Data.SqlClient;

namespace UIWindows
{
    public partial class UISalvaScript : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        #region Variáveis Globais
        ProcViewBO _objProcBO;
        constraintsBo objConstrBo;
        List<constraintsModel> lConstraints = null;
        char _controle;
        #endregion

        public struct infConstraints
        {
            public string nomeConst;
            public string scriptConst;
        }

        public UISalvaScript(string vservidor, string vuser, string vpassword,
            string vdataBase, byte vtipoConexao)
        {
            InitializeComponent();
            _objProcBO = new ProcViewBO(vservidor: vservidor, vuser: vuser, vpassword: vpassword,
                vdataBase: vdataBase, vtipoConexao: vtipoConexao);
            objConstrBo = new constraintsBo();
            toolTip.SetToolTip(btnAtualizar, "Atualizar Procedures e Views");
            Carrega();            
        }

        private void Carrega()
        {
            listProcedures.DataSource = _objProcBO.GetProcView("sys.procedures");
            listProcedures.DisplayMember = "name";
            listProcedures.ValueMember = "name";

            listView.DataSource = _objProcBO.GetProcView("sys.views");
            listView.DisplayMember = "name";
            listView.ValueMember = "name";

            listTriggers.DataSource = _objProcBO.GetProcView("sys.triggers");
            listTriggers.DisplayMember = "name";
            listTriggers.ValueMember = "name";

            lConstraints = new List<constraintsModel>();
            lConstraints = objConstrBo.GetAllConstraints();
            listConstraints.Items.Clear();
            foreach (var item in lConstraints.OrderBy(c => c.sConstrName))
            {
                listConstraints.Items.Add(item: item.sConstrName.ToString());
            }

            listProcedures_Click(this, null);
        }

        private void btnSalvarSel_Click(object sender, EventArgs e)
        {
            if (edtPreView.Text != "")
            {
                if (_controle == 'p')
                {
                    try
                    {
                        if (_objProcBO.SalvarProcedureView(edtPreView.Text, edtCaminho.Text +@"\procedures\",
                            listProcedures.SelectedValue.ToString() + ".sql"))
                        {
                            MessageBox.Show("Procedure salva com sucesso no caminho " +
                                edtCaminho.Text+@"\procedures", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine +
                            ex.InnerException + Environment.NewLine +
                            ex.StackTrace + Environment.NewLine);
                    } 
                }
                else if (_controle == 'v')
                {
                    try
                    {
                        if (_objProcBO.SalvarProcedureView(edtPreView.Text, edtCaminho.Text + @"\views\",
                            listView.SelectedValue.ToString() + ".sql"))
                        {
                            MessageBox.Show("View salva com sucesso no caminho " +
                                edtCaminho.Text+@"\views", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine +
                            ex.InnerException + Environment.NewLine +
                            ex.StackTrace + Environment.NewLine);
                    }

                }
                else if (_controle == 't')
                {
                    if (_objProcBO.SalvarProcedureView(edtPreView.Text, edtCaminho.Text + @"\triggers\",
                        listTriggers.SelectedValue.ToString() + ".sql"))
                    {
                        MessageBox.Show("Trigger salva com sucesso no caminho " +
                                edtCaminho.Text + @"\triggers", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if(_controle == 'c')
                {
                    List<infConstraints> lInfConst = new List<infConstraints>();
                    infConstraints objInfConst = new infConstraints
                    {
                        nomeConst = listConstraints.SelectedItem.ToString(),
                        scriptConst = objConstrBo.MontaScript(
                        lConstraints.Where(c => c.sConstrName == 
                            listConstraints.SelectedItem.ToString()).FirstOrDefault())
                    };
                    lInfConst.Add(objInfConst);

                    try
                    {
                        SalvarConstraint(lInfConst);
                        MessageBox.Show("Constraint salva com sucesso no caminho " +
                            edtCaminho.Text + @"\constraints");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine +
                            ex.StackTrace);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Não foi selecionada nenhuma procedure ou view", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnPesquisaProc_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edtCaminho.Text = folderBrowser.SelectedPath;
            }
        }

        private void btnPesquisaView_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edtCaminho.Text = folderBrowser.SelectedPath;
            }
        }

        private void btnSalvarTodos_Click(object sender, EventArgs e)
        {
            if (!cbProcedures.Checked && !cbViews.Checked && !cbTriggers.Checked && !cbConstraints.Checked)
            {
                MessageBox.Show("Marque uma das opções para o salvamento, Procedures ou Views", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                if (cbProcedures.Checked)
                {
                    try
                    {
                        pbGeral.Visible = true;
                        lblStatus.Visible = true;
                        lblStatus.Text = "Salvando procedures";
                        SalvarTodos(vlistView: ref listProcedures, vcompl: @"\procedures");
                        MessageBox.Show("Procedures salvas com sucesso em: " +
                            edtCaminho.Text+@"\procedures");
                    }
                    catch (Exception)
                    {
                        
                    }
                }

                if (cbViews.Checked)
                {
                    try
                    {
                        pbGeral.Visible = true;
                        lblStatus.Visible = true;
                        lblStatus.Text = "Salvando views";
                        SalvarTodos(vlistView: ref listView, vcompl: @"\views");
                        MessageBox.Show("Views salvas com sucesso em: " +
                            edtCaminho.Text+@"\views");
                    }
                    catch (Exception)
                    {
                        
                    }
                }

                if(cbTriggers.Checked)
                {
                    try
                    {
                        pbGeral.Visible = true;
                        lblStatus.Visible = true;
                        lblStatus.Text = "Salvando Triggers";
                        SalvarTodos(vlistView: ref listTriggers, vcompl: @"\triggers");
                        MessageBox.Show("Triggers salvas com sucesso em: " +
                            edtCaminho.Text + @"\triggers");
                    }
                    catch (Exception)
                    {
                        
                    }
                }

                if(cbConstraints.Checked)
                {
                    try
                    {
                        pbGeral.Visible = true;
                        lblStatus.Visible = true;
                        lblStatus.Text = "Salvando Constraints";
                        infConstraints objInfConst;
                        List<infConstraints> lInfConst = new List<infConstraints>();
                        foreach (string item in listConstraints.Items)
                        {
                            objInfConst = new infConstraints
                            {
                                nomeConst = item,
                                scriptConst = objConstrBo.MontaScript(
                                lConstraints.Where(c => c.sConstrName ==
                                    item).FirstOrDefault())
                            };
                            lInfConst.Add(objInfConst);
                        }                       

                        try
                        {
                            SalvarConstraint(lInfConst);
                            MessageBox.Show("Constraint salva com sucesso no caminho " +
                                edtCaminho.Text + @"\constraints");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + Environment.NewLine +
                                ex.StackTrace);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine +
                            ex.StackTrace);
                    }
                }

                pbGeral.Visible = false;
                lblStatus.Visible = false;
            }
        }

        private void edtCaminho_Leave(object sender, EventArgs e)
        {
            DirectoryInfo _di = new DirectoryInfo(edtCaminho.Text);

            if (!_di.Exists)
            {
                MessageBox.Show("Caminho inválido, favor corrigir");
                edtCaminho.Focus();
            }
        }

        private void listProcedures_Click(object sender, EventArgs e)
        {
            if (listProcedures.SelectedValue != null)
            {
                _controle = 'p';
                string[] _vwProcedure = null;
                edtPreView.Clear();
                _objProcBO.GetProcedureView(vProcedure: listProcedures.SelectedValue.ToString(),
                vvwProcedure: ref _vwProcedure);

                foreach (string item in _vwProcedure)
                {
                    edtPreView.Text += item;
                }
            }
        }

        private void listView_Click(object sender, EventArgs e)
        {
            if (listView.SelectedValue != null)
            {
                _controle = 'v';
                string[] _vwView = null;
                edtPreView.Clear();
                _objProcBO.GetProcedureView(vProcedure: listView.SelectedValue.ToString(),
                vvwProcedure: ref _vwView);

                foreach (string item in _vwView)
                {
                    edtPreView.Text += item;
                }
            }
        }

        private void SalvarTodos(ref ListBox vlistView, string vcompl)
        {
            pbGeral.Value = 0;
            pbGeral.Maximum = vlistView.Items.Count;
            string[] _vwView = null;
            Retornos _retorno = Retornos.Cancelar;
            formMessageBox _frmMessage;
            foreach (DataRow row in (vlistView.DataSource as DataTable).Rows)
            {
                if (_retorno != Retornos.SimTodos && _retorno != Retornos.NaoTodos)
                {
                    if (_objProcBO.VerificaProcView(edtCaminho.Text + vcompl
                        , row["name"].ToString()
                        + ".sql"))
                    {
                        _frmMessage = new UIMessage("Arquivo " + row["name"].ToString() + " já existe, deseja substituir?",
                            "Substituir?", Botoes.PadraoSimNaoTodos, Icones.Questão);
                        _frmMessage.ShowDialog();

                        _retorno = _frmMessage.Retorno;
                    }
                    else
                    {
                        _retorno = Retornos.SimTodos;
                    }
                }

                if (_retorno == Retornos.Sim || _retorno == Retornos.SimTodos)
                {
                    _vwView = null;
                    _objProcBO.GetProcedureView(vProcedure: row["name"].ToString(),
                    vvwProcedure: ref _vwView);
                    try
                    {
                        _objProcBO.SalvarProcedureView(_vwView,
                        edtCaminho.Text + vcompl, row["name"].ToString()
                        + ".sql");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine +
                            ex.InnerException + Environment.NewLine +
                            ex.StackTrace + Environment.NewLine);
                        break;
                    }

                    pbGeral.Value++;
                }
                else if (_retorno == Retornos.Cancelar)
                {
                    break;
                }
            }
        }

        private void btnExecSelec_Click(object sender, EventArgs e)
        {
            if (_controle == 'p')
            {
                _objProcBO.ExecutarProcView(edtPreView.Text,
                    listProcedures.SelectedValue.ToString());
                MessageBox.Show("Procedure executada com sucesso!");
            }
            else if (_controle == 'v')
            {
                _objProcBO.ExecutarProcView(edtPreView.Text,
                    listView.SelectedValue.ToString());
                MessageBox.Show("View executada com sucesso!");
            }
            else if(_controle == 't')
            {
                _objProcBO.ExecutarProcView(edtPreView.Text,
                    listTriggers.SelectedValue.ToString());
                MessageBox.Show("Trigger executada com sucesso!");
            }
            else if(_controle == 'c')
            {
                objConstrBo.ExecutConstr(edtPreView.Text);
                MessageBox.Show("Constraint executada com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi selecionada nenhuma procedure ou view", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        private void btnExecutarTodos_Click(object sender, EventArgs e)
        {
            if(!cbProcedures.Checked && !cbViews.Checked && !cbTriggers.Checked && !cbConstraints.Checked)
            {
                MessageBox.Show("Não foi selecionada nenhuma procedure ou view", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if(cbProcedures.Checked)
                {
                    if (Directory.Exists(edtCaminho.Text + @"\procedures"))
                    {
                        lblStatus.Text = "Executando scripts de procedures";
                        pbGeral.Visible = true;
                        lblStatus.Visible = true;            
                        ExecutarTodos(edtCaminho.Text + @"\procedures");
                        MessageBox.Show("Procedures executadas com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Pasta de procedures não existe!");
                    }
                
                }
                if(cbViews.Checked)
                {
                    if (Directory.Exists(edtCaminho.Text + @"\views"))
                    {
                        lblStatus.Text = "Executando scripts de views";
                        pbGeral.Visible = true;
                        lblStatus.Visible = true;  
                        ExecutarTodos(edtCaminho.Text + @"\views");
                        MessageBox.Show("Views executadas com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Pasta de views não existe!");
                    }
                }
                if(cbTriggers.Checked)
                {
                    if(Directory.Exists(edtCaminho.Text+@"\triggers"))
                    {
                        lblStatus.Text = "Executando scripts de triggers";
                        pbGeral.Visible = true;
                        lblStatus.Visible = true;
                        ExecutarTodos(edtCaminho.Text + @"\triggers");
                        MessageBox.Show("Triggers executadas com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Pasta de triggers não existe!");
                    }
                }
                if (cbConstraints.Checked)
                {
                    if (Directory.Exists(edtCaminho.Text + @"\constraints"))
                    {
                        lblStatus.Text = "Executando scripts de constraints";
                        pbGeral.Visible = true;
                        lblStatus.Visible = true;
                        ExecutarTodos(edtCaminho.Text + @"\constraints");
                        MessageBox.Show("Constraints executadas com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Pasta de constraints não existe!");
                    }
                }
                pbGeral.Visible = false;
                lblStatus.Visible = false;                    
            }
            
        }

        private void ExecutarTodos(string vcaminho)
        {
            string[] _arquivos = Directory.GetFiles(vcaminho);
            FileInfo _fi;
            string[] _script = null;
            string _scriptPronto;
            int _count;
            pbGeral.Maximum = _arquivos.Count();
            pbGeral.Value = 0;
            foreach (string _arq in _arquivos)
            {
                _fi = new FileInfo(_arq);
                if (_fi.Extension == ".sql")
                {
                    _objProcBO.GetProcedureView(_fi.Name, ref _script,
                    _fi.Directory.ToString());
                    _count = 0;
                    _scriptPronto = "";
                    while (_count < _script.Count())
                    {
                        _scriptPronto += _script[_count] + Environment.NewLine;
                        _count++;
                    }
                    try
                    {
                        _objProcBO.ExecutarProcView(_scriptPronto, _fi.Name.Replace(".sql", ""));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao executar o script " + _fi.Name + Environment.NewLine + "." +
                            "Erro: " + ex.Message);
                    }                    
                }
                pbGeral.Value++;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Carrega();
        }

        private void listTriggers_Click(object sender, EventArgs e)
        {
            if (listTriggers.SelectedValue != null)
            {
                _controle = 't';
                string[] _vwTrigger = null;
                edtPreView.Clear();
                _objProcBO.GetProcedureView(vProcedure: listTriggers.SelectedValue.ToString(),
                vvwProcedure: ref _vwTrigger);

                foreach (string item in _vwTrigger)
                {
                    edtPreView.Text += item;
                }
            }
        }

        private void listConstraints_Click(object sender, EventArgs e)
        {
            if (listConstraints.SelectedItem != null)
            {
                _controle = 'c';
                edtPreView.Text = objConstrBo.MontaScript(
                    lConstraints.Where(
                    c => c.sConstrName == listConstraints.SelectedItem.ToString()).FirstOrDefault());
            }
        }

        private void SalvarConstraint(List<infConstraints> lConstr)
        {
            pbGeral.Value = 0;
            pbGeral.Maximum = lConstr.Count;
            Retornos _retorno = Retornos.Cancelar;
            formMessageBox _frmMessage;

            foreach (infConstraints objInfConst in lConstr)
            {
                if (_retorno != Retornos.SimTodos && _retorno != Retornos.NaoTodos)
                {
                    if (objConstrBo.ArqConstrExiste(edtCaminho.Text, objInfConst.nomeConst))
                    {
                        _frmMessage = new UIMessage("Arquivo " + objInfConst.nomeConst+ ".sql" + " já existe, deseja substituir?",
                            "Substituir?", Botoes.PadraoSimNaoTodos, Icones.Questão);
                        _frmMessage.ShowDialog();

                        _retorno = _frmMessage.Retorno;
                    }
                    else
                    {
                        _retorno = Retornos.SimTodos;
                    }
                }

                if (_retorno == Retornos.Sim || _retorno == Retornos.SimTodos)
                {
                    
                    try
                    {
                        objConstrBo.SalvaConstraint(objInfConst.scriptConst, edtCaminho.Text,
                            objInfConst.nomeConst);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine +
                            ex.InnerException + Environment.NewLine +
                            ex.StackTrace + Environment.NewLine);
                        break;
                    }

                    pbGeral.Value++;
                }
                else if (_retorno == Retornos.Cancelar)
                {
                    break;
                }
            }
        }
    }
}
