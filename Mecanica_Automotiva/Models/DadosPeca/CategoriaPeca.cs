using System.ComponentModel;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.Produtos
{
    public class CategoriaPeca
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<SubCategoriaPeca> SubCategoria { get; set; } = new List<SubCategoriaPeca>();

        //mecanica
        //eletrica
        //fluidos/hidraulica
        //lataria/estrutural
        //interior e conforto
    }
}
