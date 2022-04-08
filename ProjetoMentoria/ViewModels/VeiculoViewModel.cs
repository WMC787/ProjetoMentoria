using System.ComponentModel.DataAnnotations;

namespace ProjetoMentoria.ViewModels
{
    public class VeiculoViewModel
    {

        public int VeiculoId { get; set; }

        public string Nome { get; set; }

        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Cor { get; set; }

        [Display(Name = "Ano Do Modelo")]
        public int AnoModelo { get; set; }

        [Display(Name = "Ano De Fabricação")]
        public int AnoFrabricacao { get; set; }
    }
}
