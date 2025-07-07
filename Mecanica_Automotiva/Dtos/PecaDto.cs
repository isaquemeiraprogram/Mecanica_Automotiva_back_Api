using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Dtos
{
    public class PecaDto
    {
        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public Guid SubCategoriaPecaId { get; set; }
        public Guid VeiculoId { get; set; }
    }
}
