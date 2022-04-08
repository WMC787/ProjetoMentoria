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
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var Clientes = await _context.Clientes.ToListAsync();
            var ListaClienteViewModel = Clientes.Select(x => new ClienteViewModel
            {
                ClienteId = x.ClienteId,    
                Nome = x.Nome,
                Idade = x.Idade,
                Genero = x.Genero,
                CPF = x.CPF,
                CNPJ = x.CNPJ,
                RG = x.RG,
                Telefone = x.Telefone,
                Email = x.Email,
                CEP = x.CEP,
                Logradouro = x.Logradouro,
                Numero = x.Numero,
                Bairro = x.Bairro,
                Cidade = x.Cidade,
                UF = x.UF,

            });

            return View(ListaClienteViewModel);
        }

        // GET: Clientes/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var ClienteViewModel = new ClienteViewModel
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Idade = cliente.Idade,
                Genero = cliente.Genero,
                CPF = cliente.CPF,
                CNPJ = cliente.CNPJ,
                RG = cliente.RG,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                CEP = cliente.CEP,
                Logradouro = cliente.Logradouro,
                Numero = cliente.Numero,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                UF = cliente.UF
            };

            return View(ClienteViewModel);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = new Cliente
                {
                    ClienteId = clienteViewModel.ClienteId,
                    Nome = clienteViewModel.Nome,
                    Idade = clienteViewModel.Idade,
                    Genero = clienteViewModel.Genero,
                    CPF = clienteViewModel.CPF,
                    CNPJ = clienteViewModel.CNPJ,
                    RG = clienteViewModel.RG,
                    Telefone = clienteViewModel.Telefone,
                    Email = clienteViewModel.Email,
                    CEP = clienteViewModel.CEP,
                    Logradouro = clienteViewModel.Logradouro,
                    Numero = clienteViewModel.Numero,
                    Bairro = clienteViewModel.Bairro,
                    Cidade = clienteViewModel.Cidade,
                    UF = clienteViewModel.UF

                };
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            var ClienteViewModel = new ClienteViewModel
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Idade = cliente.Idade,
                Genero = cliente.Genero,
                CPF = cliente.CPF,
                CNPJ = cliente.CNPJ,
                RG = cliente.RG,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                CEP = cliente.CEP,
                Logradouro = cliente.Logradouro,
                Numero = cliente.Numero,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                UF = cliente.UF
            };

            return View(ClienteViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = _context.Clientes.FirstOrDefault(c => c.ClienteId == id);

                    cliente.ClienteId = clienteViewModel.ClienteId;
                    cliente.Nome = clienteViewModel.Nome;
                    cliente.Idade = clienteViewModel.Idade;
                    cliente.Genero = clienteViewModel.Genero;
                    cliente.CPF = clienteViewModel.CPF;
                    cliente.CNPJ = clienteViewModel.CNPJ;
                    cliente.RG = clienteViewModel.RG;
                    cliente.Telefone = clienteViewModel.Telefone;
                    cliente.Email = clienteViewModel.Email;
                    cliente.CEP = clienteViewModel.CEP;
                    cliente.Logradouro = clienteViewModel.Logradouro;
                    cliente.Numero = clienteViewModel.Numero;
                    cliente.Bairro = clienteViewModel.Bairro;
                    cliente.Cidade = clienteViewModel.Cidade;
                    cliente.UF = clienteViewModel.UF;

                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(clienteViewModel.ClienteId))
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
            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var ClienteViewModel = new ClienteViewModel
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Idade = cliente.Idade,
                Genero = cliente.Genero,
                CPF = cliente.CPF,
                CNPJ = cliente.CNPJ,
                RG = cliente.RG,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                CEP = cliente.CEP,
                Logradouro = cliente.Logradouro,
                Numero = cliente.Numero,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                UF = cliente.UF
            };

            return View(ClienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
