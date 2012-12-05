namespace UIWindows
{
    partial class UIConexao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIConexao));
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cbxServidor = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTestarCon = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbxDatabase = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtSenha = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUsuario = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.rbSqlAuth = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbWindowsAuth = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxServidor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.cbxServidor);
            this.kryptonPanel.Controls.Add(this.btnCancel);
            this.kryptonPanel.Controls.Add(this.btnOK);
            this.kryptonPanel.Controls.Add(this.btnTestarCon);
            this.kryptonPanel.Controls.Add(this.cbxDatabase);
            this.kryptonPanel.Controls.Add(this.txtSenha);
            this.kryptonPanel.Controls.Add(this.txtUsuario);
            this.kryptonPanel.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel.Controls.Add(this.rbSqlAuth);
            this.kryptonPanel.Controls.Add(this.rbWindowsAuth);
            this.kryptonPanel.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonCustom1;
            this.kryptonPanel.Size = new System.Drawing.Size(392, 324);
            this.kryptonPanel.TabIndex = 0;
            this.kryptonPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel_Paint);
            // 
            // cbxServidor
            // 
            this.cbxServidor.DropDownWidth = 121;
            this.cbxServidor.Location = new System.Drawing.Point(130, 36);
            this.cbxServidor.Name = "cbxServidor";
            this.cbxServidor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.cbxServidor.Size = new System.Drawing.Size(148, 21);
            this.cbxServidor.TabIndex = 13;
            this.cbxServidor.Text = "aguarde . . .";
            this.cbxServidor.SelectionChangeCommitted += new System.EventHandler(this.cbxServidor_SelectionChangeCommitted);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Values.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(103, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 11;
            this.btnOK.Values.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTestarCon
            // 
            this.btnTestarCon.Enabled = false;
            this.btnTestarCon.Location = new System.Drawing.Point(137, 287);
            this.btnTestarCon.Name = "btnTestarCon";
            this.btnTestarCon.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnTestarCon.Size = new System.Drawing.Size(116, 25);
            this.btnTestarCon.TabIndex = 10;
            this.btnTestarCon.Values.Text = "Testar Conexão";
            this.btnTestarCon.Click += new System.EventHandler(this.btnTestarCon_Click);
            // 
            // cbxDatabase
            // 
            this.cbxDatabase.DropDownWidth = 121;
            this.cbxDatabase.Enabled = false;
            this.cbxDatabase.Location = new System.Drawing.Point(130, 170);
            this.cbxDatabase.Name = "cbxDatabase";
            this.cbxDatabase.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.cbxDatabase.Size = new System.Drawing.Size(148, 21);
            this.cbxDatabase.TabIndex = 9;
            this.cbxDatabase.SelectionChangeCommitted += new System.EventHandler(this.cbxDatabase_SelectionChangeCommitted);
            this.cbxDatabase.Enter += new System.EventHandler(this.cbxDatabase_Enter);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(130, 145);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(148, 20);
            this.txtSenha.TabIndex = 8;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(130, 119);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(148, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(63, 171);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonLabel4.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Database";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(63, 145);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonLabel3.Size = new System.Drawing.Size(44, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Senha";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(63, 119);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonLabel2.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Usuário";
            // 
            // rbSqlAuth
            // 
            this.rbSqlAuth.Location = new System.Drawing.Point(195, 79);
            this.rbSqlAuth.Name = "rbSqlAuth";
            this.rbSqlAuth.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.rbSqlAuth.Size = new System.Drawing.Size(165, 20);
            this.rbSqlAuth.TabIndex = 3;
            this.rbSqlAuth.Values.Text = "SQL Server Authentication";
            // 
            // rbWindowsAuth
            // 
            this.rbWindowsAuth.Location = new System.Drawing.Point(33, 79);
            this.rbWindowsAuth.Name = "rbWindowsAuth";
            this.rbWindowsAuth.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.rbWindowsAuth.Size = new System.Drawing.Size(156, 20);
            this.rbWindowsAuth.TabIndex = 2;
            this.rbWindowsAuth.Values.Text = "Windows Authentication";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(63, 38);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonLabel1.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Servidor";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UIConexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 324);
            this.Controls.Add(this.kryptonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(408, 362);
            this.Name = "UIConexao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexão com o banco de dados";
            this.Load += new System.EventHandler(this.UIConexao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxServidor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbxDatabase;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSenha;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUsuario;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbSqlAuth;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbWindowsAuth;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTestarCon;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbxServidor;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

