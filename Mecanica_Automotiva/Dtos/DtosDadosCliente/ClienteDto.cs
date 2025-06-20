using Mecanica_Automotiva.Models.DadosCliente;

namespace Mecanica_Automotiva.Dtos.DtoCliente
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Guid EnderecoId { get; set; }
    }
}
