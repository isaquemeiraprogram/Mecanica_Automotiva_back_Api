using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosVeiculoService
{
    public class ModeloService
    {
        private readonly DataBase _context;

        public ModeloService(DataBase _context)
        {
            this._context = _context;
        }
        //fazer filtro
        public async Task<List<Modelo>> GetAllAsync()
        {
            var modelosList = await _context.Modelos
                                    .ToListAsync();
            return modelosList;
        }

        public async Task<Modelo> GetByIdAsync(Guid id)
        {
            var modelo = await _context.Modelos.FindAsync(id);

            if (modelo == null) return null;

            return modelo;
        }

        public async Task<Modelo> AddAsync(ModeloDto dto)
        {
            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) return null;

            var modelo = new Modelo
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Marca = marca
            };

            await _context.Modelos.AddAsync(modelo);

            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<(Modelo,CodigoResult)> UpdateAsync(ModeloDto dto, Guid id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null) return (null,CodigoResult.ModeloNaoEncontrado);

            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) return (null, CodigoResult.MarcaNaoEncontrada);

            modelo.Nome = dto.Nome;
            modelo.Marca = marca;

            await _context.SaveChangesAsync();
            return (modelo,CodigoResult.Sucesso);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null) return false;

            _context.Modelos.Remove(modelo);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
