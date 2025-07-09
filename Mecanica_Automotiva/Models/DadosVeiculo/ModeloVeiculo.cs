using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosVeiculo
{
    public class ModeloVeiculo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        //precisa diser de que marca e tal modelo nao existe modelo sem marca(teoria)

        public MarcaVeiculo Marca { get; set; }

        [JsonIgnore]
        public ICollection<Veiculo> Veiculo { get; set; } = new List<Veiculo>();
    }
}
