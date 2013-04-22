using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DAO;
using BO;
using Model;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace UIWindows
{
    public enum Operacoes
    {
        inserindo = 1,
        pesquisando = 2,
        livre = 3
    }

    public partial class UICadastraMod : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        Operacoes _op;
        mModulos _objModulo;
        modulosBO _objBoMod;
        


        public UICadastraMod()
        {
            InitializeComponent();
            _op = Operacoes.livre;
            _objBoMod = new modulosBO();
        }

        private void UICadastraMod_Load(object sender, EventArgs e)
        {
            //this.formulariosTableAdapter.Fill(this.pROD_MODULOSDataSet.Formularios);
            ValidaBotoes();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _op = Operacoes.inserindo;
            ValidaBotoes();
            limpar(this);
            _objModulo = new mModulos();
            gvForms.Columns[singleton.Name].ReadOnly = true;
            formulariosBindingSource.DataSource = _objModulo.Formularios;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            _op = Operacoes.inserindo;
            ValidaBotoes();
            gvForms.Columns[singleton.Name].ReadOnly = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            _objModulo.xNome = edtModulo.Text;
            _objModulo.xNameSpaceCamada = edtNamesPrinc.Text;
            try
            {
                if(Validacao())
                {
                    edtID.Text = _objBoMod.Salvar(_objModulo).ToString();
                    MessageBox.Show("Cadastro salvo com sucesso!");
                    _op = Operacoes.pesquisando;
                    ValidaBotoes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + Environment.NewLine +
                    ex.Message);
            }       
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (edtID.Text == "")
            {
                _op = Operacoes.livre;
                limpar(this);
            }
            else
            {
                _objModulo = new mModulos();
                _objModulo = _objBoMod.GetModulo(Convert.ToInt32(edtID.Text));
                edtID.Text = _objModulo.idModulo.ToString();
                edtModulo.Text = _objModulo.xNome;
                edtNamesPrinc.Text = _objModulo.xNameSpaceCamada;
                formulariosBindingSource.DataSource = _objModulo.Formularios;
                gvForms.DataSource = formulariosBindingSource;                
                _op = Operacoes.pesquisando;
            }
            LimparValid();
            gvForms.ShowCellErrors = false;
            ValidaBotoes();
        }

        private void ValidaBotoes()
        {
            btnNovo.Enabled = (_op != Operacoes.inserindo);
            btnAlterar.Enabled = (_op == Operacoes.pesquisando);
            btnSalvar.Enabled = (_op == Operacoes.inserindo);
            btnCancelar.Enabled = btnSalvar.Enabled;
            btnPesquisa.Enabled = (_op != Operacoes.inserindo);
            painelCadastro.Enabled = !btnNovo.Enabled;
            gvForms.ReadOnly = btnNovo.Enabled;
        }

        private void limpar(Control controle)
        {
            foreach (Control c in controle.Controls)
            {
                if (c is KryptonTextBox)
                {
                    ((KryptonTextBox)c).Text = "";
                }
                if(c.Controls.Count > 0)
                {
                    limpar(c);
                }
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            UIPesquisaForm _frmPesquisaForm = new UIPesquisaForm();
            if (_frmPesquisaForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _op = Operacoes.pesquisando;
                ValidaBotoes();
                _objModulo = new mModulos();
                _objModulo = _objBoMod.GetModulo(_frmPesquisaForm.IdMod);
                edtID.Text = _objModulo.idModulo.ToString();
                edtModulo.Text = _objModulo.xNome;
                edtNamesPrinc.Text = _objModulo.xNameSpaceCamada;
                formulariosBindingSource.DataSource = _objModulo.Formularios;
                gvForms.DataSource = formulariosBindingSource;
            }
        }

        private void gvForms_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!gvForms.ReadOnly)
            {
                gvForms[e.ColumnIndex, e.RowIndex].ErrorText = null;
                if (gvForms.Columns.IndexOf(scope) == e.ColumnIndex)
                {
                    if (gvForms[scope.Name, e.RowIndex].Value.ToString() == "request")
                    {
                        gvForms[singleton.Name, e.RowIndex].Value = false;
                    }
                    else
                    {
                        gvForms[singleton.Name, e.RowIndex].Value = true;
                        gvForms[ativo.Name, e.RowIndex].Value = true;
                    }
                }
            }
        }

        private bool existeAplication(int currentRow, ref int indexRow)
        {
            int cont = 0;
            while(cont < gvForms.Rows.Count)
            {
                if(cont != currentRow)
                {
                    if (gvForms[scope.Name, cont].Value != null)
                    {
                        if(gvForms[scope.Name, cont].Value.ToString() == "application")
                        {
                            indexRow = cont;
                            return true;                        
                        }
                    }
                }
                cont++;
            }
            return false;
        }

        private void gvForms_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!gvForms.ReadOnly)
            {
                if (gvForms.Columns.IndexOf(scope) == e.ColumnIndex)
                {
                    if(e.FormattedValue.ToString() == "application")
                    {
                        int _indexRow = 0;
                        if (existeAplication(e.RowIndex, ref _indexRow))
                        {
                            if (MessageBox.Show("Já existe um form definido como application, " +
                                "deseja atribuir o form atual como application?", "Questão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                gvForms[scope.Name, _indexRow].Value = "request";
                            }
                            else
                            {
                                gvForms[scope.Name, e.RowIndex].Value = "request";
                            }
                        }
                    }
                }
                else if(gvForms.Columns.IndexOf(ativo) == e.ColumnIndex)
                {
                    if(!(bool)e.FormattedValue)
                    {
                        if(gvForms[scope.Name, e.RowIndex].Value.ToString() == "application")
                        {
                            gvForms[ativo.Name, e.RowIndex].Value = true;
                            MessageBox.Show("O formulário está definido como Application e não pode ser inativo!");
                        }
                    }
                }
            }
        }

        private bool Validacao()
        {
            bool _valida = true;
            LimparValid();
            gvForms.ShowCellErrors = true;

            if (edtModulo.Text == "")
            {
                ep.SetError(edtModulo, "Campo não pode ser vazio");
                _valida = false;
            }
            if(edtNamesPrinc.Text == "")
            {
                ep.SetError(edtNamesPrinc, "Campo não pode ser vazio");
                _valida = false;
            }

            int _cont = 0;

            while(_cont < gvForms.Rows.Count - 1)
            {
                if(gvForms[idForm.Name, _cont].Value == null)
                {
                    gvForms[idForm.Name, _cont].ErrorText = "Campo não pode ser vazio";
                    _valida = false;
                }
                if (gvForms[form.Name, _cont].Value == null)
                {
                    gvForms[form.Name, _cont].ErrorText = "Campo não pode ser vazio";
                    _valida = false;
                }
                if (gvForms[namespaceform.Name, _cont].Value == null)
                {
                    gvForms[namespaceform.Name, _cont].ErrorText = "Campo não pode ser vazio";
                    _valida = false;
                }
                if (gvForms[scope.Name, _cont].Value == null)
                {
                    gvForms[scope.Name, _cont].Style.BackColor = Color.Red;
                    _valida = false;
                }
                _cont++;
            }

            return _valida;
        }

        private void LimparValid()
        {
            ep.Clear();
            int _cont = 0;
            while(_cont < gvForms.Rows.Count)
            {
                gvForms[scope.Name, _cont].Style.BackColor = Color.Empty;
                _cont++;
            }
        }

        private string Serializacao()
        {
            belModulos _objModulos = new belModulos();
            belFormularios _objForm;
            int _cont = 0;

            while(_cont < gvForms.Rows.Count)
            {
                if((gvForms[idForm.Name, _cont].Value != null) && ((bool)gvForms[ativo.Name, _cont].Value))
                {
                    _objForm = new belFormularios();
                    _objForm.xType = gvForms[namespaceform.Name, _cont].Value.ToString() + ", " + edtNamesPrinc.Text;
                    _objForm.xScope = gvForms[scope.Name, _cont].Value.ToString();
                    _objForm.stSingleton = gvForms[singleton.Name, _cont].Value.ToString();
                    _objForm.xName = gvForms[form.Name, _cont].Value.ToString();
                    _objForm.xId = gvForms[idForm.Name, _cont].Value.ToString();
                    _objModulos.lFormularios.Add(_objForm);
                }
                _cont++;
            }

            cSerializar _objSeria = new cSerializar();
            return _objSeria.Serializar(_objModulos, Application.StartupPath+@"\confs", edtModulo.Text);
        }

        private void edtSerial_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_op == Operacoes.pesquisando && tabControl1.SelectedTab == tbSerial)
            {
                webXml.Navigate(Serializacao());
            }
        }

        private void edtModulo_Validated(object sender, EventArgs e)
        {
            
        }

        private void edtModulo_Leave(object sender, EventArgs e)
        {
            if (_objBoMod.GetCount(edtModulo.Text) > 0)
            {
                MessageBox.Show("Já existe um módulo cadastrado com o nome de "+edtModulo.Text,
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                edtModulo.Clear();
                edtModulo.Focus();
            }
        }

        private void gvForms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
            if(gvForms.Columns.IndexOf(ativo) == e.ColumnIndex)
            {
                SendKeys.Send("{RIGHT}");
                SendKeys.Send("{LEFT}");
            }
        }
    }
}