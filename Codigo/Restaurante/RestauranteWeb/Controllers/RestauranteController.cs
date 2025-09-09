using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Models;
using System.Collections.Generic;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class RestauranteController : Controller
    {
        private readonly IRestauranteService _restauranteService;
        private readonly ITipoRestauranteService _tipoRestauranteService;
        private readonly IMapper _mapper;

        public RestauranteController(
            IRestauranteService restauranteService,
            ITipoRestauranteService tipoRestauranteService,
            IMapper mapper)
        {
            _restauranteService = restauranteService;
            _tipoRestauranteService = tipoRestauranteService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var restaurantes = _restauranteService.GetAll();
            var model = _mapper.Map<List<RestauranteModel>>(restaurantes);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var restaurante = _restauranteService.Get(id);
            var model = _mapper.Map<RestauranteModel>(restaurante);
            return View(model);
        }

        public IActionResult Create()
        {
            CarregarTiposRestaurante();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestauranteModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = _mapper.Map<Restaurante>(model);
                    _restauranteService.Create(entity);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Erro ao criar restaurante: {ex.Message}");
                }
            }

            CarregarTiposRestaurante();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var restaurante = _restauranteService.Get(id);
            var model = _mapper.Map<RestauranteModel>(restaurante);
            CarregarTiposRestaurante();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestauranteModel model)
        {
            if (id != model.Id)
            {
                ModelState.AddModelError(string.Empty, "ID inválido.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = _mapper.Map<Restaurante>(model);
                    _restauranteService.Edit(entity);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Erro ao editar restaurante: {ex.Message}");
                }
            }

            CarregarTiposRestaurante();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var restaurante = _restauranteService.Get(id);
            var model = _mapper.Map<RestauranteModel>(restaurante);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _restauranteService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Erro ao deletar restaurante: {ex.Message}");
                return View("Delete", _mapper.Map<RestauranteModel>(_restauranteService.Get(id)));
            }
        }
        private void CarregarTiposRestaurante()
        {
            var tiposRestaurante = _tipoRestauranteService.GetAll();
            ViewBag.TiposRestaurante = new SelectList(tiposRestaurante, "Id", "Nome");
        }
    }
}