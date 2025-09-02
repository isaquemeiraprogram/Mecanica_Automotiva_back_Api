using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosCliente
{
    public class Endereco
    {
        //pra entrega de veiculo e outros produtos 
        // pra controlar tamanho de campos do banco e campos neccessaios

        [Key] //em id guid so usa key q ele ja reconhece como primaru key de 36 caracteres
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]//cpf mais numero do endereco tipo 1endereco 2 endereco deste cpf(cpfE1)
        public string EnderecoSlug { get; set; } // slug = codigo unico amigavel

        [Required]
        [MaxLength(8)]
        public string Cep { get; set; }
        [Required]
        [MaxLength(100)]
        public string Estado { get; set; }
        [Required]
        [MaxLength(100)]
        public string Cidade { get; set; }
        [Required]
        [MaxLength(100)]
        public string Bairro { get; set; }
        [Required]
        [MaxLength(100)]
        public string Rua { get; set; }
        [Required]
        [MaxLength(5)]
        public string Numero { get; set; }
        [Required]
        [MaxLength(150)]
        public string Complemento { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
    }
}
