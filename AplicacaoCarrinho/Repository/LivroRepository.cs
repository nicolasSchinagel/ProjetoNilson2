using AplicacaoCarrinho.Repository.Contract;
using AplicacaoCarrinho.Models;
using MySql.Data.MySqlClient;
using System.Data;
namespace AplicacaoCarrinho.Repository
{
    public class LivroRepository: ILivroRepository
    {
        private readonly string _conexaoMySQL;
        public LivroRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");

        }
        public void Cadastrar(Livro livro)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbLivro values(default, @NomeLivro, @ImagemLivro)", conexao);
                cmd.Parameters.Add("@NomeLivro", MySqlDbType.VarChar).Value = livro.NomeLivro;
                cmd.Parameters.Add("@ImagemLivro", MySqlDbType.VarChar).Value = livro.imagemLivro;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Livro ObterLivros(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("select * from tbLivro where codLivro = @cod", conexao);
                cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = id;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Livro livro = new Livro();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    livro.codLivro = Convert.ToInt32(dr["codLivro"]);
                    livro.NomeLivro = (String)(dr["nomeLivro"]);
                    livro.imagemLivro = (String)(dr["imagemLivro"]);
                }
                return livro;
            }
        }

        public IEnumerable<Livro> ObterTodosLivros()
        {
            List<Livro> LivroList = new List<Livro>();
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbLivro", conexao);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                conexao.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    LivroList.Add(
                        new Livro
                        {
                            codLivro = Convert.ToInt32(dr["codLivro"]),
                            NomeLivro = (String)(dr["nomeLivro"]),
                            imagemLivro = (String)(dr["imagemLivro"]),
                        }
                        );
                }
                return LivroList;
            }
        }
        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
        public void Atualizar(Livro livro)
        {
            throw new NotImplementedException();
        }
    }
}
