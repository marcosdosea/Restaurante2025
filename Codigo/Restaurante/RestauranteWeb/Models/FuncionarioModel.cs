using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class FuncionarioModel
    {
        public uint Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; } = string.Empty;

        [StringLength(8)]
        public string? Cep { get; set; }

        [StringLength(45)]
        public string? Rua { get; set; }

        [StringLength(45)]
        public string? Bairro { get; set; }

        [StringLength(45)]
        public string? Cidade { get; set; }

        [StringLength(2)]
        public string? Estado { get; set; }

        [StringLength(11)]
        public string? Telefone1 { get; set; }

        [StringLength(11)]
        public string? Telefone2 { get; set; }

        [Required]
        public uint IdRestaurante { get; set; }

        [Required]
        public uint IdTipoFuncionario { get; set; }
    }
}
