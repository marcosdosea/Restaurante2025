using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RestauranteWeb.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly RestauranteContext _context;

        public FuncionarioController(RestauranteContext context)
        {
            _context = context;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Funcionario funcionario)
        {
            System.Diagnostics.Debug.WriteLine("POST Create chamado");
            if (ModelState.IsValid)
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TiposFuncionario = new SelectList(_context.Tipofuncionarios, "Id", "Nome", funcionario.IdTipoFuncionario);
            return View(funcionario);
        }

    public IActionResult Edit(uint id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewBag.TiposFuncionario = new SelectList(_context.Tipofuncionarios, "Id", "Nome", funcionario.IdTipoFuncionario);
            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Funcionarios.Update(funcionario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TiposFuncionario = new SelectList(_context.Tipofuncionarios, "Id", "Nome", funcionario.IdTipoFuncionario);
            return View(funcionario);
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
