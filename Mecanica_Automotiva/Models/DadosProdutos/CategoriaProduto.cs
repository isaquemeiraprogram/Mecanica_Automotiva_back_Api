using System.ComponentModel;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.Produtos
{
    public class CategoriaProduto
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<SubCategoriaProduto> SubCategoria { get; set; } = new List<SubCategoriaProduto>();

        //mecanica
        //eletrica
        //fluidos/hidraulica
        //lataria/estrutural
        //interior e conforto
    }
}
