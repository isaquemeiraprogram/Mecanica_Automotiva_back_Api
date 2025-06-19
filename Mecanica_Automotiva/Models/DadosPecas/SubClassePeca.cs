using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.Produtos
{
    public class SubClassePeca
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ClassePeca ClassePeca { get; set; }
    }
}
