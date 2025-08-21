using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class TipoRestauranteController : Controller
    {
        private readonly ITipoRestauranteService _tipoRestauranteService;
        private readonly IMapper _mapper;

        public TipoRestauranteController(ITipoRestauranteService tipoRestauranteService, IMapper mapper)
        {
            _tipoRestauranteService = tipoRestauranteService;
            _mapper = mapper;
        }

        // GET: TipoRestauranteController
        public IActionResult Index()
        {
            var tiposRestaurante = _tipoRestauranteService.GetAll();
            var model = _mapper.Map<List<TipoRestauranteModel>>(tiposRestaurante);
            return View(model);
        }

        // GET: TipoRestauranteController/Details/5
        public IActionResult Details(int id)
        {
            var tipoRestaurante = _tipoRestauranteService.Get(id);
            var model = _mapper.Map<TipoRestauranteModel>(tipoRestaurante);
            return View(model);
        }

        // GET: TipoRestauranteController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRestauranteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoRestauranteModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Tiporestaurante>(model);
                _tipoRestauranteService.Create(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: TipoRestauranteController/Edit/5
        public IActionResult Edit(int id)
        {
            var tipoRestaurante = _tipoRestauranteService.Get(id);
            var model = _mapper.Map<TipoRestauranteModel>(tipoRestaurante);
            return View(model);
        }

        // POST: TipoRestauranteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TipoRestauranteModel model)
        {
            if (id != model.Id)
            {
                ModelState.AddModelError(string.Empty, "ID inválido.");
            }
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Tiporestaurante>(model);
                _tipoRestauranteService.Edit(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: TipoRestauranteController/Delete/5
        public IActionResult Delete(int id)
        {
            var tipoRestaurante = _tipoRestauranteService.Get(id);
            var model = _mapper.Map<TipoRestauranteModel>(tipoRestaurante);
            return View(model);
        }

        // POST: TipoRestauranteController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _tipoRestauranteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}