using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class PecasService:IPeca
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public PecasService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Peca>> GetAllAsync()
        {
            var pecaList = await _context.Pecas
                .Include(p => p.SubCategoriaPeca)
                .ToListAsync();

            return pecaList;
        }

        public async Task<Peca> GetByIdAsync(Guid id)
        {
            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null) return null;

            return peca;
        }

        public async Task<Peca> AddAsync(PecaDto dto)
        {
            var subCategoriaPeca = await _context.SubCategoriasPecas.FindAsync(dto.SubCategoriaPecaId);
            if (subCategoriaPeca == null) return null;

            var peca = _mapper.Map<Peca>(dto);
            peca.SubCategoriaPeca = subCategoriaPeca;

            await _context.Pecas.AddAsync(peca);

            await _context.SaveChangesAsync();
            return peca;
        }

        public async Task<(Peca, CodigoResult)> UpdateAsync(PecaDto dto, Guid id)
        {
            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null) return (null, CodigoResult.PecaNaoEncontrada);

            var subCategoriaPeca = await _context.SubCategoriasPecas.FindAsync(dto.SubCategoriaPecaId);
            if (subCategoriaPeca == null) return (null, CodigoResult.SubCategoriaNaoEncontrada);

            peca = _mapper.Map(dto, peca);
            peca.SubCategoriaPeca = subCategoriaPeca;

            await _context.SaveChangesAsync();
            return (peca, CodigoResult.Sucesso);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null) return false;

            _context.Pecas.Remove(peca);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
