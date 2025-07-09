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
            var modelosList = await _context.Modelos
                                    .Include(m=> m.Marca)
                                    .ToListAsync();

            return modelosList;
        }

        public async Task<ModeloVeiculo> GetByIdAsync(Guid id)
        {
            var modelo = await _context.Modelos.FindAsync(id);

            if (modelo == null) return null;

            return modelo;
        }

        public async Task<ModeloVeiculo> AddAsync(ModeloDto dto)
        {
            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) return null;

            var modelo = _mapper.Map<ModeloVeiculo>(dto);
            modelo.Marca = marca;

            await _context.Modelos.AddAsync(modelo);

            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<(ModeloVeiculo,CodigoResult)> UpdateAsync(ModeloDto dto, Guid id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null) return (null,CodigoResult.ModeloNaoEncontrado);

            var marca = await _context.Marcas.FindAsync(dto.MarcaId);
            if (marca == null) return (null, CodigoResult.MarcaNaoEncontrada);

            modelo = _mapper.Map(dto, modelo);
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
