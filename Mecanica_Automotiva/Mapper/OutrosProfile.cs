using AutoMapper;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;

namespace Mecanica_Automotiva.Mapper
{
    public class OutrosProfile : Profile
    {
        public OutrosProfile()
        {
            CreateMap<Peca, PecaDto>()
                .ForMember(dest => dest.SubCategoriaPecaId, opt => opt.Ignore())
                .ForMember(dest => dest.MarcaPecaId, opt => opt.Ignore())
                .ForMember(dest => dest.ModeloPecaId, opt => opt.Ignore())
                .ForMember(dest => dest.MarcaVeiculoId, opt => opt.Ignore())
                .ForMember(dest => dest.ModeloVeiculoId, opt => opt.Ignore());

            CreateMap<PecaDto, Peca>()
                .ForMember(dest => dest.SubCategoriaPeca, opt => opt.Ignore())
                .ForMember(dest => dest.MarcaPeca, opt => opt.Ignore())
                .ForMember(dest => dest.ModeloPeca, opt => opt.Ignore())
                .ForMember(dest => dest.MarcaVeiculo, opt => opt.Ignore())
                .ForMember(dest => dest.ModeloVeiculo, opt => opt.Ignore())
                .ForMember(dest => dest.Servico, opt => opt.Ignore());

            CreateMap<Veiculo, VeiculoDto>()
                .ForMember(dest => dest.ModeloId, opt => opt.Ignore());

            CreateMap<VeiculoDto, Veiculo>()
                .ForMember(dest => dest.Marca, opt => opt.Ignore())
                .ForMember(dest => dest.Modelo, opt => opt.Ignore())
                .ForMember(dest => dest.Pecas, opt => opt.Ignore());
        }
    }
}
