using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using BO;
using BO.pesquisas;

namespace UIWindows
{
    public partial class UIPesquisaForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        pesquisaMods _objPesquisa;
        int _idMod;

        public int IdMod
        {
            get { return _idMod; }
            set { _idMod = value; }
        }

        public UIPesquisaForm()
        {
            InitializeComponent();
            _objPesquisa = new pesquisaMods();
            gvForms.DataSource = _objPesquisa.GetTodos();
            cbCampos.SelectedIndex = 0;
            cbOp.SelectedIndex = 0;
        }

        private void gvForms_DoubleClick(object sender, EventArgs e)
        {
            _idMod = (int)gvForms["idMod", gvForms.CurrentRow.Index].Value;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if(edtPesquisa.Text == "")
            {
                gvForms.DataSource = _objPesquisa.GetTodos();
            }
            else
            {
                switch(cbCampos.Text)
                {
                    case "Id":
                    {
                        int vValor = 0;
                        int.TryParse(edtPesquisa.Text, out vValor);
                        switch (cbOp.Text)
                        {                               
                            case ">": gvForms.DataSource = 
                                _objPesquisa.GetIdMaior(vValor); break;
                            case "<": gvForms.DataSource = _objPesquisa.GetIdMenor(vValor); break;
                            case "=": gvForms.DataSource = _objPesquisa.GetIdIgual(vValor); break;
                        }
                    }
                    break;
                    case "Módulo":
                    {
                        switch (cbOp.Text)
                        {
                            case "Contém": gvForms.DataSource = _objPesquisa.GetModContem(edtPesquisa.Text); break;
                            case "Inicia": gvForms.DataSource = _objPesquisa.GetModInicia(edtPesquisa.Text); break;
                            case "Igual": gvForms.DataSource = _objPesquisa.GetModIgual(edtPesquisa.Text); break;
                        }
                    }
                    break;
                    case "Namespace":
                    {
                        switch (cbOp.Text)
                        {
                            case "Contém": gvForms.DataSource = _objPesquisa.GetNsContem(edtPesquisa.Text); break;
                            case "Inicia": gvForms.DataSource = _objPesquisa.GetNsInicia(edtPesquisa.Text); break;
                            case "Igual": gvForms.DataSource = _objPesquisa.GetNsIgual(edtPesquisa.Text); break;
                        }
                    }
                    break;
                }
            }
        }

        private void cbCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOp.Items.Clear();
            switch(cbCampos.Text)
            {
                case "Módulo": case "Namespace":
                {
                    cbOp.Items.Add("Contém");
                    cbOp.Items.Add("Inicia");
                    cbOp.Items.Add("Igual");
                }break;

                case "Id":
                {
                    cbOp.Items.Add("=");
                    cbOp.Items.Add(">");
                    cbOp.Items.Add("<");
                }break;

            }
        }

        private void btnImpRel_Click(object sender, EventArgs e)
        {
            int cont = 0;
            string _idMod = "";
            while (cont < gvForms.Rows.Count)
            {
                if (_idMod != "")
                {
                    _idMod += ", ";
                }
                _idMod += gvForms[idMod.Name, cont].Value.ToString();
                cont++;
            }

            UIRelMod _objRelat = new UIRelMod("{Formularios.idModulo} in [" + _idMod + "]");
            _objRelat.ShowDialog();
        }

    }
}