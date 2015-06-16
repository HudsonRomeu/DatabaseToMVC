namespace DatabaseToMVC
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.grbConexao = new System.Windows.Forms.GroupBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.cbxBancoDados = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServidor = new CustomTextBox.CustomTextBox();
            this.imgLista = new System.Windows.Forms.ImageList(this.components);
            this.sfdDiretorio = new System.Windows.Forms.SaveFileDialog();
            this.tbcOpcoes = new System.Windows.Forms.TabControl();
            this.tbpDadosBanco = new System.Windows.Forms.TabPage();
            this.dgvTabelas = new System.Windows.Forms.DataGridView();
            this.tblSelecionada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tblNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOpcoesTabelas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmMarcarTabelas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarcarViews = new System.Windows.Forms.ToolStripMenuItem();
            this.tbpOpcoesExportacao = new System.Windows.Forms.TabPage();
            this.txtDiretorio = new System.Windows.Forms.TextBox();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.grbOpcoesExportacao = new System.Windows.Forms.GroupBox();
            this.chkRemoverDeclaracaoView = new System.Windows.Forms.CheckBox();
            this.chkExportarControles = new System.Windows.Forms.CheckBox();
            this.chkExportarModelos = new System.Windows.Forms.CheckBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDiretorio = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbpLogs = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.chkHyperLib = new System.Windows.Forms.CheckBox();
            this.grbConexao.SuspendLayout();
            this.tbcOpcoes.SuspendLayout();
            this.tbpDadosBanco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabelas)).BeginInit();
            this.cmsOpcoesTabelas.SuspendLayout();
            this.tbpOpcoesExportacao.SuspendLayout();
            this.grbOpcoesExportacao.SuspendLayout();
            this.tbpLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbConexao
            // 
            this.grbConexao.Controls.Add(this.txtSenha);
            this.grbConexao.Controls.Add(this.txtUsuario);
            this.grbConexao.Controls.Add(this.cbxBancoDados);
            this.grbConexao.Controls.Add(this.label5);
            this.grbConexao.Controls.Add(this.btnConectar);
            this.grbConexao.Controls.Add(this.label3);
            this.grbConexao.Controls.Add(this.label2);
            this.grbConexao.Controls.Add(this.label1);
            this.grbConexao.Controls.Add(this.txtServidor);
            this.grbConexao.Location = new System.Drawing.Point(12, 12);
            this.grbConexao.Name = "grbConexao";
            this.grbConexao.Size = new System.Drawing.Size(534, 106);
            this.grbConexao.TabIndex = 0;
            this.grbConexao.TabStop = false;
            this.grbConexao.Text = "Dados da Conexão";
            // 
            // txtSenha
            // 
            this.txtSenha.ForeColor = System.Drawing.Color.Blue;
            this.txtSenha.Location = new System.Drawing.Point(283, 48);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(140, 20);
            this.txtSenha.TabIndex = 10;
            this.txtSenha.Text = "master@123@@";
            // 
            // txtUsuario
            // 
            this.txtUsuario.ForeColor = System.Drawing.Color.Blue;
            this.txtUsuario.Location = new System.Drawing.Point(74, 48);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(156, 20);
            this.txtUsuario.TabIndex = 9;
            this.txtUsuario.Text = "sa";
            // 
            // cbxBancoDados
            // 
            this.cbxBancoDados.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxBancoDados.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxBancoDados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBancoDados.FormattingEnabled = true;
            this.cbxBancoDados.Location = new System.Drawing.Point(74, 73);
            this.cbxBancoDados.Name = "cbxBancoDados";
            this.cbxBancoDados.Size = new System.Drawing.Size(444, 21);
            this.cbxBancoDados.TabIndex = 8;
            this.cbxBancoDados.SelectedIndexChanged += new System.EventHandler(this.cbxBancoDados_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Banco:";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(429, 21);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(89, 46);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Senha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor:";
            // 
            // txtServidor
            // 
            this.txtServidor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServidor.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtServidor.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtServidor.Location = new System.Drawing.Point(74, 21);
            this.txtServidor.MetodoEntradaCasasDecimais = 0;
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(349, 21);
            this.txtServidor.TabIndex = 0;
            this.txtServidor.Text = ".\\SQLEXPRESS";
            // 
            // imgLista
            // 
            this.imgLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLista.ImageStream")));
            this.imgLista.TransparentColor = System.Drawing.Color.Magenta;
            this.imgLista.Images.SetKeyName(0, "open_project_16_h.gif");
            // 
            // sfdDiretorio
            // 
            this.sfdDiretorio.DefaultExt = "cs";
            this.sfdDiretorio.Filter = "*.cs|CSharp (*.cs)";
            // 
            // tbcOpcoes
            // 
            this.tbcOpcoes.Controls.Add(this.tbpDadosBanco);
            this.tbcOpcoes.Controls.Add(this.tbpOpcoesExportacao);
            this.tbcOpcoes.Controls.Add(this.tbpLogs);
            this.tbcOpcoes.Enabled = false;
            this.tbcOpcoes.Location = new System.Drawing.Point(12, 124);
            this.tbcOpcoes.Name = "tbcOpcoes";
            this.tbcOpcoes.SelectedIndex = 0;
            this.tbcOpcoes.Size = new System.Drawing.Size(534, 310);
            this.tbcOpcoes.TabIndex = 8;
            this.tbcOpcoes.SelectedIndexChanged += new System.EventHandler(this.tabOpcoes_SelectedIndexChanged);
            // 
            // tbpDadosBanco
            // 
            this.tbpDadosBanco.BackColor = System.Drawing.SystemColors.Control;
            this.tbpDadosBanco.Controls.Add(this.dgvTabelas);
            this.tbpDadosBanco.Location = new System.Drawing.Point(4, 22);
            this.tbpDadosBanco.Name = "tbpDadosBanco";
            this.tbpDadosBanco.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDadosBanco.Size = new System.Drawing.Size(526, 284);
            this.tbpDadosBanco.TabIndex = 0;
            this.tbpDadosBanco.Text = "Tabelas e Visualizações";
            // 
            // dgvTabelas
            // 
            this.dgvTabelas.AllowUserToAddRows = false;
            this.dgvTabelas.AllowUserToDeleteRows = false;
            this.dgvTabelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tblSelecionada,
            this.tblNome,
            this.tblTipo,
            this.tblCatalogo});
            this.dgvTabelas.ContextMenuStrip = this.cmsOpcoesTabelas;
            this.dgvTabelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTabelas.Location = new System.Drawing.Point(3, 3);
            this.dgvTabelas.Name = "dgvTabelas";
            this.dgvTabelas.Size = new System.Drawing.Size(520, 278);
            this.dgvTabelas.TabIndex = 19;
            // 
            // tblSelecionada
            // 
            this.tblSelecionada.DataPropertyName = "tblSelecionada";
            this.tblSelecionada.Frozen = true;
            this.tblSelecionada.HeaderText = " ";
            this.tblSelecionada.Name = "tblSelecionada";
            this.tblSelecionada.Width = 30;
            // 
            // tblNome
            // 
            this.tblNome.DataPropertyName = "tblNome";
            this.tblNome.Frozen = true;
            this.tblNome.HeaderText = "Tabela\\View";
            this.tblNome.Name = "tblNome";
            this.tblNome.ReadOnly = true;
            this.tblNome.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tblNome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tblNome.Width = 200;
            // 
            // tblTipo
            // 
            this.tblTipo.DataPropertyName = "tblTipo";
            this.tblTipo.HeaderText = "Tipo";
            this.tblTipo.Name = "tblTipo";
            this.tblTipo.ReadOnly = true;
            this.tblTipo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tblTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tblCatalogo
            // 
            this.tblCatalogo.DataPropertyName = "tblCatalogo";
            this.tblCatalogo.HeaderText = "Catálogo";
            this.tblCatalogo.Name = "tblCatalogo";
            this.tblCatalogo.ReadOnly = true;
            this.tblCatalogo.Width = 130;
            // 
            // cmsOpcoesTabelas
            // 
            this.cmsOpcoesTabelas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMarcarTabelas,
            this.tsmMarcarViews});
            this.cmsOpcoesTabelas.Name = "cmsOpcoesTabelas";
            this.cmsOpcoesTabelas.Size = new System.Drawing.Size(216, 48);
            // 
            // tsmMarcarTabelas
            // 
            this.tsmMarcarTabelas.Checked = true;
            this.tsmMarcarTabelas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmMarcarTabelas.Name = "tsmMarcarTabelas";
            this.tsmMarcarTabelas.Size = new System.Drawing.Size(215, 22);
            this.tsmMarcarTabelas.Text = "Marcar\\Desmarcar Tabelas";
            this.tsmMarcarTabelas.Click += new System.EventHandler(this.tsmMarcarTabelas_Click);
            // 
            // tsmMarcarViews
            // 
            this.tsmMarcarViews.Checked = true;
            this.tsmMarcarViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmMarcarViews.Name = "tsmMarcarViews";
            this.tsmMarcarViews.Size = new System.Drawing.Size(215, 22);
            this.tsmMarcarViews.Text = "Marcar\\Desmarcar Views";
            this.tsmMarcarViews.Click += new System.EventHandler(this.tsmMarcarViews_Click);
            // 
            // tbpOpcoesExportacao
            // 
            this.tbpOpcoesExportacao.BackColor = System.Drawing.SystemColors.Control;
            this.tbpOpcoesExportacao.Controls.Add(this.txtDiretorio);
            this.tbpOpcoesExportacao.Controls.Add(this.txtNamespace);
            this.tbpOpcoesExportacao.Controls.Add(this.grbOpcoesExportacao);
            this.tbpOpcoesExportacao.Controls.Add(this.btnExportar);
            this.tbpOpcoesExportacao.Controls.Add(this.label6);
            this.tbpOpcoesExportacao.Controls.Add(this.btnDiretorio);
            this.tbpOpcoesExportacao.Controls.Add(this.label4);
            this.tbpOpcoesExportacao.Location = new System.Drawing.Point(4, 22);
            this.tbpOpcoesExportacao.Name = "tbpOpcoesExportacao";
            this.tbpOpcoesExportacao.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOpcoesExportacao.Size = new System.Drawing.Size(526, 284);
            this.tbpOpcoesExportacao.TabIndex = 1;
            this.tbpOpcoesExportacao.Text = "Opções de Exportação";
            this.tbpOpcoesExportacao.Click += new System.EventHandler(this.pagOpcoesExportacao_Click);
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.BackColor = System.Drawing.Color.White;
            this.txtDiretorio.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDiretorio.ForeColor = System.Drawing.Color.Blue;
            this.txtDiretorio.Location = new System.Drawing.Point(82, 15);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.Size = new System.Drawing.Size(401, 21);
            this.txtDiretorio.TabIndex = 27;
            this.txtDiretorio.Text = "C:\\";
            // 
            // txtNamespace
            // 
            this.txtNamespace.BackColor = System.Drawing.Color.White;
            this.txtNamespace.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtNamespace.ForeColor = System.Drawing.Color.Blue;
            this.txtNamespace.Location = new System.Drawing.Point(82, 41);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(401, 21);
            this.txtNamespace.TabIndex = 26;
            this.txtNamespace.Text = "DatabaseToMVC";
            this.txtNamespace.Enter += new System.EventHandler(this.txtNamespace_Enter);
            this.txtNamespace.Leave += new System.EventHandler(this.txtNamespace_Leave);
            // 
            // grbOpcoesExportacao
            // 
            this.grbOpcoesExportacao.Controls.Add(this.chkHyperLib);
            this.grbOpcoesExportacao.Controls.Add(this.chkRemoverDeclaracaoView);
            this.grbOpcoesExportacao.Controls.Add(this.chkExportarControles);
            this.grbOpcoesExportacao.Controls.Add(this.chkExportarModelos);
            this.grbOpcoesExportacao.Location = new System.Drawing.Point(16, 67);
            this.grbOpcoesExportacao.Name = "grbOpcoesExportacao";
            this.grbOpcoesExportacao.Size = new System.Drawing.Size(498, 73);
            this.grbOpcoesExportacao.TabIndex = 25;
            this.grbOpcoesExportacao.TabStop = false;
            this.grbOpcoesExportacao.Text = "Opções de exportação";
            // 
            // chkRemoverDeclaracaoView
            // 
            this.chkRemoverDeclaracaoView.AutoSize = true;
            this.chkRemoverDeclaracaoView.Checked = true;
            this.chkRemoverDeclaracaoView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoverDeclaracaoView.Location = new System.Drawing.Point(13, 42);
            this.chkRemoverDeclaracaoView.Name = "chkRemoverDeclaracaoView";
            this.chkRemoverDeclaracaoView.Size = new System.Drawing.Size(258, 17);
            this.chkRemoverDeclaracaoView.TabIndex = 26;
            this.chkRemoverDeclaracaoView.Text = "Remover o texto \"view\" da declaração da classe";
            this.chkRemoverDeclaracaoView.UseVisualStyleBackColor = true;
            // 
            // chkExportarControles
            // 
            this.chkExportarControles.AutoSize = true;
            this.chkExportarControles.Checked = true;
            this.chkExportarControles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportarControles.Location = new System.Drawing.Point(85, 19);
            this.chkExportarControles.Name = "chkExportarControles";
            this.chkExportarControles.Size = new System.Drawing.Size(70, 17);
            this.chkExportarControles.TabIndex = 25;
            this.chkExportarControles.Text = "Controles";
            this.chkExportarControles.UseVisualStyleBackColor = true;
            // 
            // chkExportarModelos
            // 
            this.chkExportarModelos.AutoSize = true;
            this.chkExportarModelos.Checked = true;
            this.chkExportarModelos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportarModelos.Location = new System.Drawing.Point(13, 19);
            this.chkExportarModelos.Name = "chkExportarModelos";
            this.chkExportarModelos.Size = new System.Drawing.Size(66, 17);
            this.chkExportarModelos.TabIndex = 24;
            this.chkExportarModelos.Text = "Modelos";
            this.chkExportarModelos.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(374, 255);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(140, 23);
            this.btnExportar.TabIndex = 17;
            this.btnExportar.Text = "Exportar classes";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Namespace:";
            // 
            // btnDiretorio
            // 
            this.btnDiretorio.ImageIndex = 0;
            this.btnDiretorio.ImageList = this.imgLista;
            this.btnDiretorio.Location = new System.Drawing.Point(487, 13);
            this.btnDiretorio.Name = "btnDiretorio";
            this.btnDiretorio.Size = new System.Drawing.Size(27, 23);
            this.btnDiretorio.TabIndex = 21;
            this.btnDiretorio.UseVisualStyleBackColor = true;
            this.btnDiretorio.Click += new System.EventHandler(this.btnDiretorio_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Destino:";
            // 
            // tbpLogs
            // 
            this.tbpLogs.Controls.Add(this.rtbLog);
            this.tbpLogs.Location = new System.Drawing.Point(4, 22);
            this.tbpLogs.Name = "tbpLogs";
            this.tbpLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLogs.Size = new System.Drawing.Size(526, 284);
            this.tbpLogs.TabIndex = 2;
            this.tbpLogs.Text = "Log de exportação";
            this.tbpLogs.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(3, 3);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(520, 278);
            this.rtbLog.TabIndex = 27;
            this.rtbLog.Text = "";
            // 
            // chkHyperLib
            // 
            this.chkHyperLib.AutoSize = true;
            this.chkHyperLib.Location = new System.Drawing.Point(161, 19);
            this.chkHyperLib.Name = "chkHyperLib";
            this.chkHyperLib.Size = new System.Drawing.Size(325, 17);
            this.chkHyperLib.TabIndex = 27;
            this.chkHyperLib.Text = "Utilizar o padrão HyperLib (lib encontrada na pasta References)";
            this.chkHyperLib.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 444);
            this.Controls.Add(this.tbcOpcoes);
            this.Controls.Add(this.grbConexao);
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversor de tabelas para classes (Padrao MVC)";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.grbConexao.ResumeLayout(false);
            this.grbConexao.PerformLayout();
            this.tbcOpcoes.ResumeLayout(false);
            this.tbpDadosBanco.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabelas)).EndInit();
            this.cmsOpcoesTabelas.ResumeLayout(false);
            this.tbpOpcoesExportacao.ResumeLayout(false);
            this.tbpOpcoesExportacao.PerformLayout();
            this.grbOpcoesExportacao.ResumeLayout(false);
            this.grbOpcoesExportacao.PerformLayout();
            this.tbpLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbConexao;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomTextBox.CustomTextBox txtServidor;
        private System.Windows.Forms.ImageList imgLista;
        private System.Windows.Forms.ComboBox cbxBancoDados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SaveFileDialog sfdDiretorio;
        private System.Windows.Forms.TabControl tbcOpcoes;
        private System.Windows.Forms.TabPage tbpDadosBanco;
        private System.Windows.Forms.DataGridView dgvTabelas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tblSelecionada;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblCatalogo;
        private System.Windows.Forms.TabPage tbpOpcoesExportacao;
        private System.Windows.Forms.Button btnDiretorio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TabPage tbpLogs;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox grbOpcoesExportacao;
        private System.Windows.Forms.CheckBox chkExportarControles;
        private System.Windows.Forms.CheckBox chkExportarModelos;
        private System.Windows.Forms.ContextMenuStrip cmsOpcoesTabelas;
        private System.Windows.Forms.ToolStripMenuItem tsmMarcarTabelas;
        private System.Windows.Forms.ToolStripMenuItem tsmMarcarViews;
        private System.Windows.Forms.CheckBox chkRemoverDeclaracaoView;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtDiretorio;
        private System.Windows.Forms.CheckBox chkHyperLib;
    }
}

