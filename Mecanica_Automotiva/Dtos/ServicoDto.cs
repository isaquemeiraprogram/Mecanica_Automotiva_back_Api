﻿using Mecanica_Automotiva.Models;
using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Dtos
{
    public class ServicoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public TimeOnly Duracao { get; set; }
        public Guid AgendarId { get; set; }
        public List<Guid> ProdutosId { get; set; } = new List<Guid>();
    }
}
