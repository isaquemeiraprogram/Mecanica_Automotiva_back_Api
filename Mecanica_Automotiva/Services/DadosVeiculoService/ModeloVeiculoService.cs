using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Interface.IDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosVeiculoService
{
    public class ModeloVeiculoService: IModelo
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public ModeloVeiculoService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //fazer filtro
        public async Task<List<ModeloVeiculo>> GetAllAsync()
        {
            var modelosList = await _context.ModeloVeiculos
                                    .Include(m=> m.MarcaVeiculo)
                                    .ToListAsync();

            return modelosList;
        }

        public async Task<ModeloVeiculo> GetByIdAsync(Guid id)
        {
            var modelo = await _context.ModeloVeiculos.FindAsync(id);

            if (modelo == null) return null;

            return modelo;
        }

        public async Task<ModeloVeiculo> AddAsync(ModeloVeiculoDto dto)
        {
            var marca = await _context.MarcaVeiculos.FindAsync(dto.MarcaId);
            if (marca == null) return null;

            var modelo = _mapper.Map<ModeloVeiculo>(dto);
            modelo.MarcaVeiculo = marca;

            await _context.ModeloVeiculos.AddAsync(modelo);

            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<(ModeloVeiculo,CodigoResult)> UpdateAsync(ModeloVeiculoDto dto, Guid id)
        {
            var modelo = await _context.ModeloVeiculos.FindAsync(id);
            if (modelo == null) return (null,CodigoResult.ModeloNaoEncontrado);

            var marca = await _context.MarcaVeiculos.FindAsync(dto.MarcaId);
            if (marca == null) return (null, CodigoResult.MarcaVeiculoNaoEncontrada);

            modelo = _mapper.Map(dto, modelo);
            modelo.MarcaVeiculo = marca;

            await _context.SaveChangesAsync();
            return (modelo,CodigoResult.Sucesso);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var modelo = await _context.ModeloVeiculos.FindAsync(id);
            if (modelo == null) return false;

            _context.ModeloVeiculos.Remove(modelo);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
