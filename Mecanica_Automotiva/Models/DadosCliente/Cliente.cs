using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.DadosCliente
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }//email e tel?
        public int QtdEnderecosCadastrados { get; set; }

        [JsonIgnore]
        public ICollection<Endereco> Endereco { get; set; } = new List<Endereco>();

        [JsonIgnore]
        public ICollection<Agenda> Agendamentos { get; set; } = new List<Agenda>();

    }
}
