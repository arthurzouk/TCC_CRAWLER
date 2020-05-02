namespace CALLPLUS_PA
{
    partial class frmInputClaroMigracaoWM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputClaroMigracaoWM));
            this.tsMenuClaro = new System.Windows.Forms.ToolStrip();
            this.btnIniciar = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgStatus = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.chkCrivado = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.lblUltimaAcao = new System.Windows.Forms.Label();
            this.wbVisualizacao = new AxSHDocVw.AxWebBrowser();
            this.labUrl = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tsMenuClaro.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wbVisualizacao)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenuClaro
            // 
            this.tsMenuClaro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIniciar});
            this.tsMenuClaro.Location = new System.Drawing.Point(0, 0);
            this.tsMenuClaro.Name = "tsMenuClaro";
            this.tsMenuClaro.Size = new System.Drawing.Size(1065, 25);
            this.tsMenuClaro.TabIndex = 11;
            this.tsMenuClaro.Text = "ToolStrip";
            // 
            // btnIniciar
            // 
            this.btnIniciar.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(56, 22);
            this.btnIniciar.Text = "&Executar";
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.lblCount,
            this.toolStripStatusLabel1,
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 470);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1065, 22);
            this.statusStrip.TabIndex = 37;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(173, 17);
            this.toolStripStatusLabel.Text = "Número de registros realizados:";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(14, 17);
            this.lblCount.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // dgStatus
            // 
            this.dgStatus.AllowUserToAddRows = false;
            this.dgStatus.AllowUserToDeleteRows = false;
            this.dgStatus.AllowUserToResizeRows = false;
            this.dgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStatus.Location = new System.Drawing.Point(15, 260);
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.RowHeadersVisible = false;
            this.dgStatus.Size = new System.Drawing.Size(253, 198);
            this.dgStatus.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Status da Operação";
            // 
            // chkCrivado
            // 
            this.chkCrivado.AutoSize = true;
            this.chkCrivado.Checked = true;
            this.chkCrivado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCrivado.Location = new System.Drawing.Point(15, 44);
            this.chkCrivado.Name = "chkCrivado";
            this.chkCrivado.Size = new System.Drawing.Size(112, 17);
            this.chkCrivado.TabIndex = 42;
            this.chkCrivado.Text = "Somente Crivadas";
            this.chkCrivado.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(12, 126);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(63, 13);
            this.lblDataInicio.TabIndex = 43;
            this.lblDataInicio.Text = "Data Início:";
            // 
            // lblUltimaAcao
            // 
            this.lblUltimaAcao.AutoSize = true;
            this.lblUltimaAcao.Location = new System.Drawing.Point(12, 151);
            this.lblUltimaAcao.Name = "lblUltimaAcao";
            this.lblUltimaAcao.Size = new System.Drawing.Size(67, 13);
            this.lblUltimaAcao.TabIndex = 44;
            this.lblUltimaAcao.Text = "Última Ação:";
            // 
            // wbVisualizacao
            // 
            this.wbVisualizacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbVisualizacao.Enabled = true;
            this.wbVisualizacao.Location = new System.Drawing.Point(274, 42);
            this.wbVisualizacao.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wbVisualizacao.OcxState")));
            this.wbVisualizacao.Size = new System.Drawing.Size(779, 416);
            this.wbVisualizacao.TabIndex = 41;
            this.wbVisualizacao.NewWindow3 += new AxSHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(this.wbVisualizacao_NewWindow3);
            // 
            // labUrl
            // 
            this.labUrl.AutoSize = true;
            this.labUrl.Location = new System.Drawing.Point(397, 9);
            this.labUrl.Name = "labUrl";
            this.labUrl.Size = new System.Drawing.Size(0, 13);
            this.labUrl.TabIndex = 55;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(12, 174);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(64, 13);
            this.lblProduto.TabIndex = 56;
            this.lblProduto.Text = "PRODUTO:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(12, 197);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(48, 13);
            this.lblMarca.TabIndex = 57;
            this.lblMarca.Text = "MARCA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "CARREFOUR - Consulta de Produto";
            // 
            // frmInputClaroMigracaoWM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 492);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.labUrl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.lblUltimaAcao);
            this.Controls.Add(this.lblDataInicio);
            this.Controls.Add(this.chkCrivado);
            this.Controls.Add(this.wbVisualizacao);
            this.Controls.Add(this.dgStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tsMenuClaro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInputClaroMigracaoWM";
            this.Text = "TCC_CRAWLER";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInputClaroMigracaoWM_FormClosing);
            this.Load += new System.EventHandler(this.frmInputClaroMigracaoWM_Load);
            this.tsMenuClaro.ResumeLayout(false);
            this.tsMenuClaro.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wbVisualizacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuClaro;
        private System.Windows.Forms.ToolStripButton btnIniciar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.DataGridView dgStatus;
        private System.Windows.Forms.Label label5;
        private AxSHDocVw.AxWebBrowser wbVisualizacao;
        private System.Windows.Forms.CheckBox chkCrivado;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.Label lblUltimaAcao;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label labUrl;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label label2;
    }
}