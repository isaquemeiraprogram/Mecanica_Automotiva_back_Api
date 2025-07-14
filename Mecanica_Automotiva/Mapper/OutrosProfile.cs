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
                .ForMember(dest => dest.ModelosVeiculosIds, opt => opt.Ignore());

            CreateMap<ProdutoDto, Produto>()
                .ForMember(dest => dest.SubCategoriaProduto, opt => opt.Ignore())
                .ForMember(dest => dest.MarcaProduto, opt => opt.Ignore())
                .ForMember(dest => dest.MarcasVeiculos, opt => opt.Ignore())
                .ForMember(dest => dest.ModelosVeiculos, opt => opt.Ignore())
                .ForMember(dest => dest.Servico, opt => opt.Ignore());

            CreateMap<Veiculo, VeiculoDto>()
                .ForMember(dest => dest.ModeloId, opt => opt.Ignore());

            CreateMap<VeiculoDto, Veiculo>()
                .ForMember(dest => dest.Marca, opt => opt.Ignore())
                .ForMember(dest => dest.Modelo, opt => opt.Ignore())
                .ForMember(dest => dest.Produtos, opt => opt.Ignore());

            CreateMap<Agenda, AgendarDto>()
                .ForMember(dest => dest.ServicosId, opt => opt.Ignore())
                .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
                .ForMember(dest => dest.VeiculoId, opt => opt.Ignore());

            CreateMap<AgendarDto,Agenda>()
                .ForMember(dest => dest.TempoServiçoTotal, opt => opt.Ignore())
                .ForMember(dest => dest.ValorTotal, opt => opt.Ignore())
                .ForMember(dest => dest.Servicos, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Veiculo, opt => opt.Ignore());

        }
    }
}
