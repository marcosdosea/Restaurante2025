using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class TipoFuncionarioController : Controller
    {
        private readonly ITipoFuncionario _tipoFuncionarioService;
        private readonly IMapper _mapper;

        public TipoFuncionarioController(ITipoFuncionario tipoFuncionarioService, IMapper mapper)
        {
            _tipoFuncionarioService = tipoFuncionarioService;
            _mapper = mapper;
        }

        // GET: TipoFuncionarioController
        public IActionResult Index()
        {
            var tiposFuncionario = _tipoFuncionarioService.GetAll();
            var model = _mapper.Map<List<TipoFuncionarioModel>>(tiposFuncionario);
            return View(model);
        }

        // GET: TipoFuncionarioController/Details/5
        public IActionResult Details(int id)
        {
            var tipoFuncionario = _tipoFuncionarioService.Get(id);
            var model = _mapper.Map<TipoFuncionarioModel>(tipoFuncionario);
            return View(model);
        }

        // GET: TipoFuncionarioController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoFuncionarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoFuncionarioModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Tipofuncionario>(model);
                _tipoFuncionarioService.Create(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: TipoFuncionarioController/Edit/5
        public IActionResult Edit(int id)
        {
            var tipoFuncionario = _tipoFuncionarioService.Get(id);
            var model = _mapper.Map<TipoFuncionarioModel>(tipoFuncionario);
            return View(model);
        }

        // POST: TipoFuncionarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TipoFuncionarioModel model)
        {
            if (id != model.Id)
            {
                ModelState.AddModelError(string.Empty, "ID inválido.");
            }
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Tipofuncionario>(model);
                _tipoFuncionarioService.Edit(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: TipoFuncionarioController/Delete/5
        public IActionResult Delete(int id)
        {
            var tipoFuncionario = _tipoFuncionarioService.Get(id);
            var model = _mapper.Map<TipoFuncionarioModel>(tipoFuncionario);
            return View(model);
        }

        // POST: TipoFuncionarioController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _tipoFuncionarioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
