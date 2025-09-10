using Core;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class MesaModel
    {
        [Display(Name = "Código")]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Numero { get; set; }

        [Display(Name = "Capacidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Capacidade { get; set; }

        [Display(Name = "Restaurante")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public uint IdRestaurante { get; set; }

        [Display(Name = "Identificação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(45, ErrorMessage = "O campo {0} deve ter até {1} caracteres.")]
        public string Identificacao { get; set; } = string.Empty;

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; } = true;
    }
}
