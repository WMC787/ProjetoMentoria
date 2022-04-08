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
    public class PessoasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PessoasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {

            var Pessoas = await _context.Pessoas.ToListAsync();
            var ListaPessoaViewModel = Pessoas.Select(x => new PessoaViewModel
            {
                PessoaId = x.PessoaId,
                Nome = x.Nome,
                Idade = x.Idade,
                Genero = x.Genero,
                CPF = x.CPF,
                RG = x.RG,
                EstadoCivil = x.EstadoCivil,
                Telefone = x.Telefone,
                Email = x.Email,
                CEP = x.CEP,
                Logradouro = x.Logradouro,
                Numero = x.Numero,
                Bairro = x.Bairro,
                Cidade = x.Cidade,
                UF = x.UF,
            });

            return View(ListaPessoaViewModel);
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoas
                .FirstOrDefaultAsync(m => m.PessoaId == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var PessoaViewModel = new PessoaViewModel
            {

                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade,
                Genero = pessoa.Genero,
                CPF = pessoa.CPF,
                RG = pessoa.RG,
                EstadoCivil = pessoa.EstadoCivil,
                Telefone = pessoa.Telefone,
                Email = pessoa.Email,
                CEP = pessoa.CEP,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Bairro = pessoa.Bairro,
                Cidade = pessoa.Cidade,
                UF = pessoa.UF,

            };

            return View(PessoaViewModel);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PessoaViewModel pessoaViewModel)
        {
            

            if (ModelState.IsValid)
            {

                var pessoa = new Pessoa
                {
                    PessoaId = pessoaViewModel.PessoaId,
                    Nome = pessoaViewModel.Nome,
                    Idade = pessoaViewModel.Idade,
                    Genero = pessoaViewModel.Genero,
                    CPF = pessoaViewModel.CPF,
                    RG = pessoaViewModel.RG,
                    EstadoCivil = pessoaViewModel.EstadoCivil,
                    Telefone = pessoaViewModel.Telefone,
                    Email = pessoaViewModel.Email,
                    CEP = pessoaViewModel.CEP,
                    Logradouro = pessoaViewModel.Logradouro,
                    Numero = pessoaViewModel.Numero,
                    Bairro = pessoaViewModel.Bairro,
                    Cidade = pessoaViewModel.Cidade,
                    UF = pessoaViewModel.UF,
                };


                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaViewModel);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var PessoaViewModel = new PessoaViewModel
            {

                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade,
                Genero = pessoa.Genero,
                CPF = pessoa.CPF,
                RG = pessoa.RG,
                EstadoCivil = pessoa.EstadoCivil,
                Telefone = pessoa.Telefone,
                Email = pessoa.Email,
                CEP = pessoa.CEP,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Bairro = pessoa.Bairro,
                Cidade = pessoa.Cidade,
                UF = pessoa.UF,

            };

            return View(PessoaViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PessoaViewModel pessoaViewModel)
        {
            if (id != pessoaViewModel.PessoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var pessoa = _context.Pessoas.FirstOrDefault(c => c.PessoaId == id);
                    pessoa.PessoaId = pessoaViewModel.PessoaId;
                    pessoa.Nome = pessoaViewModel.Nome;
                    pessoa.Idade = pessoaViewModel.Idade;
                    pessoa.Genero = pessoaViewModel.Genero;
                    pessoa.CPF = pessoaViewModel.CPF;
                    pessoa.RG = pessoaViewModel.RG;
                    pessoa.EstadoCivil = pessoaViewModel.EstadoCivil;
                    pessoa.Email = pessoaViewModel.Email;
                    pessoa.CEP = pessoaViewModel.CEP;
                    pessoa.Logradouro = pessoaViewModel.Logradouro;
                    pessoa.Numero = pessoaViewModel.Numero;
                    pessoa.Bairro = pessoaViewModel.Bairro;
                    pessoa.Cidade = pessoaViewModel.Cidade;
                    pessoa.UF = pessoaViewModel.UF;

                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoaViewModel.PessoaId))
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
            return View(pessoaViewModel);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoas
                .FirstOrDefaultAsync(m => m.PessoaId == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var PessoaViewModel = new PessoaViewModel
            {

                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade,
                Genero = pessoa.Genero,
                CPF = pessoa.CPF,
                RG = pessoa.RG,
                EstadoCivil = pessoa.EstadoCivil,
                Telefone = pessoa.Telefone,
                Email = pessoa.Email,
                CEP = pessoa.CEP,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Bairro = pessoa.Bairro,
                Cidade = pessoa.Cidade,
                UF = pessoa.UF,

            };

            return View(PessoaViewModel);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoas.Any(e => e.PessoaId == id);
        }
    }
}
