namespace UIWindows
{
    partial class UIPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.geradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storedProceduresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.códigosCSharpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mudarAConexãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeMódulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geradorToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(593, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // geradorToolStripMenuItem
            // 
            this.geradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storedProceduresToolStripMenuItem,
            this.códigosCSharpToolStripMenuItem});
            this.geradorToolStripMenuItem.Name = "geradorToolStripMenuItem";
            this.geradorToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.geradorToolStripMenuItem.Text = "Gerador";
            // 
            // storedProceduresToolStripMenuItem
            // 
            this.storedProceduresToolStripMenuItem.Name = "storedProceduresToolStripMenuItem";
            this.storedProceduresToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.storedProceduresToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.storedProceduresToolStripMenuItem.Text = "Códigos SQL";
            this.storedProceduresToolStripMenuItem.Click += new System.EventHandler(this.storedProceduresToolStripMenuItem_Click);
            // 
            // códigosCSharpToolStripMenuItem
            // 
            this.códigosCSharpToolStripMenuItem.Name = "códigosCSharpToolStripMenuItem";
            this.códigosCSharpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.códigosCSharpToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.códigosCSharpToolStripMenuItem.Text = "Códigos CSharp";
            this.códigosCSharpToolStripMenuItem.Click += new System.EventHandler(this.códigosCSharpToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvarScriptsToolStripMenuItem});
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // salvarScriptsToolStripMenuItem
            // 
            this.salvarScriptsToolStripMenuItem.Name = "salvarScriptsToolStripMenuItem";
            this.salvarScriptsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salvarScriptsToolStripMenuItem.Text = "Salvar scripts";
            this.salvarScriptsToolStripMenuItem.Click += new System.EventHandler(this.salvarScriptsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 346);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(593, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mudarAConexãoToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(62, 20);
            this.toolStripDropDownButton1.Text = "HLPSRV";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // mudarAConexãoToolStripMenuItem
            // 
            this.mudarAConexãoToolStripMenuItem.Name = "mudarAConexãoToolStripMenuItem";
            this.mudarAConexãoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.mudarAConexãoToolStripMenuItem.Text = "Mudar a Conexão";
            this.mudarAConexãoToolStripMenuItem.Click += new System.EventHandler(this.mudarAConexãoToolStripMenuItem_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeMódulosToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // cadastroDeMódulosToolStripMenuItem
            // 
            this.cadastroDeMódulosToolStripMenuItem.Name = "cadastroDeMódulosToolStripMenuItem";
            this.cadastroDeMódulosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.cadastroDeMódulosToolStripMenuItem.Text = "Cadastro de Módulos";
            this.cadastroDeMódulosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeMódulosToolStripMenuItem_Click);
            // 
            // UIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 368);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UIPrincipal";
            this.Text = "Gerador de códigos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem geradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storedProceduresToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mudarAConexãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem códigosCSharpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarScriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeMódulosToolStripMenuItem;
    }
}