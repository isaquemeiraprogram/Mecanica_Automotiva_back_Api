using System.Globalization;
using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Middleware;
using Mecanica_Automotiva.Models;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class AgendaService : IAgenda
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public AgendaService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Agenda>> GetAllAsync()
        {
            var agendamentoList = await _context.Agendamentos
                 .Include(a => a.Servicos)
                    .ThenInclude(s => s.Produtos)
                 .Include(a => a.Cliente)
                    .ThenInclude(c => c.Endereco)
                 .Include(a => a.Veiculo)
                    .ThenInclude(v => v.Modelo)
                    .ThenInclude(v => v.MarcaVeiculo)
                 .ToListAsync();

            return agendamentoList;
        }
        public async Task<Agenda> GetByIdAsync(Guid id)
        {
            var agendamento = await _context.Agendamentos
                .Include(a => a.Servicos)
                .Include(a => a.Cliente)
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (agendamento == null) return null;

            return agendamento;
        }
        public async Task<(Agenda, CodigoResult)> AddAsync(AgendarDto dto)
        {
            var servicoList = await _context.Servicos
                .Where(s => dto.ServicosId
                .Contains(s.Id))
                .ToListAsync();
            if (!servicoList.Any()) return (null, CodigoResult.ServicoNaoEncontrado);

            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null) return (null, CodigoResult.ClienteNaoEncontrado);

            var veiculo = await _context.Veiculos.FindAsync(dto.VeiculoId);
            if (veiculo == null) return (null, CodigoResult.VeiculoNaoEncontrado);

            var TempoServiçoTotal = TimeSpan.Zero;
            foreach (var item in servicoList)
            {
                TempoServiçoTotal += item.Duracao;
            }

            var ValorTotal = 0.0;
            foreach (var item in servicoList)
            {
                ValorTotal = item.Valor;
            }

            var agendar = _mapper.Map<Agenda>(dto);
            agendar.Servicos = servicoList;
            agendar.Cliente = cliente;
            agendar.Veiculo = veiculo;
            agendar.TempoServiçoTotal = TempoServiçoTotal;
            agendar.ValorTotal = ValorTotal;

            await _context.Agendamentos.AddAsync(agendar);

            await _context.SaveChangesAsync();
            return (agendar, CodigoResult.Sucesso);
        }
        public async Task<(Agenda, CodigoResult)> UpdateAsync(AgendarDto dto, Guid id)
        {
            var agendamento = await _context.Agendamentos
                .Include(a => a.Servicos) // use include na hora de acahar quando for atualizar classes que tenham colecoes
                .FirstOrDefaultAsync(a => a.Id == id);
            if (agendamento == null) return (null, CodigoResult.AgendamentoNaoEncontrado);

            var servicoList = await _context.Servicos
               .Where(s => dto.ServicosId
               .Contains(s.Id))
               .ToListAsync();
            if (!servicoList.Any()) return (null, CodigoResult.ServicoNaoEncontrado);

            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null) return (null, CodigoResult.ClienteNaoEncontrado);

            var veiculo = await _context.Veiculos.FindAsync(dto.VeiculoId);
            if (veiculo == null) return (null, CodigoResult.VeiculoNaoEncontrado);

            var tempoServiçoTotal = TimeSpan.Zero;
            foreach (var item in servicoList)
            {
                tempoServiçoTotal += item.Duracao;
            }

            var valorTotal = 0.0;
            foreach (var item in servicoList)
            {
                valorTotal = item.Valor;
            }

            //pra poder fazer update da lista de uma classe limpa ela pq senao ele vai adicionar os mesmos itens novamente deixando duplicado
            agendamento.Servicos.Clear();
            //_context.Entry(agendamento).Collection(a => a.Servicos).Load();

            agendamento = _mapper.Map(dto, agendamento);
            agendamento.Servicos = servicoList;
            agendamento.Cliente = cliente;
            agendamento.Veiculo = veiculo;
            agendamento.TempoServiçoTotal = tempoServiçoTotal;
            agendamento.ValorTotal = valorTotal;

            await _context.SaveChangesAsync();
            return (agendamento, CodigoResult.Sucesso);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null) return false;

            _context.Agendamentos.Remove(agendamento);

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
