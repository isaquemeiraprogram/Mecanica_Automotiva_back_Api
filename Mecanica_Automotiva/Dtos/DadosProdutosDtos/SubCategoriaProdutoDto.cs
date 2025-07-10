using Mecanica_Automotiva.Models.Produtos;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Dtos.DtosDadosPescas
{
    public class SubCategoriaProdutoDto
    {
        public string Nome { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
