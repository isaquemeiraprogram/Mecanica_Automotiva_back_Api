namespace Mecanica_Automotiva.Models.DadosVeiculo
{
    public class Marca
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        ICollection< Modelo> Modelo { get; set; } = new List<Modelo>();

    }
}
