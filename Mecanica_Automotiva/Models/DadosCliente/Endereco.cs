using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosCliente
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public  int Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
    }
}
