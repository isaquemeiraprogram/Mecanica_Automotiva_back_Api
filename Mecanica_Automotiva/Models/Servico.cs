using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models
{
    public class Servico
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor{ get; set; }
        public TimeOnly Duracao { get; set; }

        [JsonIgnore]
        public Agendar Agendar { get; set; }
        public ICollection<Peca> Pecas { get; set; } = new List<Peca>();
    }
}
