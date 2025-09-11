using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class PedidoModel
    {
        public uint Id { get; set; }

        [Display(Name = "Data/Hora Solicitação")]
        public DateTime DataHoraSolicitacao { get; set; } = DateTime.Now;

        [Display(Name = "Data/Hora Atendimento")]
        public DateTime? DataHoraAtendimento { get; set; }

        [Display(Name = "Atendimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public uint IdAtendimento { get; set; }

        [Display(Name = "Garçom")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public uint IdGarcom { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "S"; // S - SOLICITADO

        // Propriedades de navegação para exibição
        [Display(Name = "Número Atendimento")]
        public string? NumeroAtendimento { get; set; }

        [Display(Name = "Nome do Garçom")]
        public string? NomeGarcom { get; set; }

        [Display(Name = "Mesa")]
        public string? MesaIdentificacao { get; set; }

        [Display(Name = "Itens do Pedido")]
        public List<PedidoItemModel> Itens { get; set; } = new List<PedidoItemModel>();

        [Display(Name = "Total do Pedido")]
        public decimal TotalPedido => Itens.Sum(i => i.Total);
    }

    public class PedidoItemModel
    {
        [Display(Name = "Item do Cardápio")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public uint IdItemCardapio { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.01, 100, ErrorMessage = "Quantidade deve ser entre {1} e {2}")]
        public decimal Quantidade { get; set; } = 1;

        [Display(Name = "Nome do Item")]
        public string? NomeItem { get; set; }

        [Display(Name = "Preço Unitário")]
        public decimal PrecoUnitario { get; set; }

        [Display(Name = "Total")]
        public decimal Total => Quantidade * PrecoUnitario;
    }
}