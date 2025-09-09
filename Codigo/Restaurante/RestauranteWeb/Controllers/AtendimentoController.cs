using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Models;
using System.Linq;

namespace RestauranteWeb.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly RestauranteContext _context;

        public AtendimentoController(RestauranteContext context)
        {
            _context = context;
        }

        public IActionResult Iniciar()
        {
            ViewBag.Mesas = new SelectList(_context.Mesas.Where(m => m.Ativo), "Id", "Identificacao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Iniciar(AtendimentoModel model)
        {
            if (ModelState.IsValid)
            {
                var atendimento = new Atendimento
                {
                    IdMesa = model.IdMesa,
                    DataHoraInicio = DateTime.Now,
                    Status = "I"
                };
                _context.Atendimentos.Add(atendimento);
                _context.SaveChanges();
                return RedirectToAction("RegistrarPedido", "Pedido", new { atendimentoId = atendimento.Id });
            }
            ViewBag.Mesas = new SelectList(_context.Mesas.Where(m => m.Ativo), "Id", "Identificacao", model.IdMesa);
            return View(model);
        }
    }
}
