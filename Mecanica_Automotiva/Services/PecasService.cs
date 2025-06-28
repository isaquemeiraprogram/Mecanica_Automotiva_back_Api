using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class PecasService
    {
        private readonly DataBase _context;

        public PecasService(DataBase _context)
        {
            this._context = _context;
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

        public async Task<Peca> AddAsync(PecasDto dto)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(dto.SubCategoriaPecaId);
            if (subCategoria == null) return null;

            Peca peca = new Peca
            {
                Id = Guid.NewGuid(),
                Img = dto.Img,
                Nome = dto.Nome,
                Preco = dto.Preco,
                SubCategoriaPeca = subCategoria,//subcategoria esta na categoria
            };

            await _context.Pecas.AddAsync(peca);

            await _context.SaveChangesAsync();
            return peca;
        }

        public async Task<(Peca, CodigoResult)> UpdateAsync(PecasDto dto, Guid id)
        {
            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null) return (null, CodigoResult.PecaNaoEncontrada);

            var subCategoria = await _context.SubCategoriasPecas.FindAsync(dto.SubCategoriaPecaId);
            if (subCategoria == null) return (null, CodigoResult.SubCategoriaNaoEncontrada);

            peca.Img = dto.Img;
            peca.Nome = dto.Nome;
            peca.Preco = dto.Preco;
            peca.SubCategoriaPeca = subCategoria;

            await _context.SaveChangesAsync();
            return (peca,CodigoResult.Sucesso);
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
