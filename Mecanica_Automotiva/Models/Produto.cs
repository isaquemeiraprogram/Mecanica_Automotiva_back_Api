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
        public ModeloProduto ModeloProduto { get; set; }
        public int QtdEstoque { get; set; }

        //para que veiculo
        public MarcaVeiculo MarcaVeiculo { get; set; }
        public ModeloVeiculo ModeloVeiculo { get; set; }
        public CategoriaVeiculo CategoriaVeiculo { get; set; }

        [JsonIgnore]
        public Servico Servico { get; set; }
    }
}
