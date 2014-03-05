namespace UIWindows
{
    partial class UIGeradorCSharp
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
            this.tabModels = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPaiModel = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRepository = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPaiRepository = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtPaiService = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbParameterOrder = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.lbTabelas = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selecionarTabelasFilhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGerarProc = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbPropertyChanged = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.tabModels.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabRepository.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.tabModels);
            this.kryptonPanel.Controls.Add(this.tabControl1);
            this.kryptonPanel.Controls.Add(this.panel2);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(931, 516);
            this.kryptonPanel.TabIndex = 0;
            // 
            // tabModels
            // 
            this.tabModels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabModels.Controls.Add(this.tabPage3);
            this.tabModels.Location = new System.Drawing.Point(638, 6);
            this.tabModels.Name = "tabModels";
            this.tabModels.SelectedIndex = 0;
            this.tabModels.Size = new System.Drawing.Size(281, 507);
            this.tabModels.TabIndex = 115;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtPaiModel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(273, 481);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Tabela Pai";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtPaiModel
            // 
            this.txtPaiModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaiModel.Location = new System.Drawing.Point(3, 3);
            this.txtPaiModel.Multiline = true;
            this.txtPaiModel.Name = "txtPaiModel";
            this.txtPaiModel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPaiModel.Size = new System.Drawing.Size(267, 475);
            this.txtPaiModel.TabIndex = 114;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabRepository);
            this.tabControl1.Location = new System.Drawing.Point(224, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(408, 507);
            this.tabControl1.TabIndex = 114;
            // 
            // tabRepository
            // 
            this.tabRepository.Controls.Add(this.tabControl2);
            this.tabRepository.Location = new System.Drawing.Point(4, 22);
            this.tabRepository.Name = "tabRepository";
            this.tabRepository.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepository.Size = new System.Drawing.Size(400, 481);
            this.tabRepository.TabIndex = 0;
            this.tabRepository.Text = "Tabela Pai";
            this.tabRepository.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(394, 475);
            this.tabControl2.TabIndex = 114;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPaiRepository);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 449);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Repository";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPaiRepository
            // 
            this.txtPaiRepository.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaiRepository.Location = new System.Drawing.Point(3, 3);
            this.txtPaiRepository.Multiline = true;
            this.txtPaiRepository.Name = "txtPaiRepository";
            this.txtPaiRepository.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.txtPaiRepository.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPaiRepository.Size = new System.Drawing.Size(380, 443);
            this.txtPaiRepository.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtPaiService);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 449);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Service";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtPaiService
            // 
            this.txtPaiService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaiService.Location = new System.Drawing.Point(3, 3);
            this.txtPaiService.Multiline = true;
            this.txtPaiService.Name = "txtPaiService";
            this.txtPaiService.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.txtPaiService.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPaiService.Size = new System.Drawing.Size(380, 443);
            this.txtPaiService.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.cbPropertyChanged);
            this.panel2.Controls.Add(this.cbParameterOrder);
            this.panel2.Controls.Add(this.lbTabelas);
            this.panel2.Controls.Add(this.btnGerarProc);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 510);
            this.panel2.TabIndex = 110;
            // 
            // cbParameterOrder
            // 
            this.cbParameterOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbParameterOrder.Checked = true;
            this.cbParameterOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbParameterOrder.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.cbParameterOrder.Location = new System.Drawing.Point(3, 455);
            this.cbParameterOrder.Name = "cbParameterOrder";
            this.cbParameterOrder.Size = new System.Drawing.Size(114, 20);
            this.cbParameterOrder.TabIndex = 110;
            this.cbParameterOrder.Text = "Parameter Order";
            this.cbParameterOrder.Values.Text = "Parameter Order";
            // 
            // lbTabelas
            // 
            this.lbTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTabelas.ContextMenuStrip = this.contextMenuStrip1;
            this.lbTabelas.Location = new System.Drawing.Point(3, 3);
            this.lbTabelas.Name = "lbTabelas";
            this.lbTabelas.Size = new System.Drawing.Size(209, 402);
            this.lbTabelas.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selecionarTabelasFilhaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 26);
            // 
            // selecionarTabelasFilhaToolStripMenuItem
            // 
            this.selecionarTabelasFilhaToolStripMenuItem.Name = "selecionarTabelasFilhaToolStripMenuItem";
            this.selecionarTabelasFilhaToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.selecionarTabelasFilhaToolStripMenuItem.Text = "Selecionar Tabela(s) Filha";
            this.selecionarTabelasFilhaToolStripMenuItem.Click += new System.EventHandler(this.selecionarTabelasFilhaToolStripMenuItem_Click);
            // 
            // btnGerarProc
            // 
            this.btnGerarProc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarProc.Location = new System.Drawing.Point(3, 480);
            this.btnGerarProc.Name = "btnGerarProc";
            this.btnGerarProc.Size = new System.Drawing.Size(210, 26);
            this.btnGerarProc.TabIndex = 2;
            this.btnGerarProc.Values.Text = "&Gerar Códigos";
            this.btnGerarProc.Click += new System.EventHandler(this.btnGerarProc_Click);
            // 
            // cbPropertyChanged
            // 
            this.cbPropertyChanged.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPropertyChanged.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.cbPropertyChanged.Location = new System.Drawing.Point(3, 429);
            this.cbPropertyChanged.Name = "cbPropertyChanged";
            this.cbPropertyChanged.Size = new System.Drawing.Size(156, 20);
            this.cbPropertyChanged.TabIndex = 111;
            this.cbPropertyChanged.Text = "INotifyPropertyChanged";
            this.cbPropertyChanged.Values.Text = "INotifyPropertyChanged";
            // 
            // UIGeradorCSharp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 516);
            this.Controls.Add(this.kryptonPanel);
            this.Name = "UIGeradorCSharp";
            this.ShowIcon = false;
            this.Text = "Gerador CSharp";
            this.Load += new System.EventHandler(this.UIGeradorCSharp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.tabModels.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabRepository.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbParameterOrder;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lbTabelas;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGerarProc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selecionarTabelasFilhaToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRepository;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPaiService;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPaiRepository;
        private System.Windows.Forms.TabControl tabModels;
        private System.Windows.Forms.TabPage tabPage3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPaiModel;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbPropertyChanged;
    }
}

