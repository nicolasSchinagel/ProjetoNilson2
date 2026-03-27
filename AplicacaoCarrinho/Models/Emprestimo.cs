using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AplicacaoCarrinho.Models
{
    public class Emprestimo
    {
        public string? codEmp { get; set; }

        public string? dtEmpre { get; set; }

        public string? dtDev { get; set; }

        public string? codUsu { get; set; }
    }
}
