using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Dtos.DtosDadosVeiculo
{
    public class ModeloVeiculoDto
    {
        public string Nome { get; set; }
        public Guid MarcaId { get; set; }
        public CategoriaVeiculo CategoriaVeiculo { get; set; }
    }
}
