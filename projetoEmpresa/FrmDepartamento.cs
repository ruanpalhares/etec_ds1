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
    public partial class FrmDep : Form
    {
        public FrmDep()
        {
            InitializeComponent();
        }

        Departamento objDep = new Departamento();
        private bool RecuperarDados()
        {
            try
            {
                objDep.IDDepartamento = int.Parse(txtID_Dep.Text);
                objDep.NomeDep = txtNomeDep.Text;
                objDep.SiglaDep = txtSiglaDep.Text;
                return true;
            }
            catch (FormatException) // erro de formato
            {
                MessageBox.Show("Preencha todos os campos corretamente!");
                return false;
            }
        }

        private void FormatarGrid()
        {
            #region Formatação para o Cabeçalho do GRID

            // CABECALHO 

            //alinhamento centralizado
            dtDepartamento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtDepartamento.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12); // fonte
            dtDepartamento.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue; // cor de fundo
            dtDepartamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;// cor da letra

            dtDepartamento.EnableHeadersVisualStyles = false; // desabilita o visual padrao do grid



            #endregion

            #region Formatação demais células

            dtDepartamento.DefaultCellStyle.Font = new Font("Tahoma", 12); // fonte
            dtDepartamento.DefaultCellStyle.ForeColor = Color.Red;// cor letra
            dtDepartamento.DefaultCellStyle.SelectionForeColor = Color.White; // cor da letra qdo linha selecionada
            dtDepartamento.DefaultCellStyle.SelectionBackColor = Color.DarkBlue; // cor de fundo qdo linha selecionada

            #endregion
        }

        private void RedefinirCampos()
        {
            txtID_Dep.Clear();
            txtNomeDep.Clear();
            txtSiglaDep.Clear();
            dtDepartamento.DataSource = null;
            txtID_Dep.Focus();
        }

        #region Botoes/Eventos
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (RecuperarDados())
            {
                objDep.Incluir();
                RedefinirCampos();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var dadosDepartamentos = objDep.Consultar();

            // se qtde de linha  maior q zero
            if (dadosDepartamentos.Rows.Count > 0)
            {
                FormatarGrid();
                dtDepartamento.DataSource = dadosDepartamentos;// exibe os dados se  existir registro na consulta

            }
            else
            {
                MessageBox.Show("Não há registros no banco!");
                dtDepartamento.Columns.Clear(); // limpa o GRID para que as colunas não apareçam
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                // recuperando o código para a propriedade
                objDep.IDDepartamento = int.Parse(txtID_Dep.Text);

                // Chamada do método pesquisar
                var tblDados = objDep.Pesquisar();

                // exibe no textbox o valor contido nas colunas da tabela (originada da consulta)
                txtNomeDep.Text = tblDados.Rows[0]["NomeDep"].ToString();
                txtSiglaDep.Text = tblDados.Rows[0]["SiglaDep"].ToString();

            }

            catch (FormatException)
            {
                MessageBox.Show("Digite o Código antes de pesquisar");
                txtID_Dep.Focus();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (RecuperarDados())
            {
                objDep.Alterar();
                RedefinirCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                objDep.IDDepartamento = int.Parse(txtID_Dep.Text);
                if (MessageBox.Show("Deseja excluir esse registro?",
                    "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objDep.Excluir();
                    RedefinirCampos();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Informe o número do Código para a exclusão!");
                txtID_Dep.Clear();
            }
        }

        // dublo clique na linha do grid
        private void dtDepartamento_DoubleClick(object sender, EventArgs e)
        {
            // linha selecionada. TextBox recebe o valor(conteúdo) contido nas colunas(Cells[0] e [1])
            txtID_Dep.Text = $"{dtDepartamento.CurrentRow.Cells[0].Value}";
            txtNomeDep.Text = $"{dtDepartamento.CurrentRow.Cells[0].Value}";
        }

      
        #endregion       

    }
}
