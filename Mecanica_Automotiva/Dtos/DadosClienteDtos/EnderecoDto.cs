using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Dtos.DtoCliente
{
    public class EnderecoDto
    {
        //usado pra proteger a api caso fizerem requisições direto nao confie so no front-end
        //valida o que entra antes de enviar pra dentro e envia mensagem caso nao passe na validacao
        //balida tamanho formato e se é obrigatorio
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve conter exatamente 8 números.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = " Maximo de 100 Caracteres neste campo")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = " Maximo de 100 Caracteres neste campo")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = " Maximo de 100 Caracteres neste campo")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = " Maximo de 100 Caracteres neste campo")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^\d{1,5}$", ErrorMessage = "Este campo so deve conter números")]
        public string Numero { get; set; }

        [MaxLength(150, ErrorMessage = " Maximo de 150 Caracteres neste campo")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 números.")]
        public string ClienteCpf { get; set; }

    }
}
