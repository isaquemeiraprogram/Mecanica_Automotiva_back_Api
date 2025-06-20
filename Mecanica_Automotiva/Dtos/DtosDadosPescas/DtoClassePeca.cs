using Mecanica_Automotiva.Models.Produtos;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Dtos.DtosDadosPescas
{
    public class DtoClassePeca
    {
        public string Nome { get; set; }

        [JsonIgnore]
        public List<Guid> ClassesId { get; set; } = new List<Guid>();
    }
}
