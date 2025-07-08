using Mecanica_Automotiva.Models.DadosVeiculo;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosPeca
{
    public class MarcaPeca
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<ModeloPeca> Modelos { get; set; } = new List<ModeloPeca>();

        [JsonIgnore]
        public ICollection<Peca> Pecas { get; set; } = new List<Peca>();
    }
}
