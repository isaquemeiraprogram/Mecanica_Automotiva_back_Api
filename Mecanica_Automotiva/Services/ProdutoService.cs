using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Exception;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Models.Produtos;
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

        public async Task<Produto> AddAsync(ProdutoDto dto)
        {
            var subCategoriaProduto = await _context.SubCategoriasProdutos
                .Include(subcat => subcat.CategoriaProduto)
                .FirstOrDefaultAsync(subcat => dto.SubCategoriaProdutoId == subcat.Id);
            if (subCategoriaProduto == null) throw new NotFoundException("Subgategoria do produto não Encontrada");

            var marcaProduto = await _context.MarcaProdutos.FindAsync(dto.MarcaProdutoId);
            if (marcaProduto == null) throw new NotFoundException("marca do Produto não encontrada");

            //um produto pode servir para varios modelos 
            var modeloVeiculoList = await _context.ModeloVeiculos
                .Include(modv => modv.MarcaVeiculo)
                .Where(modv => dto.ModelosVeiculosIds.Contains(modv.Id))
                .ToListAsync();

            if (!modeloVeiculoList.Any()) throw new NotFoundException("modelo de veiculo do Produto não encontrado");

            var Produto = _mapper.Map<Produto>(dto);
            Produto.SubCategoriaProduto = subCategoriaProduto;
            Produto.MarcaProduto = marcaProduto;
            Produto.MarcasVeiculos = modeloVeiculoList.Select(modv => modv.MarcaVeiculo).ToList();
            Produto.ModelosVeiculos = modeloVeiculoList;

            await _context.Produtos.AddAsync(Produto);

            await _context.SaveChangesAsync();
            return Produto;
        }

        public async Task<Produto> UpdateAsync(ProdutoDto dto, Guid id)
        {
            var Produto = await _context.Produtos.FindAsync(id);
            if (Produto == null)  throw new NotFoundException("Produto não encontrado");

            var subCategoriaProduto = await _context.SubCategoriasProdutos
                .Include(subcat => subcat.CategoriaProduto)
                .FirstOrDefaultAsync(subcat => dto.SubCategoriaProdutoId == subcat.Id);

            if (subCategoriaProduto == null) throw new NotFoundException("Subcategoria Do Produto Não Encontrada");

            var marcaProduto = await _context.MarcaProdutos.FindAsync(dto.MarcaProdutoId);
            if (marcaProduto == null) throw new NotFoundException("Marca Do Produto Não Encontrada");

            var modeloVeiculoList = await _context.ModeloVeiculos
                .Include(modv => modv.MarcaVeiculo)
                .Where(modv => dto.ModelosVeiculosIds
                .Contains(modv.Id)).ToListAsync();

            //any verifica se tem item na lista !any se nao tiver
            if (!modeloVeiculoList.Any())  throw new NotFoundException("Nenhum Modelo De Produto Foi Encontrado Na Lista");

            Produto = _mapper.Map(dto, Produto);
            Produto.SubCategoriaProduto = subCategoriaProduto;
            Produto.MarcaProduto = marcaProduto;
            Produto.MarcasVeiculos = modeloVeiculoList.Select(m => m.MarcaVeiculo).ToList();
            Produto.ModelosVeiculos = modeloVeiculoList;

            await _context.SaveChangesAsync();
            return Produto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var Produto = await _context.Produtos.FindAsync(id);
            if (Produto == null) throw new NotFoundException("Produto Não Encontrado");

            _context.Produtos.Remove(Produto);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
