using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iMarket.Models;
using Microsoft.AspNetCore.Http;

namespace iMarket.Controllers
{
    public class CarrinhoDeCompraController : Controller
    {

        ISession["userame"]= txtusername.Text;

        private readonly iMarketDatabaseContext _context;

        public CarrinhoDeCompraController(iMarketDatabaseContext context)
        {
            _context = context;
        }

        // GET: CarrinhoDeCompra
        public async Task<IActionResult> Index()
        {

            var iMarketDatabaseContext = _context.CarrinhoDeCompra.Include(c => c.Produto).Include(c => c.Usuario);
            return View(await iMarketDatabaseContext.ToListAsync());
        }

        // GET: CarrinhoDeCompra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinhoDeCompra = await _context.CarrinhoDeCompra
                .Include(c => c.Produto)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinhoDeCompra == null)
            {
                return NotFound();
            }

            return View(carrinhoDeCompra);
        }

        // GET: CarrinhoDeCompra/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Marca");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email");
            return View();
        }

        // POST: CarrinhoDeCompra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,UsuarioId")] CarrinhoDeCompra carrinhoDeCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrinhoDeCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Marca", carrinhoDeCompra.ProdutoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", carrinhoDeCompra.UsuarioId);
            return View(carrinhoDeCompra);
        }

        // GET: CarrinhoDeCompra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinhoDeCompra = await _context.CarrinhoDeCompra.FindAsync(id);
            if (carrinhoDeCompra == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Marca", carrinhoDeCompra.ProdutoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", carrinhoDeCompra.UsuarioId);
            return View(carrinhoDeCompra);
        }

        // POST: CarrinhoDeCompra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,UsuarioId")] CarrinhoDeCompra carrinhoDeCompra)
        {
            if (id != carrinhoDeCompra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrinhoDeCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrinhoDeCompraExists(carrinhoDeCompra.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Marca", carrinhoDeCompra.ProdutoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", carrinhoDeCompra.UsuarioId);
            return View(carrinhoDeCompra);
        }

        // GET: CarrinhoDeCompra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinhoDeCompra = await _context.CarrinhoDeCompra
                .Include(c => c.Produto)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinhoDeCompra == null)
            {
                return NotFound();
            }

            return View(carrinhoDeCompra);
        }

        // POST: CarrinhoDeCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrinhoDeCompra = await _context.CarrinhoDeCompra.FindAsync(id);
            _context.CarrinhoDeCompra.Remove(carrinhoDeCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrinhoDeCompraExists(int id)
        {
            return _context.CarrinhoDeCompra.Any(e => e.Id == id);
        }
    }
}
