using Core;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class PedidoController : Controller
    {
        private readonly RestauranteContext _context;

        public PedidoController(RestauranteContext context)
        {
            _context = context;
        }

        public IActionResult RegistrarPedido(int atendimentoId)
        {
            // Aqui você pode buscar o atendimento e exibir os pedidos vinculados
            ViewBag.AtendimentoId = atendimentoId;
            return View();
        }
    }
}
