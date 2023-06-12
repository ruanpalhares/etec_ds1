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
    class Funcionario
    {
        public int IdFunc { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public decimal Salario { get; set; }
        public int IdDep { get; set; }

        Dados objDados = new Dados();

        #region Metodos

        #region Consultar Departamento

        public DataTable ConsultarDepartamento()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable("SELECT IDDEP, SIGLADEP FROM" +
                " DEPARTAMENTO ORDER BY SIGLADEP");
            return tblRecuperada;
        }

        #endregion

        #region Incluir

        public void Incluir()
        {
            if (objDados.ConvertSqlToInt(
                "INSERT INTO FUNCIONARIO (NOME, CEP, ENDERECO, COMPLEMENTO, NUMERO, BAIRRO, CIDADE, UF, SALARIO, IDDEP) " +
                " VALUES (?Nome, ?Cep, ?Endereco, ?Complemento, ?Numero, ?Bairro, ?Cidade, ?Uf, ?Salario, ?IdDep)",
                new MySqlParameter("?Nome", Nome),
                new MySqlParameter("?Cep", CEP),
                new MySqlParameter("?Endereco", Endereco),
                new MySqlParameter("?Complemento", Complemento),
                new MySqlParameter("?Numero", Numero),
                new MySqlParameter("?Bairro", Bairro),
                new MySqlParameter("?Cidade", Cidade),
                new MySqlParameter("?Uf", UF),
                new MySqlParameter("?Salario", Salario),
                new MySqlParameter("?IdDep", IdDep)) != 0)

                MessageBox.Show("Inclusão realizada!");
            else
                MessageBox.Show("Não foi possível realizar a inclusão!");


        }

        #endregion

        #region Consultar
        public DataTable Consultar()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable(
                "SELECT F.*, D.SIGLADEP FROM FUNCIONARIO F, DEPARTAMENTO D WHERE F.IDDEP = D.IDDEP");

            return tblRecuperada;
        }
        #endregion

        #region Pesquisar
        public DataTable Pesquisar()
        {
            DataTable tblRecuperada = objDados.ConvertSqlToDataTable(
                "SELECT F.*, D.SIGLADEP FROM FUNCIONARIO F, DEPARTAMENTO D " +
                "WHERE F.IDDEP = D.IDDEP AND F.IDFUNC = ?IdFunc",
               new MySqlParameter("?IdFunc", IdFunc));

            return tblRecuperada;
        }
        #endregion

        #region Alterar
        public void Alterar()
        {
            if (objDados.ConvertSqlToInt(
                    "UPDATE FUNCIONARIO SET NOME = ?Nome, CEP = ?Cep, ENDERECO = ?Endereco, COMPLEMENTO = ?Complemento," +
                    "NUMERO = ?Numero, BAIRRO = ?Bairro, CIDADE = ?Cidade, UF = ?Uf, SALARIO = ?Salario, IDDEP = ?IdDep" +
                    " WHERE IDFUNC = ?IdFunc",
                    new MySqlParameter("?IdFunc", IdFunc),
                    new MySqlParameter("?Nome", Nome),
                    new MySqlParameter("?Cep", CEP),
                    new MySqlParameter("?Endereco", Endereco),
                    new MySqlParameter("?Complemento", Complemento),
                    new MySqlParameter("?Numero", Numero),
                    new MySqlParameter("?Bairro", Bairro),
                    new MySqlParameter("?Cidade", Cidade),
                    new MySqlParameter("?Uf", UF),
                    new MySqlParameter("?Salario", Salario),
                    new MySqlParameter("?IdDep", IdDep)) != 0)

                MessageBox.Show("Alteração realizada!");
            else
                MessageBox.Show("Não foi possível realizar a Alteração!");
        }
        #endregion

        #endregion
    }
}
