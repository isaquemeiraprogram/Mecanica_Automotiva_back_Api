using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Services.DadosPecaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Controllers.DadosPecaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _service;

        public CategoriaController(CategoriaService _service)
        {
            this._service = _service;
        }


        [HttpGet]
        public async Task<List<CategoriaPeca>> GetAllCategorias()
        {
            return await _service.GetAllCategorias();
        }

        [HttpGet("{id}")]
        public async Task<CategoriaPeca> GetCategoriasById(Guid id)
        {
            return await _service.GetCategoriasById(id);
        }

        [HttpPost]
        public async Task<string> AddCategoria([FromBody] CategoriaPecaDto dto)
        {
            return await _service.AddCategoria(dto);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateCategoria([FromBody] CategoriaPecaDto dto, Guid id)
        {
            return await _service.UpdateCategoria(dto,id);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteCategoria(Guid id)
        {
            return await _service.DeleteCategoria(id);
        }

    }
}
