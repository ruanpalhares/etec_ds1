using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace projetoEmpresa
{
    class Dados
    {
        ///Objeto para conexao com BD
        private MySqlConnection objConexao = null;

        #region Metodos Privados

        #region Conectar()
        /// <summary>
        /// Inicia uma conexao com o banco de dados.
        /// </summary>
        private void Conectar()
        {
            string server = "localhost";
            string user = "root";
            string password = "123456";
            string database = "BDEMPRESA";

           
            // string de conexao 
            string StringConexao = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={password};";
 
            // Cria uma conexao com o banco de dados
            objConexao = new MySqlConnection(StringConexao);

            // Abre a conexao
            objConexao.Open();
        }
        #endregion

        #region Desconectar()
        /// <summary>
        /// Fecha a conexao com o banco de dados
        /// </summary>
        private void Desconectar()
        {
            // Fecha a conexao
            objConexao.Close();
        }
        #endregion

        #endregion

        #region Metodos Publicos

        #region ConvertSqlToDataTable(string)
        /// <summary>
        /// Executa um comando SQL e retorna um DataTable preenchido com o resultado da pesquisa.
        /// </summary>
        /// <param name="p_strComandoSQL">
        /// String contendo o comando SQL a ser executado.
        /// </param>
        /// <returns>
        /// DataTable com o resultado da consulta.
        /// </returns>

        public DataTable ConvertSqlToDataTable(string p_strComandoSQL)
        {
            // Executa o comando SQL sem passar parametros
            return ConvertSqlToDataTable(p_strComandoSQL, null);
        }

        #endregion

        #region ConvertSqlToDataTable(string, SqlParameter[])
        /// <summary>
        /// Executa um comando SQL e retorna um DataTable preenchido com o resultado da pesquisa.
        /// </summary>
        /// <param name="p_strComandoSQL">
        /// String contendo o comando SQL a ser executado.
        /// </param>
        /// <param name="p_arrParametros">
        /// Colecao de parametros utilizados pelo comando SQL.
        /// </param>
        /// <returns>
        /// DataTable com o resultado da consulta.
        /// </returns>
        public DataTable ConvertSqlToDataTable(string p_strComandoSQL, params MySqlParameter[] p_arrParametros)
        {
            // Conecta ao banco
            Conectar();

            // Cria um DataTable para os dados retornados
            DataTable tblResultado = new DataTable();

            try
            {
                #region Cria comando SQL

                // Comando SQL a ser executado
                using var objComandoSQL = new MySqlCommand(p_strComandoSQL, objConexao);
           
                #endregion

                #region Adiciona parametros ao comando
                // Verifica se existem parametros
                if (p_arrParametros != null)
                {
                    // Percorre cada parametro recebido
                    foreach (MySqlParameter objParametro in p_arrParametros)
                    {
                        // Adiciona ao comando SQL
                        objComandoSQL.Parameters.Add(objParametro);
                    }
                }
                #endregion

                #region Executa o comando SQL

                // Define o adaptador de comando Select
                var objAdaptador = new MySqlDataAdapter(objComandoSQL);

                // Preenche o resultado executando o comando
                objAdaptador.Fill(tblResultado); //Adiciona ou atualiza linhas
              
                #endregion
            }
            catch (MySqlException ex) // erro
            {
                MessageBox.Show(ex.Message); // mensagem contendo a MySqlException(erro)
            }
            finally
            {
                // Fecha a conexao
                Desconectar();
            }

            // Retorna o resultado
            return tblResultado;
        }
        #endregion

        #region ConvertSqlToInt(string, SqlParameter[])
        /// <summary>
        /// Executa um comando SQL e retorna o numero de linhas afetadas.
        /// </summary>
        /// <param name="p_strComandoSQL">
        /// String contendo o comando SQL a ser executado.
        /// </param>
        /// <param name="p_arrParametros">
        /// Colecao de parametros utilizados pelo comando SQL.
        /// </param>
        /// <returns>
        /// Numero de linhas afetadas pelo comando.
        /// </returns>
        public int ConvertSqlToInt(string p_strComandoSQL,params MySqlParameter[] p_arrParametros)
        {
            // Conecta ao banco
            Conectar();

            // Cria variavel para armazenar as linhas afetadas
            int intLinhasAfetadas = 0;

            try
            {
                #region Cria comando SQL

                // Comando SQL a ser executado
                using var objComandoSQL = new MySqlCommand(p_strComandoSQL, objConexao);

                #endregion

                #region Adiciona parametros ao comando
                // Verifica se existem parametros
                if (p_arrParametros != null)
                {
                    // Percorre cada parametro recebido.
                    foreach (MySqlParameter objParametro in p_arrParametros)
                    {
                        // Adiciona ao comando SQL.
                        objComandoSQL.Parameters.Add(objParametro);
                    }
                }
                #endregion

                // Executa o comando
                intLinhasAfetadas = objComandoSQL.ExecuteNonQuery();

            }
            catch (MySqlException ex) // erro
            {
                MessageBox.Show(ex.Message); // mensagem contendo a MySqlException(erro)
            }

            finally
            {
                // Fecha a conexao
                Desconectar();
            }

            // Retorna o numero de linhas afetadas
            return intLinhasAfetadas;
        }
        #endregion

        #endregion
    }
}
