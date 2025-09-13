using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly RestauranteContext _context;

        public PedidoController(RestauranteContext context)
        {
            _context = context;
        }

        public IActionResult RegistrarPedido(int atendimentoId)
        {
            var atendimento = _context.Atendimentos
                .Include(a => a.IdMesaNavigation)
                .FirstOrDefault(a => a.Id == atendimentoId);

            if (atendimento == null)
            {
                return NotFound();
            }

            var itensCardapio = _context.Itemcardapios
                .Where(i => i.IdRestaurante == atendimento.IdMesaNavigation.IdRestaurante && i.Ativo == 1)
                .ToList();

            var garcons = _context.Funcionarios
                .Where(f => f.IdTipoFuncionario == 2)
                .ToList();

            ViewBag.ItensCardapio = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(itensCardapio, "Id", "Nome");
            ViewBag.Garcons = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(garcons, "Id", "Nome");
            ViewBag.AtendimentoId = atendimentoId;

            var model = new PedidoModel
            {
                IdAtendimento = (uint)atendimentoId,
                Itens = new List<PedidoItemModel>()
            };

            return View(model);
        }
    }
}