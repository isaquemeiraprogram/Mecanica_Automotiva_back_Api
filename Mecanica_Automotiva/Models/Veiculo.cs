using Mecanica_Automotiva.Models.DadosVeiculo;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public int Nome { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }

        [JsonIgnore]
        public ICollection<Servico> Servico { get; set; } = new List<Servico>();
    }
}
