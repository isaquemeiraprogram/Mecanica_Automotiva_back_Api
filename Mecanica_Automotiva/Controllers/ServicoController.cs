using Mecanica_Automotiva.Dtos;
using Mecanica_Automotiva.Interface;
using Mecanica_Automotiva.Models;
using Mecanica_Automotiva.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServico _service;

        public ServicoController(IServico service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Servico>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Servico> GetByIdAsync(Guid id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Servico> AddAsync(ServicoDto dto)
        {
            return await _service.AddAsync(dto);
        }

        [HttpPut("{id}")]
        public async Task<(Servico, CodigoResult)> UpdateAsync(ServicoDto dto, Guid id)
        {
            return await _service.UpdateAsync(dto, id);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _service.DeleteAsync(id);
        }
    }
}
