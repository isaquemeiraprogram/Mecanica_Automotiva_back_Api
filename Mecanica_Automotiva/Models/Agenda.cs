using Mecanica_Automotiva.Models.DadosCliente;

namespace Mecanica_Automotiva.Models
{
    public class Agenda
    {
        public Guid Id { get; set; }
        public DateOnly Data { get; set; }
        public TimeOnly Hora { get; set; }
        public string Queixa { get; set; }
        //timespam pra somar tempo
        public TimeSpan TempoServiçoTotal { get; set; }
        public double ValorTotal { get; set; }
        public ICollection<Servico> Servicos { get; set; } = new List<Servico>();
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
