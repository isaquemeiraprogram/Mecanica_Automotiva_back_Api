using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Services.DadosVeiculoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers.DadosVeiculoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly ModeloService _service;

        public ModeloController(ModeloService _service)
        {
            this._service = _service;
        }


        [HttpGet]
        public async Task<List<Modelo>> GetAllModelo()
        {
            return await _service.GetAllModelo();
        }

        [HttpGet("{id}")]
        public async Task<Modelo> GetModeloById(Guid id)
        {
            return await _service.GetModeloById(id);
        }

        [HttpPost]
        public async Task<string> AddModelo([FromBody] ModeloDto dto)
        {
            return await _service.AddModelo(dto);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateModelo([FromBody] ModeloDto dto, Guid id)
        {
            return await _service.UpdateModelo(dto, id);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteModelo(Guid id)
        {
            return await _service.DeleteModelo(id);
        }
    }
}
