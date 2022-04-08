using System.ComponentModel.DataAnnotations;

namespace ProjetoMentoria.Models
{
    public class Celular
    {
        public int CelularId { get; set; }
        public string Dercicao { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public bool TemCameraFrontal { get; set; }

        public string SistemaOperaciona { get; set; }

        public int CapaciadadeMemoriaRam { get; set; }

        public int CapaciadadeAramazenamento { get; set; }
    }
}
