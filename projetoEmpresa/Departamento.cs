using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoEmpresa
{
    class Departamento
    {
        public int IDDepartamento { get; set; }
        public string NomeDep { get; set; }
        public string SiglaDep { get; set; }

        #region Métodos

        Dados objDados = new Dados();

        #region Incluir
        public void Incluir()
        {
            if (objDados.ConvertSqlToInt("INSERT INTO DEPARTAMENTO" +
                "(IDDEP,NOMEDEP,SIGLADEP)VALUES(?Id,?Nome,?Sigla)",
                    new MySqlParameter("?Id", IDDepartamento),
                    new MySqlParameter("?Nome", NomeDep),
                    new MySqlParameter("?Sigla", SiglaDep)) != 0)

                MessageBox.Show("Inclusão realizada!");
            
            else
                MessageBox.Show("Não foi possível realizar a inclusão!");
        }
        #endregion

        #region Consultar
        public DataTable Consultar()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable(
                "SELECT * FROM DEPARTAMENTO");

            return tblRecuperada;
        }
        #endregion

        #region Pesquisar pelo Código
        public DataTable Pesquisar()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable(
                "SELECT * FROM DEPARTAMENTO WHERE IDDEP = ?Id",
                new MySqlParameter("?Id", IDDepartamento));

            return tblRecuperada;
        }
        #endregion

        #region Alterar
        public void Alterar()
        {
            if (objDados.ConvertSqlToInt(
                    "UPDATE DEPARTAMENTO SET NOME = ?Nome, SIGLADEP = ?Sigla " +
                    "WHERE IDDEP = ?Id",
                    new MySqlParameter("?Id", IDDepartamento),
                    new MySqlParameter("?Nome", NomeDep),
                    new MySqlParameter("?Sigla", SiglaDep)) != 0)

                MessageBox.Show("Alteração realizada!");
            else
                MessageBox.Show("Não foi possível realizar a Alteração!");
        }
        #endregion

        #region Excluir
        public void Excluir()
        {
            if (objDados.ConvertSqlToInt("DELETE FROM DEPARTAMENTO WHERE IDDEP = ?Id",
                      new MySqlParameter("?Id", IDDepartamento)) != 0)

                MessageBox.Show("Registro Excluído!");
            else
                MessageBox.Show("Código não encontrado!\nNão foi possível realizar a Exclusão!");
        }
        #endregion

        #endregion

    }
}
