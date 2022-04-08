using System.ComponentModel.DataAnnotations;

namespace ProjetoMentoria.ViewModels
{
    public class ComputadorViewModel
    {

        public int ComputadorId { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório")]
        [Display(Name = "Descrição")]
        [MinLength(5, ErrorMessage = "A desrição deve conter no minimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "A desrição deve conter no maximo 5 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Data de lançamento")]
        public DateTime DataLacamento { get; set; }

        [Display(Name = "Tem placa de vídeo ?")]
        public bool TemPlacaDeVideo { get; set; }

        [Display(Name = "Versão processador")]
        public string VersaoProcessador { get; set; }

        [Display(Name = "Capacidade de memoria Ram")]
        public int CapacidadeMemoriaRam { get; set; }

        [Display(Name = "Capacidade de HD em GB")]
        public int CapacidadeHDEmGb { get; set; }

    }
}
