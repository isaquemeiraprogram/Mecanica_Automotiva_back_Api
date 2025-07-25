﻿using AutoMapper;
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
            CreateMap<CategoriaProdutoDto, CategoriaProduto>()
                .ForMember(dest=> dest.Id, opt=> opt.Ignore());


            CreateMap<SubCategoriaProduto, SubCategoriaProdutoDto>()
                .ForMember(dest => dest.CategoriaId, opt => opt.Ignore());

            CreateMap<SubCategoriaProdutoDto, SubCategoriaProduto>()
                .ForMember(dest => dest.CategoriaProduto, opt => opt.Ignore())
                .ForMember(dest => dest.Produtos, opt => opt.Ignore());

            CreateMap<MarcaProduto, MarcaProdutoDto>();
            CreateMap<MarcaProdutoDto, MarcaProduto>()
                .ForMember(dest => dest.Produtos, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
