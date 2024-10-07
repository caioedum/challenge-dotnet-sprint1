using ChallengeDotnet.Data;
using ChallengeDotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChallengeDotnet.Controllers
{
    public class PrevisaoController : Controller
    {
        private readonly dbContext _context;

        public PrevisaoController(dbContext context)
        {
            _context = context;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Previsoes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? PrevisaoUsuarioId)
        {
            if (PrevisaoUsuarioId == null)
            {
                return NotFound();
            }

            var previsoes = await _context.Previsoes
                .FirstOrDefaultAsync(m => m.PrevisaoUsuarioId == PrevisaoUsuarioId);
            if (previsoes == null)
            {
                return NotFound();
            }

            return View(previsoes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImagemUsuarioId, UsuarioId, PrevisaoTexto, Probabilidade, Recomendacao, DataPrevisao")] Previsao previsoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(previsoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(previsoes);
        }

        public async Task<IActionResult> Edit(int PrevisaoUsuarioId)
        {
            var previsoes = await _context.Atendimentos.FindAsync(PrevisaoUsuarioId);
            if (previsoes == null)
            {
                return NotFound();
            }
            return View(previsoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int PrevisaoUsuarioId, [Bind("ImagemUsuarioId, UsuarioId, PrevisaoTexto, Probabilidade, Recomendacao, DataPrevisao")] Previsao previsoes)
        {
            if (PrevisaoUsuarioId != previsoes.PrevisaoUsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(previsoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrevisoesExists(previsoes.PrevisaoUsuarioId))
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
            return View(previsoes);
        }

        public async Task<IActionResult> Delete(int? PrevisaoUsuarioId)
        {
            if (PrevisaoUsuarioId == null)
            {
                return NotFound();
            }

            var previsoes = await _context.Previsoes
                .FirstOrDefaultAsync(m => m.PrevisaoUsuarioId == PrevisaoUsuarioId);
            if (previsoes == null)
            {
                return NotFound();
            }

            return View(previsoes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int PrevisaoUsuarioId)
        {
            var previsoes = await _context.Previsoes.FindAsync(PrevisaoUsuarioId);
            _context.Previsoes.Remove(previsoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrevisoesExists(int PrevisaoUsuarioId)
        {
            return _context.Previsoes.Any(e => e.PrevisaoUsuarioId == PrevisaoUsuarioId);
        }


    }
}
