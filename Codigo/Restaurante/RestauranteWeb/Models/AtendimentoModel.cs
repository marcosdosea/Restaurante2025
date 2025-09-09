using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class AtendimentoModel
    {
        public uint Id { get; set; }

        [Required]
        [Display(Name = "Mesa")]
        public int IdMesa { get; set; }

        [Display(Name = "Data de Início")]
        public DateTime DataHoraInicio { get; set; } = DateTime.Now;

        [Display(Name = "Status")]
        public string Status { get; set; } = "I";
    }
}
