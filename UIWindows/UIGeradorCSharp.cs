using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using BO;
using BO.Classes;

namespace UIWindows
{
    public partial class UIGeradorCSharp : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        TabelasBO objbo;
        List<string> lTabelasFilhas = new List<string>();
        public UIGeradorCSharp(TabelasBO objbo)
        {
            InitializeComponent();
            this.objbo = objbo;
        }

        private void selecionarTabelasFilhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                if (lbTabelas.SelectedItem != null)
                {
                    TabPage pgPai = tabControl1.TabPages[0];
                    tabControl1.TabPages.Clear();
                    tabControl1.TabPages.Add(pgPai);

                    TabPage pgMod = tabModels.TabPages[0];
                    tabModels.TabPages.Clear();
                    tabModels.TabPages.Add(pgMod);


                    string TabPai = lbTabelas.SelectedValue.ToString();
                    string PkPai = objbo.CarregaPK(TabPai)[0];

                    UIListaTabelasFilha Uitab = new UIListaTabelasFilha(TabPai, objbo);
                    Uitab.ShowDialog();
                    lTabelasFilhas = Uitab.lTabelas;

                    RepositoryPai rep = new RepositoryPai(TabPai, PkPai);
                    txtPaiRepository.Text = rep.Inject() + rep.Save() + rep.Delete() + rep.Copy() + rep.Get() + rep.Transactions();

                    ServicePai servPai = new ServicePai(TabPai, objbo.CarregaPK(TabPai)[0], lTabelasFilhas);
                    txtPaiService.Text = servPai.Inject() + servPai.Save() + servPai.Delete() + servPai.Copy() + servPai.Get();

                    if (cbParameterOrder.Enabled)
                    {
                        txtPaiModel.Text = objbo.GerarPropriedadesWithOrder(TabPai, false);
                    }
                    else
                    {
                        txtPaiModel.Text = objbo.GerarPropriedades(TabPai, false);
                    }


                    int iTxtRep = 1;
                    int iTxtSer = 1;
                    int iTxtMod = 1;

                    if (lTabelasFilhas == null) return;

                    foreach (string TabFilha in lTabelasFilhas)
                    {
                        tabControl1.TabPages.Add("tab" + TabFilha, TabFilha);
                        tabControl1.TabPages["tab" + TabFilha].BackColor = Color.White;

                        TabControl tabc = new TabControl();
                        tabc.Dock = DockStyle.Fill;

                        TabPage tabRepository = new TabPage("Repository");
                        tabRepository.BackColor = Color.White;

                        TabPage tabService = new TabPage("Service");
                        tabService.BackColor = Color.White;

                        KryptonTextBox txtRep = new KryptonTextBox();
                        txtRep.Name = "txt" + iTxtRep.ToString();
                        txtRep.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
                        txtRep.Multiline = true;
                        txtRep.ScrollBars = ScrollBars.Vertical;
                        txtRep.Dock = DockStyle.Fill;

                        RepositoryFilho repFilho = new RepositoryFilho(TabFilha, PkPai, objbo.CarregaPK(TabFilha)[0]);
                        txtRep.Text = repFilho.Save() + repFilho.Update() + repFilho.Delete() + repFilho.Delete2() + repFilho.Copy() + repFilho.Get() + repFilho.GetAll();

                        KryptonTextBox txtSer = new KryptonTextBox();
                        txtSer.Name = "txt" + iTxtSer.ToString();
                        txtSer.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
                        txtSer.Multiline = true;
                        txtSer.ScrollBars = ScrollBars.Vertical;
                        txtSer.Dock = DockStyle.Fill;
                        ServiceFilho servFilho = new ServiceFilho(PkPai, objbo.CarregaPK(TabFilha)[0], TabFilha);
                        txtSer.Text = servFilho.Save() + servFilho.Update() + servFilho.Delete() + servFilho.Delete2() + servFilho.Copy() + servFilho.Get() + servFilho.GetAll();


                        tabRepository.Controls.Add(txtRep);
                        tabService.Controls.Add(txtSer);

                        tabc.TabPages.Add(tabRepository);
                        tabc.TabPages.Add(tabService);

                        tabControl1.TabPages["tab" + TabFilha].Controls.Add(tabc);

                        TabPage tabModel = new TabPage(TabFilha);
                        tabService.BackColor = Color.White;

                        KryptonTextBox txtMod = new KryptonTextBox();
                        txtMod.Name = "txt" + iTxtMod.ToString();
                        txtMod.Multiline = true;
                        txtMod.ScrollBars = ScrollBars.Vertical;
                        txtMod.Dock = DockStyle.Fill;

                        if (cbParameterOrder.Enabled)
                        {
                            txtMod.Text = objbo.GerarPropriedadesWithOrder(TabFilha, true);
                        }
                        else
                        {
                            txtMod.Text = objbo.GerarPropriedades(TabFilha, true);
                        }


                        tabModel.Controls.Add(txtMod);
                        tabModels.TabPages.Add(tabModel);


                        iTxtRep++;
                        iTxtSer++;
                        iTxtMod++;
                    }
                }
            }
            catch (Exception)
            {
                txtPaiModel.Text = "";
                txtPaiRepository.Text = "";
                txtPaiService.Text = "";
            }
        }

        private void UIGeradorCSharp_Load(object sender, EventArgs e)
        {
            lbTabelas.DataSource = objbo.GetTabelas();  // Carrega o ListBox com as tabelas do banco selecionado...
            lbTabelas.DisplayMember = "TABLE_NAME";
            lbTabelas.ValueMember = "TABLE_NAME";
        }

        private void btnGerarProc_Click(object sender, EventArgs e)
        {
            TabPage pgPai = tabControl1.TabPages[0];
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(pgPai);

            TabPage pgMod = tabModels.TabPages[0];
            tabModels.TabPages.Clear();
            tabModels.TabPages.Add(pgMod);

            string TabPai = lbTabelas.SelectedValue.ToString();
            string PkPai = objbo.CarregaPK(TabPai)[0];

            RepositoryNormal repNrml = new RepositoryNormal(TabPai, PkPai);
            txtPaiRepository.Text = repNrml.Inject() + repNrml.Save() + repNrml.Delete() + repNrml.Copy() + repNrml.Get() + repNrml.GetAll();

            ServiceNormal servNrml = new ServiceNormal(TabPai, PkPai);
            txtPaiService.Text = servNrml.Inject() + servNrml.Save() + servNrml.Delete() + servNrml.Copy() + servNrml.Get() + servNrml.GetAll();

            if (cbPropertyChanged.Checked)
            {
                txtPaiModel.Text = objbo.GerarPropriedadesWithINotifyPropertyChanged(TabPai,
                    tbFilho: false, bParameterOrder: cbParameterOrder.Checked);
            }
            else if (cbParameterOrder.Checked)
            {
                txtPaiModel.Text = objbo.GerarPropriedadesWithOrder(TabPai, false);
            }
            else
            {
                txtPaiModel.Text = objbo.GerarPropriedades(TabPai, false);
            }

        }
    }
}