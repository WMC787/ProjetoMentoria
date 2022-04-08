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
    public class ComputadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComputadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Computadores
        public async Task<IActionResult> Index()
        {

            var computadores = await _context.Computadores.ToArrayAsync();
            var ListaComputadorViewModel = computadores.Select(x => new ComputadorViewModel
            {
                ComputadorId = x.ComputadorId,
                Descricao = x.Descricao,
                DataLacamento = x.DataLacamento,
                TemPlacaDeVideo = x.TemPlacaDeVideo,
                VersaoProcessador = x.VersaoProcessador,
                CapacidadeMemoriaRam = x.CapacidadeMemoriaRam,
                CapacidadeHDEmGb = x.CapacidadeHDEmGb,

            });
            return View(ListaComputadorViewModel);


        }

        // GET: Computadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _context.Computadores
                .FirstOrDefaultAsync(m => m.ComputadorId == id);
            if (computador == null)
            {
                return NotFound();
            }
            var ComputadorViewModel = new ComputadorViewModel
            {
                ComputadorId = computador.ComputadorId,
                Descricao = computador.Descricao,   
                DataLacamento = computador.DataLacamento,  
                TemPlacaDeVideo = computador.TemPlacaDeVideo,
                VersaoProcessador = computador.VersaoProcessador,
                CapacidadeMemoriaRam = computador.CapacidadeMemoriaRam,
                CapacidadeHDEmGb = computador.CapacidadeHDEmGb
            };

            return View(ComputadorViewModel);
        }

        // GET: Computadores/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComputadorViewModel computadorViewModel)
        {
            if (ModelState.IsValid)
            {
                var computador = new Computador
                {
                    ComputadorId = computadorViewModel.ComputadorId,
                    Descricao = computadorViewModel.Descricao,
                    DataLacamento = computadorViewModel.DataLacamento,
                    TemPlacaDeVideo = computadorViewModel.TemPlacaDeVideo,
                    VersaoProcessador = computadorViewModel.VersaoProcessador,
                    CapacidadeMemoriaRam = computadorViewModel.CapacidadeMemoriaRam,
                    CapacidadeHDEmGb = computadorViewModel.CapacidadeHDEmGb
                };
                _context.Add(computador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computadorViewModel);
        }

        // GET: Computadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _context.Computadores.FindAsync(id);
            if (computador == null)
            {
                return NotFound();
            }

            var ComputadorViewModel = new ComputadorViewModel
            {
                ComputadorId = computador.ComputadorId,
                Descricao = computador.Descricao,
                DataLacamento = computador.DataLacamento,
                TemPlacaDeVideo = computador.TemPlacaDeVideo,
                VersaoProcessador = computador.VersaoProcessador,
                CapacidadeMemoriaRam = computador.CapacidadeMemoriaRam,
                CapacidadeHDEmGb = computador.CapacidadeHDEmGb
            };

            return View(ComputadorViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ComputadorViewModel computadorViewModel)
        {
            if (id != computadorViewModel.ComputadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    var computador = _context.Computadores.FirstOrDefault(c => c.ComputadorId == id);
                    computador.ComputadorId = computadorViewModel.ComputadorId;
                    computador.Descricao = computadorViewModel.Descricao;
                    computador.DataLacamento = computadorViewModel.DataLacamento;
                    computador.TemPlacaDeVideo = computadorViewModel.TemPlacaDeVideo;
                    computador.VersaoProcessador = computadorViewModel.VersaoProcessador;
                    computador.CapacidadeMemoriaRam = computadorViewModel.CapacidadeMemoriaRam;
                    computador.CapacidadeHDEmGb = computadorViewModel.CapacidadeHDEmGb;

                    _context.Update(computador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputadorExists(computadorViewModel.ComputadorId))
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
            return View(computadorViewModel);
        }

        // GET: Computadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _context.Computadores
                .FirstOrDefaultAsync(m => m.ComputadorId == id);
            if (computador == null)
            {
                return NotFound();
            }

            var ComputadorViewModel = new ComputadorViewModel
            {
                ComputadorId = computador.ComputadorId,
                Descricao = computador.Descricao,
                DataLacamento = computador.DataLacamento,
                TemPlacaDeVideo = computador.TemPlacaDeVideo,
                VersaoProcessador = computador.VersaoProcessador,
                CapacidadeMemoriaRam = computador.CapacidadeMemoriaRam,
                CapacidadeHDEmGb = computador.CapacidadeHDEmGb
            };

            return View(ComputadorViewModel);
        }

        // POST: Computadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computador = await _context.Computadores.FindAsync(id);
            _context.Computadores.Remove(computador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputadorExists(int id)
        {
            return _context.Computadores.Any(e => e.ComputadorId == id);
        }
    }
}
