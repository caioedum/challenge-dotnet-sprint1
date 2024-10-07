using ChallengeDotnet.Data;
using ChallengeDotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChallengeDotnet.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly dbContext _context;

        public AtendimentoController(dbContext context)
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
            return View(await _context.Atendimentos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? AtendimentoId)
        {
            if (AtendimentoId == null)
            {
                return NotFound();
            }

            var atendimentos = await _context.Atendimentos
                .FirstOrDefaultAsync(m => m.AtendimentoId == AtendimentoId);
            if (atendimentos == null)
            {
                return NotFound();
            }

            return View(atendimentos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId, DentistaNome, ClinicaNome, DataAtendimento, DescricaoProcedimento, Custo, DataRegistro")] Atendimento atendimentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendimentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atendimentos);
        }

        public async Task<IActionResult> Edit(int AtendimentoId)
        {
            /* Professor, tentei desvendar porque a model está vindo como null na view mas não consegui,
             espero que possa considerar a criação do método */
            var atendimentos = await _context.Atendimentos.FindAsync(AtendimentoId);
            if (atendimentos == null)
            {
                return NotFound();
            }
            return View(atendimentos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int AtendimentoId, [Bind("AtendimentoId, UsuarioId, DentistaNome, ClinicaNome, DataAtendimento, DescricaoProcedimento, Custo, DataRegistro")] Atendimento atendimentos)
        {
            if (AtendimentoId != atendimentos.AtendimentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentosExists(atendimentos.AtendimentoId))
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
            return View(atendimentos);
        }

        public async Task<IActionResult> Delete(int? AtendimentoId)
        {
            if (AtendimentoId == null)
            {
                return NotFound();
            }

            var atendimentos = await _context.Atendimentos
                .FirstOrDefaultAsync(m => m.AtendimentoId == AtendimentoId);
            if (atendimentos == null)
            {
                return NotFound();
            }

            return View(atendimentos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int AtendimentoId)
        {
            var atendimentos = await _context.Atendimentos.FindAsync(AtendimentoId);
            _context.Atendimentos.Remove(atendimentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentosExists(int AtendimentoId)
        {
            return _context.Atendimentos.Any(e => e.AtendimentoId == AtendimentoId);
        }
    }
}
