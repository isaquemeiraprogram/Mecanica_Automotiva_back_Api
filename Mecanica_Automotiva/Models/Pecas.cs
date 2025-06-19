using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Models
{
    public class Pecas
    {
        public Guid Id { get; set; }

        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public TipoPeca Tipo { get; set; }
        public ClassePeca ClassePeca { get; set; }
        public SubClassePeca SubClassePeca { get; set; }
    }
}
