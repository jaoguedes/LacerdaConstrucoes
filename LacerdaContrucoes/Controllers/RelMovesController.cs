using LacerdaContrucoes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LacerdaContrucoes.Controllers
{
    public class RelMovesController : Controller
    {
        private readonly Context _context;

        public RelMovesController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var context = _context.Produtos.Include(p => p.CategoriaDeProdutos).Include(p => p.Fornecedor);
            return View(await context.ToListAsync());

        }

        public async Task<IActionResult> Filter(string? dateIn, string? dateOf, string? tipoMove, string? prods)
        {
            return View();
        }
    }
}
