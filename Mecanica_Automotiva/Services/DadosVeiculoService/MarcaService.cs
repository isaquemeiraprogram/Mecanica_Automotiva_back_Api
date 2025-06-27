using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
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

        public async Task<List<Marca>> GetAllMarcas()
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task<Marca> GetMarcaById(Guid id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) throw new Exception("Marca não encontrada");

            return marca;
        }

        public async Task<string> AddMarca(MarcaDto dto)
        {
            Marca marca = new Marca
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome
            };
            
            await _context.Marcas.AddAsync(marca);

            await _context.SaveChangesAsync();
            return $"Marca {marca.Nome} adicionada com sucesso";
        }

        public async Task<string> UpdateMarca(MarcaDto dto, Guid id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) throw new Exception("Marca não encontrada");

            marca.Nome = dto.Nome;

            await _context.SaveChangesAsync();
            return $"Marca {marca.Nome} atualizada com sucesso";
        }

        public async Task<string> DeleteMarca(Guid id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) throw new Exception("Marca não encontrada");

            _context.Marcas.Remove(marca);

            await _context.SaveChangesAsync();
            return $"Marca {marca.Nome} deletada com sucesso";
        }
    }
}
