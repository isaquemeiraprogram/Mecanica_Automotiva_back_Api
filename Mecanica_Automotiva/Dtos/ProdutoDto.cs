using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Dtos
{
    public class ProdutoDto
    {
        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public int QtdEstoque { get; set; }
        public Guid SubCategoriaProdutoId { get; set; }
        public Guid MarcaProdutoId { get; set; }
        public Guid MarcaVeiculoId { get; set; }
        public Guid ModeloVeiculoId { get; set; }
        public CategoriaVeiculo CategoriaVeiculo { get; set; }
    }
}
