using AutoMapper;
using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;

namespace Mecanica_Automotiva.Mapper
{
    public class DadosClienteProfile : Profile
    {
        public DadosClienteProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();

            CreateMap<Endereco, EnderecoDto>()
                .ForMember(dest => dest.ClienteId, opt => opt.Ignore());

            CreateMap<EnderecoDto, Endereco>()
                .ForMember(dest => dest.Cliente, opt => opt.Ignore());
        }
    }
}
