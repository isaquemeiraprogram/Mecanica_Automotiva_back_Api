﻿using System.Text.Json.Serialization;

namespace Mecanica_Automotiva.Dtos.DtoCliente
{
    public class EnderecoDto
    {
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }// apto 502, bloco B	Informações extras (apartamento)
        public string ClienteCpf { get; set; }

    }
}
