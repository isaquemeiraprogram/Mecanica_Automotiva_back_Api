using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Dtos
{
    public class VeiculoDto
    {
        public string Placa { get; set; }
        public Guid MarcaId { get; set; }
        public Guid ModeloId { get; set; }
        public int Ano { get; set; }
    }
}
