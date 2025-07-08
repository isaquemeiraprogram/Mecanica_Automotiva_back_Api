using Mecanica_Automotiva.Models.DadosPeca;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Models.Produtos;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models
{
    public class Peca
    {
        public Guid Id { get; set; }
        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public SubCategoriaPeca SubCategoriaPeca { get; set; }
        public MarcaPeca MarcaPeca { get; set; }
        public ModeloPeca ModeloPeca { get; set; }
        public int QtdEstoque { get; set; }

        //para que veiculo
        public MarcaVeiculo MarcaVeiculo { get; set; }
        public ModeloVeiculo ModeloVeiculo { get; set; }
        public CategoriaVeiculo CategoriaVeiculo { get; set; }

        [JsonIgnore]
        public Servico Servico { get; set; }
    }
}
