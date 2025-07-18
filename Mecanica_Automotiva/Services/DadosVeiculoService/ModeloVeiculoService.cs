using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Exception;
using Mecanica_Automotiva.Interface.IDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
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
            var modelo = await _context.ModeloVeiculos
                .Include(mod=> mod.MarcaVeiculo)
                .FirstOrDefaultAsync(mod => mod.Id == id);

            if (modelo == null) throw new NotFoundException("Modelo Do Veíclo Não Encontrado");

            return modelo;
        }

        public async Task<ModeloVeiculo> AddAsync(ModeloVeiculoDto dto)
        {
            var marca = await _context.MarcaVeiculos.FindAsync(dto.MarcaId);
            if (marca == null) throw new NotFoundException("Marca Do Veíclo Não Encontrado");

            var modelo = _mapper.Map<ModeloVeiculo>(dto);
            modelo.MarcaVeiculo = marca;

            await _context.ModeloVeiculos.AddAsync(modelo);

            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<ModeloVeiculo> UpdateAsync(ModeloVeiculoDto dto, Guid id)
        {
            var modelo = await _context.ModeloVeiculos.FindAsync(id);
            if (modelo == null) throw new NotFoundException("Modelo Do Veíclo Não Encontrado");

            var marca = await _context.MarcaVeiculos.FindAsync(dto.MarcaId);
            if (marca == null) throw new NotFoundException("Marca Do Veíclo Não Encontrada");

            modelo = _mapper.Map(dto, modelo);
            modelo.MarcaVeiculo = marca;

            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var modelo = await _context.ModeloVeiculos.FindAsync(id);
            if (modelo == null) throw new NotFoundException("Modelo Do Veíclo Não Encontrado");

            _context.ModeloVeiculos.Remove(modelo);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
