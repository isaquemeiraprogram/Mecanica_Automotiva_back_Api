using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Dtos.DtoCliente
{
    public class EnderecoDto
    {
        //usado pra proteger a api caso fizerem requisições direto nao confie so no front-end
        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve conter exatamente 8 números.")]
        public string Cep { get; set; }

        [Required] // colocar controle de tamanho em todos pra um racker nao colar um script q da ruim em tudo
        [RegularExpression(@"^.{1,100}$")]
        public string Estado { get; set; }

        [Required]
        [RegularExpression(@"^.{1,100}$")]
        public string Cidade { get; set; }

        [Required]
        [RegularExpression(@"^.{1,100}$")]
        public string Bairro { get; set; }

        [Required]
        [RegularExpression(@"^.{1,100}$")]
        public string Rua { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,5}$", ErrorMessage = "Este campo so deve conter números")]
        public string Numero { get; set; }

        [RegularExpression(@"^.{1,100}$")]
        public string Complemento { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 números.")]
        public string ClienteCpf { get; set; }

    }
}
