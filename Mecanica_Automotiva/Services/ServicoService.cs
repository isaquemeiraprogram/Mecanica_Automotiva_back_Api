using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class ServicoService : IServico
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public ServicoService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //recebe um servico dto e sai um servico com a lista de Produtos necessarias para oservico
        public async Task<Servico> AddAsync(ServicoDto dto)
        {
            if (dto.ProdutosId == null) { }
            var listProdutos = await _context.Produtos
                .Where(lp=>dto.ProdutosId
                .Contains(lp.Id)).ToListAsync();

            var servico = _mapper.Map<Servico>(dto);
            servico.Produtos = listProdutos;

            await _context.Servicos.AddAsync(servico);

            await _context.SaveChangesAsync();
            return servico;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null) return false;
            
            _context.Servicos.Remove(servico);

            return true;
        }

        //pensar em retornar Produtos tbm dai ja tem nocao esse servico vai tantas Produtos
        public async Task<List<Servico>> GetAllAsync()
        {
            var servicoList = await _context.Servicos.ToListAsync();
            return servicoList;
        }

        public async Task<Servico> GetByIdAsync(Guid id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null) return null;

            return servico;
        }

        public async Task<(Servico,CodigoResult)> UpdateAsync(ServicoDto dto, Guid id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null) return (null,CodigoResult.ServicoNaoEncontrado);

            var ProdutoList = await _context.Produtos.Where(pl=> dto.ProdutosId.Contains(pl.Id)).ToListAsync();
            if (ProdutoList == null) return (null,CodigoResult.ProdutoNaoEncontrado);

            servico = _mapper.Map(dto,servico);
            servico.Produtos = ProdutoList;

            return (servico,CodigoResult.Sucesso);
        }
    }
}
