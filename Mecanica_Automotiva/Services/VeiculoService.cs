using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class VeiculoService //talves de pra tirar veiculo ja que modelo ja pega marca
    {
        private readonly DataBase _context;
        public VeiculoService(DataBase context)
        {
            this._context = context;
        }
        public async Task<List<Veiculo>> GetAllAsync()
        {
            var veiculoList = await _context.Veiculos.Include(v => v.Marca)
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
            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) return (null, CodigoResult.MarcaNaoEncontrada);

            var modelo = await _context.Modelos.FindAsync(dto.ModeloId);
            if (modelo == null) return (null, CodigoResult.ModeloNaoEncontrado);

            var veiculo = new Veiculo()
            {
                Id = Guid.NewGuid(),
                Placa = dto.Placa,
                Marca = marca,
                Modelo = modelo,
                Ano = dto.Ano
            };

            await _context.Veiculos.AddAsync(veiculo);

            await _context.SaveChangesAsync();
            return (veiculo, CodigoResult.Sucesso);
        }

        // Entrada: id do veiculo, dto com os dados atualizados
        public async Task<(Veiculo, CodigoResult)> UpdateAsync(Guid id, VeiculoDto dto)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) return (null, CodigoResult.VeiculoNaoEncontrado);

            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) return (null, CodigoResult.MarcaNaoEncontrada);

            var modelo = await _context.Modelos.FindAsync(dto.ModeloId);
            if (modelo == null) return (null, CodigoResult.ModeloNaoEncontrado);

            veiculo.Placa = dto.Placa;
            veiculo.Marca = marca;
            veiculo.Modelo = modelo;
            veiculo.Ano = dto.Ano;

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
