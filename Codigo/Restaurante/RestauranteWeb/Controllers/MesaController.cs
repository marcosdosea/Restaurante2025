using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class MesaController : Controller
    {

        private readonly IMesaService _mesaService;
        private readonly IMapper _mapper;
        private readonly IRestauranteService _restauranteService;

        public MesaController(IMesaService mesaService, IMapper mapper, IRestauranteService restauranteService)
        {
            _mesaService = mesaService;
            _mapper = mapper;
            _restauranteService = restauranteService;
        }

        private void CarregarRestaurantes()
        {
            var restaurantes = _restauranteService.GetAll();
            ViewBag.IdRestaurante = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(restaurantes, "Id", "Nome");
        }

        // GET: MesaController
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

        // GET: MesaController/Details/5
        public ActionResult Details(int id)
        {
            var mesa = _mesaService.Get(id);
            var mesaModel = _mapper.Map<Models.MesaModel>(mesa);
            return View(mesaModel);
        }

        // GET: MesaController/Create
        public ActionResult Create()
        {
            CarregarRestaurantes();
            return View();
        }

        // POST: MesaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.MesaModel mesaModel)
        {
            if (ModelState.IsValid)
            {
                var mesa = _mapper.Map<Core.Mesa>(mesaModel);
                _mesaService.Create(mesa);
                return RedirectToAction(nameof(Index));
            }
            CarregarRestaurantes();
            // Exibe os erros de validação na view
            return View(mesaModel);
        }

        // GET: MesaController/Edit/5
        public ActionResult Edit(int id)
        {
            var mesa = _mesaService.Get(id);
            var mesaModel = _mapper.Map<Models.MesaModel>(mesa);
            return View(mesaModel);
        }

        // POST: MesaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.MesaModel mesaModel)
        {
            if(ModelState.IsValid)
            {
                var mesa = _mapper.Map<Core.Mesa>(mesaModel);
                mesa.Id = id;
                _mesaService.Edit(mesa);
                return RedirectToAction(nameof(Index));
            }
            return View(mesaModel);
        }

        // GET: MesaController/Delete/5
        public ActionResult Delete(int id)
        {
            var mesa = _mesaService.Get(id);
            var mesaModel = _mapper.Map<Models.MesaModel>(mesa);
            return View(mesaModel);
        }

        // POST: MesaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Models.MesaModel mesaModel)
        {
            _mesaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
