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
    public class VeiculoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeiculoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Veiculoes
        public async Task<IActionResult> Index()
        {
            var Veiculos = await _context.Veiculos.ToListAsync();
            var ListaVeiculoViewModel = Veiculos.Select(x => new VeiculoViewModel
            {
                VeiculoId = x.VeiculoId,
                Nome = x.Nome,
                Placa = x.Placa,
                Marca = x.Marca,
                Cor = x.Cor,
                AnoModelo = x.AnoModelo,
                AnoFrabricacao = x.AnoFrabricacao,
            });

            return View(ListaVeiculoViewModel);


        }

        // GET: Veiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculos
                .FirstOrDefaultAsync(m => m.VeiculoId == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            var VeiculoViewModel = new VeiculoViewModel
            {
                VeiculoId = veiculo.VeiculoId,
                Nome = veiculo.Nome,
                Placa = veiculo.Placa,
                Marca = veiculo.Marca,
                Cor = veiculo.Cor,
                AnoModelo = veiculo.AnoModelo,
                AnoFrabricacao = veiculo.AnoFrabricacao,
            };

            return View(VeiculoViewModel);
        }

        // GET: Veiculoes/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VeiculoViewModel veiculoViewModel)
        {
            if (ModelState.IsValid)
            {
                var veiculo = new Veiculo
                {
                    VeiculoId = veiculoViewModel.VeiculoId,
                    Placa = veiculoViewModel.Placa,
                    Marca = veiculoViewModel.Marca,
                    Cor = veiculoViewModel.Cor,
                    AnoModelo = veiculoViewModel.AnoModelo,
                    AnoFrabricacao = veiculoViewModel.AnoFrabricacao,

                };

                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculoViewModel);
        }

        // GET: Veiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            var VeiculoViewModel = new VeiculoViewModel
            {
                VeiculoId = veiculo.VeiculoId,
                Nome = veiculo.Nome,
                Placa = veiculo.Placa,
                Marca = veiculo.Marca,
                Cor = veiculo.Cor,
                AnoModelo = veiculo.AnoModelo,
                AnoFrabricacao = veiculo.AnoFrabricacao,
            };

            return View(VeiculoViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VeiculoViewModel veiculoViewModel)
        {
            if (id != veiculoViewModel.VeiculoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var veiculo = _context.Veiculos.FirstOrDefault(v => v.VeiculoId == id);
                    veiculo.VeiculoId = veiculoViewModel.VeiculoId;
                    veiculo.Placa = veiculoViewModel.Placa;
                    veiculo.Marca = veiculoViewModel.Marca;
                    veiculo.Cor = veiculoViewModel.Cor;
                    veiculo.AnoModelo = veiculoViewModel.AnoModelo;
                    veiculo.AnoFrabricacao = veiculoViewModel.AnoFrabricacao;

                    _context.Update(veiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(veiculoViewModel.VeiculoId))
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
            return View(veiculoViewModel);
        }

        // GET: Veiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculos
                .FirstOrDefaultAsync(m => m.VeiculoId == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            var VeiculoViewModel = new VeiculoViewModel
            {
                VeiculoId = veiculo.VeiculoId,
                Nome = veiculo.Nome,
                Placa = veiculo.Placa,
                Marca = veiculo.Marca,
                Cor = veiculo.Cor,
                AnoModelo = veiculo.AnoModelo,
                AnoFrabricacao = veiculo.AnoFrabricacao,
            };

            return View(VeiculoViewModel);
        }

        // POST: Veiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculos.Any(e => e.VeiculoId == id);
        }
    }
}
