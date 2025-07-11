﻿using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Shared;

namespace Mecanica_Automotiva.Interface.IDadosVeiculo
{
    public interface IModelo
    {
        Task<List<ModeloVeiculo>> GetAllAsync();
        Task<ModeloVeiculo> GetByIdAsync(Guid id);
        Task<ModeloVeiculo> AddAsync(ModeloVeiculoDto dto);
        Task<(ModeloVeiculo, CodigoResult)> UpdateAsync(ModeloVeiculoDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
