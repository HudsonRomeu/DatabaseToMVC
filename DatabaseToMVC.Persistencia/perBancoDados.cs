using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseToMVC.Persistencia
{
    public class perBancoDados
    {
        /// <summary>
        /// Parametros que vão para o banco de dados (SQL, ACCESS, ORACLE, FIREBIRD E ETC)
        /// </summary>
        private SqlParameterCollection SqlParameterCollection = new SqlCommand().Parameters;
        private SqlConnection cn = new SqlConnection();

        /// <summary>
        /// Metodo que retorna a minha string de conexão
        /// </summary>
        public static string StringConexao
        {
            get
            {
                var conexao = ConfigurationManager.ConnectionStrings["MASTER"].ConnectionString;
                return conexao;
            }
        }

        /// <summary>
        /// Metodo que limpa os parametros 
        /// </summary>
        public void limparParametros()
        {
            SqlParameterCollection.Clear();
        }

        /// <summary>
        /// Metodo que adiciona os parametros
        /// </summary>
        /// <param name="nomeParametro"></param>
        /// <param name="valorParametro"></param>
        public void adicionarParametros(string nomeParametro, object valorParametro)
        {
            SqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        /// <summary>
        /// Metodo que executa um comando no banco de dados.
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="textoSQL"></param>
        /// <returns></returns>
        public object executaComando(string textoSQL)
        {
            cn.ConnectionString = StringConexao.ToString();
            SqlTransaction transaction = null;

            try
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = textoSQL;
                cmd.CommandTimeout = 7200;

                foreach (SqlParameter SqlParameter in SqlParameterCollection)
                {
                    if (SqlParameter.DbType == DbType.DateTime)
                    {
                        if (Convert.ToDateTime(SqlParameter.Value) == DateTime.MinValue)
                        {
                            cmd.Parameters.Add(new SqlParameter(SqlParameter.ParameterName, DBNull.Value));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter(SqlParameter.ParameterName, SqlParameter.Value));
                        }
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(SqlParameter.ParameterName, SqlParameter.Value));
                    }
                }

                cmd.ExecuteScalar();
                transaction.Commit();
                return 0;

            }
            catch (SqlException ex)
            {
                transaction.Rollback();

                if ((ex.Number == 2601) || (ex.Number == 2627))
                {
                    throw new Exception("Registros duplicados. Operação não pode continuar.");
                }
                else if (ex.Number == 547)
                {
                    throw new Exception("Não é possível excluir esse registro.\nO mesmo possui vinculos com outras tabelas no sistema.");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (ConstraintException)
            {
                transaction.Rollback();
                throw new Exception("Registros duplicados. Operação não pode continuar.");
            }
            catch (Exception exception)
            {
                throw new Exception(String.Format("Mensagem: {0}", exception.Message));

                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format("Ocorreu um erro Rollack tipo {0}. \nMensagem: ", ex.GetType(), ex.Message));
                }
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Metodo que retorna um DataTable cheio
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="textoSQL"></param>
        /// <returns></returns>
        public DataTable executaConsulta(string textoSQL, string sConnectionString = "")
        {
            cn.ConnectionString = string.IsNullOrEmpty(sConnectionString) ? StringConexao.ToString() : sConnectionString;

            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = textoSQL;
                cmd.CommandTimeout = 7200;

                foreach (SqlParameter SqlParameter in SqlParameterCollection)
                {
                    cmd.Parameters.Add(new SqlParameter(SqlParameter.ParameterName, SqlParameter.Value));
                }

                SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();

                SqlDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Metodo que retorna um DataSet cheio
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="textoSQL"></param>
        /// <returns></returns>
        public DataSet retornaDataSet(string textoSQL, String tabelaPopular)
        {
            cn.ConnectionString = StringConexao.ToString();

            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = textoSQL;
                cmd.CommandTimeout = 7200;

                SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(cmd);

                DataSet dataSet = new DataSet();

                SqlDataAdapter.Fill(dataSet, tabelaPopular); //, "vMovimentoDia"

                return dataSet;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Classe para retornar um DataReader()
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns></returns>
        public SqlDataReader retornarDataReader(string strQuery)
        {
            cn.ConnectionString = StringConexao.ToString();

            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = strQuery;
                cmd.CommandTimeout = 7200;

                return cmd.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Metodo que executa uma select e retorna um id conforme parametro
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="textoSQL"></param>
        /// <returns></returns>
        public Object buscarId(string textoSQL)
        {
            cn.ConnectionString = StringConexao.ToString();

            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = textoSQL;
                cmd.CommandTimeout = 7200;

                return cmd.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Metodo que retorna um DataSet cheio e seta um dataSet para o relatório
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="textoSQL"></param>
        /// <returns></returns>
        public DataSet retornaDataSetRelatorio(string textoSQL, String tipoOperacao)
        {
            cn.ConnectionString = StringConexao.ToString();

            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @textoSQL;
                cmd.CommandTimeout = 7200;

                foreach (SqlParameter SqlParameter in SqlParameterCollection)
                {
                    cmd.Parameters.Add(new SqlParameter(SqlParameter.ParameterName, SqlParameter.Value));
                }

                SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(cmd);

                DataSet dataSet = new DataSet();

                SqlDataAdapter.Fill(dataSet, tipoOperacao);

                return dataSet;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        public DataTable RetornarSchema(string sSchema)
        {
            cn.ConnectionString = StringConexao.ToString();

            try
            {
                cn.Open();
                return cn.GetSchema(sSchema);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }
    }
}