using Mecanica_Automotiva.Models.Produtos;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Dtos.DtosDadosPescas
{
    public class DtoSubClassePeca
    {
        public string Nome { get; set; }

        [JsonIgnore]
        public Guid SubClassesPecaId { get; set; }
    }
}
