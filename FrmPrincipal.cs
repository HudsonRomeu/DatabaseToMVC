using DatabaseToMVC.Controle;
using DatabaseToMVC.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseToMVC
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            dgvTabelas.AutoGenerateColumns = false;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            Conectar();
        }

        private void Conectar()
        {
            mdoBancoDados.Servidor = txtServidor.Text;
            mdoBancoDados.Usuario = txtUsuario.Text;
            mdoBancoDados.Senha = txtSenha.Text;

            var dsBancoDados = new ctrBancoDados().ListarBancoDados();
            cbxBancoDados.DataSource = dsBancoDados;
        }

        private void CarregarTabelas()
        {
            var dsTabelas = new ctrTabelas().ListarTabelas();
            dgvTabelas.DataSource = dsTabelas;
        }

        private void cbxBancoDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            mdoBancoDados.BancoDados = cbxBancoDados.Text;
            tsmMarcarTabelas.Checked = true;
            tsmMarcarViews.Checked = true;

            CarregarTabelas();
            tbcOpcoes.Enabled = true;
        }

        private void txtDiretorio_Enter(object sender, EventArgs e)
        {
            txtDiretorio.SelectAll();
        }

        private void btnDiretorio_Click(object sender, EventArgs e)
        {
            if (sfdDiretorio.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            txtDiretorio.Text = new FileInfo(sfdDiretorio.FileName).DirectoryName;
        }

        private void tabOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pagOpcoesExportacao_Click(object sender, EventArgs e)
        {

        }

        private void btnAvancarVoltar_Click(object sender, EventArgs e)
        {
            switch (tbcOpcoes.SelectedIndex)
            {
                case 0:
                    {
                        tbcOpcoes.SelectedIndex = 1;
                        break;
                    }
                case 1:
                    {
                        tbcOpcoes.SelectedIndex = 0;
                        break;
                    }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            CriarDiretorios();
            
            mdoBancoDados.Namespace = txtNamespace.Text;
            mdoBancoDados.DiretorioDestino = txtDiretorio.Text;
            mdoBancoDados.ExportarModelos = chkExportarModelos.Checked;
            mdoBancoDados.ExportarControles = chkExportarControles.Checked;
            mdoBancoDados.RemoverDeclaracaoView = chkRemoverDeclaracaoView.Checked;
            mdoBancoDados.UtilizarPadraoHyperLib = chkHyperLib.Checked;


            var objBancoDados = new ctrBancoDados();
            rtbLog.Clear();
            tbcOpcoes.SelectedTab = tbpLogs;
            objBancoDados.FollowUp += objBancoDados_FollowUp;
            objBancoDados.IniciarExportacao((List<mdoTabelas>)dgvTabelas.DataSource);
        }

        private void CriarDiretorios()
        {
            if (!Directory.Exists(txtDiretorio.Text))
                Directory.CreateDirectory(txtDiretorio.Text);

            if (!Directory.Exists(txtDiretorio.Text + "Modelos"))
                Directory.CreateDirectory(txtDiretorio.Text + "Modelos");

            if (!Directory.Exists(txtDiretorio.Text + "Controles"))
                Directory.CreateDirectory(txtDiretorio.Text + "Controles");
        }

        void objBancoDados_FollowUp(string sFollowUp)
        {
            rtbLog.AppendText(sFollowUp + "\u2028");
        }

        private void tsmMarcarTabelas_Click(object sender, EventArgs e)
        {
            MarcarDesmarcar(ctrTabelas.enumTipoTabela.Tabela);
        }

        private void MarcarDesmarcar(ctrTabelas.enumTipoTabela eTipoTabela)
        {
            var sTipoTabela = eTipoTabela == ctrTabelas.enumTipoTabela.Tabela ? "BASE TABLE" : "VIEW";
            var listaTabelas = (List<mdoTabelas>)dgvTabelas.DataSource;

            var tsm = eTipoTabela == ctrTabelas.enumTipoTabela.Tabela ? tsmMarcarTabelas : tsmMarcarViews;
            tsm.Checked = !tsm.Checked;

            foreach (var objTabela in listaTabelas)
            {
                if (!objTabela.tblTipo.Equals(sTipoTabela))
                    continue;

                objTabela.tblSelecionada = tsm.Checked;
            }

            dgvTabelas.Refresh();
        }

        private void tsmMarcarViews_Click(object sender, EventArgs e)
        {
            MarcarDesmarcar(ctrTabelas.enumTipoTabela.View);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Inicializar();            
        }

        private void Inicializar()
        {
            ctrBancoDados.InstanciarConexao();
            txtServidor.Text = mdoBancoDados.Servidor;
            txtUsuario.Text = mdoBancoDados.Usuario;
            txtSenha.Text = mdoBancoDados.Senha;

            txtDiretorio.Text = AppDomain.CurrentDomain.BaseDirectory + "Output\\";
            CriarDiretorios();
        }

        private void txtNamespace_Enter(object sender, EventArgs e)
        {
            txtNamespace.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void txtNamespace_Leave(object sender, EventArgs e)
        {
            txtNamespace.BackColor = Color.White;
        }
    }
}
