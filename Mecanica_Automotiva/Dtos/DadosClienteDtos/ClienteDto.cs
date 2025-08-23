using Mecanica_Automotiva.Models.DadosCliente;
using System.ComponentModel.DataAnnotations;

namespace Mecanica_Automotiva.Dtos.DtoCliente
{
    public class ClienteDto
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100 , ErrorMessage = " Maximo de 100 Caracteres neste campo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 Dígitos.")]
        public string Cpf { get; set; }
    }
}
