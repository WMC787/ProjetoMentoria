using System.ComponentModel.DataAnnotations;

namespace ProjetoMentoria.ViewModels
{
    public class CelularViewModel
    {

        public int CelularId { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [Display(Name = "Descrição")]
        [MinLength(5, ErrorMessage = "O campo Descrição deve conter no minimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Descrição deve conter no maximo 100 caracteres")]
        public string Dercicao { get; set; }

        [Required(ErrorMessage = "O campo Data de lançamento é obrigatório")]
        [Display(Name = "Data de lançamento")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório")]
        public string Modelo { get; set; }

        [Display(Name = "Tem câmera frontal ?")]
        public bool TemCameraFrontal { get; set; }

        [Display(Name = "Sistema operacional")]
        public string SistemaOperaciona { get; set; }

        [Display(Name = "Capaciadade de memoria Ram")]
        public int CapaciadadeMemoriaRam { get; set; }

        [Display(Name = "Capacidade de aramazenamento")]
        public int CapaciadadeAramazenamento { get; set; }

    }
}
