using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosVeiculo
{
    public class Marca
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}
