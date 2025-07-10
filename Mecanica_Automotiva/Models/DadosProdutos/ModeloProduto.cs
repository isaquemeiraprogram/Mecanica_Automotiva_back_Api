using Mecanica_Automotiva.Models.DadosVeiculo;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosPeca
{
    public class ModeloProduto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        //precisa diser de que marca e tal modelo nao existe modelo sem marca(teoria)

        public MarcaProduto Marca { get; set; }

        [JsonIgnore]
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
