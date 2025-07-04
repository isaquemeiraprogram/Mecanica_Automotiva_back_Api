namespace Mecanica_Automotiva.Models.DadosVeiculo
{
    public class TipoVeiculo
    {
        public Guid Id{ get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public Enum CategoriaVeiculo { get; set; }
    }
}
