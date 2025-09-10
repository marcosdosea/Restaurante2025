using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class PagamentoModel
    {
        public uint Id { get; set; }

        [Required]
        [Display(Name = "Data/Hora")]
        public DateTime DataHora { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required]
        [Display(Name = "Atendimento")]
        public uint IdAtendimento { get; set; }

        [Required]
        [Display(Name = "Forma de Pagamento")]
        public uint IdFormaPagamento { get; set; }
    }
}
