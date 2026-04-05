using AplicacaoCarrinho.Repository.Contract;
using AplicacaoCarrinho.Models;
using MySql.Data.MySqlClient;
namespace AplicacaoCarrinho.Repository
{
    public class ItemRepository : IItemRepository
    {
        // CRUD

        private readonly string _conexaoMySQL;

        public ItemRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Cadastrar(Item item)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into itensEmp values(default, @codEmp, @codLivro)", conexao);

                cmd.Parameters.Add("@codEmp", MySqlDbType.VarChar).Value = item.CodEmp;
                cmd.Parameters.Add("@codLivro", MySqlDbType.VarChar).Value = item.codLivro;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Atualizar(Item item)
        {

        }

        public void Excluir(int Id)
        {

        }

        public Item ObterItens(int Id)
        {
            
        }

        public IEnumerable<Item> ObterTodosItens()
        {

        }
    }
}
