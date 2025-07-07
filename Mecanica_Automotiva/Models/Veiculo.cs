using Mecanica_Automotiva.Models.DadosVeiculo;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models
{
    public class Veiculo // placa pra servico
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public CategoriaVeiculo CategoriaVeiculo { get; set; }
        public int Ano { get; set; }

        [JsonIgnore]
        public ICollection<Peca> Pecas { get; set; } = new List<Peca>();

        [JsonIgnore]
        public ICollection<Servico> Servico { get; set; } = new List<Servico>();
    }
}
