using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoAvaliativo_BD
{
    class ClsProduto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double PrecoUnit { get; set; }

        Dados objDados = new Dados();

        #region Metodos

        #region Incluir

        public void Incluir()
        {
            try
            {
                objDados.ConvertSqlToInt("INSERT INTO Produto(Codigo, Nome, PrecoUnitario) VALUES(?Codigo, ?Nome, ?PrecoUnitario)",
                new MySqlParameter("?Codigo", Codigo),
                new MySqlParameter("?Nome", Nome),
                new MySqlParameter("?PrecoUnitario", PrecoUnit));
                MessageBox.Show("Registro Incluido!");
            }
            catch (Exception)
            {
                MessageBox.Show("Registro não Incluido!");
            }

        }

        #endregion

        #region Consultar

        public DataTable Consultar()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM Produto");

            return tblRecuperada;
        }

        #endregion

        #region Pesquisar

        public DataTable PesquisarCod()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM Produto WHERE Codigo = ?Codigo",
                new MySqlParameter("?Codigo", Codigo));

            return tblRecuperada;
        }

        public DataTable PesquisarNome()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM Produto WHERE Nome LIKE ?Nome",
                new MySqlParameter("?Nome", Nome+"%"));

            return tblRecuperada;
        }

        #endregion

        #region Alterar

        public void Alterar()
        {
            try
            {
                objDados.ConvertSqlToInt("UPDATE Produto SET Nome = ?Nome, PrecoUnitario = ?PrecoUnit WHERE Codigo = ?Codigo",
                new MySqlParameter("?Codigo", Codigo),
                new MySqlParameter("?Nome", Nome),
                new MySqlParameter("?PrecoUnit", PrecoUnit));
                MessageBox.Show("Registro Alterado!");
            }
            catch (Exception)
            {
                MessageBox.Show("Registro não Alterado!");
            } 
        }

        #endregion

        #region Excluir

        public void Excluir()
        {
            if (objDados.ConvertSqlToInt("DELETE FROM Produto WHERE Codigo = ?Codigo",
                new MySqlParameter("?Codigo", Codigo)) != 0)
            {
                MessageBox.Show("Registro Excluido");
            }
            else
            {
                MessageBox.Show("Codigo Não Encontrado!");
            }
        }

        #endregion

        #endregion
    }
}
