using System;
using System.Net.Http;
using System.Windows.Forms;

namespace projetoEmpresa
{
    public partial class FrmFuncionario : Form
    {
        Funcionario objFuncionario = new Funcionario();

        public void MostrarDados() 
        {
            txtID_Func.Text = $"{dtFuncionario.CurrentRow.Cells["IDFUNC"].Value}";
            txtNome.Text = $"{dtFuncionario.CurrentRow.Cells["NOME"].Value}";
            txtCEP.Text = $"{dtFuncionario.CurrentRow.Cells["CEP"].Value}";
            txtCidade.Text = $"{dtFuncionario.CurrentRow.Cells["CIDADE"].Value}";
            txtComplemento.Text = $"{dtFuncionario.CurrentRow.Cells["COMPLEMENTO"].Value}";
            txtEndereco.Text = $"{dtFuncionario.CurrentRow.Cells["ENDERECO"].Value}";
            txtBairro.Text = $"{dtFuncionario.CurrentRow.Cells["BAIRRO"].Value}";
            txtNumero.Text = $"{dtFuncionario.CurrentRow.Cells["NUMERO"].Value}";
            txtSalario.Text = $"{dtFuncionario.CurrentRow.Cells["SALARIO"].Value}";
            txtUF.Text = $"{dtFuncionario.CurrentRow.Cells["UF"].Value}";
            cboDepartamento.Text = $"{dtFuncionario.CurrentRow.Cells["SIGLADEP"].Value}";
        }

        public void LimparDados() 
        {
            txtID_Func.Clear();
            txtNome.Clear();
            txtEndereco.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            txtCEP.Clear();
            txtUF.Clear();
            txtComplemento.Clear();
            txtSalario.Clear();
            txtNumero.Clear();
            cboDepartamento.SelectedIndex = -1;
            dtFuncionario.DataSource = null;

        }

        public bool RecuperarDados()
        {
            try
            {
                objFuncionario.Nome = txtNome.Text;
                objFuncionario.CEP = txtCEP.Text;
                objFuncionario.Endereco = txtEndereco.Text;
                objFuncionario.Complemento = txtComplemento.Text;
                objFuncionario.Numero = txtNumero.Text;
                objFuncionario.Bairro = txtBairro.Text;
                objFuncionario.Cidade = txtCidade.Text;
                objFuncionario.UF = txtUF.Text;
                objFuncionario.Salario = decimal.Parse(txtSalario.Text);
                objFuncionario.IdDep = int.Parse(cboDepartamento.SelectedValue.ToString());
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Preencha os campos corretamente");
                return false;
            }
            
        }

        public FrmFuncionario()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            objFuncionario.IdFunc = int.Parse(txtID_Func.Text);
            dtFuncionario.DataSource = objFuncionario.Pesquisar();
            MostrarDados();
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            cboDepartamento.DataSource = objFuncionario.ConsultarDepartamento();
            cboDepartamento.DisplayMember = "SIGLADEP";
            cboDepartamento.ValueMember = "IDDEP";
            
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            RecuperarDados();
            objFuncionario.Incluir();
            LimparDados();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dtFuncionario.DataSource = objFuncionario.Consultar();
        }

        private void dtFuncionario_DoubleClick(object sender, EventArgs e)
        {
            MostrarDados();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            RecuperarDados();
            objFuncionario.Alterar();
        }
    }
}
