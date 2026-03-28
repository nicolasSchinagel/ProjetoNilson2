using AplicacaoCarrinho.Repository.Contract;
using AplicacaoCarrinho.Models;
using Microsoft.AspNetCore.Mvc;
using AplicacaoCarrinho.GerenciaArquivos;

namespace AplicacaoCarrinho.Controllers
{
    public class LivrosController : Controller
    {
        private ILivroRepository _livroRepository;

        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Livro livro, IFormFile file)
        {
            var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            livro.imagemLivro = Caminho;

            _livroRepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro realizado";
            return View();
        }
    }
}
