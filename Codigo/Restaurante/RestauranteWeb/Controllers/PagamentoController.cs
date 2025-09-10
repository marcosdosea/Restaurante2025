using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class PagamentoController : Controller
    {
        private readonly IPagamentoService _pagamentoService;
        private readonly IFormaPagamentoService _formaPagamentoService;
        private readonly IMapper _mapper;

        public PagamentoController(IPagamentoService pagamentoService, IFormaPagamentoService formaPagamentoService, IMapper mapper)
        {
            _pagamentoService = pagamentoService;
            _formaPagamentoService = formaPagamentoService;
            _mapper = mapper;
        }

        public IActionResult Registrar(uint atendimentoId)
        {
            ViewBag.FormasPagamento = new SelectList(_formaPagamentoService.GetAll(), "Id", "Nome");
            var model = new PagamentoModel { IdAtendimento = atendimentoId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(PagamentoModel model)
        {
            if (ModelState.IsValid)
            {
                var pagamento = _mapper.Map<Core.Pagamento>(model);
                _pagamentoService.Create(pagamento);
                return RedirectToAction("Pagamentos", new { atendimentoId = model.IdAtendimento });
            }
            ViewBag.FormasPagamento = new SelectList(_formaPagamentoService.GetAll(), "Id", "Nome", model.IdFormaPagamento);
            return View(model);
        }

        public IActionResult Pagamentos(uint atendimentoId)
        {
            var pagamentos = _pagamentoService.GetByAtendimento(atendimentoId);
            var model = _mapper.Map<List<PagamentoModel>>(pagamentos);
            ViewBag.TotalPago = _pagamentoService.GetTotalPago(atendimentoId);
            return View(model);
        }
    }
}
