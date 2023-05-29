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

        public bool FetchData()
        {
            try
            {
                objProduto.Codigo = int.Parse(txtCodigo.Text);
                objProduto.Nome = txtNome.Text;
                objProduto.PrecoUnit = double.Parse(txtPrecoUnit.Text.Replace(".", ",").Trim());
                return true;
            }
            catch (Exception)
            { 
                MessageBox.Show("Preencha os campos corretamente!");
                return false;
            }
                  
        }

        private void FormatGrid()
        {
            #region Formatação para o Cabeçalho do GRID

            // CABECALHO 

            //alinhamento centralizado
            dgvDados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDados.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12); // fonte
            dgvDados.ColumnHeadersDefaultCellStyle.BackColor = Color.Red; // cor de fundo
            dgvDados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;// cor da letra

            dgvDados.EnableHeadersVisualStyles = false; // desabilita o visual padrao do grid



            #endregion

            #region Formatação demais células

            dgvDados.DefaultCellStyle.Font = new Font("Tahoma", 12); // fonte
            dgvDados.DefaultCellStyle.ForeColor = Color.Red;// cor letra
            dgvDados.DefaultCellStyle.SelectionForeColor = Color.White; // cor da letra qdo linha selecionada
            dgvDados.DefaultCellStyle.SelectionBackColor = Color.DarkBlue; // cor de fundo qdo linha selecionada

            #endregion
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (FetchData())
            {
                objProduto.Incluir();
            }
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = objProduto.Consultar();
            FormatGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (FetchData())
            {
                objProduto.Alterar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                objProduto.Codigo = int.Parse(txtCodigo.Text);
                objProduto.Excluir();
                txtNome.Clear();
                txtCodigo.Clear();
                txtPrecoUnit.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha os campos corretamente!");
            }
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                FormatGrid();
                objProduto.Codigo = int.Parse(txtCodigo.Text);
                dgvDados.DataSource = objProduto.PesquisarCod();
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha os campos corretamente!");
            }
                
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            objProduto.Nome = txtNome.Text;
            dgvDados.DataSource = objProduto.PesquisarNome();
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = $"{dgvDados.CurrentRow.Cells[0].Value}";
            txtNome.Text = $"{dgvDados.CurrentRow.Cells[1].Value}";
            txtPrecoUnit.Text = $"{dgvDados.CurrentRow.Cells[2].Value}";
        }
    }
}
