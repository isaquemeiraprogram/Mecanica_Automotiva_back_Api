using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Services;
using Mecanica_Automotiva.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculo _service;

        public VeiculoController(IVeiculo _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Veiculo>>> GetAllAsync()
        {
            var veiculoList = await _service.GetAllAsync();
            return Ok(veiculoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetByIdAsync(Guid id)
        {
            var veiculo = await _service.GetByIdAsync(id);
            if (veiculo == null) return NotFound("Veículo não encontrado.");

            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<ActionResult<(Veiculo, CodigoResult)>> AddAsync([FromBody] VeiculoDto dto)
        {
            var (veiculo, codigo) = await _service.AddAsync(dto);

            switch (codigo)
            {
                case CodigoResult.MarcaVeiculoNaoEncontrada:
                    return NotFound("Marca  do veiculo não encontrada.");
                case CodigoResult.ModeloNaoEncontrado:
                    return NotFound("Modelo não encontrado.");

            }
            return Ok(veiculo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<(Veiculo, CodigoResult)>> UpdateAsync(Guid id, [FromBody] VeiculoDto dto)
        {
            var (veiculo, codigo) = await _service.UpdateAsync(id, dto);

            switch (codigo)
            {
                case CodigoResult.VeiculoNaoEncontrado:
                    return NotFound("Veículo não encontrado.");

                case CodigoResult.MarcaVeiculoNaoEncontrada:
                    return NotFound("Marca do veiculo não encontrada.");

                case CodigoResult.ModeloNaoEncontrado:
                    return NotFound("Modelo não encontrado.");
            }

            return Ok(veiculo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var veiculo = await _service.DeleteAsync(id);
            if (veiculo == false) return NotFound("Veículo não encontrado.");

            return Ok(veiculo);
        }

    }
}
