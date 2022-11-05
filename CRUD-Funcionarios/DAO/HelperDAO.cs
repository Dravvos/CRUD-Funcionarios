using System;
using System.Data;
using System.Data.SqlClient;
using Ex_Cadastro_Funcionarios.Models;

namespace Ex_Cadastro_Funcionarios.DAO
{
    public class HelperDAO
    {
        public static void ExecutaSQL(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }
        public static DataTable ExecutaSelect(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    conexao.Close();
                    return tabela;
                }
            }
        }

    }
}
