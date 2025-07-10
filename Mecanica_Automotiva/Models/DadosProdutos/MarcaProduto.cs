using Mecanica_Automotiva.Models.DadosVeiculo;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosPeca
{
    public class MarcaProduto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<ModeloProduto> Modelos { get; set; } = new List<ModeloProduto>();

        [JsonIgnore]
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
