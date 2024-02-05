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
        public string NovoContato(Contatos contatos)
        {
            string resposta = string.Empty;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                con.ConnectionString = ConexaoMySql.Conectar();
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = $"insert into contato(nome,telefone,email)values('{contatos.Nome}','{contatos.Telefone}','{contatos.Email}')";

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Contato adicionado com sucesso!";
                }
                else
                {
                    resposta = "Erro ao adicionado Contato!";
                }
            }
            catch (SqlException ex)
            {
                resposta = ex.Message;
            }
            return resposta;
        }
    }
}
