using Mecanica_Automotiva.CodigosdeErros;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mecanica_Automotiva.Services.DadosPecaService
{
    public class SubCategoriaService
    {
        private readonly DataBase _context;

        public SubCategoriaService(DataBase context)
        {
            _context = context;
        }

        public async Task<List<SubCategoriaPeca>> GetAllAsync()
        {
            var subcategoriaList = await _context.SubCategoriasPecas
                .Include(subcategoria => subcategoria.CategoriaPeca)
                .ToListAsync();

            return subcategoriaList;
        }

        public async Task<SubCategoriaPeca> GetByIdAsync(Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (subCategoria == null) return null;

            return subCategoria;
        }

        //filtro entrada:um id de categoria
        //saida : lista de subcategorias que pertencem a categoriaid
        public async Task<List<SubCategoriaPeca>> GetFiltroSubcategoriaAsync(Guid id)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(id);
            if (categoria == null) return null;

            var subcategoriaList = await _context.SubCategoriasPecas
                    .Include(s => s.CategoriaPeca)
                    .Where(sbc => sbc.CategoriaPeca.ID == id)
                    .ToListAsync();

            return subcategoriaList;
        }

        public async Task<SubCategoriaPeca> AddAsync(SubCategoriaPecaDto dto)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(dto.CategoriaId);
            if (categoria == null) return null; 

            var subCategoria = new SubCategoriaPeca
            {
                ID = Guid.NewGuid(),
                Nome = dto.Nome,
                CategoriaPeca = categoria
            };

            await _context.SubCategoriasPecas.AddAsync(subCategoria);

            await _context.SaveChangesAsync();
            return subCategoria;
        }

        public async Task<(SubCategoriaPeca,CodigoResult)> UpdateAsync(SubCategoriaPecaDto dto, Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (subCategoria == null) return (null,CodigoResult.SubCategoriaNaoEncontrada);

            var categoria = await _context.CategoriasPecas.FindAsync(dto.CategoriaId);
            if (categoria == null) return (null, CodigoResult.CategoriaNaoEncontrada);


            subCategoria.Nome = dto.Nome;
            subCategoria.CategoriaPeca = categoria;

            await _context.SaveChangesAsync();
            return (subCategoria,0);
        }

        //Entrada: id da subcategoria
        public async Task<(bool,CodigoResult)> DeleteAsync(Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (subCategoria == null) return(false,CodigoResult.SubCategoriaNaoEncontrada);

            _context.SubCategoriasPecas.Remove(subCategoria);

            await _context.SaveChangesAsync();
            return (true, CodigoResult.Sucesso);
        }
    }
}
