using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Interface.IDadosPeca;//peca == produto
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Shared;
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
            var subCategoria = await _context.SubCategoriasProdutos.FindAsync(id);
            if (subCategoria == null) return null;

            return subCategoria;
        }

        //filtro entrada:um id de categoria
        //saida : lista de subcategorias que pertencem a categoriaid
        public async Task<List<SubCategoriaProduto>> GetFiltroSubcategoriaAsync(Guid id)
        {
            var categoria = await _context.CategoriasProdutos.FindAsync(id);
            if (categoria == null) return null;

            var subcategoriaList = await _context.SubCategoriasProdutos
                    .Include(s => s.CategoriaProduto)
                    .Where(sbc => sbc.CategoriaProduto.ID == id)
                    .ToListAsync();

            return subcategoriaList;
        }

        public async Task<SubCategoriaProduto> AddAsync(SubCategoriaProdutoDto dto)
        {
            var categoriaProduto = await _context.CategoriasProdutos.FindAsync(dto.CategoriaId);
            if (categoriaProduto == null) return null; 

            var subCategoriaProduto = _mapper.Map<SubCategoriaProduto>(dto);
            subCategoriaProduto.CategoriaProduto = categoriaProduto;

            await _context.SubCategoriasProdutos.AddAsync(subCategoriaProduto);

            await _context.SaveChangesAsync();
            return subCategoriaProduto;
        }

        public async Task<(SubCategoriaProduto,CodigoResult)> UpdateAsync(SubCategoriaProdutoDto dto, Guid id)
        {
            var subCategoriaProduto = await _context.SubCategoriasProdutos.FindAsync(id);
            if (subCategoriaProduto == null) return (null,CodigoResult.SubCategoriaNaoEncontrada);

            var categoria = await _context.CategoriasProdutos.FindAsync(dto.CategoriaId);
            if (categoria == null) return (null, CodigoResult.CategoriaNaoEncontrada);


            subCategoriaProduto = _mapper.Map(dto, subCategoriaProduto);
            subCategoriaProduto.CategoriaProduto = categoria;

            await _context.SaveChangesAsync();
            return (subCategoriaProduto, CodigoResult.Sucesso);
        }

        //Entrada: id da subcategoria
        public async Task<(bool,CodigoResult)> DeleteAsync(Guid id)
        {
            var subCategoria = await _context.SubCategoriasProdutos.FindAsync(id);
            if (subCategoria == null) return(false,CodigoResult.SubCategoriaNaoEncontrada);

            _context.SubCategoriasProdutos.Remove(subCategoria);

            await _context.SaveChangesAsync();
            return (true, CodigoResult.Sucesso);
        }
    }
}
