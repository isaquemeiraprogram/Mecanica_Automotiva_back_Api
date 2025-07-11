using Mecanica_Automotiva.Models.DadosPeca;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Models.Produtos;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public SubCategoriaProduto SubCategoriaProduto { get; set; }
        public MarcaProduto MarcaProduto { get; set; }
        public int QtdEstoque { get; set; }

        //para que veiculo
        public ICollection<MarcaVeiculo> MarcasVeiculos { get; set; } = new List<MarcaVeiculo>();
        public ICollection<ModeloVeiculo> ModelosVeiculos { get; set; } = new List<ModeloVeiculo>();
        
        [JsonIgnore]
        public ICollection<Servico> Servico { get; set; } = new List<Servico>();
    }
}
