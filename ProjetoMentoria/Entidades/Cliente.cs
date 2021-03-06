using ProjetoMentoria.Data;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMentoria.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public GeneroEnum Genero { get; set; }

        public string? CPF { get; set; }

        public string? CNPJ { get; set; }

        public string? RG { get; set; }
        public string Telefone { get; set; }

        public string Email { get; set; }

        public string? CEP { get; set; }

        public string? Logradouro { get; set; }

        public string? Numero { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? UF { get; set; }

        public string? UrlImagem { get; set; }
    }
}
