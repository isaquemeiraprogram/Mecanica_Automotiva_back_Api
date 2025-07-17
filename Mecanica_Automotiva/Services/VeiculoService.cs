using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Exception;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class VeiculoService : IVeiculo
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public VeiculoService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Veiculo>> GetAllAsync()
        {
            var veiculoList = await _context.Veiculos
                .Include(v => v.Marca)
                .Include(v => v.Modelo)
                .ToListAsync();
            //implantar api pra pegar veiculo pela placa
            return veiculoList;
        }

        //Entrada: id do veiculo
        public async Task<Veiculo> GetByIdAsync(Guid id)
        {
            var veiculo = await _context.Veiculos
                .Include(v => v.Marca)
                .Include(v => v.Modelo).FirstOrDefaultAsync(v => v.Id == id);

            if (veiculo == null) throw new NotFoundException("Veículo Não Encontrado");

            return veiculo;
        }

        public async Task<Veiculo> AddAsync(VeiculoDto dto)
        {
            var modeloVeiculo = await _context.ModeloVeiculos
                               .Include(mv => mv.MarcaVeiculo)
                               .FirstOrDefaultAsync(mv => dto.ModeloId == mv.Id);
            if (modeloVeiculo == null) throw new NotFoundException("Modelo De Veículo Não Encontrado");

            var veiculo = _mapper.Map<Veiculo>(dto);
            veiculo.Marca = modeloVeiculo.MarcaVeiculo;
            veiculo.Modelo = modeloVeiculo;

            await _context.Veiculos.AddAsync(veiculo);

            await _context.SaveChangesAsync();
            return veiculo;
        }

        // Entrada: id do veiculo, dto com os dados atualizados
        public async Task<Veiculo> UpdateAsync(Guid id, VeiculoDto dto)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) throw new NotFoundException("Veículo Não Encontrado");

            var modeloVeiculo = await _context.ModeloVeiculos
                .Include(modv => modv.MarcaVeiculo)
                .FirstOrDefaultAsync(modv => dto.ModeloId == modv.Id);
            if (modeloVeiculo == null) throw new NotFoundException("Modelo De Veículo Não Encontrado");

            veiculo = _mapper.Map(dto, veiculo);
            veiculo.Marca = modeloVeiculo.MarcaVeiculo;
            veiculo.Modelo = modeloVeiculo;

            await _context.SaveChangesAsync();
            return veiculo;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) throw new NotFoundException("Veículo Não Encontrado");

            _context.Veiculos.Remove(veiculo);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
