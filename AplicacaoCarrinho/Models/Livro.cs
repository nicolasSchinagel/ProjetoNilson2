using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AplicacaoCarrinho.Models
{
    public class Livro
    {
        [Required (ErrorMessage="Código é obrigatório")]
        public int codLivro { get; set; }

        [Required(ErrorMessage = "Nome do Livro é obrigatório")]
        [DisplayName("XYZ")]
        public string? NomeLivro { get; set; }

        [Required(ErrorMessage = "Imagem do Livro é obrigatória")]
        public string? imagemLivro { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatória")]
        public int quantidade { get; set; }
    }
}
