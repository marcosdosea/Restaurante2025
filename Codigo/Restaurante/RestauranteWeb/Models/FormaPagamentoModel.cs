using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class FormaPagamentoModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]

        public uint Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre 3 e 20 caracteres.")]
        public string Nome { get; set; } = null!;

    }
}
