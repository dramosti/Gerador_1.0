using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using BO;
using System.Threading;

namespace UIWindows
{
    public partial class UIConexao : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public bool bConn = false;
        public TabelasBO tbo;
        Thread t = null;
        public UIConexao()
        {
            InitializeComponent();
        }

        private void kryptonPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UIConexao_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = "SA";
            txtSenha.Text = "H029060tSql";
            rbSqlAuth.Checked = true;

            t = new Thread(new ThreadStart(CarregaInstancias));
            t.Start();

            //CarregaInstancias();



        }

        private void CarregaInstancias()
        {
            tbo = new TabelasBO();
            foreach (string item in tbo.GetServidores())
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        cbxServidor.Items.Add(item);
                        cbxServidor.Text = "HLPSRV";
                        btnTestarCon.Enabled = true;
                        cbxDatabase.Enabled = true;
                    }
                    ));
                }
                catch (Exception) { this.Dispose(); }
                
            }           
        }

        private void cbxDatabase_Enter(object sender, EventArgs e)
        {
            if (tbo != null)
            {
                if (rbSqlAuth.Checked)
                {
                    tbo.TipoConexao = 1;
                }
                else
                {
                    tbo.TipoConexao = 0;
                }

                tbo.UserId = txtUsuario.Text;
                tbo.Senha = txtSenha.Text;
                tbo.DataBase = "master"; // defino a master como padrão somente para testar a conexão

                tbo.Servidor = cbxServidor.Text;
                cbxDatabase.DataSource = tbo.GetDatabases().Tables[0];
                cbxDatabase.DisplayMember = "name";
                cbxDatabase.ValueMember = "name";
            }
        }

        private void cbxServidor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbxDatabase.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbxDatabase.Text.Trim().Length <= 0)
            {
                errorProvider1.SetError(cbxDatabase, "Selecione um banco de dados !");
                return;
            }


            if (rbSqlAuth.Checked)
            {
                tbo.TipoConexao = 1;
            }
            else
            {
                tbo.TipoConexao = 0;
            }

            tbo.UserId = txtUsuario.Text;
            tbo.Senha = txtSenha.Text;
            tbo.Servidor = cbxServidor.Text;
            tbo.DataBase = cbxDatabase.SelectedValue.ToString();

            try
            {
                if (!tbo.isConectado())
                {
                    tbo.Conectar();
                }
                bConn = true;
                this.Close();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(null, "Erro: " + ex.Message, "E R R O", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tbo.CloseConnection();
            }


        }

        private void btnTestarCon_Click(object sender, EventArgs e)
        {
            if (rbSqlAuth.Checked)
            {
                tbo.TipoConexao = 1;
            }
            else
            {
                tbo.TipoConexao = 0;
            }

            tbo.UserId = txtUsuario.Text;
            tbo.Senha = txtSenha.Text;
            tbo.Servidor = cbxServidor.Text;
            tbo.DataBase = "master";


            try
            {
                if (!tbo.isConectado())
                {
                    tbo.Conectar();
                }
                KryptonMessageBox.Show(null, "A Conexão foi realizada com sucesso.", "S U C E S S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(null, "Falha na conexão: \n" +ex.Message, "E R R O", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tbo.CloseConnection();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxDatabase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }
    }
}