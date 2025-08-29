using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class ItemCardapioModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public uint Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal? Preco { get; set; }

        [Display(Name = "Detalhes")]
        [StringLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string? Detalhes { get; set; }

        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public sbyte Ativo { get; set; }

        [Display(Name = "Disponível")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(45, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Disponivel { get; set; } = null!;

        [Display(Name = "Restaurante")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public uint IdRestaurante { get; set; }

        [Display(Name = "Grupo de Cardápio")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public uint IdGrupoCardapio { get; set; }
    }
}
