using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Interface.IDadosProdutos;
using Mecanica_Automotiva.Models.DadosPeca;
using Microsoft.EntityFrameworkCore;

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
            var marcaP = _mapper.Map<MarcaProduto>(dto);

            await _context.MarcaProdutos.AddAsync(marcaP);

            await _context.SaveChangesAsync();
            return marcaP;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var marca = await _context.MarcaProdutos.FindAsync(id);
            if (marca == null) return false;
            
            _context.MarcaProdutos.Remove(marca);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MarcaProduto>> GetAllAsync()
        {
            var marcaPList = await _context.MarcaProdutos.ToListAsync();
            return marcaPList;
        }

        public async Task<MarcaProduto> GetByIdAsync(Guid id)
        {
            var marcap = await _context.MarcaProdutos.FindAsync(id);
            if (marcap == null) return null;
            
            return marcap;
        }

        public async Task<MarcaProduto> UpdateAsync(MarcaDto dto, Guid id)
        {
            var marcaP = await _context.MarcaProdutos.FindAsync(id);
            if (marcaP == null) return null;

            marcaP = _mapper.Map(dto,marcaP);

            await _context.SaveChangesAsync();
            return marcaP;
        }
    }
}
