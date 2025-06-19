using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosCliente
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome  { get; set; }
        public int Cpf  { get; set; }
        public Endereco Endereco { get; set; }

    }
}
