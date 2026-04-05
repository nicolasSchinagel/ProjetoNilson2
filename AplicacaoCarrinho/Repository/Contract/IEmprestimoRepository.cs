using AplicacaoCarrinho.Models;

namespace AplicacaoCarrinho.Repository.Contract
{
    public interface IEmprestimoRepository
    {
        //CRUD
        IEnumerable<Emprestimo> ObterTodosEmprestimos();

        void Cadastrar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);

        Emprestimo ObterEmprestimos(int id);

        void buscaIdEmp(Emprestimo emprestimo):

        void Excluir(int id);
    }
}
