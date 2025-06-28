using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosVeiculoService
{
    public class MarcaService
    {
        private readonly DataBase _context;
        public MarcaService(DataBase context)
        {
            this._context = context;
        }

        public async Task<List<Marca>> GetAllAsync()
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task<Marca> GetByIdAsync(Guid id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) return null;

            return marca;
        }

        public async Task<Marca> AddAsync(MarcaDto dto)
        {
            Marca marca = new Marca
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome
            };
            
            await _context.Marcas.AddAsync(marca);

            await _context.SaveChangesAsync();
            return marca;
        }

        public async Task<Marca> UpdateAsync(MarcaDto dto, Guid id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) return null;

            marca.Nome = dto.Nome;

            await _context.SaveChangesAsync();
            return (marca);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) return false;

            _context.Marcas.Remove(marca);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
