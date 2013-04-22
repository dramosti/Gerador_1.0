namespace UIWindows
{
    partial class UIPesquisaForm
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
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pnBotoes = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSelecionar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.gvForms = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.mModulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnPesquisa = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnImpRel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbOp = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbCampos = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.edtPesquisa = new System.Windows.Forms.TextBox();
            this.idMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xNomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xNameSpaceCamadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formulariosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnBotoes)).BeginInit();
            this.pnBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mModulosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnPesquisa)).BeginInit();
            this.pnPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCampos)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.pnBotoes);
            this.kryptonPanel.Controls.Add(this.gvForms);
            this.kryptonPanel.Controls.Add(this.pnPesquisa);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(870, 375);
            this.kryptonPanel.TabIndex = 0;
            // 
            // pnBotoes
            // 
            this.pnBotoes.Controls.Add(this.btnCancelar);
            this.pnBotoes.Controls.Add(this.btnSelecionar);
            this.pnBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBotoes.Location = new System.Drawing.Point(0, 332);
            this.pnBotoes.Name = "pnBotoes";
            this.pnBotoes.Size = new System.Drawing.Size(870, 43);
            this.pnBotoes.StateNormal.Color1 = System.Drawing.Color.WhiteSmoke;
            this.pnBotoes.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(768, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Values.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(657, 6);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(90, 25);
            this.btnSelecionar.TabIndex = 0;
            this.btnSelecionar.Values.Text = "Selecionar";
            this.btnSelecionar.Click += new System.EventHandler(this.gvForms_DoubleClick);
            // 
            // gvForms
            // 
            this.gvForms.AllowUserToAddRows = false;
            this.gvForms.AllowUserToDeleteRows = false;
            this.gvForms.AutoGenerateColumns = false;
            this.gvForms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvForms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMod,
            this.xNomeDataGridViewTextBoxColumn,
            this.xNameSpaceCamadaDataGridViewTextBoxColumn,
            this.formulariosDataGridViewTextBoxColumn});
            this.gvForms.DataSource = this.mModulosBindingSource;
            this.gvForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvForms.Location = new System.Drawing.Point(0, 68);
            this.gvForms.Name = "gvForms";
            this.gvForms.ReadOnly = true;
            this.gvForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvForms.Size = new System.Drawing.Size(870, 307);
            this.gvForms.TabIndex = 1;
            this.gvForms.DoubleClick += new System.EventHandler(this.gvForms_DoubleClick);
            // 
            // mModulosBindingSource
            // 
            this.mModulosBindingSource.DataSource = typeof(DAO.mModulos);
            // 
            // pnPesquisa
            // 
            this.pnPesquisa.Controls.Add(this.btnImpRel);
            this.pnPesquisa.Controls.Add(this.cbOp);
            this.pnPesquisa.Controls.Add(this.cbCampos);
            this.pnPesquisa.Controls.Add(this.edtPesquisa);
            this.pnPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnPesquisa.Location = new System.Drawing.Point(0, 0);
            this.pnPesquisa.Name = "pnPesquisa";
            this.pnPesquisa.Size = new System.Drawing.Size(870, 68);
            this.pnPesquisa.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.pnPesquisa.StateNormal.Color1 = System.Drawing.Color.WhiteSmoke;
            this.pnPesquisa.TabIndex = 0;
            // 
            // btnImpRel
            // 
            this.btnImpRel.Location = new System.Drawing.Point(683, 20);
            this.btnImpRel.Name = "btnImpRel";
            this.btnImpRel.Size = new System.Drawing.Size(114, 29);
            this.btnImpRel.TabIndex = 5;
            this.btnImpRel.Values.Text = "Imprimir Relatório";
            this.btnImpRel.Click += new System.EventHandler(this.btnImpRel_Click);
            // 
            // cbOp
            // 
            this.cbOp.DropDownWidth = 121;
            this.cbOp.Items.AddRange(new object[] {
            "Contém",
            "Igual",
            "Inicia"});
            this.cbOp.Location = new System.Drawing.Point(157, 23);
            this.cbOp.Name = "cbOp";
            this.cbOp.Size = new System.Drawing.Size(121, 21);
            this.cbOp.TabIndex = 4;
            // 
            // cbCampos
            // 
            this.cbCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampos.DropDownWidth = 133;
            this.cbCampos.Items.AddRange(new object[] {
            "Id",
            "Módulo",
            "Namespace"});
            this.cbCampos.Location = new System.Drawing.Point(12, 23);
            this.cbCampos.Name = "cbCampos";
            this.cbCampos.Size = new System.Drawing.Size(133, 21);
            this.cbCampos.TabIndex = 3;
            this.cbCampos.SelectedIndexChanged += new System.EventHandler(this.cbCampos_SelectedIndexChanged);
            // 
            // edtPesquisa
            // 
            this.edtPesquisa.Location = new System.Drawing.Point(292, 23);
            this.edtPesquisa.Name = "edtPesquisa";
            this.edtPesquisa.Size = new System.Drawing.Size(301, 20);
            this.edtPesquisa.TabIndex = 1;
            this.edtPesquisa.TextChanged += new System.EventHandler(this.edtPesquisa_TextChanged);
            // 
            // idMod
            // 
            this.idMod.DataPropertyName = "idModulo";
            this.idMod.HeaderText = "Id";
            this.idMod.Name = "idMod";
            this.idMod.ReadOnly = true;
            this.idMod.Width = 46;
            // 
            // xNomeDataGridViewTextBoxColumn
            // 
            this.xNomeDataGridViewTextBoxColumn.DataPropertyName = "xNome";
            this.xNomeDataGridViewTextBoxColumn.HeaderText = "Módulo";
            this.xNomeDataGridViewTextBoxColumn.Name = "xNomeDataGridViewTextBoxColumn";
            this.xNomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.xNomeDataGridViewTextBoxColumn.Width = 78;
            // 
            // xNameSpaceCamadaDataGridViewTextBoxColumn
            // 
            this.xNameSpaceCamadaDataGridViewTextBoxColumn.DataPropertyName = "xNameSpaceCamada";
            this.xNameSpaceCamadaDataGridViewTextBoxColumn.HeaderText = "Namespace";
            this.xNameSpaceCamadaDataGridViewTextBoxColumn.Name = "xNameSpaceCamadaDataGridViewTextBoxColumn";
            this.xNameSpaceCamadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.xNameSpaceCamadaDataGridViewTextBoxColumn.Width = 98;
            // 
            // formulariosDataGridViewTextBoxColumn
            // 
            this.formulariosDataGridViewTextBoxColumn.DataPropertyName = "Formularios";
            this.formulariosDataGridViewTextBoxColumn.HeaderText = "Formularios";
            this.formulariosDataGridViewTextBoxColumn.Name = "formulariosDataGridViewTextBoxColumn";
            this.formulariosDataGridViewTextBoxColumn.ReadOnly = true;
            this.formulariosDataGridViewTextBoxColumn.Visible = false;
            this.formulariosDataGridViewTextBoxColumn.Width = 99;
            // 
            // UIPesquisaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 375);
            this.Controls.Add(this.kryptonPanel);
            this.MaximizeBox = false;
            this.Name = "UIPesquisaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Form";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnBotoes)).EndInit();
            this.pnBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvForms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mModulosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnPesquisa)).EndInit();
            this.pnPesquisa.ResumeLayout(false);
            this.pnPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCampos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gvForms;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnPesquisa;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnBotoes;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSelecionar;
        private System.Windows.Forms.TextBox edtPesquisa;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbOp;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbCampos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImpRel;
        private System.Windows.Forms.BindingSource mModulosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMod;
        private System.Windows.Forms.DataGridViewTextBoxColumn xNomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xNameSpaceCamadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formulariosDataGridViewTextBoxColumn;
    }
}

