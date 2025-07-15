using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models
{
    public class Servico
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public TimeSpan Duracao { get; set; }

        [JsonIgnore]
        public ICollection<Agenda> Agendar { get; set; } = new List<Agenda>();
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
