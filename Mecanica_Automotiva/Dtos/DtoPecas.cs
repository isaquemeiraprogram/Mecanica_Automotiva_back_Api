using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Dtos
{
    public class DtoPecas
    {
        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public Guid CategoriaPecaId { get; set; }
        public Guid SubCategoriaPecaId { get; set; }
    }
}
