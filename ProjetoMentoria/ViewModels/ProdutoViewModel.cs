using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMentoria.ViewModels
{
    public class ProdutoViewModel
    {

        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Marca' é obrigatório")]
        [Display(Name = "Marca")]
        public string Marca { get; set; }


        [Display(Name = "Cor")]
        public string? Cor { get; set; }

        [Required(ErrorMessage = "O campo 'Quantidade' é obrigatório")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Peso Kg")]
        public double? Peso { get; set; }

        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }
    }
}
