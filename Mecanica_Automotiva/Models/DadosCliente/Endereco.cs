using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosCliente
{
    public class Endereco
    {
        //pra entrega de veiculo
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}
