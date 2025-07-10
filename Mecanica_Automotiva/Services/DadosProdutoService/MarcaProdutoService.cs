using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Interface.IDadosProdutos;
using Mecanica_Automotiva.Models.DadosPeca;

namespace Mecanica_Automotiva.Services.DadosProdutoService
{
    public class MarcaProdutoService : IMarcaProduto
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public MarcaProdutoService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MarcaProduto> AddAsync(MarcaDto dto)
        {
            var marca = 
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MarcaProduto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MarcaProduto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MarcaProduto> UpdateAsync(MarcaDto dto, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
