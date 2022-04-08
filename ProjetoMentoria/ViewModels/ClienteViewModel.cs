using ProjetoMentoria.Data;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMentoria.ViewModels
{
    public class ClienteViewModel
    {

        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        [Display(Name = "Nome")]
        [MinLength(5, ErrorMessage = "O Nome deve conter no minimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O Nome deve conter no maximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Idade' é obrigatório")]
        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo 'Gênero' é obrigatório")]
        [Display(Name = "Gênero")]
        public GeneroEnum Genero { get; set; }


        [Display(Name = "CPF")]
        [MinLength(11, ErrorMessage = "O CPF deve conter 11 números.")]
        public string? CPF { get; set; }

        [Display(Name = "CNPJ")]
        [MinLength(14, ErrorMessage = "O CNPJ deve conter 14 números.")]
        public string? CNPJ { get; set; }


        [Display(Name = "RG")]
        public string? RG { get; set; }

        [Required(ErrorMessage = "O campo 'Telefone' é obrigatório")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo 'Email' é obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string? CEP { get; set; }

        public string? Logradouro { get; set; }

        [Display(Name = "Número")]
        public string? Numero { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? UF { get; set; }

    }
}
