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
    public class ProdutoService:IProduto
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public ProdutoService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            var ProdutoList = await _context.Produtos
                .Include(p => p.SubCategoriaProduto)
                .ToListAsync();

            return ProdutoList;
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            var Produto = await _context.Produtos.FindAsync(id);
            if (Produto == null) return null;

            return Produto;
        }

        public async Task<Produto> AddAsync(ProdutoDto dto)
        {
            var subCategoriaProduto = await _context.SubCategoriasProdutos.FindAsync(dto.SubCategoriaProdutoId);
            if (subCategoriaProduto == null) return null;

            var Produto = _mapper.Map<Produto>(dto);
            Produto.SubCategoriaProduto = subCategoriaProduto;

            await _context.Produtos.AddAsync(Produto);

            await _context.SaveChangesAsync();
            return Produto;
        }

        public async Task<(Produto, CodigoResult)> UpdateAsync(ProdutoDto dto, Guid id)
        {
            var Produto = await _context.Produtos.FindAsync(id);
            if (Produto == null) return (null, CodigoResult.ProdutoNaoEncontrado);

            var subCategoriaProduto = await _context.SubCategoriasProdutos.FindAsync(dto.SubCategoriaProdutoId);
            if (subCategoriaProduto == null) return (null, CodigoResult.SubCategoriaNaoEncontrada);

            Produto = _mapper.Map(dto, Produto);
            Produto.SubCategoriaProduto = subCategoriaProduto;

            await _context.SaveChangesAsync();
            return (Produto, CodigoResult.Sucesso);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var Produto = await _context.Produtos.FindAsync(id);
            if (Produto == null) return false;

            _context.Produtos.Remove(Produto);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
