using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Models.DadosCliente;

namespace Mecanica_Automotiva.Dtos
{
    public class AgendarDto
    {
        public DateOnly Data { get; set; }
        public TimeOnly Hora { get; set; }
        public double ValorTotal { get; set; }
        public TimeOnly TempoDeServiço { get; set; }
        public List<Guid> ServicosId { get; set; } = new List<Guid>();
        public Guid ClienteId { get; set; }
    }
}
