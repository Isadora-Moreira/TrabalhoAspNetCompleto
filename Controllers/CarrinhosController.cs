using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoASPNet.Models;

namespace TrabalhoAspNet.Controllers
{
    public class CarrinhosController : Controller
    {
        private readonly Contexto _context;

        public CarrinhosController(Contexto context)
        {
            _context = context;
        }
        [Authorize(Roles = "Administrador")]
        // GET: Carrinhos
        // Exibe a lista de itens no carrinho que ainda não foram comprados.
        [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
        public async Task<IActionResult> Index()
        {
            // Se a compra foi finalizada, retorna uma lista vazia.
            if (TempData["CarrinhoEsvaziado"] != null)
            {
                
                return View(new List<Carrinho>());
            }

            // Pega apenas os items que o CompraId é nulo, ou seja, não está associado a uma compra
            var contexto = _context.Carrinhos
                .Include(c => c.Compra)
                .Include(c => c.Livro)
                .Where(c => c.CompraId == null);

            return View(await contexto.ToListAsync());
        }


        // GET: Carrinhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinhos
                .Include(c => c.Compra)
                .Include(c => c.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // GET: Carrinhos/Create
        //Exibe a view para cadastrar um carrinho.
        // Popula listas para seleção de compra e livro.
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compras, "Id", "Id");
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Titulo");
            return View();
        }

        // POST: Carrinhos/Create
        // Valida e cadastra um carrinho.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LivroId,Quantidade")] Carrinho carrinho)
        {
            var livroSelecionado = await _context.Livros.FindAsync(carrinho.LivroId);
            
            // verifica se o livro existe
            if (livroSelecionado == null)
            {
                ModelState.AddModelError("LivroId", "Livro não encontrado.");
            }

            //verifica se a quantidade está disponível em estoque
            if (livroSelecionado != null && carrinho.Quantidade > livroSelecionado.QuantidadeEmEstoque)
            {
                ModelState.AddModelError("Quantidade", "Quantidade inserida excede o estoque disponível.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(carrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LivroId"] = new SelectList(await _context.Livros.ToListAsync(), "Id", "Titulo", carrinho.LivroId);
            return View(carrinho);
        }
        
        private async Task AtualizarEstoque(Livro livro, int quantidade)
        {
            livro.QuantidadeEmEstoque -= quantidade;
            _context.Update(livro);
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Finaliza a compra.
        // Verifica o estoque, atualiza a quantidade disponível
        // cria uma nova compra
        // Se algum item não tiver estoque suficiente, retorna uma mensagem de erro.
        public async Task<IActionResult> SalvarCarrinho(int[] carrinhoIds)
        {
            var compra = new Compra { TotalItens = 0, ValorTotal = 0 };

            
            foreach (var carrinhoId in carrinhoIds)
            {
                var carrinho = await _context.Carrinhos.Include(c => c.Livro).FirstOrDefaultAsync(c => c.Id == carrinhoId);
                if (carrinho != null)
                {
                    if (carrinho.Quantidade > carrinho.Livro.QuantidadeEmEstoque)
                    {
                        ModelState.AddModelError("", $"Estoque insuficiente para o livro: {carrinho.Livro.Titulo}");
                        return View("Carrinhos", carrinhoIds);
                    }

                    await AtualizarEstoque(carrinho.Livro, carrinho.Quantidade);

                    compra.TotalItens += carrinho.Quantidade;
                    compra.ValorTotal += carrinho.Quantidade * carrinho.Livro.Preco;
                }
            }
            compra.DataCompra =  DateOnly.FromDateTime(DateTime.Now);
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            
            // associa a compra aos carrinhos
            foreach (var carrinhoId in carrinhoIds)
            {
                var carrinho = await _context.Carrinhos.FirstOrDefaultAsync(c => c.Id == carrinhoId);
                if (carrinho != null)
                {
                    carrinho.CompraId = compra.Id;
                    _context.Carrinhos.Update(carrinho);
                }
            }

            await _context.SaveChangesAsync();

            TempData["CarrinhoEsvaziado"] = true;

            return RedirectToAction("Index");
        }
        
        // GET: Carrinhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "Id", "Id", carrinho.CompraId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Titulo", carrinho.LivroId);
            return View(carrinho);
        }

        // POST: Carrinhos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LivroId,Quantidade,CompraId")] Carrinho carrinho)
        {
            if (id != carrinho.Id)
            {
                return NotFound();
            }
            
            var livroSelecionado = await _context.Livros.FindAsync(carrinho.LivroId);
            //verifica se a quantidade está disponível em estoque
            if (livroSelecionado != null && carrinho.Quantidade > livroSelecionado.QuantidadeEmEstoque)
            {
                ModelState.AddModelError("Quantidade", "Quantidade inserida excede o estoque disponível.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrinho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrinhoExists(carrinho.Id))
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
            ViewData["CompraId"] = new SelectList(_context.Compras, "Id", "Id", carrinho.CompraId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Titulo", carrinho.LivroId);
            return View(carrinho);
        }

        // GET: Carrinhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinhos
                .Include(c => c.Compra)
                .Include(c => c.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // POST: Carrinhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho != null)
            {
                _context.Carrinhos.Remove(carrinho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrinhoExists(int id)
        {
            return _context.Carrinhos.Any(e => e.Id == id);
        }
    }
}
