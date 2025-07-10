using AutoMapper;
using Mecanica_Automotiva.Dtos.DadosProdutosDtos;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.DadosPeca;
using Mecanica_Automotiva.Models.Produtos;

namespace Mecanica_Automotiva.Mapper
{
    public class DadosProdutoProfile : Profile
    {
        public DadosProdutoProfile()
        {
            CreateMap<CategoriaProduto, CategoriaProdutoDto>();
            CreateMap<CategoriaProdutoDto, CategoriaProduto>();

            CreateMap<SubCategoriaProduto, SubCategoriaProdutoDto>()
                .ForMember(dest => dest.CategoriaId, opt => opt.Ignore());

            CreateMap<SubCategoriaProdutoDto, SubCategoriaProduto>()
                .ForMember(dest => dest.CategoriaProduto, opt => opt.Ignore())
                .ForMember(dest => dest.Produtos, opt => opt.Ignore());

            CreateMap<MarcaProduto, MarcaProdutoDto>();
            CreateMap<MarcaProdutoDto, MarcaProduto>()
                .ForMember(dest => dest.Modelos, opt => opt.Ignore())
                .ForMember(dest => dest.Produtos, opt => opt.Ignore());

            CreateMap<ModeloProduto, ModeloProdutoDto>()
               .ForMember(dest => dest.Marca, opt => opt.Ignore());

            CreateMap<ModeloProdutoDto, ModeloProduto>()
                .ForMember(dest => dest.Marca, opt => opt.Ignore())
                .ForMember(dest => dest.Produtos, opt => opt.Ignore());
        }
    }
}
