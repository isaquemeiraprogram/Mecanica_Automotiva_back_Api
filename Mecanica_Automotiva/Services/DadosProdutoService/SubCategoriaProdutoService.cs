using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Exception;
using Mecanica_Automotiva.Interface.IDadosPeca;//peca == produto
using Mecanica_Automotiva.Models.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mecanica_Automotiva.Services.DadosPecaService
{
    public class SubCategoriaProdutoService:ISubCategoriaProduto
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;


        public SubCategoriaProdutoService(DataBase _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        public async Task<List<SubCategoriaProduto>> GetAllAsync()
        {
            var subcategoriaList = await _context.SubCategoriasProdutos
                .Include(subcategoria => subcategoria.CategoriaProduto)
                .ToListAsync();

            return subcategoriaList;
        }

        public async Task<SubCategoriaProduto> GetByIdAsync(Guid id)
        {
            var subCategoria = await _context.SubCategoriasProdutos
                .Include(subcategoria => subcategoria.CategoriaProduto)
                .FirstOrDefaultAsync(subcat => subcat.Id == id);
            if (subCategoria == null) throw new NotFoundException("Sub-Categoria Do Produto Não Encontrada");

            return subCategoria;
        }

        //filtro entrada:um id de categoria
        //saida : lista de subcategorias que pertencem a categoriaid
        public async Task<List<SubCategoriaProduto>> GetFiltroSubcategoriaAsync(Guid id)
        {
            var categoria = await _context.CategoriasProdutos.FindAsync(id);
            if (categoria == null) throw new NotFoundException("Categoria Do Produto Não Encontrada");

            var subcategoriaList = await _context.SubCategoriasProdutos
                    .Include(s => s.CategoriaProduto)
                    .Where(sbc => sbc.CategoriaProduto.Id == id)
                    .ToListAsync();

            return subcategoriaList;
        }

        public async Task<SubCategoriaProduto> AddAsync(SubCategoriaProdutoDto dto)
        {
            var categoriaProduto = await _context.CategoriasProdutos.FindAsync(dto.CategoriaId);
            if (categoriaProduto == null) throw new NotFoundException("Categoria Do Produto Não Encontrada");

            var subCategoriaProduto = _mapper.Map<SubCategoriaProduto>(dto);
            subCategoriaProduto.CategoriaProduto = categoriaProduto;

            await _context.SubCategoriasProdutos.AddAsync(subCategoriaProduto);

            await _context.SaveChangesAsync();
            return subCategoriaProduto;
        }

        public async Task<SubCategoriaProduto> UpdateAsync(SubCategoriaProdutoDto dto, Guid id)
        {
            var subCategoriaProduto = await _context.SubCategoriasProdutos.FindAsync(id);
            if (subCategoriaProduto == null) throw new NotFoundException("Subcategora Do Produto Não Encontrada");
            var categoria = await _context.CategoriasProdutos.FindAsync(dto.CategoriaId);
            if (categoria == null) throw new NotFoundException("Categoria Do Produto Não Encontrada");

            subCategoriaProduto = _mapper.Map(dto, subCategoriaProduto);
            subCategoriaProduto.CategoriaProduto = categoria;

            await _context.SaveChangesAsync();
            return subCategoriaProduto;
        }

        //Entrada: id da subcategoria
        public async Task<bool> DeleteAsync(Guid id)
        {
            var subCategoria = await _context.SubCategoriasProdutos.FindAsync(id);
            if (subCategoria == null) throw new NotFoundException("Sub-Categoria Do Produto Não Encontrada");
            _context.SubCategoriasProdutos.Remove(subCategoria);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
