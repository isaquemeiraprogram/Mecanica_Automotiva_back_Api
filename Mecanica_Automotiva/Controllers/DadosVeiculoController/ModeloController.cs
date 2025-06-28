using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Services.DadosVeiculoService;
using Mecanica_Automotiva.Shared;
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
        public async Task<ActionResult<List<Modelo>>> GetAllAsync()
        {
            var modeloList = await _service.GetAllAsync();
            return Ok(modeloList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetByIdAsync(Guid id)
        {
            var modelo = await _service.GetByIdAsync(id);
            if (modelo == null) return NotFound("Modelo não encontrado.");

            return modelo;
        }

        [HttpPost]
        public async Task<ActionResult<Modelo>> AddAsync([FromBody] ModeloDto dto)
        {
            var modelo = await _service.AddAsync(dto);
            if (modelo == null) return NotFound("Marca do modelo nao encontrada");
            return modelo;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Modelo>> UpdateAsync([FromBody] ModeloDto dto, Guid id)
        {
            var (modelo,codigo) = await _service.UpdateAsync(dto, id);

            if (codigo == CodigoResult.ModeloNaoEncontrado) return NotFound("Modelo não encontrado.");
            if(codigo == CodigoResult.MarcaNaoEncontrada) return NotFound("Marca do modelo não encontrada.");

            return modelo;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var modelo = await _service.DeleteAsync(id);
            if (modelo == false) NotFound("Modelo não encontrado.");
            
            return modelo;
        }
    }
}
