namespace Mecanica_Automotiva.Models.Produtos
{
    public class TipoPeca
    {
        public Guid Id{ get; set; }
        public string Nome { get; set; }

        public ClassePeca ClassePeca { get; set; }
        public SubClassePeca SubClassePeca { get; set; }
        //portas
        //pneus
        //capo
    }
}
