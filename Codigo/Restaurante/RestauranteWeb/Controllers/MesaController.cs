using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteWeb.Controllers
{
    public class MesaController : Controller
    {

        private readonly IMesaService _mesaService;
        private readonly IMapper _mapper;

        public MesaController(IMesaService mesaService, IMapper mapper)
        {
            _mesaService = mesaService;
            _mapper = mapper;
        }

        // GET: MesaController
        public ActionResult Index()
        {
            var mesas = _mesaService.GetAll();
            var mesaModel = _mapper.Map<List<Models.MesaModel>>(mesas);

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

            return View();
        }

        // POST: MesaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var mesa = _mapper.Map<Core.Mesa>(collection);
                _mesaService.Create(mesa);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: MesaController/Edit/5
        public ActionResult Edit(int id)
        {
            var mesa = _mesaService.Get(id);
            var mesaModel = _mapper.Map<Models.MesaModel>(mesa);

            return View();
        }

        // POST: MesaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if(ModelState.IsValid)
            {
                var mesa = _mapper.Map<Core.Mesa>(collection);
                mesa.Id = id;
                _mesaService.Edit(mesa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MesaController/Delete/5
        public ActionResult Delete(int id)
        {
            var mesa = _mesaService.Get(id);
            var mesaModel = _mapper.Map<Models.MesaModel>(mesa);
            return View();
        }

        // POST: MesaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _mesaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
