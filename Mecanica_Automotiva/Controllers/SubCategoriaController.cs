using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        private readonly SubCategoriaService _Service;

        public SubCategoriaController(SubCategoriaService _Service)
        {
            this._Service = _Service;
        }

        [HttpGet]
        public async Task<List<SubCategoriaPeca>> GetAllAsync()
        {
            return await _Service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<SubCategoriaPeca> GetByIdAsync(Guid id)
        {
            return await _Service.GetByIdAsync(id);
        }

        [HttpGet("/Categoria/{id}")]//o nome da rota tem que ser igual no parametro
        public async Task<List<SubCategoriaPeca>> GetSubcategoriaPorCategoria(Guid id)
        {
            return await _Service.GetSubcategoriaPorCategoria(id);
        }

        [HttpPost]
        public async Task<string> AddSubCategoria(SubCategoriaPecaDto dto)
        {
            return await _Service.AddSubCategoria(dto);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateSubCategoria(SubCategoriaPecaDto dto, Guid id)
        {
            return await _Service.UpdateSubCategoria(dto, id);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteSubCategoria(Guid id)
        {
            return await _Service.DeleteSubCategoria(id);
        }
    }
}
