using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosVeiculo
{
    public class MarcaVeiculo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<ModeloVeiculo> Modelos { get; set; } = new List<ModeloVeiculo>();
        [JsonIgnore]
        public ICollection<Veiculo> Veiculo { get; set; } = new List<Veiculo>();
    }
}
