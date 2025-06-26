using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class CategoriaService
    {
        private readonly DataBase _context;

        public CategoriaService(DataBase _context)
        {
            this._context = _context;
        }


        public async Task<List<CategoriaPeca>> GetAllCategorias()
        {
            return await _context.CategoriasPecas.ToListAsync();
        }
        public async Task<CategoriaPeca> GetCategoriasById(Guid id)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(id);
            if (categoria == null) throw new Exception("Categoria não encontrada");

            return categoria;
        }
        public async Task<string> AddCategoria(CategoriaPecaDto dto)
        {
            CategoriaPeca categoria = new CategoriaPeca
            {
                ID = Guid.NewGuid(),
                Nome = dto.Nome
            };

            await _context.CategoriasPecas.AddAsync(categoria);

            await _context.SaveChangesAsync();
            return $"Categoria {categoria.Nome} adicionada com sucesso";
        }
        public async Task<string> UpdateCategoria(Guid id, CategoriaPecaDto dto)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(id);
            if (categoria == null) throw new Exception("Categoria não encontrada");

            categoria.Nome = dto.Nome;

            await _context.SaveChangesAsync();
            return $"Categoria {categoria.Nome} atualizada com sucesso";
        }
        public async Task<string> DeleteCategoria(Guid id)
        {
            CategoriaPeca categoria = await _context.CategoriasPecas.FindAsync(id);
            if (categoria == null) throw new Exception("Categoria não encontrada");

            _context.CategoriasPecas.Remove(categoria);

            await _context.SaveChangesAsync();
            return $"Categoria {categoria.Nome} deletada com sucesso";
        }
    }
}
