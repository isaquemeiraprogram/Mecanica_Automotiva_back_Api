using System.ComponentModel;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.Produtos
{
    public class ClassePeca
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<SubClassePeca> SubClasses { get; set; } = new List<SubClassePeca>();
        //mecanica
        //eletrica
        //fluidos/hidraulica
        //lataria/estrutural
        //interior e conforto
    }
}
