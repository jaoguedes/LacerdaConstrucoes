﻿using System;
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
    public class CadComprasController : Controller
    {
        private readonly Context _context;

        public CadComprasController(Context context)
        {
            _context = context;
        }

        // GET: CadCompras
        public async Task<IActionResult> Index()
        {
            var context = _context.CadCompras.Include(c => c.Fornecedor);
            return View(await context.ToListAsync());
        }

        // GET: CadCompras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CadCompras == null)
            {
                return NotFound();
            }

            var cadCompras = await _context.CadCompras
                .Include(c => c.Fornecedor)
                .FirstOrDefaultAsync(m => m.CadComprasId == id);
            if (cadCompras == null)
            {
                return NotFound();
            }

            return View(cadCompras);
        }

        // GET: CadCompras/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorId");
            return View();
        }

        // POST: CadCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadComprasId,NotaDaCompra,DataDaCompra,FornecedorId")] CadCompras cadCompras)
        {
            if (ModelState.IsValid)
            {
                cadCompras.CadComprasId = Guid.NewGuid();
                _context.Add(cadCompras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorId", cadCompras.FornecedorId);
            return View(cadCompras);
        }

        // GET: CadCompras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CadCompras == null)
            {
                return NotFound();
            }

            var cadCompras = await _context.CadCompras.FindAsync(id);
            if (cadCompras == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorId", cadCompras.FornecedorId);
            return View(cadCompras);
        }

        // POST: CadCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CadComprasId,NotaDaCompra,DataDaCompra,FornecedorId")] CadCompras cadCompras)
        {
            if (id != cadCompras.CadComprasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadCompras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadComprasExists(cadCompras.CadComprasId))
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
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorId", cadCompras.FornecedorId);
            return View(cadCompras);
        }

        // GET: CadCompras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CadCompras == null)
            {
                return NotFound();
            }

            var cadCompras = await _context.CadCompras
                .Include(c => c.Fornecedor)
                .FirstOrDefaultAsync(m => m.CadComprasId == id);
            if (cadCompras == null)
            {
                return NotFound();
            }

            return View(cadCompras);
        }

        // POST: CadCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CadCompras == null)
            {
                return Problem("Entity set 'Context.CadCompras'  is null.");
            }
            var cadCompras = await _context.CadCompras.FindAsync(id);
            if (cadCompras != null)
            {
                _context.CadCompras.Remove(cadCompras);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadComprasExists(Guid id)
        {
          return (_context.CadCompras?.Any(e => e.CadComprasId == id)).GetValueOrDefault();
        }
    }
}
