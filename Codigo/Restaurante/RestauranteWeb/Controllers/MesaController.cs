using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class MesaController : Controller
    {
        private readonly IMesaService _mesaService;
        private readonly IMapper _mapper;
        private readonly IRestauranteService _restauranteService;
        private readonly RestauranteContext _context;

        public MesaController(IMesaService mesaService, IMapper mapper,
                            IRestauranteService restauranteService,
                            RestauranteContext context)
        {
            _mesaService = mesaService;
            _mapper = mapper;
            _restauranteService = restauranteService;
            _context = context;
        }

        private void CarregarRestaurantes()
        {
            var restaurantes = _restauranteService.GetAll();
            ViewBag.IdRestaurante = new SelectList(restaurantes, "Id", "Nome");
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var query = _mesaService.GetAll().AsQueryable();
            var totalItems = query.Count();
            var mesas = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var mesaModel = _mapper.Map<List<Models.MesaModel>>(mesas);
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewBag.CurrentPage = page;
            return View(mesaModel);
        }

        public ActionResult Details(int id)
        {
            var mesa = _mesaService.Get(id);
            var mesaModel = _mapper.Map<Models.MesaModel>(mesa);
            return View(mesaModel);
        }

        public ActionResult Create()
        {
            CarregarRestaurantes();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.MesaModel mesaModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mesa = new Core.Mesa
                    {
                        Numero = mesaModel.Numero,
                        Capacidade = mesaModel.Capacidade,
                        IdRestaurante = mesaModel.IdRestaurante,
                        Identificacao = mesaModel.Identificacao,
                        Ativo = true
                    };

                    _context.Mesas.Add(mesa);
                    _context.SaveChanges();

                    var atendimento = new Atendimento
                    {
                        IdMesa = mesa.Id,
                        DataHoraInicio = DateTime.Now,
                        Status = "I",
                        TotalConta = 0,
                        TotalServico = 0,
                        TotalDesconto = 0,
                        Total = 0
                    };

                    _context.Atendimentos.Add(atendimento);
                    _context.SaveChanges();

                    return RedirectToAction("RegistrarPedido", "Pedido", new
                    {
                        atendimentoId = atendimento.Id
                    });
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = $"Erro: {ex.Message}";
                }
            }

            CarregarRestaurantes();
            return View(mesaModel);
        }

        public ActionResult Edit(int id)
        {
            var mesa = _mesaService.Get(id);
            var mesaModel = _mapper.Map<Models.MesaModel>(mesa);
            CarregarRestaurantes();
            return View(mesaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.MesaModel mesaModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mesa = _mapper.Map<Core.Mesa>(mesaModel);
                    mesa.Id = id;
                    _mesaService.Edit(mesa);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar mesa: {ex.Message}");
                }
            }
            CarregarRestaurantes();
            return View(mesaModel);
        }

        public ActionResult Delete(int id)
        {
            var mesa = _mesaService.Get(id);
            var mesaModel = _mapper.Map<Models.MesaModel>(mesa);
            return View(mesaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Models.MesaModel mesaModel)
        {
            try
            {
                _mesaService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}