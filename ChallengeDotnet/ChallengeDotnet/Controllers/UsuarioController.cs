using ChallengeDotnet.Data;
using ChallengeDotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace ChallengeDotnet.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly dbContext _context;

        public UsuarioController (dbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Details(int? UsuarioId)
        {
            if (UsuarioId == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == UsuarioId);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId, CPF, Nome, Sobrenome, Email, Senha, DataNascimento, Genero, DataCadastro")] Usuario usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        public async Task<IActionResult> Edit(int UsuarioId)
        {

            var usuarios = await _context.Usuarios.FindAsync(UsuarioId);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int UsuarioId, [Bind("UsuarioId, CPF, Nome, Sobrenome, Email, Senha, DataNascimento, Genero, DataCadastro")] Usuario usuarios)
        {
            if (UsuarioId != usuarios.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.UsuarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        public async Task<IActionResult> Delete(int? UsuarioId)
        {
            if (UsuarioId == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == UsuarioId);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int UsuarioId)
        {
            var usuarios = await _context.Usuarios.FindAsync(UsuarioId);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int UsuarioId)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == UsuarioId);
        }
    }
}
