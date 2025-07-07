using AutoMapper;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Mapper
{
    public class DadosVeiculoProfile : Profile
    {
        public DadosVeiculoProfile()
        {
            CreateMap<Marca, MarcaDto>();
            CreateMap<MarcaDto, Marca>();

            CreateMap<Modelo, ModeloDto>();
            CreateMap<ModeloDto, Modelo>();           
        }
    }
}
