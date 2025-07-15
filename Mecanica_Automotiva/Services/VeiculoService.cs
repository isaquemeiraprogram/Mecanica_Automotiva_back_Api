using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Shared;
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

            if (veiculo == null) return null;

            return veiculo;
        }

        public async Task<(Veiculo, CodigoResult)> AddAsync(VeiculoDto dto)
        {
            var modeloVeiculo = await _context.ModeloVeiculos.Include(mv => mv.MarcaVeiculo).FirstOrDefaultAsync(mv => dto.ModeloId == mv.Id);
            if (modeloVeiculo == null) return (null, CodigoResult.ModeloNaoEncontrado);



            var veiculo = _mapper.Map<Veiculo>(dto);
            veiculo.Marca = modeloVeiculo.MarcaVeiculo;
            veiculo.Modelo = modeloVeiculo;

            await _context.Veiculos.AddAsync(veiculo);

            await _context.SaveChangesAsync();
            return (veiculo, CodigoResult.Sucesso);
        }

        // Entrada: id do veiculo, dto com os dados atualizados
        public async Task<(Veiculo, CodigoResult)> UpdateAsync(Guid id, VeiculoDto dto)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) return (null, CodigoResult.VeiculoNaoEncontrado);

            var modeloVeiculo = await _context.ModeloVeiculos
                .Include(modv => modv.MarcaVeiculo)
                .FirstOrDefaultAsync(modv => dto.ModeloId == modv.Id);
            if (modeloVeiculo == null) return (null, CodigoResult.ModeloNaoEncontrado);


            veiculo = _mapper.Map(dto, veiculo);
            veiculo.Marca = modeloVeiculo.MarcaVeiculo;
            veiculo.Modelo = modeloVeiculo;

            await _context.SaveChangesAsync();
            return (veiculo, CodigoResult.Sucesso);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) return false;

            _context.Veiculos.Remove(veiculo);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
