using AutoMapper;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;

namespace Mecanica_Automotiva.Mapper
{
    public class OutrosProfile : Profile
    {
        public OutrosProfile()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.SubCategoriaProdutoId, opt => opt.Ignore())
                .ForMember(dest => dest.MarcaProdutoId, opt => opt.Ignore())
                .ForMember(dest => dest.MarcaVeiculoId, opt => opt.Ignore())
                .ForMember(dest => dest.ModeloVeiculoId, opt => opt.Ignore());

            CreateMap<ProdutoDto, Produto>()
                .ForMember(dest => dest.SubCategoriaProduto, opt => opt.Ignore())
                .ForMember(dest => dest.MarcaProduto, opt => opt.Ignore())
                .ForMember(dest => dest.MarcaVeiculo, opt => opt.Ignore())
                .ForMember(dest => dest.ModeloVeiculo, opt => opt.Ignore())
                .ForMember(dest => dest.Servico, opt => opt.Ignore());

            CreateMap<Veiculo, VeiculoDto>()
                .ForMember(dest => dest.ModeloId, opt => opt.Ignore());

            CreateMap<VeiculoDto, Veiculo>()
                .ForMember(dest => dest.Marca, opt => opt.Ignore())
                .ForMember(dest => dest.Modelo, opt => opt.Ignore())
                .ForMember(dest => dest.Produtos, opt => opt.Ignore());
        }
    }
}
