using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using majulicroche.Data;
using majulicroche.Models;
using Microsoft.AspNetCore.Authorization;

namespace majulicroche.Controllers
{
    //[Authorize]
    public class ControleEstoquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ControleEstoquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ControleEstoques
        public async Task<IActionResult> Index()
        {
            return View(await _context.ControleEstoque.ToListAsync());
        }

        // GET: ControleEstoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controleEstoque = await _context.ControleEstoque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controleEstoque == null)
            {
                return NotFound();
            }

            return View(controleEstoque);
        }

        // GET: ControleEstoques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControleEstoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeMaterial,Quantidade,UnidadeMedida,Fornecedor,DataUltimoReabastecimento")] ControleEstoque controleEstoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controleEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controleEstoque);
        }

        // GET: ControleEstoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controleEstoque = await _context.ControleEstoque.FindAsync(id);
            if (controleEstoque == null)
            {
                return NotFound();
            }
            return View(controleEstoque);
        }

        // POST: ControleEstoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeMaterial,Quantidade,UnidadeMedida,Fornecedor,DataUltimoReabastecimento")] ControleEstoque controleEstoque)
        {
            if (id != controleEstoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controleEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControleEstoqueExists(controleEstoque.Id))
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
            return View(controleEstoque);
        }

        // GET: ControleEstoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controleEstoque = await _context.ControleEstoque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controleEstoque == null)
            {
                return NotFound();
            }

            return View(controleEstoque);
        }

        // POST: ControleEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controleEstoque = await _context.ControleEstoque.FindAsync(id);
            if (controleEstoque != null)
            {
                _context.ControleEstoque.Remove(controleEstoque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControleEstoqueExists(int id)
        {
            return _context.ControleEstoque.Any(e => e.Id == id);
        }
    }
}
