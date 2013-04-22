namespace UIWindows
{
    partial class UICadastraMod
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.pROD_MODULOSDataSet = new UIWindows.PROD_MODULOSDataSet();
            this.formulariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formulariosTableAdapter = new UIWindows.PROD_MODULOSDataSetTableAdapters.FormulariosTableAdapter();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.painelBotoes = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnPesquisa = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSalvar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAlterar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNovo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.painelPrincipal = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCadastro = new System.Windows.Forms.TabPage();
            this.gbCadastro = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.gbForms = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.gvForms = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.idFormularioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idModuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.form = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namespaceform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scope = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.singleton = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.xObservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.painelCadastro = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.edtNamesPrinc = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.edtModulo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.edtID = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tbSerial = new System.Windows.Forms.TabPage();
            this.webXml = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.pROD_MODULOSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formulariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.painelBotoes)).BeginInit();
            this.painelBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.painelPrincipal)).BeginInit();
            this.painelPrincipal.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbCadastro.Panel)).BeginInit();
            this.gbCadastro.Panel.SuspendLayout();
            this.gbCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbForms.Panel)).BeginInit();
            this.gbForms.Panel.SuspendLayout();
            this.gbForms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.painelCadastro)).BeginInit();
            this.painelCadastro.SuspendLayout();
            this.tbSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // pROD_MODULOSDataSet
            // 
            this.pROD_MODULOSDataSet.DataSetName = "PROD_MODULOSDataSet";
            this.pROD_MODULOSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // formulariosBindingSource
            // 
            this.formulariosBindingSource.DataMember = "Formularios";
            this.formulariosBindingSource.DataSource = this.pROD_MODULOSDataSet;
            // 
            // formulariosTableAdapter
            // 
            this.formulariosTableAdapter.ClearBeforeFill = true;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // painelBotoes
            // 
            this.painelBotoes.Controls.Add(this.btnPesquisa);
            this.painelBotoes.Controls.Add(this.btnCancelar);
            this.painelBotoes.Controls.Add(this.btnSalvar);
            this.painelBotoes.Controls.Add(this.btnAlterar);
            this.painelBotoes.Controls.Add(this.btnNovo);
            this.painelBotoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.painelBotoes.Location = new System.Drawing.Point(0, 0);
            this.painelBotoes.Name = "painelBotoes";
            this.painelBotoes.Size = new System.Drawing.Size(863, 50);
            this.painelBotoes.TabIndex = 6;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(450, 13);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(90, 25);
            this.btnPesquisa.TabIndex = 4;
            this.btnPesquisa.Values.Text = "Pesquisa";
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(342, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Values.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(231, 13);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 25);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Values.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(122, 13);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(90, 25);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Values.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(12, 13);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(90, 25);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Values.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // painelPrincipal
            // 
            this.painelPrincipal.Controls.Add(this.tabControl1);
            this.painelPrincipal.Controls.Add(this.painelBotoes);
            this.painelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.painelPrincipal.Name = "painelPrincipal";
            this.painelPrincipal.Size = new System.Drawing.Size(863, 432);
            this.painelPrincipal.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCadastro);
            this.tabControl1.Controls.Add(this.tbSerial);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 382);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpCadastro
            // 
            this.tpCadastro.Controls.Add(this.gbCadastro);
            this.tpCadastro.Location = new System.Drawing.Point(4, 22);
            this.tpCadastro.Name = "tpCadastro";
            this.tpCadastro.Padding = new System.Windows.Forms.Padding(3);
            this.tpCadastro.Size = new System.Drawing.Size(855, 356);
            this.tpCadastro.TabIndex = 0;
            this.tpCadastro.Text = "Cadastro";
            this.tpCadastro.UseVisualStyleBackColor = true;
            // 
            // gbCadastro
            // 
            this.gbCadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCadastro.Location = new System.Drawing.Point(3, 3);
            this.gbCadastro.Name = "gbCadastro";
            // 
            // gbCadastro.Panel
            // 
            this.gbCadastro.Panel.Controls.Add(this.gbForms);
            this.gbCadastro.Panel.Controls.Add(this.painelCadastro);
            this.gbCadastro.Size = new System.Drawing.Size(849, 350);
            this.gbCadastro.TabIndex = 8;
            this.gbCadastro.Text = "Módulo";
            this.gbCadastro.Values.Heading = "Módulo";
            // 
            // gbForms
            // 
            this.gbForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbForms.Location = new System.Drawing.Point(0, 100);
            this.gbForms.Name = "gbForms";
            // 
            // gbForms.Panel
            // 
            this.gbForms.Panel.Controls.Add(this.gvForms);
            this.gbForms.Size = new System.Drawing.Size(845, 226);
            this.gbForms.TabIndex = 16;
            this.gbForms.Text = "Formulários";
            this.gbForms.Values.Heading = "Formulários";
            // 
            // gvForms
            // 
            this.gvForms.AutoGenerateColumns = false;
            this.gvForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvForms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFormularioDataGridViewTextBoxColumn,
            this.idModuloDataGridViewTextBoxColumn,
            this.idForm,
            this.form,
            this.namespaceform,
            this.scope,
            this.singleton,
            this.ativo,
            this.xObservacaoDataGridViewTextBoxColumn});
            this.gvForms.DataSource = this.formulariosBindingSource;
            this.gvForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvForms.Location = new System.Drawing.Point(0, 0);
            this.gvForms.Name = "gvForms";
            this.gvForms.ReadOnly = true;
            this.gvForms.Size = new System.Drawing.Size(841, 202);
            this.gvForms.TabIndex = 0;
            this.gvForms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvForms_CellContentClick);
            this.gvForms.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvForms_CellValidating);
            this.gvForms.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvForms_CellValueChanged);
            // 
            // idFormularioDataGridViewTextBoxColumn
            // 
            this.idFormularioDataGridViewTextBoxColumn.DataPropertyName = "idFormulario";
            this.idFormularioDataGridViewTextBoxColumn.HeaderText = "idFormulario";
            this.idFormularioDataGridViewTextBoxColumn.Name = "idFormularioDataGridViewTextBoxColumn";
            this.idFormularioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idFormularioDataGridViewTextBoxColumn.Visible = false;
            this.idFormularioDataGridViewTextBoxColumn.Width = 104;
            // 
            // idModuloDataGridViewTextBoxColumn
            // 
            this.idModuloDataGridViewTextBoxColumn.DataPropertyName = "idModulo";
            this.idModuloDataGridViewTextBoxColumn.HeaderText = "ID MOD";
            this.idModuloDataGridViewTextBoxColumn.Name = "idModuloDataGridViewTextBoxColumn";
            this.idModuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.idModuloDataGridViewTextBoxColumn.Visible = false;
            this.idModuloDataGridViewTextBoxColumn.Width = 78;
            // 
            // idForm
            // 
            this.idForm.DataPropertyName = "xID";
            this.idForm.HeaderText = "ID FORM";
            this.idForm.Name = "idForm";
            this.idForm.ReadOnly = true;
            this.idForm.Width = 70;
            // 
            // form
            // 
            this.form.DataPropertyName = "xName";
            this.form.HeaderText = "FORMULÁRIO";
            this.form.Name = "form";
            this.form.ReadOnly = true;
            this.form.Width = 150;
            // 
            // namespaceform
            // 
            this.namespaceform.DataPropertyName = "xType";
            this.namespaceform.HeaderText = "NAMESPACE";
            this.namespaceform.Name = "namespaceform";
            this.namespaceform.ReadOnly = true;
            this.namespaceform.Width = 250;
            // 
            // scope
            // 
            this.scope.DataPropertyName = "xScope";
            this.scope.HeaderText = "SCOPE";
            this.scope.Items.AddRange(new object[] {
            "application",
            "request"});
            this.scope.Name = "scope";
            this.scope.ReadOnly = true;
            this.scope.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.scope.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // singleton
            // 
            this.singleton.DataPropertyName = "stSingleton";
            this.singleton.HeaderText = "SINGLETON";
            this.singleton.Name = "singleton";
            this.singleton.ReadOnly = true;
            this.singleton.Width = 50;
            // 
            // ativo
            // 
            this.ativo.DataPropertyName = "stAtivo";
            this.ativo.FalseValue = "false";
            this.ativo.HeaderText = "ATIVO";
            this.ativo.Name = "ativo";
            this.ativo.ReadOnly = true;
            this.ativo.TrueValue = "true";
            this.ativo.Width = 50;
            // 
            // xObservacaoDataGridViewTextBoxColumn
            // 
            this.xObservacaoDataGridViewTextBoxColumn.DataPropertyName = "xObservacao";
            this.xObservacaoDataGridViewTextBoxColumn.HeaderText = "OBSERVAÇÃO";
            this.xObservacaoDataGridViewTextBoxColumn.Name = "xObservacaoDataGridViewTextBoxColumn";
            this.xObservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.xObservacaoDataGridViewTextBoxColumn.Width = 300;
            // 
            // painelCadastro
            // 
            this.painelCadastro.Controls.Add(this.edtNamesPrinc);
            this.painelCadastro.Controls.Add(this.kryptonLabel3);
            this.painelCadastro.Controls.Add(this.edtModulo);
            this.painelCadastro.Controls.Add(this.kryptonLabel2);
            this.painelCadastro.Controls.Add(this.edtID);
            this.painelCadastro.Controls.Add(this.kryptonLabel1);
            this.painelCadastro.Dock = System.Windows.Forms.DockStyle.Top;
            this.painelCadastro.Enabled = false;
            this.painelCadastro.Location = new System.Drawing.Point(0, 0);
            this.painelCadastro.Name = "painelCadastro";
            this.painelCadastro.Size = new System.Drawing.Size(845, 100);
            this.painelCadastro.TabIndex = 15;
            // 
            // edtNamesPrinc
            // 
            this.edtNamesPrinc.Location = new System.Drawing.Point(168, 65);
            this.edtNamesPrinc.Name = "edtNamesPrinc";
            this.edtNamesPrinc.Size = new System.Drawing.Size(380, 20);
            this.edtNamesPrinc.TabIndex = 17;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(10, 65);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(142, 20);
            this.kryptonLabel3.TabIndex = 16;
            this.kryptonLabel3.Values.Text = "NAMESPACE PRINCIPAL";
            // 
            // edtModulo
            // 
            this.edtModulo.Location = new System.Drawing.Point(168, 42);
            this.edtModulo.Name = "edtModulo";
            this.edtModulo.Size = new System.Drawing.Size(529, 20);
            this.edtModulo.TabIndex = 15;
            this.edtModulo.Leave += new System.EventHandler(this.edtModulo_Leave);
            this.edtModulo.Validated += new System.EventHandler(this.edtModulo_Validated);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(89, 42);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel2.TabIndex = 14;
            this.kryptonLabel2.Values.Text = "MÓDULO";
            // 
            // edtID
            // 
            this.edtID.Enabled = false;
            this.edtID.Location = new System.Drawing.Point(168, 16);
            this.edtID.Name = "edtID";
            this.edtID.ReadOnly = true;
            this.edtID.Size = new System.Drawing.Size(115, 20);
            this.edtID.TabIndex = 13;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(130, 16);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(22, 20);
            this.kryptonLabel1.TabIndex = 12;
            this.kryptonLabel1.Values.Text = "ID";
            // 
            // tbSerial
            // 
            this.tbSerial.Controls.Add(this.webXml);
            this.tbSerial.Location = new System.Drawing.Point(4, 22);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Padding = new System.Windows.Forms.Padding(3);
            this.tbSerial.Size = new System.Drawing.Size(855, 356);
            this.tbSerial.TabIndex = 1;
            this.tbSerial.Text = "Serialização";
            this.tbSerial.UseVisualStyleBackColor = true;
            // 
            // webXml
            // 
            this.webXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webXml.Location = new System.Drawing.Point(3, 3);
            this.webXml.MinimumSize = new System.Drawing.Size(20, 20);
            this.webXml.Name = "webXml";
            this.webXml.Size = new System.Drawing.Size(849, 350);
            this.webXml.TabIndex = 0;
            // 
            // UICadastraMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 432);
            this.ControlBox = false;
            this.Controls.Add(this.painelPrincipal);
            this.Name = "UICadastraMod";
            this.Text = "Cadastro de Módulos";
            this.Load += new System.EventHandler(this.UICadastraMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pROD_MODULOSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formulariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.painelBotoes)).EndInit();
            this.painelBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.painelPrincipal)).EndInit();
            this.painelPrincipal.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpCadastro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbCadastro.Panel)).EndInit();
            this.gbCadastro.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbCadastro)).EndInit();
            this.gbCadastro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbForms.Panel)).EndInit();
            this.gbForms.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbForms)).EndInit();
            this.gbForms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvForms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.painelCadastro)).EndInit();
            this.painelCadastro.ResumeLayout(false);
            this.painelCadastro.PerformLayout();
            this.tbSerial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private PROD_MODULOSDataSet pROD_MODULOSDataSet;
        private System.Windows.Forms.BindingSource formulariosBindingSource;
        private PROD_MODULOSDataSetTableAdapters.FormulariosTableAdapter formulariosTableAdapter;
        private System.Windows.Forms.ErrorProvider ep;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel painelPrincipal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCadastro;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbCadastro;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbForms;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gvForms;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel painelCadastro;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox edtNamesPrinc;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox edtModulo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox edtID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.TabPage tbSerial;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel painelBotoes;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPesquisa;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSalvar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAlterar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNovo;
        private System.Windows.Forms.WebBrowser webXml;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFormularioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idModuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn form;
        private System.Windows.Forms.DataGridViewTextBoxColumn namespaceform;
        private System.Windows.Forms.DataGridViewComboBoxColumn scope;
        private System.Windows.Forms.DataGridViewCheckBoxColumn singleton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn xObservacaoDataGridViewTextBoxColumn;
    }
}

