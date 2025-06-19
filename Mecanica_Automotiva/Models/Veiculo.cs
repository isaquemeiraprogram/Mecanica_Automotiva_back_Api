using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Models
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public int Nome { get; set; }
        public Marca Marca { get; set; }
        public TipoVeiculo Tipo { get; set; }
        public Modelo Modelo { get; set; }
    }
}
