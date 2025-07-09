using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Dtos
{
    public class PecaDto
    {
        public string Img { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public int QtdEstoque { get; set; }
        public Guid SubCategoriaPecaId { get; set; }
        public Guid MarcaPecaId { get; set; }
        public Guid ModeloPecaId { get; set; }
        public Guid MarcaVeiculoId { get; set; }
        public Guid ModeloVeiculoId { get; set; }
        public CategoriaVeiculo CategoriaVeiculo { get; set; }
    }
}
