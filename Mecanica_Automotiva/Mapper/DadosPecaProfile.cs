using AutoMapper;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Mapper
{
    public class DadosPecaProfile : Profile
    {
        public DadosPecaProfile()
        {
            CreateMap<CategoriaPeca, CategoriaPecaDto>();
            CreateMap<CategoriaPecaDto, CategoriaPeca>();

            CreateMap<SubCategoriaPeca, SubCategoriaPecaDto>()
                .ForMember(dest => dest.CategoriaId, opt => opt.Ignore());

            CreateMap<SubCategoriaPecaDto, SubCategoriaPeca>()
                .ForMember(dest => dest.CategoriaPeca, opt => opt.Ignore())
                .ForMember(dest => dest.Pecas, opt => opt.Ignore());
        }
    }
}
