using Mecanica_Automotiva.Models.DadosVeiculo;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosPeca
{
    public class ModeloPeca
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        //precisa diser de que marca e tal modelo nao existe modelo sem marca(teoria)

        [JsonIgnore]
        public MarcaPeca Marca { get; set; }

        [JsonIgnore]
        public ICollection<Peca> Pecas { get; set; } = new List<Peca>();
    }
}
