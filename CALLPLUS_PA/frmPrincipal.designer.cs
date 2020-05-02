namespace CALLPLUS_PA
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuIniciar = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.migraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aquisiçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExibir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBarra = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpcao = new System.Windows.Forms.ToolStripMenuItem();
            this.loginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJanela = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascata = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFecharTudo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAnaliseDeCredito = new System.Windows.Forms.ToolStripButton();
            this.btnClaroOnLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClaroMigracao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClaroAquisicao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAjuda = new System.Windows.Forms.ToolStripButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIniciar,
            this.mnuExibir,
            this.mnuConfig,
            this.mnuJanela,
            this.mnuAjuda});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.mnuJanela;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.Visible = false;
            // 
            // mnuIniciar
            // 
            this.mnuIniciar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator4,
            this.migraçãoToolStripMenuItem,
            this.toolStripSeparator5,
            this.aquisiçãoToolStripMenuItem});
            this.mnuIniciar.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.mnuIniciar.Name = "mnuIniciar";
            this.mnuIniciar.Size = new System.Drawing.Size(51, 20);
            this.mnuIniciar.Text = "&Iniciar";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.newToolStripMenuItem.Text = "&On Line";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.AbrirInstanciaClaroOnline);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(123, 6);
            // 
            // migraçãoToolStripMenuItem
            // 
            this.migraçãoToolStripMenuItem.Name = "migraçãoToolStripMenuItem";
            this.migraçãoToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.migraçãoToolStripMenuItem.Text = "&Migração";
            this.migraçãoToolStripMenuItem.Click += new System.EventHandler(this.AbrirInstanciaClaroMigracao);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(123, 6);
            // 
            // aquisiçãoToolStripMenuItem
            // 
            this.aquisiçãoToolStripMenuItem.Name = "aquisiçãoToolStripMenuItem";
            this.aquisiçãoToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aquisiçãoToolStripMenuItem.Text = "&Aquisição";
            this.aquisiçãoToolStripMenuItem.Click += new System.EventHandler(this.AbrirInstanciaClaroAquisicao);
            // 
            // mnuExibir
            // 
            this.mnuExibir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBarra,
            this.mnuStatus});
            this.mnuExibir.Name = "mnuExibir";
            this.mnuExibir.Size = new System.Drawing.Size(48, 20);
            this.mnuExibir.Text = "E&xibir";
            // 
            // mnuBarra
            // 
            this.mnuBarra.Checked = true;
            this.mnuBarra.CheckOnClick = true;
            this.mnuBarra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuBarra.Name = "mnuBarra";
            this.mnuBarra.Size = new System.Drawing.Size(185, 22);
            this.mnuBarra.Text = "&Barra de Ferramentas";
            this.mnuBarra.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
            // 
            // mnuStatus
            // 
            this.mnuStatus.Checked = true;
            this.mnuStatus.CheckOnClick = true;
            this.mnuStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuStatus.Name = "mnuStatus";
            this.mnuStatus.Size = new System.Drawing.Size(185, 22);
            this.mnuStatus.Text = "Barra de &Status";
            this.mnuStatus.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // mnuConfig
            // 
            this.mnuConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpcao,
            this.loginsToolStripMenuItem,
            this.usuáriosToolStripMenuItem});
            this.mnuConfig.Name = "mnuConfig";
            this.mnuConfig.Size = new System.Drawing.Size(96, 20);
            this.mnuConfig.Text = "&Configurações";
            // 
            // mnuOpcao
            // 
            this.mnuOpcao.Name = "mnuOpcao";
            this.mnuOpcao.Size = new System.Drawing.Size(119, 22);
            this.mnuOpcao.Text = "&Opções";
            // 
            // loginsToolStripMenuItem
            // 
            this.loginsToolStripMenuItem.Name = "loginsToolStripMenuItem";
            this.loginsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.loginsToolStripMenuItem.Text = "Logins";
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            // 
            // mnuJanela
            // 
            this.mnuJanela.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascata,
            this.mnuVertical,
            this.mnuHorizontal,
            this.mnuFecharTudo});
            this.mnuJanela.Name = "mnuJanela";
            this.mnuJanela.Size = new System.Drawing.Size(51, 20);
            this.mnuJanela.Text = "&Janela";
            // 
            // mnuCascata
            // 
            this.mnuCascata.Name = "mnuCascata";
            this.mnuCascata.Size = new System.Drawing.Size(199, 22);
            this.mnuCascata.Text = "Exibir em &Cascata";
            this.mnuCascata.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // mnuVertical
            // 
            this.mnuVertical.Name = "mnuVertical";
            this.mnuVertical.Size = new System.Drawing.Size(199, 22);
            this.mnuVertical.Text = "Organizar na &Vertical";
            this.mnuVertical.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // mnuHorizontal
            // 
            this.mnuHorizontal.Name = "mnuHorizontal";
            this.mnuHorizontal.Size = new System.Drawing.Size(199, 22);
            this.mnuHorizontal.Text = "Organizar na &Horizontal";
            this.mnuHorizontal.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // mnuFecharTudo
            // 
            this.mnuFecharTudo.Name = "mnuFecharTudo";
            this.mnuFecharTudo.Size = new System.Drawing.Size(199, 22);
            this.mnuFecharTudo.Text = "Fechar &Tudo";
            this.mnuFecharTudo.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // mnuAjuda
            // 
            this.mnuAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indexToolStripMenuItem,
            this.toolStripSeparator8,
            this.mnuSobre});
            this.mnuAjuda.Name = "mnuAjuda";
            this.mnuAjuda.Size = new System.Drawing.Size(50, 20);
            this.mnuAjuda.Text = "&Ajuda";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.indexToolStripMenuItem.Text = "&Exibir Ajuda";
            this.indexToolStripMenuItem.Click += new System.EventHandler(this.ExibirBibliotecaDeAjuda);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuSobre
            // 
            this.mnuSobre.Name = "mnuSobre";
            this.mnuSobre.Size = new System.Drawing.Size(159, 22);
            this.mnuSobre.Text = "&Sobre o Callplus";
            this.mnuSobre.Click += new System.EventHandler(this.ExibirSobreSistema);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAnaliseDeCredito,
            this.btnClaroOnLine,
            this.toolStripSeparator1,
            this.btnClaroMigracao,
            this.toolStripSeparator2,
            this.btnClaroAquisicao,
            this.toolStripSeparator3,
            this.btnAjuda});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1028, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            this.toolStrip.Visible = false;
            // 
            // btnAnaliseDeCredito
            // 
            this.btnAnaliseDeCredito.Image = ((System.Drawing.Image)(resources.GetObject("btnAnaliseDeCredito.Image")));
            this.btnAnaliseDeCredito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnaliseDeCredito.Name = "btnAnaliseDeCredito";
            this.btnAnaliseDeCredito.Size = new System.Drawing.Size(145, 22);
            this.btnAnaliseDeCredito.Text = "Análise de Crédito WA";
            this.btnAnaliseDeCredito.Click += new System.EventHandler(this.btnAnaliseDeCredito_Click);
            // 
            // btnClaroOnLine
            // 
            this.btnClaroOnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnClaroOnLine.Image")));
            this.btnClaroOnLine.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnClaroOnLine.Name = "btnClaroOnLine";
            this.btnClaroOnLine.Size = new System.Drawing.Size(155, 22);
            this.btnClaroOnLine.Text = "Input de Vendas &On Line";
            this.btnClaroOnLine.Click += new System.EventHandler(this.AbrirInstanciaClaroOnline);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClaroMigracao
            // 
            this.btnClaroMigracao.Image = ((System.Drawing.Image)(resources.GetObject("btnClaroMigracao.Image")));
            this.btnClaroMigracao.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnClaroMigracao.Name = "btnClaroMigracao";
            this.btnClaroMigracao.Size = new System.Drawing.Size(164, 22);
            this.btnClaroMigracao.Text = "Input de Vendas &Migração";
            this.btnClaroMigracao.Click += new System.EventHandler(this.AbrirInstanciaClaroMigracao);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClaroAquisicao
            // 
            this.btnClaroAquisicao.Image = ((System.Drawing.Image)(resources.GetObject("btnClaroAquisicao.Image")));
            this.btnClaroAquisicao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClaroAquisicao.Name = "btnClaroAquisicao";
            this.btnClaroAquisicao.Size = new System.Drawing.Size(166, 22);
            this.btnClaroAquisicao.Text = "Input de Vendas &Aquisição";
            this.btnClaroAquisicao.Click += new System.EventHandler(this.AbrirInstanciaClaroAquisicao);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAjuda
            // 
            this.btnAjuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjuda.Image = ((System.Drawing.Image)(resources.GetObject("btnAjuda.Image")));
            this.btnAjuda.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnAjuda.Name = "btnAjuda";
            this.btnAjuda.Size = new System.Drawing.Size(23, 22);
            this.btnAjuda.Text = "Ajuda";
            this.btnAjuda.Click += new System.EventHandler(this.ExibirBibliotecaDeAjuda);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 453);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmPrincipal";
            this.Text = "TCC_CRAWLER";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mnuSobre;
        private System.Windows.Forms.ToolStripMenuItem mnuHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuIniciar;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExibir;
        private System.Windows.Forms.ToolStripMenuItem mnuBarra;
        private System.Windows.Forms.ToolStripMenuItem mnuStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuOpcao;
        private System.Windows.Forms.ToolStripMenuItem mnuJanela;
        private System.Windows.Forms.ToolStripMenuItem mnuCascata;
        private System.Windows.Forms.ToolStripMenuItem mnuVertical;
        private System.Windows.Forms.ToolStripMenuItem mnuFecharTudo;
        private System.Windows.Forms.ToolStripMenuItem mnuAjuda;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnClaroOnLine;
        private System.Windows.Forms.ToolStripButton btnClaroMigracao;
        private System.Windows.Forms.ToolStripButton btnAjuda;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem migraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aquisiçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnClaroAquisicao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem loginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton btnAnaliseDeCredito;
    }
}



