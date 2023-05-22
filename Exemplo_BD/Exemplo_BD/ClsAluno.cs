using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exemplo_BD
{
    class ClsAluno
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        Dados objDados = new Dados();

        #region Metodos

        #region Incluir
        public void Incluir() 
        {
            try
            {
                objDados.ConvertSqlToInt("INSERT INTO ALUNO(CODIGO, NOME) VALUES (?Codigo, ?Nome)",
                    new MySqlParameter("?Codigo", Codigo),
                    new MySqlParameter("?Nome", Nome));

                MessageBox.Show("Inclusão Realizada!");
            }
            catch (Exception)
            {
                MessageBox.Show("Inclusão Não Realizada!");
            }
        }
        #endregion

        #region Consultar

        public DataTable Consultar()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM Aluno");

            return tblRecuperada;
        }

        #endregion

        #region Pesquisar
        public DataTable Pesquisar()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable(
                "SELECT * FROM ALUNO WHERE CODIGO = ?Codigo",
                new MySqlParameter("Codigo", Codigo));

            return tblRecuperada;
        }
        #endregion

        #region Alterar
        public void Alterar()
        {
            try
            {
                objDados.ConvertSqlToInt(
                "UPDATE ALUNO SET NOME = ?Nome WHERE CODIGO = ?Codigo",
                new MySqlParameter("Codigo", Codigo),
                new MySqlParameter("Nome", Nome));

                MessageBox.Show("Alteração Realizada!");
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possivel realizar a alteração!");
            }
        }
        #endregion

        #region Excluir
        public void Excluir()
        {
            try
            {
                if (objDados.ConvertSqlToInt("DELETE FROM ALUNO WHERE CODIGO = ?Codigo",
                    new MySqlParameter("?Codigo", Codigo)) !=0)
                {
                    MessageBox.Show("Registro Excluido!");
                }
                else
                {
                    MessageBox.Show("Codigo não encontrada!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possivel realizar a exclusão!");
            }
        }
        #endregion

        #endregion
    }
}
