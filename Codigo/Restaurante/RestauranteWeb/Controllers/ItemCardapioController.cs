using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class ItemCardapioController : Controller
    {
        private readonly IItemCardapioService _itemCardapioService;
        private readonly IMapper _mapper;

        public ItemCardapioController(IItemCardapioService itemCardapioService, IMapper mapper)
        {
            _itemCardapioService = itemCardapioService;
            _mapper = mapper;
        }

        // GET: ItemCardapioController
        public ActionResult Index()
        {
            var itensCardapio = _itemCardapioService.GetAll();
            var itemCardapioModel = _mapper.Map<List<ItemCardapioModel>>(itensCardapio);

            return View(itemCardapioModel);
        }

        // GET: ItemCardapioController/Details/5
        public ActionResult Details(int id)
        {
            var itemCardapio = _itemCardapioService.Get(id);
            var itemCardapioModel = _mapper.Map<ItemCardapioModel>(itemCardapio);
            return View(itemCardapioModel);
        }

        // GET: ItemCardapioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemCardapioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCardapioModel itemCardapioModel)
        {
            if (ModelState.IsValid)
            {
                var itemCardapio = _mapper.Map<Itemcardapio>(itemCardapioModel);
                _itemCardapioService.Create(itemCardapio);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ItemCardapioController/Edit/5
        public ActionResult Edit(int id)
        {
            Itemcardapio itemCardapio = _itemCardapioService.Get(id);
            ItemCardapioModel itemCardapioModel = _mapper.Map<ItemCardapioModel>(itemCardapio);
            return View(itemCardapioModel);
        }

        // POST: ItemCardapioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemCardapioModel itemCardapioModel)
        {
            if (ModelState.IsValid)
            {
                var itemCardapio = _mapper.Map<Itemcardapio>(itemCardapioModel);
                _itemCardapioService.Edit(itemCardapio);
                return RedirectToAction(nameof(Index));
            }

            return View(itemCardapioModel);
        }

        // GET: ItemCardapioController/Delete/5
        public ActionResult Delete(int id)
        {
            var itemCardapio = _itemCardapioService.Get(id);
            var itemCardapioModel = _mapper.Map<ItemCardapioModel>(itemCardapio);
            return View(itemCardapioModel);
        }

        // POST: ItemCardapioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ItemCardapioModel itemCardapioModel)
        {
            _itemCardapioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
