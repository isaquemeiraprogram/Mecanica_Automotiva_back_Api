using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Dtos
{
    public class DtoPecas
    {
        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public Guid TipoId { get; set; }
        public Guid ClassePecaId { get; set; }
        public Guid SubClassePecaId { get; set; }
    }
}
