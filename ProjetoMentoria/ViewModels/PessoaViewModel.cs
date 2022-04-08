using ProjetoMentoria.Data;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMentoria.ViewModels
{
    public class PessoaViewModel
    {

        public int PessoaId { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Idade' é obrigatório")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo 'Genero' é obrigatório")]
        public char Genero { get; set; }

        [Required(ErrorMessage = "O campo 'CPF' é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo 'RG' é obrigatório")]
        public string RG { get; set; }

        public EstadoCivilEnum EstadoCivil { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string? CEP { get; set; }

        public string? Logradouro { get; set; }

        public string? Numero { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? UF { get; set; }

    }
}
