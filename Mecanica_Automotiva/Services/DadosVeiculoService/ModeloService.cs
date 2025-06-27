using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
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
        public async Task<List<Modelo>> GetAllModelo()
        {
            return await _context.Modelos.Include(m => m.Marca).ToListAsync();
        }

        public async Task<Modelo> GetModeloById(Guid id)
        {
            var modelo = await _context.Modelos
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modelo == null) throw new Exception("Modelo not found");

            return modelo;
        }

        public async Task<string> AddModelo(ModeloDto dto)
        {
            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) throw new Exception("Marca nao encontrada");

            var modelo = new Modelo
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Marca = marca
            };

            await _context.Modelos.AddAsync(modelo);

            await _context.SaveChangesAsync();
            return $"Modelo {modelo.Nome} adicionado com sucesso";
        }

        public async Task<string> UpdateModelo(ModeloDto dto, Guid id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null) throw new Exception("Modelo not found");

            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) throw new Exception("Marca nao encontrada");

            modelo.Nome = dto.Nome;
            modelo.Marca = marca;

            await _context.SaveChangesAsync();
            return $"Modelo {modelo.Nome} atualizado com sucesso";
        }

        public async Task<string> DeleteModelo(Guid id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null) throw new Exception("Modelo não encontrado");

            _context.Modelos.Remove(modelo);

            await _context.SaveChangesAsync();
            return $"Modelo {modelo.Nome} removido com sucesso";
        }
    }
}
