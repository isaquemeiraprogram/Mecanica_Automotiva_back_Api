using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models
{
    public class Servico
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor{ get; set; }
        public TimeSpan Duracao { get; set; }

        [JsonIgnore]
        public Agenda Agendar { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
