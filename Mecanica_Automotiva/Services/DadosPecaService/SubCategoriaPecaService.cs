using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtosDadosPescas;
using Mecanica_Automotiva.Interface.IDadosPeca;
using Mecanica_Automotiva.Models.Produtos;
using Mecanica_Automotiva.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mecanica_Automotiva.Services.DadosPecaService
{
    public class SubCategoriaPecaService:ISubCategoriaPeca
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;


        public SubCategoriaPecaService(DataBase _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        public async Task<List<SubCategoriaPeca>> GetAllAsync()
        {
            var subcategoriaList = await _context.SubCategoriasPecas
                .Include(subcategoria => subcategoria.CategoriaPeca)
                .ToListAsync();

            return subcategoriaList;
        }

        public async Task<SubCategoriaPeca> GetByIdAsync(Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (subCategoria == null) return null;

            return subCategoria;
        }

        //filtro entrada:um id de categoria
        //saida : lista de subcategorias que pertencem a categoriaid
        public async Task<List<SubCategoriaPeca>> GetFiltroSubcategoriaAsync(Guid id)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(id);
            if (categoria == null) return null;

            var subcategoriaList = await _context.SubCategoriasPecas
                    .Include(s => s.CategoriaPeca)
                    .Where(sbc => sbc.CategoriaPeca.ID == id)
                    .ToListAsync();

            return subcategoriaList;
        }

        public async Task<SubCategoriaPeca> AddAsync(SubCategoriaPecaDto dto)
        {
            var categoria = await _context.CategoriasPecas.FindAsync(dto.CategoriaId);
            if (categoria == null) return null; 

            var subCategoria = _mapper.Map<SubCategoriaPeca>(dto);

            await _context.SubCategoriasPecas.AddAsync(subCategoria);

            await _context.SaveChangesAsync();
            return subCategoria;
        }

        public async Task<(SubCategoriaPeca,CodigoResult)> UpdateAsync(SubCategoriaPecaDto dto, Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (subCategoria == null) return (null,CodigoResult.SubCategoriaNaoEncontrada);

            var categoria = await _context.CategoriasPecas.FindAsync(dto.CategoriaId);
            if (categoria == null) return (null, CodigoResult.CategoriaNaoEncontrada);


            subCategoria = _mapper.Map(dto, subCategoria);

            await _context.SaveChangesAsync();
            return (subCategoria, CodigoResult.Sucesso);
        }

        //Entrada: id da subcategoria
        public async Task<(bool,CodigoResult)> DeleteAsync(Guid id)
        {
            var subCategoria = await _context.SubCategoriasPecas.FindAsync(id);
            if (subCategoria == null) return(false,CodigoResult.SubCategoriaNaoEncontrada);

            _context.SubCategoriasPecas.Remove(subCategoria);

            await _context.SaveChangesAsync();
            return (true, CodigoResult.Sucesso);
        }
    }
}
