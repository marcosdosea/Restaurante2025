using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;
using Core.Service;
using AutoMapper;

namespace RestauranteWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestauranteService _restauranteService;
        private readonly IItemCardapioService _itemCardapioService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IRestauranteService restauranteService, IItemCardapioService itemCardapioService, IMapper mapper)
        {
            _logger = logger;
            _restauranteService = restauranteService;
            _itemCardapioService = itemCardapioService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var restaurantes = _restauranteService.GetAll().Take(6).ToList();
            var cardapios = _itemCardapioService.GetAll().Take(6).ToList();
            ViewBag.Restaurantes = restaurantes;
            ViewBag.Cardapios = cardapios;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
