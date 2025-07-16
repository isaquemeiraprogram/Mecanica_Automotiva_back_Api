using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Interface.IDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosVeiculoService
{
    public class MarcaVeiculoService:IMarca
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public MarcaVeiculoService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MarcaVeiculo>> GetAllAsync()
        {
            return await _context.MarcaVeiculos.ToListAsync();
        }

        public async Task<MarcaVeiculo> GetByIdAsync(Guid id)
        {
            var marca = await _context.MarcaVeiculos.FindAsync(id);
            if (marca == null) return null;

            return marca;
        }

        public async Task<MarcaVeiculo> AddAsync(MarcaVeiculoDto dto)
        {
            var marca = _mapper.Map<MarcaVeiculo>(dto);

            await _context.MarcaVeiculos.AddAsync(marca);

            await _context.SaveChangesAsync();
            return marca;
        }

        public async Task<MarcaVeiculo> UpdateAsync(MarcaVeiculoDto dto, Guid id)
        {
            var marca = await _context.MarcaVeiculos.FindAsync(id);
            if (marca == null) return null;

            marca = _mapper.Map(dto, marca);

            await _context.SaveChangesAsync();
            return (marca);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var marca = await _context.MarcaVeiculos.FindAsync(id);
            if (marca == null) return false;

            _context.MarcaVeiculos.Remove(marca);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
