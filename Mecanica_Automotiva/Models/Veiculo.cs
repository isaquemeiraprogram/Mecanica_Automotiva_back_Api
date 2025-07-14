using Mecanica_Automotiva.Models.DadosVeiculo;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models
{
    public class Veiculo // placa pra servico
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        [JsonIgnore]
        public MarcaVeiculo Marca { get; set; }
        public ModeloVeiculo Modelo { get; set; }
        public int Ano { get; set; }

        [JsonIgnore]
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        [JsonIgnore]
        public ICollection<Agenda> Agendamentos { get; set; } = new List<Agenda>();
    }
}
