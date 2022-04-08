using System.ComponentModel.DataAnnotations;

namespace ProjetoMentoria.Models
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }

        public string Nome { get; set; }

        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Cor { get; set; }

        public int AnoModelo { get; set; }

        public int AnoFrabricacao { get; set; }
    }
}
