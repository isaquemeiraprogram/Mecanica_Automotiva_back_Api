using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosCliente
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }//email e tel?

        [JsonIgnore]
        public ICollection<Endereco> Endereco { get; set; } = new List<Endereco>();

        [JsonIgnore]
        public ICollection<Agenda> Agendamentos { get; set; } = new List<Agenda>();

    }
}
