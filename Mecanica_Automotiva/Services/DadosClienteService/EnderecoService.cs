using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Interface.IDadosCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosClienteService
{
    public class EnderecoService : IEndereco
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public EnderecoService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        //nao precisa de getAll quando pega cliente ja vem getbyid pode precisar pra descobrir de quem é o endereco

        public async Task<Endereco> GetByIdAsync(Guid id)
        {
            var endereco = await _context.Enderecos
                          .Include(e => e.Cliente)
                          .FirstOrDefaultAsync(e=> e.Id == id);

            if (endereco == null) return null;

            
            return endereco;
        }
        public async Task<Endereco> AddAsync(EnderecoDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null) return null;

            var endereco = _mapper.Map<Endereco>(dto);
            endereco.Cliente = cliente;

            await _context.Enderecos.AddAsync(endereco);

            await _context.SaveChangesAsync();
            return endereco;
        }
        public async Task<Endereco> UpdateAsync(EnderecoDto dto, Guid id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) return null;

            endereco = _mapper.Map(dto,endereco);
            //nao tem pq botar o cliente na atualizacao mas se tirar da dto da ruim arruma mais tarde

            await _context.SaveChangesAsync();
            return endereco;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            Endereco endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) return false;

            _context.Enderecos.Remove(endereco);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
