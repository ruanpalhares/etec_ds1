using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoAvaliativo_BD
{
    public partial class Form1 : Form
    {
        ClsProduto objProduto = new ClsProduto();

        #region Metodos

        public void FetchData()
        {
                objProduto.Codigo = int.Parse(txtCodigo.Text);
                objProduto.Nome = txtNome.Text;
                objProduto.PrecoUnit = double.Parse(txtPrecoUnit.Text);  
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FetchData();
            objProduto.Incluir();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = objProduto.Consultar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            FetchData();
            objProduto.Alterar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            objProduto.Codigo = int.Parse(txtCodigo.Text);
            objProduto.Excluir();
        }
    }
}
