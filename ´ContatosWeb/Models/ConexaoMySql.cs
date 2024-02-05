using System.Data;
using System.Data.SqlClient;

namespace _ContatosWeb.Models
{
    public class ConexaoMySql
    {
        private static string ConexaoString = $"Data Source={Environment.UserDomainName}\\SQLEXPRESS02; Initial Catalog=sistema;Integrated Security=true";
        public static string Conectar()
        {
            return ConexaoString;
        }
        public static string TestarConexao()
        {
            string resposta = string.Empty;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConexaoString;
            con.Open();

            if (con.State == ConnectionState.Open)
                resposta = "Conexão bem sucedida";
            else
                resposta = "Conexão mal sucedida";

            return resposta;
        }
    }

}
