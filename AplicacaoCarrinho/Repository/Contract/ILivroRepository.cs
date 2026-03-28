using AplicacaoCarrinho.Models;
namespace AplicacaoCarrinho.Repository.Contract
{
    public interface ILivroRepository
    {
        //CRUD
        IEnumerable<Livro> ObterTodosLivros();
        void Cadastrar(Livro livro);
        void Atualizar(Livro livro);
        Livro ObterLivros(int id);
        void Excluir(int id);
    }
}
