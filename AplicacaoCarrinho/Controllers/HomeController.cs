using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AplicacaoCarrinho.Models;
using AplicacaoCarrinho.Repository.Contract;
using AplicacaoCarrinho.CarrinhoCompra;

namespace AplicacaoCarrinho.Controllers;

public class HomeController : Controller
{
    private ILivroRepository _livroRepository;
    private CookieCarrinhoCompra _cookieCarrinhoCompra;

    private IEmprestimoRepository _emprestimoRepository;
    private IItemRepository _itemRepository;

    

    public HomeController(ILivroRepository livroRepository, CookieCarrinhoCompra cookieCarrinhoCompra, IEmprestimoRepository emprestimoRepository, IItemRepository itemRepository)
    {
        _livroRepository = livroRepository;
        _cookieCarrinhoCompra = cookieCarrinhoCompra;
        _emprestimoRepository = emprestimoRepository;
        _itemRepository = itemRepository;
    }

    public IActionResult Index()
    {
        return View(_livroRepository.ObterTodosLivros());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult AdicionarItem(int id)
    {
        Livro produto = _livroRepository.ObterLivros(id);

        if(produto == null)
        {
            return View("NaoExisteItem");
        }
        else
        {
            var item = new Livro()
            {
                codLivro = id,
                quantidade = 1,
                imagemLivro = produto.imagemLivro,
                NomeLivro = produto.NomeLivro
            };
            _cookieCarrinhoCompra.Cadastrar(item);

            return RedirectToAction(nameof(Carrinho));
        }
    }
    //carrinho de compra
    public IActionResult Carrinho()
    {
        return View(_cookieCarrinhoCompra.Consultar());
    }

    //Remover itens do carrinho
    public IActionResult RemoverItem(int id)
    {
        _cookieCarrinhoCompra.Remover(new Livro() { codLivro = id });
        return RedirectToAction(nameof(Carrinho));
    }
    DateTime data;
    public IActionResult SalvarCarrinho(Emprestimo emprestimo)
    {
        List<Livro> carrinho = _cookieCarrinhoCompra.Consultar();
        Emprestimo mdE = new Emprestimo();
        Item mdI = new Item();

        data = DateTime.Now.ToLocalTime();
        mdE.dtEmpre = data.ToString("dd/MM/yyyy");
        mdE.dtDev = data.AddDays(7).ToString();
        mdE.codUsu = "1";
        _emprestimoRepository.Cadastrar(mdE);
        _emprestimoRepository.buscaIdEmp(emprestimo);

        for(int i = 0; i < carrinho.Count; i++)
        {
            mdI.CodEmp = Convert.ToInt32(emprestimo.codEmp);
            mdI.codLivro = Convert.ToString(carrinho[i].codLivro);

            _itemRepository.Cadastrar(mdI);
        }

        _cookieCarrinhoCompra.RemoverTodos();
        return RedirectToAction("confEmp");
    }
    public IActionResult confEmp()
    {
        return View();
    }
}
