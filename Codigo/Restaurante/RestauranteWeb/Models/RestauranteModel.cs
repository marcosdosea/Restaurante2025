using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class RestauranteModel
    {
        [Display(Name = "Código")]
        public uint Id { get; set; }

        [Display(Name = "Tipo de Restaurante")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public uint IdTipoRestaurante { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(15, ErrorMessage = "O campo {0} deve ter {1} caracteres.")]
        public string Cnpj { get; set; } = null!;

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "CEP")]
        [StringLength(8, ErrorMessage = "O campo {0} deve ter {1} caracteres.")]
        public string? Cep { get; set; }

        [Display(Name = "Rua")]
        [StringLength(45, ErrorMessage = "O campo {0} deve ter até {1} caracteres.")]
        public string? Rua { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(45, ErrorMessage = "O campo {0} deve ter até {1} caracteres.")]
        public string? Bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(45, ErrorMessage = "O campo {0} deve ter até {1} caracteres.")]
        public string? Cidade { get; set; }

        [Display(Name = "Estado")]
        [StringLength(2, ErrorMessage = "O campo {0} deve ter {1} caracteres.")]
        public string? Estado { get; set; }

        [Display(Name = "Telefone 1")]
        [StringLength(14, ErrorMessage = "O campo {0} deve ter até {1} caracteres.")]
        public string? Telefone1 { get; set; }

        [Display(Name = "Telefone 2")]
        [StringLength(14, ErrorMessage = "O campo {0} deve ter até {1} caracteres.")]
        public string? Telefone2 { get; set; }

        // Para exibir o nome do tipo de restaurante na view
        [Display(Name = "Tipo de Restaurante")]
        public string? TipoRestauranteNome { get; set; }
    }
}