using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoAspNet.Models;
using TrabalhoASPNet.Models;

namespace TrabalhoAspNet.Controllers
{
    public class ComprasController : Controller
    {
        private readonly Contexto _context;

        public ComprasController(Contexto context)
        {
            _context = context;
        }
        [Authorize(Roles = "Administrador")]
        // GET: Compras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compras.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var compra = await _context.Compras
                .FirstOrDefaultAsync(m => m.Id == id);

            if (compra == null)
            {
                return NotFound();
            }
            
            var carrinhoItens = await _context.Carrinhos
                .Include(c => c.Livro)
                .Where(c => c.CompraId == id)
                .ToListAsync();
            
            var viewModel = new ViewCarrinhoCompra
            {
                Compra = compra,
                CarrinhoItens = carrinhoItens
            };

            return View(viewModel);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TotalItens,ValorTotal")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalItens,ValorTotal")] Compra compra)
        {
            if (id != compra.Id)
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
                    if (!CompraExists(compra.Id))
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
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.Id == id);
        }
    }
}
