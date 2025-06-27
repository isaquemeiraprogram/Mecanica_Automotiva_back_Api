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
        //possivel que possa ter marca
        //qtd em estoque
        public SubCategoriaPeca SubCategoriaPeca { get; set; }

        //tem que dizer de que veiculo e esta peca pra filtros mais tarde filtro por veiculo,marca etc
        public Veiculo Veiculo { get; set; }

        [JsonIgnore]
        public Servico Servico { get; set; }
    }
}
