using Mecanica_Automotiva.Models.Produtos;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models
{
    public class Pecas
    {
        public Guid Id { get; set; }

        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }

        public CategoriaPeca CategoriaPeca { get; set; }

        [JsonIgnore]
        public Servico Servico { get; set; }
    }
}
