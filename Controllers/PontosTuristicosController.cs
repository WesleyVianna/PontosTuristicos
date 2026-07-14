using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontosTuristicos.Data;
using PontosTuristicos.Models;

namespace PontosTuristicos.Controllers
{
    public class PontosTuristicosController : Controller
    {
        private readonly AppDbContext _context;

        public PontosTuristicosController(AppDbContext context)
        {
            _context = context;
        }


        // Lista pontos turísticos
        public async Task<IActionResult> Index()
        {
            var pontos = await _context.PontosTuristicos
                .OrderByDescending(x => x.DataInclusao)
                .ToListAsync();

            return View(pontos);
        }


        // Tela cadastro
        public IActionResult Novo()
        {
            return View();
        }


        // Salvar cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(PontoTuristico ponto)
        {
            if (ModelState.IsValid)
            {
                ponto.DataInclusao = DateTime.Now;

                _context.Add(ponto);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(ponto);
        }


        // Detalhes
        public async Task<IActionResult> Detalhes(int id)
        {
            var ponto = await _context.PontosTuristicos
                .FirstOrDefaultAsync(x => x.Id == id);


            if (ponto == null)
            {
                return NotFound();
            }


            return View(ponto);
        }
    }
}