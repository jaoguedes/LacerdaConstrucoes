using LacerdaContrucoes.Data;
using LacerdaContrucoes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LacerdaContrucoes.Controllers
{
    public class CategoriaDeProdutosController : Controller
    {
        private readonly Context _context;

        public CategoriaDeProdutosController(Context context)
        {
            _context = context;
        }

        // GET: CategoriaDeProdutos
        public async Task<IActionResult> Index()
        {
            return _context.CategoriaDeProdutos != null ?
                        View(await _context.CategoriaDeProdutos.ToListAsync()) :
                        Problem("Entity set 'Context.CategoriaDeProdutos'  is null.");
        }

        // GET: CategoriaDeProdutos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CategoriaDeProdutos == null)
            {
                return NotFound();
            }

            var categoriaDeProdutos = await _context.CategoriaDeProdutos
                .FirstOrDefaultAsync(m => m.CategoriaDeProdutosId == id);
            if (categoriaDeProdutos == null)
            {
                return NotFound();
            }

            return View(categoriaDeProdutos);
        }

        // GET: CategoriaDeProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaDeProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaDeProdutosId,NomeDaCategoria")] CategoriaDeProdutos categoriaDeProdutos)
        {
            if (ModelState.IsValid)
            {
                categoriaDeProdutos.CategoriaDeProdutosId = Guid.NewGuid();
                _context.Add(categoriaDeProdutos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDeProdutos);
        }

        // GET: CategoriaDeProdutos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CategoriaDeProdutos == null)
            {
                return NotFound();
            }

            var categoriaDeProdutos = await _context.CategoriaDeProdutos.FindAsync(id);
            if (categoriaDeProdutos == null)
            {
                return NotFound();
            }
            return View(categoriaDeProdutos);
        }

        // POST: CategoriaDeProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoriaDeProdutosId,NomeDaCategoria")] CategoriaDeProdutos categoriaDeProdutos)
        {
            if (id != categoriaDeProdutos.CategoriaDeProdutosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaDeProdutos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaDeProdutosExists(categoriaDeProdutos.CategoriaDeProdutosId))
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
            return View(categoriaDeProdutos);
        }

        // GET: CategoriaDeProdutos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CategoriaDeProdutos == null)
            {
                return NotFound();
            }

            var categoriaDeProdutos = await _context.CategoriaDeProdutos
                .FirstOrDefaultAsync(m => m.CategoriaDeProdutosId == id);
            if (categoriaDeProdutos == null)
            {
                return NotFound();
            }

            return View(categoriaDeProdutos);
        }

        // POST: CategoriaDeProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CategoriaDeProdutos == null)
            {
                return Problem("Entity set 'Context.CategoriaDeProdutos'  is null.");
            }
            var categoriaDeProdutos = await _context.CategoriaDeProdutos.FindAsync(id);
            if (categoriaDeProdutos != null)
            {
                _context.CategoriaDeProdutos.Remove(categoriaDeProdutos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaDeProdutosExists(Guid id)
        {
            return (_context.CategoriaDeProdutos?.Any(e => e.CategoriaDeProdutosId == id)).GetValueOrDefault();
        }
    }
}
