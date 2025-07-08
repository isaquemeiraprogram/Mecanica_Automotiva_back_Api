using AutoMapper;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Mapper
{
    public class DadosVeiculoProfile : Profile
    {
        public DadosVeiculoProfile()
        {
            CreateMap<MarcaVeiculo, MarcaDto>();
            CreateMap<MarcaDto, MarcaVeiculo>()
                .ForMember(dest => dest.Modelos, opt => opt.Ignore())
                .ForMember(dest => dest.Veiculo, opt => opt.Ignore());

            CreateMap<ModeloVeiculo, ModeloDto>()
                .ForMember(dest=> dest.MarcaId, opt=>opt.Ignore());
            CreateMap<ModeloDto, ModeloVeiculo>()
                .ForMember(dest=> dest.Marca, opt=>opt.Ignore())
                .ForMember(dest=> dest.Veiculo, opt=>opt.Ignore());
        }
    }
}
