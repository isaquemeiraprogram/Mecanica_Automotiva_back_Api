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
                .ForMember(dest => dest.VeiculoId, opt => opt.Ignore());

            CreateMap<PecaDto, Peca>()
                .ForMember(dest => dest.SubCategoriaPeca, opt => opt.Ignore())
                .ForMember(dest => dest.Veiculo, opt => opt.Ignore())
                .ForMember(dest => dest.Servico, opt => opt.Ignore());

            CreateMap<Veiculo, VeiculoDto>()
                .ForMember(dest => dest.MarcaId, opt => opt.Ignore())
                .ForMember(dest => dest.ModeloId, opt => opt.Ignore());

            CreateMap<VeiculoDto, Veiculo>()
                .ForMember(dest => dest.Marca, opt => opt.Ignore())
                .ForMember(dest => dest.Modelo, opt => opt.Ignore())
                .ForMember(dest => dest.Pecas, opt => opt.Ignore())
                .ForMember(dest => dest.Servico, opt => opt.Ignore());
        }
    }
}
