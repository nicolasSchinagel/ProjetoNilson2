using AplicacaoCarrinho.Repository.Contract;
using AplicacaoCarrinho.Models;
using Microsoft.AspNetCore.Mvc;
using AplicacaoCarrinho.GerenciaArquivos;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        public IActionResult CadLivro()
        {
            var listCategorias = _livroRepository.ObterTodosLivros();
            ViewBag.Categorias = new SelectList(listCategorias, "codLivro", "descricao");
            return View();
        }
        [HttpPost]
        public IActionResult CadLivro(Livro livro, IFormFile file)
        {
            var listCategorias = _livroRepository.ObterTodosLivros();
            ViewBag.Categorias = new SelectList(listCategorias, "codLivro", "descricao");

            var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            livro.imagemLivro = Caminho;

            _livroRepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro realizado";
            return View();
        }
    }
}

