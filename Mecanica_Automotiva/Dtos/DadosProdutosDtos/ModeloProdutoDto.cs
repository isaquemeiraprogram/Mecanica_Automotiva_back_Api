namespace Mecanica_Automotiva.Dtos.DadosProdutosDtos
{
    public class ModeloProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public MarcaProdutoDto Marca { get; set; }
    }
}
