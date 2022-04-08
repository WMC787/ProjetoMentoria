using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMentoria.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public string? Cor { get; set; }

        public int Quantidade { get; set; }

        public double? Peso { get; set; }

        public decimal Valor { get; set; }
    }
}
