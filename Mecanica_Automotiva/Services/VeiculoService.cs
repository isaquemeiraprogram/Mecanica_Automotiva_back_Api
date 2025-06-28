using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services
{
    public class VeiculoService
    {
        private readonly DataBase _context;
        public VeiculoService(DataBase context)
        {
            this._context = context;
        }
        public async Task<List<Veiculo>> GetAllAsync()
        {

            //implantar api pra pegar veiculo pela placa
            return await _context.Veiculos.Include(v => v.Marca)
                                          .Include(v => v.Modelo)
                                          .ToListAsync();
        }
        public async Task<Veiculo> GetByIdAsync(Guid id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) throw new Exception("Veículo não encontrado");
            return veiculo;
        }

        public async Task<string> AddAsync(VeiculoDto dto)
        {
            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) throw new Exception("Marca não encontrada");

            var modelo = await _context.Modelos.FindAsync(dto.ModeloId);
            if (modelo == null) throw new Exception("Modelo não encontrado");

            var veiculo = new Veiculo()
            {
                Id = Guid.NewGuid(),
                Marca = marca,
                Modelo = modelo
            };
            
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
            return "Veículo adicionado com sucesso!";
        }

        public async Task<string> UpdateAsync(Guid id, VeiculoDto dto)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) throw new Exception("Veículo não encontrado");

            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) throw new Exception("Marca não encontrada");

            var modelo = await _context.Modelos.FindAsync(dto.ModeloId);
            if (modelo == null) throw new Exception("Modelo não encontrado");

            veiculo.Marca = marca;
            veiculo.Modelo = modelo;

            await _context.SaveChangesAsync();
            return "Veículo atualizado com sucesso!";
        }

        public async Task<string> DeleteAsync(Guid id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) throw new Exception("Veículo não encontrado");

            _context.Veiculos.Remove(veiculo);

            await _context.SaveChangesAsync();
            return "Veículo removido com sucesso!";
        }
    }
}
