using AutoMapper;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;

namespace Mecanica_Automotiva.Mapper
{
    public class DadosVeiculoProfile : Profile
    {
        public DadosVeiculoProfile()
        {
            CreateMap<MarcaVeiculo, MarcaVeiculoDto>();
            CreateMap<MarcaVeiculoDto, MarcaVeiculo>()
                .ForMember(dest => dest.Modelos, opt => opt.Ignore())
                .ForMember(dest => dest.Veiculo, opt => opt.Ignore());

            CreateMap<ModeloVeiculo, ModeloVeiculoDto>()
                .ForMember(dest=> dest.MarcaId, opt=>opt.Ignore());
            CreateMap<ModeloVeiculoDto, ModeloVeiculo>()
                .ForMember(dest=> dest.MarcaVeiculo, opt=>opt.Ignore())
                .ForMember(dest=> dest.Veiculo, opt=>opt.Ignore());
        }
    }
}
