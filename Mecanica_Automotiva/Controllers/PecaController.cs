using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Services;
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
        public async Task<List<Peca>> GetPecasAsync()
        {
            return await _service.GetPecasAsync();
        }

        [HttpGet("{id}")]
        public async Task<Peca> GetPecaByIdAsync(Guid id)
        {
            return await _service.GetPecaByIdAsync(id);
        }

        [HttpPost]
        public async Task<string> AddPeca([FromBody] PecasDto dto)
        {
            return await _service.AddPeca(dto);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdatePeca([FromBody] PecasDto dto, Guid id)
        {
            return await _service.UpdatePeca(dto, id);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeletePeca(Guid id)
        {
            return await _service.DeletePeca(id);
        }
    }
}
