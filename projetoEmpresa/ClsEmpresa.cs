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
    class ClsEmpresa
    {
        public int Id { get; set; }
        public string NomeDep { get; set; }
        public string SiglaDep { get; set; }

        Dados objDados = new Dados();

        #region Metodos

        #region Incluir

        public void Incluir()
        {
            try
            {
                if (objDados.ConvertSqlToInt("INSERT INTO DEPARTAMENTO(ID, NOMEDEP, SIGLADEP) VALUES(?Id, ?NomeDep, ?SiglaDep)",
                new MySqlParameter("?Id", Id),
                new MySqlParameter("?NomeDep", NomeDep),
                new MySqlParameter("?SiglaDep", SiglaDep)) != 0)
                {
                    MessageBox.Show("Registro incluido");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Registro não incluido!");
            }
        }

        #endregion

        #region Consultar

        public DataTable Consultar()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM DEPARTAMENTO");

            return tblRecuperada;
        }

        #endregion

        #region Alterar

        public void Alterar()
        {
            if (objDados.ConvertSqlToInt("UPDATE DEPARTAMENTO SET NOMEDEP = ?NomeDep, SIGLADEP = ?SiglaDep WHERE ID = ?Id",
                new MySqlParameter("?Id", Id),
                new MySqlParameter("?NomeDep", NomeDep),
                new MySqlParameter("?SiglaDep", SiglaDep)) != 0)
            {
                MessageBox.Show("Registro Alterado!");
            }
            else
            {
                MessageBox.Show("Registro Não Alterado!");
            }
        }

        #endregion

        #region Excluir

        public void Excluir()
        {
            if (objDados.ConvertSqlToInt("DELETE FROM DEPARTAMENTO WHERE ID = ?Id",
                new MySqlParameter("?Id", Id)) != 0)
            {
                MessageBox.Show("Registro Excluido");
            }
            else
            {
                MessageBox.Show("Codigo Não Encontrado!");
            }
        }

        #endregion

        #region PesquisarCod

        public DataTable PesquisarCod()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM DEPARTAMENTO WHERE ID = ?Id",
               new MySqlParameter("?Id", Id));

            return tblRecuperada;
        }

        public DataTable PesquisarNome()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM DEPARTAMENTO WHERE NOMEDEP LIKE ?NomeDep",
               new MySqlParameter("?NomeDep", NomeDep+"%"));

            return tblRecuperada;
        }

        public DataTable PesquisarSigla()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM DEPARTAMENTO WHERE SIGLADEP LIKE ?SiglaDep",
               new MySqlParameter("?SiglaDep", SiglaDep + "%"));

            return tblRecuperada;
        }

        #endregion

        #endregion
    }
}
