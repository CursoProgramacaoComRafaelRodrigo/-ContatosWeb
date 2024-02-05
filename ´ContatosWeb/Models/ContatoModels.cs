using System.Data.SqlClient;

namespace _ContatosWeb.Models
{
    public class ContatoModels
    {
        public List<Contatos> GetContatos()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            List<Contatos> Lista = new List<Contatos>();
            try
            {
                con.ConnectionString = ConexaoMySql.Conectar();
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = "select * from contato";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Contatos ct = new Contatos();
                        ct.Id = Convert.ToInt32(dr["id"]);
                        ct.Nome = dr["nome"].ToString();
                        ct.Email = dr["email"].ToString();
                        ct.Telefone = dr["telefone"].ToString();
                        Lista.Add(ct);
                    }
                    dr.Close();
                }
            }
            catch (SqlException)
            {
                con = null;
                cmd = null;
                dr = null;
            }
            return Lista;
        }

    }
}
