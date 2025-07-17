using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Interface.IDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Services.DadosVeiculoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers.DadosVeiculoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloVeiculoController : ControllerBase
    {
        private readonly IModelo _service;

        public ModeloVeiculoController(IModelo _service)
        {
            this._service = _service;
        }


        [HttpGet]
        public async Task<ActionResult<List<ModeloVeiculo>>> GetAllAsync()
        {
            var modeloList = await _service.GetAllAsync();
            return Ok(modeloList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModeloVeiculo>> GetByIdAsync(Guid id)
        {
            var modelo = await _service.GetByIdAsync(id);

            return modelo;
        }

        [HttpPost]
        public async Task<ActionResult<ModeloVeiculo>> AddAsync([FromBody] ModeloVeiculoDto dto)
        {
            var modelo = await _service.AddAsync(dto);

            return modelo;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModeloVeiculo>> UpdateAsync([FromBody] ModeloVeiculoDto dto, Guid id)
        {
            var modelo = await _service.UpdateAsync(dto, id);

            return modelo;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var modelo = await _service.DeleteAsync(id);
            
            return modelo;
        }
    }
}
