using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using BO;
using System.IO;
using System.Data.SqlClient;

namespace UIWindows
{
    public partial class UIGerador : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private TabelasBO objbo;

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
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diretorio = new FolderBrowserDialog();
            diretorio.ShowDialog();
            if (diretorio.SelectedPath != String.Empty)
            {
                txtCaminho.Text = diretorio.SelectedPath;
                txtCaminho.Text += @"\";
            }

        }

        private void buttonSpecAny1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diretorio = new FolderBrowserDialog();
            diretorio.ShowDialog();
            if (diretorio.SelectedPath != String.Empty)
            {
                txtCaaminhoView.Text = diretorio.SelectedPath;
                txtCaaminhoView.Text += @"\";
            }
        }

        private void btnExecutarProc_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dInfoProcedure = new DirectoryInfo(txtCaminho.Text);
                FileInfo[] fInfoProcedure = dInfoProcedure.GetFiles("*.sql");

                DirectoryInfo dInfoView = new DirectoryInfo(txtCaaminhoView.Text.Replace("\r\n", "\\"));
                FileInfo[] fInfoView = dInfoView.GetFiles("*.sql");

                lblProcess.Visible = true;
                int atualizados = 0;
                int novos = 0;
                int erros = 0;

                StringBuilder sResult = new StringBuilder();
                int iCount = 0;
                pgProgresso.Value = 0;
                pgProgresso.Minimum = 0;
                pgProgresso.Maximum = fInfoProcedure.Length;
                pgProgresso.Step = 1;

                #region Executa Procedures

                foreach (FileInfo file in fInfoProcedure)
                {
                    pgProgresso.PerformStep();

                    lblProcess.Text = string.Format("Executando {0} de {1} Procedures", iCount.ToString(), fInfoProcedure.GetLength(0).ToString());
                    lblProcess.Refresh();

                    iCount++;
                    string sProc = "";
                    string sNameProc = "";
                    try
                    {
                        StreamReader reader = new StreamReader(file.FullName);
                        sProc = reader.ReadToEnd();

                        int iAux = 0;


                        reader.Close();
                        if (file.Name.ToUpper().Contains("DBO"))
                        {
                            sNameProc = file.Name.Split('.')[1].ToString();
                        }
                        else
                        {
                            sNameProc = file.Name.Split('.')[0].ToString();
                        }
                        if (ProcExiste(sNameProc))
                        {
                            iAux = sProc.IndexOf("CREATE");
                            sProc = sProc.Substring(iAux);
                            sProc = sProc.Replace("\r\nGO\r\n", "");

                            sProc = sProc.Replace("CREATE", "ALTER");
                            atualizados++;
                        }
                        else
                        {
                            iAux = sProc.IndexOf("ALTER");
                            sProc = sProc.Substring(iAux);
                            sProc = sProc.Replace("\r\nGO\r\n", "");
                            novos++;
                        }

                        sProc = sProc.Replace(";", "");

                        if (!objbo.isConectado())
                        {
                            objbo.Conectar();
                        }

                        SqlCommand command = new SqlCommand(sProc, objbo.GetConexao());
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        sResult.Append("Erro na procedure " + sNameProc + " - " + ex.Message + Environment.NewLine);
                        erros++;
                    }
                }

                #endregion

                #region Executa Views

                int iCountView = 0;
                int atualizadosView = 0;
                int novosView = 0;
                int errosView = 0;
                lblProcess.Text = "";

                foreach (FileInfo file in fInfoView)
                {
                    pgProgresso.PerformStep();

                    lblProcess.Text = string.Format("Executando {0} de {1} Views", iCountView.ToString(), fInfoView.GetLength(0).ToString());
                    lblProcess.Refresh();

                    iCountView++;


                    string sProc = "";
                    string sNameProc = "";
                    try
                    {
                        StreamReader reader = new StreamReader(file.FullName);
                        sProc = reader.ReadToEnd();

                        int iAux = 0;


                        reader.Close();
                        if (file.Name.ToUpper().Contains("DBO"))
                        {
                            sNameProc = file.Name.Split('.')[1].ToString();
                        }
                        else
                        {
                            sNameProc = file.Name.Split('.')[0].ToString();
                        }
                        if (ProcExiste(sNameProc))
                        {
                            iAux = sProc.IndexOf("CREATE");
                            sProc = sProc.Substring(iAux);
                            sProc = sProc.Replace("\r\nGO\r\n", "");

                            sProc = sProc.Replace("CREATE", "ALTER");
                            atualizadosView++;
                        }
                        else
                        {
                            iAux = sProc.IndexOf("ALTER");
                            sProc = sProc.Substring(iAux);
                            sProc = sProc.Replace("\r\nGO\r\n", "");

                            novosView++;
                        }


                        if (!objbo.isConectado())
                        {
                            objbo.Conectar();
                        }

                        SqlCommand command = new SqlCommand(sProc, objbo.GetConexao());
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        sResult.Append("Erro na View " + sNameProc + " - " + ex.Message + Environment.NewLine);
                        errosView++;
                    }
                }

                #endregion

                if (!sResult.ToString().Equals(""))
                {
                    KryptonMessageBox.Show(sResult.ToString());
                }
                KryptonMessageBox.Show(null, "Comandos executados com sucessos !\n\n Banco de dados: " + objbo.DataBase + "\n Procedures atualizadas: " + (atualizados - erros) + "\n Novas Procedures: " + novos + "\n Erros: " + erros + "\n\n Views Atualizadas: " + (atualizadosView - errosView) + "\n Novas Views: " + novosView + "\n Erros: " + errosView, "I N F O R M A Ç Ã O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pgProgresso.Value = 0;
                lblProcess.Text = "";
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(null, "Erro ao listar Procedures / Views \n\n" + ex.Message, "E R R O", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { objbo.CloseConnection(); }
        }

        private void btnSalvarProc_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            try
            {
                string texto = string.Empty;
                Button btn = sender as Button;

                if (cbProcedure.Checked)
                {

                    texto = txtInsertUpdate.Text;
                    sw = new StreamWriter(txtCaminho.Text + objbo.ProcNome_Insert + ".StoredProcedure.sql");
                    sw.Write(texto);
                    sw.Close();

                    texto = txtUpdate.Text;
                    sw = new StreamWriter(txtCaminho.Text + objbo.ProcNome_Update + ".StoredProcedure.sql");
                    sw.Write(texto);
                    sw.Close();

                    texto = txtDelete.Text;
                    sw = new StreamWriter(txtCaminho.Text + objbo.ProcNome_Delete + ".StoredProcedure.sql");
                    sw.Write(texto);
                    sw.Close();

                    texto = txtPesquisa.Text;
                    sw = new StreamWriter(txtCaminho.Text + objbo.ProcNome_Select + ".StoredProcedure.sql");
                    sw.Write(texto);
                    sw.Close();

                    texto = txtDuplicar.Text;
                    sw = new StreamWriter(txtCaminho.Text + objbo.ProcNome_Duplicar + ".StoredProcedure.sql");
                    sw.Write(texto);
                    sw.Close();
                }

                if (cbView.Checked)
                {
                    texto = txtViews.Text;
                    sw = new StreamWriter(txtCaaminhoView.Text.Replace("\r\n", "") + "\\dbo." + objbo.nmView + ".View.sql");
                    sw.Write(texto);
                    sw.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao salvar procedures.");
            }
            finally
            {
                sw.Close();
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
            pgProgresso.Maximum = 8;
            pgProgresso.Step = 1;

            try
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

                string sNameProcDelete= objbo.GetNameProc(TabelasBO.tipoProc.DELETE);
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


                string nmView = objbo.nmView;
                if (ProcExiste(nmView))
                {
                    view = view.Replace("CREATE", "ALTER");
                }
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

                command = new SqlCommand(view, objbo.GetConexao());
                command.ExecuteNonQuery();
                pgProgresso.PerformStep();
                System.Threading.Thread.Sleep(100);

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


 

    }
}