using LacerdaContrucoes.Data;
using LacerdaContrucoes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LacerdaContrucoes.Controllers
{
    public class CadVendasController : Controller
    {
        private readonly Context _context;

        public CadVendasController(Context context)
        {
            _context = context;
        }

        // GET: CadVendas
        public async Task<IActionResult> Index()
        {
            var context = _context.CadVendas.Include(c => c.Cliente);
            return View(await context.ToListAsync());
        }

        // GET: CadVendas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CadVendas == null)
            {
                return NotFound();
            }

            var cadVendas = await _context.CadVendas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.CadVendasId == id);
            if (cadVendas == null)
            {
                return NotFound();
            }

            return View(cadVendas);
        }

        // GET: CadVendas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            return View();
        }

        // POST: CadVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadVendasId,NotaDaVenda,DataDaVenda,ClienteId")] CadVendas cadVendas)
        {
            if (ModelState.IsValid)
            {
                cadVendas.CadVendasId = Guid.NewGuid();
                _context.Add(cadVendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", cadVendas.ClienteId);
            return View(cadVendas);
        }

        // GET: CadVendas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CadVendas == null)
            {
                return NotFound();
            }

            var cadVendas = await _context.CadVendas.FindAsync(id);
            if (cadVendas == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", cadVendas.ClienteId);
            return View(cadVendas);
        }

        // POST: CadVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CadVendasId,NotaDaVenda,DataDaVenda,ClienteId")] CadVendas cadVendas)
        {
            if (id != cadVendas.CadVendasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadVendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadVendasExists(cadVendas.CadVendasId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", cadVendas.ClienteId);
            return View(cadVendas);
        }

        // GET: CadVendas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CadVendas == null)
            {
                return NotFound();
            }

            var cadVendas = await _context.CadVendas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.CadVendasId == id);
            if (cadVendas == null)
            {
                return NotFound();
            }

            return View(cadVendas);
        }

        // POST: CadVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CadVendas == null)
            {
                return Problem("Entity set 'Context.CadVendas'  is null.");
            }
            var cadVendas = await _context.CadVendas.FindAsync(id);
            if (cadVendas != null)
            {
                _context.CadVendas.Remove(cadVendas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadVendasExists(Guid id)
        {
            return (_context.CadVendas?.Any(e => e.CadVendasId == id)).GetValueOrDefault();
        }
    }
}
