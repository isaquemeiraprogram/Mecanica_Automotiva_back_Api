using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosPecaService
{
    public class CategoriaService
    {
        private readonly DataBase _context;

        public CategoriaService(DataBase _context)
        {
            this._context = _context;
        }


        public async Task<List<CategoriaPeca>> GetAllAsync()
        {
            var categoriaList = await _context.CategoriasPecas.ToListAsync();

            return categoriaList;
        }
        public async Task<CategoriaPeca> GetByIdAsync(Guid id)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(id);
            if (categoria == null) return null;

            return categoria;
        }
        public async Task<CategoriaPeca> AddAsync(CategoriaPecaDto dto)
        {
            CategoriaPeca categoria = new CategoriaPeca
            {
                ID = Guid.NewGuid(),
                Nome = dto.Nome
            };

            await _context.CategoriasPecas.AddAsync(categoria);

            await _context.SaveChangesAsync();
            return categoria;
        }
        public async Task<CategoriaPeca> UpdateAsync(CategoriaPecaDto dto, Guid id)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(id);
            if (categoria == null) return null;

            categoria.Nome = dto.Nome;

            await _context.SaveChangesAsync();
            return categoria;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(id);
            if (categoria == null) return false;

            _context.CategoriasPecas.Remove(categoria);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
