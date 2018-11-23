using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iMarket.Models;

namespace iMarket.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly iMarketDatabaseContext _context;

        public ProdutoController(iMarketDatabaseContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index(int Categoria, int Fornecedor)
        {
            IQueryable<Produto> iMarketDatabaseContext = null;

            if (Categoria != 0)
            {
                iMarketDatabaseContext = _context.Produto.Where(p => p.Categoria.Id == Categoria);
            }
            if(Fornecedor != 0)
            {
                iMarketDatabaseContext = _context.Produto.Where(p => p.Fornecedor.Id == Fornecedor);
            }
            if(Fornecedor != 0 && Categoria != 0)
            {
                iMarketDatabaseContext = _context.Produto.Where(p => p.Fornecedor.Id == Fornecedor).Where(p => p.Categoria.Id == Categoria);
            }
            if (Fornecedor == 0 && Categoria == 0)
            {
                iMarketDatabaseContext = _context.Produto.Include(p => p.Categoria).Include(p => p.Fornecedor);
            }

            return View(await iMarketDatabaseContext.ToListAsync());
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome");
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "Id", "NomeFantasia");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Marca,Preco,Imagem,Desconto,CategoriaId,FornecedorId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", produto.CategoriaId);
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "Id", "NomeFantasia", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", produto.CategoriaId);
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "Id", "NomeFantasia", produto.FornecedorId);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Marca,Preco,Imagem,Desconto,CategoriaId,FornecedorId")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", produto.CategoriaId);
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "Id", "NomeFantasia", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
