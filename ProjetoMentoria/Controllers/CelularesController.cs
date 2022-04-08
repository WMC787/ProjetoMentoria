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
   
    public class CelularesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CelularesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Celulares

        public async Task<IActionResult> Index()
        {

            var Celulares = await _context.Celulares.ToListAsync();
            var ListaCelularViewModel = Celulares.Select(x => new CelularViewModel
            {
                CelularId = x.CelularId,
                Dercicao = x.Dercicao,
                DataLancamento = x.DataLancamento,
                Marca = x.Marca,
                Modelo = x.Modelo,
                TemCameraFrontal = x.TemCameraFrontal,
                SistemaOperaciona = x.SistemaOperaciona,
                CapaciadadeMemoriaRam = x.CapaciadadeMemoriaRam,
                CapaciadadeAramazenamento = x.CapaciadadeAramazenamento,

            });

            return View(ListaCelularViewModel);
        }

        // GET: Celulares/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celulares
                .FirstOrDefaultAsync(m => m.CelularId == id);
            if (celular == null)
            {
                return NotFound();
            }

            var celularViewModel = new CelularViewModel
            {
                CelularId = celular.CelularId,
                Dercicao = celular.Dercicao,
                DataLancamento = celular.DataLancamento,
                Marca = celular.Marca,
                Modelo = celular.Modelo,
                TemCameraFrontal = celular.TemCameraFrontal,
                SistemaOperaciona = celular.SistemaOperaciona,
                CapaciadadeMemoriaRam = celular.CapaciadadeMemoriaRam,
                CapaciadadeAramazenamento = celular.CapaciadadeAramazenamento,
            };
            return View(celularViewModel);
        }

        // GET: Celulares/Create
        public IActionResult Create()
        {
          
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CelularViewModel celularViewModel)
        {
            if (ModelState.IsValid)
            {

                var celular = new Celular
                {
                    CelularId = celularViewModel.CelularId,
                    Dercicao = celularViewModel.Dercicao,
                    DataLancamento = celularViewModel.DataLancamento,
                    Marca = celularViewModel.Marca,
                    Modelo = celularViewModel.Modelo,
                    TemCameraFrontal = celularViewModel.TemCameraFrontal,
                    SistemaOperaciona = celularViewModel.SistemaOperaciona,
                    CapaciadadeMemoriaRam = celularViewModel.CapaciadadeMemoriaRam,
                    CapaciadadeAramazenamento = celularViewModel.CapaciadadeAramazenamento,
                };

                _context.Add(celular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(celularViewModel);
        }

        // GET: Celulares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celulares.FindAsync(id);
            if (celular == null)
            {
                return NotFound();
            }

            var celularViewModel = new CelularViewModel
            {
                CelularId = celular.CelularId,
                Dercicao = celular.Dercicao,
                DataLancamento = celular.DataLancamento,
                Marca = celular.Marca,
                Modelo = celular.Modelo,
                TemCameraFrontal = celular.TemCameraFrontal,
                SistemaOperaciona = celular.SistemaOperaciona,
                CapaciadadeMemoriaRam = celular.CapaciadadeMemoriaRam,
                CapaciadadeAramazenamento = celular.CapaciadadeAramazenamento,
            };

            return View(celularViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CelularViewModel celularViewModel)
        {
            if (id != celularViewModel.CelularId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var celular = _context.Celulares.FirstOrDefault(c => c.CelularId == id);
                    celular.CelularId = celularViewModel.CelularId;
                    celular.Dercicao = celularViewModel.Dercicao;
                    celular.DataLancamento = celularViewModel.DataLancamento;
                    celular.Marca = celularViewModel.Marca;
                    celular.Modelo = celularViewModel.Modelo;
                    celular.TemCameraFrontal = celularViewModel.TemCameraFrontal;
                    celular.SistemaOperaciona = celularViewModel.SistemaOperaciona;
                    celular.CapaciadadeMemoriaRam = celularViewModel.CapaciadadeMemoriaRam;
                    celular.CapaciadadeAramazenamento = celularViewModel.CapaciadadeAramazenamento;

                    _context.Update(celular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelularExists(celularViewModel.CelularId))
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
            return View(celularViewModel);
        }

        // GET: Celulares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celulares
                .FirstOrDefaultAsync(m => m.CelularId == id);
            if (celular == null)
            {
                return NotFound();
            }

            var celularViewModel = new CelularViewModel
            {
                CelularId = celular.CelularId,
                Dercicao = celular.Dercicao,
                DataLancamento = celular.DataLancamento,
                Marca = celular.Marca,
                Modelo = celular.Modelo,
                TemCameraFrontal = celular.TemCameraFrontal,
                SistemaOperaciona = celular.SistemaOperaciona,
                CapaciadadeMemoriaRam = celular.CapaciadadeMemoriaRam,
                CapaciadadeAramazenamento = celular.CapaciadadeAramazenamento,
            };

            return View(celularViewModel);
        }

        // POST: Celulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celular = await _context.Celulares.FindAsync(id);
            _context.Celulares.Remove(celular);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelularExists(int id)
        {
            return _context.Celulares.Any(e => e.CelularId == id);
        }
    }
}
