using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Models.Produtos
{
    public class SubCategoriaPeca
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }

        public CategoriaPeca CategoriaPeca { get; set; }
        //mecanica -> motor, transmissão, suspensão, freios, direção
        //eletrica -> bateria, alternador, motor de partida, faróis, lanternas
        //fluidos/hidraulica -> óleo, fluido de freio, fluido de direção, refrigerante
        //lataria/estrutural -> chassis, carroceria, portas, capô, para-choques
        //interior e conforto -> bancos, painel, volante, ar-condicionado, sistema de som

    }
}
