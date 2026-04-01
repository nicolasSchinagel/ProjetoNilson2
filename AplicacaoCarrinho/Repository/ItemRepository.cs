using AplicacaoCarrinho.Repository.Contract;
using AplicacaoCarrinho.Models;
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
