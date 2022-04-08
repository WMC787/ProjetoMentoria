#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMentoria.Data;
using ProjetoMentoria.Models;
using ProjetoMentoria.ViewModels;

namespace ProjetoMentoria.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var Produtos = await  _context.Produtos.ToListAsync();
            var ListaProdutoViewModel = Produtos.Select(x => new ProdutoViewModel
            {

                ProdutoId = x.ProdutoId,
                Nome = x.Nome,
                Marca = x.Marca,
                Cor = x.Cor,
                Quantidade = x.Quantidade,
                Peso = x.Peso,
                Valor = x.Valor,

            });
            return View(ListaProdutoViewModel);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            var ProdutoViewModel = new ProdutoViewModel
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Marca = produto.Marca,
                Cor = produto.Cor,
                Quantidade = produto.Quantidade,
                Peso = produto.Peso,
                Valor = produto.Valor,
            };

            return View(ProdutoViewModel);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto
                {
                    ProdutoId = produtoViewModel.ProdutoId,
                    Nome = produtoViewModel.Nome,
                    Marca = produtoViewModel.Marca,
                    Cor = produtoViewModel.Cor,
                    Quantidade = produtoViewModel.Quantidade,
                    Peso = produtoViewModel.Peso,
                    Valor = produtoViewModel.Valor,

                };

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtoViewModel);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var ProdutoViewModel = new ProdutoViewModel
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Marca = produto.Marca,
                Cor = produto.Cor,
                Quantidade = produto.Quantidade,
                Peso = produto.Peso,
                Valor = produto.Valor,
            };


            return View(ProdutoViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                    produto.ProdutoId = produtoViewModel.ProdutoId;
                    produto.Nome = produtoViewModel.Nome;
                    produto.Marca = produtoViewModel.Marca;
                    produto.Cor = produtoViewModel.Cor;
                    produto.Quantidade = produtoViewModel.Quantidade;
                    produto.Peso = produtoViewModel.Peso;
                    produto.Valor = produtoViewModel.Valor;

                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produtoViewModel.ProdutoId))
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
            return View(produtoViewModel);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            var ProdutoViewModel = new ProdutoViewModel
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Marca = produto.Marca,
                Cor = produto.Cor,
                Quantidade = produto.Quantidade,
                Peso = produto.Peso,
                Valor = produto.Valor,
            };


            return View(ProdutoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
