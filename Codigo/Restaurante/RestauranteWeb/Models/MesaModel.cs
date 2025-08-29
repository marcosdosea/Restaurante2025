using Core;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class MesaModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Id { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Numero { get; set; }

        [Display(Name = "Capacidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Capacidade { get; set; }

        [Display(Name = "Restaurante")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int IdRestaurante { get; set; }

        public virtual bool Ativo { get; set; }

        public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    }
}
