using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;
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

        public async Task<List<SubCategoriaPeca>> GetAllSubCategoria()
        {
            return await _context.SubCategoriasPecas.Include(subcategoria => subcategoria.CategoriaPeca).ToListAsync();
        }

        public async Task<SubCategoriaPeca> GetByIdSubCategoria(Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (subCategoria == null) throw new Exception("SubCategoria não encontrada");

            return subCategoria;
        }

        //filtro entrada:um id de categoria saida : lista de subcategorias que pertencem a categoriaid
        public async Task<List<SubCategoriaPeca>> GetSubcategoriaPorCategoria(Guid CategoriaId)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(CategoriaId);
            if (categoria == null) throw new Exception("Categoria não encontrada");

            return await _context.SubCategoriasPecas.Include(s => s.CategoriaPeca)
                .Where(sbc => sbc.CategoriaPeca.ID == CategoriaId).ToListAsync();
        }

        public async Task<string> AddSubCategoria(SubCategoriaPecaDto dto)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(dto.CategoriaId);
            if(categoria == null) throw new Exception("Categoria não encontrada");
            
            SubCategoriaPeca subCategoriaPeca = new SubCategoriaPeca
            {
                ID = Guid.NewGuid(),
                Nome = dto.Nome,
                CategoriaPeca = categoria
            };

            await _context.SubCategoriasPecas.AddAsync(subCategoriaPeca);

            await _context.SaveChangesAsync();
            return "SubCategoria adicionada com sucesso!";
        }

        public async Task<string> UpdateSubCategoria( SubCategoriaPecaDto dto, Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (subCategoria == null) throw new Exception("SubCategoria não encontrada");

            var categoria = await _context.CategoriasPecas.FindAsync(dto.CategoriaId);
            if (categoria == null) throw new Exception("Categoria não encontrada");

            subCategoria.Nome = dto.Nome;
            subCategoria.CategoriaPeca = categoria;

            await _context.SaveChangesAsync();
            return "SubCategoria atualizada com sucesso!";
        }

        public async Task<string> DeleteSubCategoria(Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (subCategoria == null) throw new Exception("SubCategoria não encontrada");

            _context.SubCategoriasPecas.Remove(subCategoria);

            await _context.SaveChangesAsync();
            return "SubCategoria removida com sucesso!";
        }
    }
}
