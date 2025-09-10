using AutoMapper;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public FuncionarioController(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public IActionResult Index()
        {
            var funcionarios = _context.Funcionarios.Include(f => f.IdTipoFuncionarioNavigation).ToList();
            return View(funcionarios);
        }

        public IActionResult Details(uint id)
        {
            var funcionario = _context.Funcionarios.Include(f => f.IdTipoFuncionarioNavigation).FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        public IActionResult Create()
        {
            ViewBag.TiposFuncionario = new SelectList(_context.Tipofuncionarios, "Id", "Nome");
            ViewBag.Restaurantes = new SelectList(_context.Restaurantes, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FuncionarioModel funcionarioModel)
        {
            if (ModelState.IsValid)
            {
                var funcionario = _mapper.Map<Funcionario>(funcionarioModel);
                funcionario.Id = 0;
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TiposFuncionario = new SelectList(_context.Tipofuncionarios, "Id", "Nome", funcionarioModel.IdTipoFuncionario);
            ViewBag.Restaurantes = new SelectList(_context.Restaurantes, "Id", "Nome", funcionarioModel.IdRestaurante);
            return View(funcionarioModel);
        }

        public IActionResult Edit(uint id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            var funcionarioModel = _mapper.Map<FuncionarioModel>(funcionario);
            ViewBag.TiposFuncionario = new SelectList(_context.Tipofuncionarios, "Id", "Nome", funcionarioModel.IdTipoFuncionario);
            ViewBag.Restaurantes = new SelectList(_context.Restaurantes, "Id", "Nome", funcionarioModel.IdRestaurante);
            return View(funcionarioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FuncionarioModel funcionarioModel)
        {
            if (ModelState.IsValid)
            {
                var funcionario = _mapper.Map<Funcionario>(funcionarioModel);
                _context.Funcionarios.Update(funcionario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TiposFuncionario = new SelectList(_context.Tipofuncionarios, "Id", "Nome", funcionarioModel.IdTipoFuncionario);
            ViewBag.Restaurantes = new SelectList(_context.Restaurantes, "Id", "Nome", funcionarioModel.IdRestaurante);
            return View(funcionarioModel);
        }

        public IActionResult Delete(uint id)
        {
            var funcionario = _context.Funcionarios.Include(f => f.IdTipoFuncionarioNavigation).FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(uint id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
