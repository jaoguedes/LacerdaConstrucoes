using LacerdaContrucoes.Data;
using LacerdaContrucoes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LacerdaContrucoes.Controllers
{
    public class VendasController : Controller
    {
        private readonly Context _context;

        public VendasController(Context context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index(string? id)
        {
            var context = _context.Venda.Where(i => i.CadVendasId.ToString() == id).Include(v => v.CadVendas).Include(v => v.Produto);
            if(id != null)
            {
                ViewData["idVenda"] = id;
            }

            return View(await context.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.CadVendas)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create(string? id)
        {
            ViewData["CadVendasId"] = new SelectList(_context.CadVendas, "CadVendasId", "CadVendasId");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId");
            ViewData["idVenda"] = id;
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaId,CadVendasId,qtdVendas,ProdutoId")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                venda.VendaId = Guid.NewGuid();
                _context.Add(venda);
                await _context.SaveChangesAsync(); 

                var prod = _context.Produtos.FirstOrDefault(i => i.ProdutoId == venda.ProdutoId);
                    prod.qnt = prod.qnt - venda.qtdVendas;
                    await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = venda.CadVendasId });
            }
            ViewData["CadVendasId"] = new SelectList(_context.CadVendas, "CadVendasId", "CadVendasId", venda.CadVendasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", venda.ProdutoId);
           await _context.SaveChangesAsync();
           return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["CadVendasId"] = new SelectList(_context.CadVendas, "CadVendasId", "CadVendasId", venda.CadVendasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", venda.ProdutoId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("VendaId,CadVendasId,qtdVendas,ProdutoId")] Venda venda)
        {
            if (id != venda.VendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.VendaId))
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
            ViewData["CadVendasId"] = new SelectList(_context.CadVendas, "CadVendasId", "CadVendasId", venda.CadVendasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", venda.ProdutoId);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.CadVendas)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Venda == null)
            {
                return Problem("Entity set 'Context.Venda'  is null.");
            }
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(Guid id)
        {
            return (_context.Venda?.Any(e => e.VendaId == id)).GetValueOrDefault();
        }
    }
}
