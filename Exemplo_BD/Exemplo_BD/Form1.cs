using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exemplo_BD
{
    public partial class Form1 : Form
    {
        ClsAluno objAluno = new ClsAluno();

        public Form1()
        {
            InitializeComponent();
        }

        void RecuperarDados()
        {
            try
            {
                objAluno.Codigo = int.Parse(txtCodigo.Text);
                objAluno.Nome = txtNome.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha os campos corretamente!");
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            RecuperarDados();
            objAluno.Incluir();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = objAluno.Consultar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objAluno.Codigo = int.Parse(txtCodigo.Text);

            var tblDados = objAluno.Pesquisar();
            txtNome.Text = tblDados.Rows[0]["Nome"].ToString();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            RecuperarDados();
            objAluno.Alterar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            objAluno.Codigo = int.Parse(txtCodigo.Text);
            objAluno.Excluir();
        }
    }
}
