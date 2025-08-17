using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class GrupoCardapioController : Controller
    {
        private readonly IGrupoCardapioService _grupoCardapioService;
        private readonly IMapper _mapper;

        public GrupoCardapioController(IGrupoCardapioService grupoCardapioService, IMapper mapper)
        {
            _grupoCardapioService = grupoCardapioService;
            _mapper = mapper;
        }

        // GET: GrupoCardapioController
        public ActionResult Index()
        {
            var gruposCardapio = _grupoCardapioService.GetAll();
            var grupoCardapioModel = _mapper.Map<List<GrupoCardapioModel>>(gruposCardapio);
            return View(grupoCardapioModel);
        }

        // GET: GrupoCardapioController/Details/5
        public ActionResult Details(uint id)
        {
            Grupocardapio grupocardapio = _grupoCardapioService.Get(id);
            GrupoCardapioModel grupoCardapioModel = _mapper.Map<GrupoCardapioModel>(grupocardapio);
            return View(grupoCardapioModel);
        }

        // GET: GrupoCardapioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoCardapioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GrupoCardapioModel grupoCardapioModel)
        {
            if (ModelState.IsValid)
            {
                var grupocardapio = _mapper.Map<Grupocardapio>(grupoCardapioModel);
                _grupoCardapioService.Create(grupocardapio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: GrupoCardapioController/Edit/5
        public ActionResult Edit(int id)
        {
            Grupocardapio grupocardapio = _grupoCardapioService.Get((uint)id);
            GrupoCardapioModel grupoCardapioModel = _mapper.Map<GrupoCardapioModel>(grupocardapio);
            return View(grupoCardapioModel);
        }

        // POST: GrupoCardapioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GrupoCardapioModel grupoCardapioModel)
        {
            if (ModelState.IsValid)
            {
                var grupocardapio = _mapper.Map<Grupocardapio>(grupoCardapioModel);
                _grupoCardapioService.Edit(grupocardapio);
                return RedirectToAction(nameof(Index));
            }
            return View(grupoCardapioModel);
        }

        // GET: GrupoCardapioController/Delete/5
        public ActionResult Delete(int id)
        {
            Grupocardapio grupocardapio = _grupoCardapioService.Get((uint)id);
            GrupoCardapioModel grupoCardapioModel = _mapper.Map<GrupoCardapioModel>(grupocardapio);
            return View(grupoCardapioModel);
        }

        // POST: GrupoCardapioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, IFormCollection collection)
        {
            _grupoCardapioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
