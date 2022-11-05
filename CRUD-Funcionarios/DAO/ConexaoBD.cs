using System.Data.SqlClient;

namespace Ex_Cadastro_Funcionarios.DAO
{
    public class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            //string cx="Data Source=Localhost; Initial Catalog=AulaDb; integrated security=true;
            string cx = "Data Source=Localhost; Initial Catalog=AulaDb; user id=your_user_id; password=your_password";
            SqlConnection conexao = new SqlConnection(cx);
            conexao.Open();
            return conexao;
        }
    }
}
