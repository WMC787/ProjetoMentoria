#nullable disable
using System;
using System.Collections;
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
       Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironmet;

        public ClientesController(ApplicationDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironmet)
        {
            _context = context;
            _hostingEnvironmet = hostingEnvironmet;
        }
          
            [HttpGet]
        public async Task<IActionResult> Index(string Pesquisa,string Cnpj)
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

            var Query = _context.Clientes.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisa))
            {
                Query = Query.Where(p => p.CPF.Contains(Pesquisa));

            }
           if (!string.IsNullOrEmpty(Cnpj))
            {
                Query = Query.Where(p => p.CNPJ.Contains(Cnpj));
      
            }
            var ListaPesquisa = Query.Select(p => new ClienteViewModel
            {
                ClienteId = p.ClienteId,
                Nome = p.Nome,
                Idade = p.Idade,
                Genero = p.Genero,
                CPF = p.CPF,
                CNPJ = p.CNPJ,
                RG = p.RG,
                Telefone = p.Telefone,
                Email = p.Email,
                CEP = p.CEP,
                Logradouro = p.Logradouro,
                Numero = p.Numero,
                Bairro = p.Bairro,
                Cidade = p.Cidade,
                UF = p.UF,
        });
            return View(ListaPesquisa);

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
                UF = cliente.UF,
                UrlImagem = cliente.UrlImagem
            };

            return View(ClienteViewModel);
        }

        [HttpGet]
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

                string filePatch = "";
                if (clienteViewModel.Imagem != null && clienteViewModel.Imagem.Length > 0)
                {
                    string uploads = Path.Combine(_hostingEnvironmet.WebRootPath, "uploads", clienteViewModel.Imagem.FileName);
                    filePatch = Path.Combine("uploads", clienteViewModel.Imagem.FileName);
                    using (Stream fileStream = new FileStream(uploads, FileMode.Create))
                    {
                        await clienteViewModel.Imagem.CopyToAsync(fileStream);
                    }
                }
                cliente.UrlImagem = filePatch;
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteViewModel);
        }

        [HttpGet]
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

                    string filePatch = "";
                    if (clienteViewModel.Imagem != null && clienteViewModel.Imagem.Length > 0)
                    {
                        string uploads = Path.Combine(_hostingEnvironmet.WebRootPath, "uploads", clienteViewModel.Imagem.FileName);
                        filePatch = Path.Combine("uploads", clienteViewModel.Imagem.FileName);
                        using (Stream fileStream = new FileStream(uploads, FileMode.Create))
                        {
                            await clienteViewModel.Imagem.CopyToAsync(fileStream);
                        }
                    }

                    cliente.UrlImagem = filePatch;
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
