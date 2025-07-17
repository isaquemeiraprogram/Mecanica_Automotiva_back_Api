using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DadosProdutosDtos;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Exception;
using Mecanica_Automotiva.Interface.IDadosProdutos;
using Mecanica_Automotiva.Models.DadosPeca;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosProdutoService
{
    public class MarcaProdutoService : IMarcaProduto
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public MarcaProdutoService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MarcaProduto> AddAsync(MarcaProdutoDto dto)
        {
            var marcaP = _mapper.Map<MarcaProduto>(dto);

            await _context.MarcaProdutos.AddAsync(marcaP);

            await _context.SaveChangesAsync();
            return marcaP;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var marca = await _context.MarcaProdutos.FindAsync(id);
            if (marca == null) throw new NotFoundException("Marca Do Produto Não Encontrado");
            
            _context.MarcaProdutos.Remove(marca);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MarcaProduto>> GetAllAsync()
        {
            var marcaPList = await _context.MarcaProdutos.ToListAsync();

            return marcaPList;
        }

        public async Task<MarcaProduto> GetByIdAsync(Guid id)
        {
            var marcaP = await _context.MarcaProdutos.FindAsync(id);
            if (marcaP == null) throw new NotFoundException("Marca Do Produto Não Encontrada");
            
            return marcaP;
        }

        public async Task<MarcaProduto> UpdateAsync(MarcaProdutoDto dto, Guid id)
        {
            var marcaP = await _context.MarcaProdutos.FindAsync(id);
            if (marcaP == null) throw new NotFoundException("Marca Do Produto Não Encontrada");

            marcaP = _mapper.Map(dto,marcaP);

            await _context.SaveChangesAsync();
            return marcaP;
        }
    }
}
