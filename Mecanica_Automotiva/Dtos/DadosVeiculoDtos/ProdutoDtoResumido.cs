namespace Mecanica_Automotiva.Dtos.DadosVeiculoDtos
{
    public class ProdutoDtoResumido
    {
        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public int QtdEstoque { get; set; }
        public Guid MarcaProdutoId { get; set; }
    }
}
