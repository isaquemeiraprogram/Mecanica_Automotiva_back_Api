using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Dtos.DtosDadosPescas
{
    public class DtoTipoPeca
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public Guid ClassePecaId { get; set; }
        public Guid SubClassePecaId { get; set; }
    }
}
