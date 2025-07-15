using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

namespace Mecanica_Automotiva.Services
{
    public class ProdutoService : IProduto
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
                .ThenInclude(subcatp=> subcatp.CategoriaProduto)
                .Include(p => p.MarcaProduto)
                .Include(p => p.MarcasVeiculos)
                .Include(p => p.ModelosVeiculos)
                .ToListAsync();

            return ProdutoList;
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            var Produto = await _context.Produtos
                .Include(p => p.SubCategoriaProduto)
                .ThenInclude(subcatp => subcatp.CategoriaProduto)
                .Include(p => p.MarcaProduto)
                .Include(p => p.MarcasVeiculos)
                .Include(p => p.ModelosVeiculos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (Produto == null) return null;

            return Produto;
        }

        public async Task<(Produto, CodigoResult)> AddAsync(ProdutoDto dto)
        {
            var subCategoriaProduto = await _context.SubCategoriasProdutos
                .Include(subcat => subcat.CategoriaProduto)
                .FirstOrDefaultAsync(subcat => dto.SubCategoriaProdutoId == subcat.Id);
            if (subCategoriaProduto == null) return (null, CodigoResult.SubCategoriaNaoEncontrada);

            var marcaProduto = await _context.MarcaProdutos.FindAsync(dto.MarcaProdutoId);
            if (marcaProduto == null) return (null, CodigoResult.MarcaProdutoNaoEncontrada);

            //um produto pode servir para varios modelos 
            var modeloVeiculoList = await _context.ModeloVeiculos
                .Include(modv => modv.MarcaVeiculo)
                .Where(modv => dto.ModelosVeiculosIds.Contains(modv.Id))
                .ToListAsync();

            if (!modeloVeiculoList.Any()) return (null, CodigoResult.ModeloNaoEncontrado);

            var Produto = _mapper.Map<Produto>(dto);
            Produto.SubCategoriaProduto = subCategoriaProduto;
            Produto.MarcaProduto = marcaProduto;
            Produto.MarcasVeiculos = modeloVeiculoList.Select(modv => modv.MarcaVeiculo).ToList();
            Produto.ModelosVeiculos = modeloVeiculoList;

            await _context.Produtos.AddAsync(Produto);

            await _context.SaveChangesAsync();
            return (Produto, CodigoResult.Sucesso);
        }

        public async Task<(Produto, CodigoResult)> UpdateAsync(ProdutoDto dto, Guid id)
        {
            var Produto = await _context.Produtos.FindAsync(id);
            if (Produto == null) return (null, CodigoResult.ProdutoNaoEncontrado);

            var subCategoriaProduto = await _context.SubCategoriasProdutos
                .Include(subcat => subcat.CategoriaProduto)
                .FirstOrDefaultAsync(subcat => dto.SubCategoriaProdutoId == subcat.Id);

            if (subCategoriaProduto == null) return (null, CodigoResult.SubCategoriaNaoEncontrada);

            var marcaProduto = await _context.MarcaProdutos.FindAsync(dto.MarcaProdutoId);
            if (marcaProduto == null) return (null, CodigoResult.MarcaProdutoNaoEncontrada);

            var modeloVeiculoList = await _context.ModeloVeiculos
                .Include(modv => modv.MarcaVeiculo)
                .Where(modv => dto.ModelosVeiculosIds
                .Contains(modv.Id)).ToListAsync();

            //any verifica se tem item na lista !any se nao tiver
            if (!modeloVeiculoList.Any()) return (null, CodigoResult.ModeloNaoEncontrado);

            Produto = _mapper.Map(dto, Produto);
            Produto.SubCategoriaProduto = subCategoriaProduto;
            Produto.MarcaProduto = marcaProduto;
            Produto.MarcasVeiculos = modeloVeiculoList.Select(m => m.MarcaVeiculo).ToList();
            Produto.ModelosVeiculos = modeloVeiculoList;

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
