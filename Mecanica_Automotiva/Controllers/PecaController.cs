using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Services;
using Mecanica_Automotiva.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecaController : ControllerBase
    {
        private readonly PecasService _service;

        public PecaController(PecasService _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Peca>>> GetAllAsync()
        {
            var pecaList = await _service.GetAllAsync();
            return Ok(pecaList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Peca>> GetByIdAsync(Guid id)
        {
            var peca = await _service.GetByIdAsync(id);
            if (peca == null) return NotFound("Peça não encontrada.");

            return Ok(peca);
        }

        [HttpPost]
        public async Task<ActionResult<Peca>> AddAsync(PecasDto dto)
        {
            var peca = await _service.AddAsync(dto);
            if (peca == null) return NotFound("Subcategoria não encontrada.");

            return Ok(peca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<(Peca, CodigoResult)>> UpdateAsync(PecasDto dto, Guid id)
        {
            var (peca, codigo) = await _service.UpdateAsync(dto, id);

            switch (codigo)
            {
                case CodigoResult.PecaNaoEncontrada:
                    return NotFound("Peça não encontrada.");
                case CodigoResult.SubCategoriaNaoEncontrada:
                    return NotFound("Subcategoria da peca não encontrada.");
            }

            return Ok(peca);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var peca = await _service.DeleteAsync(id);
            if (peca) return NotFound("Peça não encontrada.");

            return true;
        }
    }
}
