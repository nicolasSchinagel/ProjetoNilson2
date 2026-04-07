using AplicacaoCarrinho.Cookie;
using AplicacaoCarrinho.Models;

namespace AplicacaoCarrinho.CarrinhoCompra
{

    
    public class CookieCarrinhoCompra()
    {
        private string Key = "Carrinho.Compras";
        private Cookie.Cookie _cookie;

        public CookieCarrinhoCompra(Cookie.Cookie cookie)
        {
            _cookie = cookie;
        }
    }
}
