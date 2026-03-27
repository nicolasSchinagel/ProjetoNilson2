using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AplicacaoCarrinho.Models
{
    public class Item
    {
        public Guid ItemPedidoId { get; set; }

        public int CodEmp { get; set; }

        public string? codLivro { get; set; }

        public string? nomeLivro { get; set; }

        public string? imagem { get; set; }

        public string? quantidade { get; set; }
    }
}
