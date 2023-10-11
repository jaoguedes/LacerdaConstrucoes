using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LacerdaContrucoes.Data;
using LacerdaContrucoes.Models;

namespace LacerdaContrucoes.Controllers
{
    public class ComprasController : Controller
    {
        private readonly Context _context;

        public ComprasController(Context context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index(string? id)
        {
            var context = _context.Compra.Where(i => i.CadComprasId.ToString() == id).Include(c => c.CadCompras).Include(c => c.Produto);
            if (id != null)
            {
                ViewData["idCompra"] = id;
            }
            return View(await context.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .Include(c => c.CadCompras)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create(string? id)
        {
            ViewData["CadComprasId"] = new SelectList(_context.CadCompras, "CadComprasId", "CadComprasId");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId");
            ViewData["idCompra"] = id;
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompraId,CadComprasId,qtdCompra,ProdutoId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                compra.CompraId = Guid.NewGuid();
                _context.Add(compra);
                await _context.SaveChangesAsync();
                var prod = _context.Produtos.FirstOrDefault(i => i.ProdutoId == compra.ProdutoId);
                    prod.qnt = prod.qnt + compra.qtdCompra;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = compra.CadComprasId });
            }
            ViewData["CadComprasId"] = new SelectList(_context.CadCompras, "CadComprasId", "CadComprasId", compra.CadComprasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", compra.ProdutoId);

            await _context.SaveChangesAsync();
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["CadComprasId"] = new SelectList(_context.CadCompras, "CadComprasId", "CadComprasId", compra.CadComprasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", compra.ProdutoId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CompraId,CadComprasId,qtdCompra,ProdutoId")] Compra compra)
        {
            if (id != compra.CompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.CompraId))
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
            ViewData["CadComprasId"] = new SelectList(_context.CadCompras, "CadComprasId", "CadComprasId", compra.CadComprasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", compra.ProdutoId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .Include(c => c.CadCompras)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Compra == null)
            {
                return Problem("Entity set 'Context.Compra'  is null.");
            }
            var compra = await _context.Compra.FindAsync(id);
            if (compra != null)
            {
                _context.Compra.Remove(compra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(Guid id)
        {
          return (_context.Compra?.Any(e => e.CompraId == id)).GetValueOrDefault();
        }
    }
}
