using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Services.DadosVeiculoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers.DadosVeiculoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly MarcaService _service;

        public MarcaController(MarcaService _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public async Task<List<Marca>> GetAllMarcas()
        {
            return await _service.GetAllMarcas();
        }

        [HttpGet("{id}")]
        public async Task<Marca> GetMarcaById(Guid id)
        {
            return await _service.GetMarcaById(id);
        }

        [HttpPost]
        public async Task<string> AddMarca( [FromBody] MarcaDto dto)
        {
            return await _service.AddMarca(dto);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateMarca([FromBody] MarcaDto dto, Guid id)
        {
            return await _service.UpdateMarca(dto, id);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteMarca(Guid id)
        {
            return await _service.DeleteMarca(id);
        }
    }
}
