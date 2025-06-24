using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Models.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mecanica_Automotiva.Services
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
            return await _context.SubCategoriasPecas.Include(subcategoria => subcategoria.CategoriaPeca).ToListAsync();
        }

        public async Task<SubCategoriaPeca> GetByIdAsync(Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (id == null) throw new Exception("SubCategoria não encontrada");

            return subCategoria;
        }

        //filtro
        public async Task<SubCategoriaPeca> GetSubcategoriaPorCategoria(Guid CategoriaId)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(CategoriaId);
            if (categoria == null) throw new Exception("Categoria não encontrada");

            return await _context.SubCategoriasPecas
                .Where(sbc => sbc.CategoriaPeca.Contains(categoria).ToListAsync());
        }
    }
}
