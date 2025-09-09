using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class FormaPagamentoController : Controller
    {
        
        private readonly IFormaPagamentoService _formaPagamentoService;
        private readonly IMapper _mapper;

        public FormaPagamentoController(IFormaPagamentoService formaPagamentoService, IMapper mapper)
        {
            _formaPagamentoService = formaPagamentoService;
            _mapper = mapper;
        }

        // GET: FormaPagamentoController
        public ActionResult Index()
        {
            var formasPagamento = _formaPagamentoService.GetAll();
            var formaPagamentoModel = _mapper.Map<List<FormaPagamentoModel>>(formasPagamento);
            return View(formaPagamentoModel);
        }

        // GET: FormaPagamentoController/Details/5
        public ActionResult Details(uint id)
        {
            var formaPagamento = _formaPagamentoService.Get(id);
            var formaPagamentoModel = _mapper.Map<FormaPagamentoModel>(formaPagamento);
            return View(formaPagamentoModel);
        }

        // GET: FormaPagamentoController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: FormaPagamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormaPagamentoModel formaPagamentoModel)
        {
            if (ModelState.IsValid)
            {
                var formaPagamento = _mapper.Map<Formapagamento>(formaPagamentoModel);
                _formaPagamentoService.Create(formaPagamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: FormaPagamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            var formaPagamento = _formaPagamentoService.Get((uint)id);
            var formaPagamentoModel = _mapper.Map<FormaPagamentoModel>(formaPagamento);
            return View(formaPagamentoModel);
        }

        // POST: FormaPagamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormaPagamentoModel formaPagamentoModel)
        {
            
            if (ModelState.IsValid)
            {
                var formaPagamento = _mapper.Map<Formapagamento>(formaPagamentoModel);
                _formaPagamentoService.Edit(formaPagamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: FormaPagamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            var formaPagamento = _formaPagamentoService.Get((uint)id);
            var formaPagamentoModel = _mapper.Map<FormaPagamentoModel>(formaPagamento);
            return View(formaPagamentoModel);
        }

        // POST: FormaPagamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, IFormCollection collection)
        {
                _formaPagamentoService.Delete(id);
                return RedirectToAction(nameof(Index));
        }
    }
}
