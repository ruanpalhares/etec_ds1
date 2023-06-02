using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoEmpresa
{
    public partial class Form1 : Form
    {
        ClsEmpresa objEmpresa = new ClsEmpresa();

        public bool recuperarDados()
        {
            try
            {
                objEmpresa.Id = int.Parse(txtCod.Text);
                objEmpresa.NomeDep = txtNome.Text;
                objEmpresa.SiglaDep = txtSigla.Text;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha corretamente os campos!");
                return false;
            }
            
        }

        public void resetData()
        {
            txtCod.Clear();
            txtNome.Clear();
            txtSigla.Clear();
            dgvDados.DataSource = objEmpresa.Consultar();
            txtCod.Focus();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (recuperarDados())
            {
                objEmpresa.Incluir();
                resetData();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = objEmpresa.Consultar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (recuperarDados())
            {
                objEmpresa.Alterar();
                resetData();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                objEmpresa.Id = int.Parse(txtCod.Text);
                objEmpresa.Excluir();
                resetData();
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha corretamente os campos!");
            }
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                objEmpresa.Id = int.Parse(txtCod.Text);
                dgvDados.DataSource = objEmpresa.PesquisarCod();
                txtNome.Text = $"{dgvDados.CurrentRow.Cells[1].Value}";
                txtSigla.Text = $"{dgvDados.CurrentRow.Cells[2].Value}";

            }
            catch (Exception)
            {
                MessageBox.Show("Preencha corretamente os campos!");
            }
            
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCod.Text = $"{dgvDados.CurrentRow.Cells[0].Value}";
            txtNome.Text = $"{dgvDados.CurrentRow.Cells[1].Value}";
            txtSigla.Text = $"{dgvDados.CurrentRow.Cells[2].Value}";
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            objEmpresa.NomeDep = txtNome.Text;
            dgvDados.DataSource = objEmpresa.PesquisarNome();
        }

        private void txtSigla_TextChanged(object sender, EventArgs e)
        {
            objEmpresa.SiglaDep = txtSigla.Text;
            dgvDados.DataSource = objEmpresa.PesquisarSigla();
        }
    }
}
