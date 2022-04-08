using System.ComponentModel.DataAnnotations;

namespace ProjetoMentoria.Models
{
    public class Computador
    {
        public int ComputadorId { get; set; }

        public string Descricao { get; set; }

        public DateTime DataLacamento { get; set; }

        public bool TemPlacaDeVideo { get; set; }

        public string VersaoProcessador { get; set; }

        public int CapacidadeMemoriaRam { get; set; }

        public int CapacidadeHDEmGb { get; set; }
    }
}
