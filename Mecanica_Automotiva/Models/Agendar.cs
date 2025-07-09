﻿using Mecanica_Automotiva.Models.DadosCliente;

namespace Mecanica_Automotiva.Models
{
    public class Agendar
    {
        public Guid ID { get; set; }
        public DateOnly Data { get; set; }
        public TimeOnly Hora { get; set; }
        public string Queixa { get; set; }
        public double ValorTotal { get; set; }
        public TimeOnly TempoServiçoTotal { get; set; }
        public ICollection<Servico> Servicos { get; set; } = new List<Servico>();
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
