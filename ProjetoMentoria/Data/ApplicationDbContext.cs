using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoMentoria.Models;

namespace ProjetoMentoria.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }
        
        public DbSet<Produto> Produtos { get; set; }
        
        public DbSet<Cliente> Clientes { get; set; }    

        public DbSet<Computador> Computadores { get; set; }  

        public DbSet<Celular> Celulares { get; set;}


    }
}