using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Interface.IDadosPeca; //peca == produto
using Mecanica_Automotiva.Models.Produtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosPecaService
{
    public class CategoriaProdutoService:ICategoriaProduto
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;


        public CategoriaProdutoService(DataBase _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }


        public async Task<List<CategoriaProduto>> GetAllAsync()
        {
            var categoriaList = await _context.CategoriasProdutos.ToListAsync();

            return categoriaList;
        }
        public async Task<CategoriaProduto> GetByIdAsync(Guid id)
        {
            var categoria = await _context.CategoriasProdutos.FindAsync(id);
            if (categoria == null) return null;

            return categoria;
        }
        public async Task<CategoriaProduto> AddAsync(CategoriaProdutoDto dto)
        {
            var categoria = _mapper.Map<CategoriaProduto>(dto);

            await _context.CategoriasProdutos.AddAsync(categoria);

            await _context.SaveChangesAsync();
            return categoria;
        }
        public async Task<CategoriaProduto> UpdateAsync(CategoriaProdutoDto dto, Guid id)
        {
            var categoria = await _context.CategoriasProdutos.FindAsync(id);
            if (categoria == null) return null;

           categoria = _mapper.Map(dto, categoria);

            await _context.SaveChangesAsync();
            return categoria;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var categoria = await _context.CategoriasProdutos.FindAsync(id);
            if (categoria == null) return false;

            _context.CategoriasProdutos.Remove(categoria);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
