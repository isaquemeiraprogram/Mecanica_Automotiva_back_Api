using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosClienteService
{
    public class ClienteService
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public ClienteService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClienteDto>> GetAllAsync()
        {
            var clienteList = await _context.Clientes
                .Include(c => c.Endereco)
                .ToListAsync();

           var clienteListDto = _mapper.Map<List<ClienteDto>>(clienteList);
            return clienteListDto;
        }
        public async Task<ClienteDto> GetByIdAsync(Guid id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);

            var clienteDto = _mapper.Map<ClienteDto>(cliente);
            return clienteDto;
        }

       // fazer ele botar endereco tambem quando cria cliente
        public async Task<Cliente> AddAsync(ClienteDto dto)
        {

            var cliente = _mapper.Map<Cliente>(dto);
            //Cliente cliente = new Cliente
            //{
            //    Id = Guid.NewGuid(),
            //    Nome = dto.Nome,
            //    Cpf = dto.Cpf
            //};

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }
        public async Task<ClienteDto> UpdateAsync(ClienteDto dto, Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return null;


            cliente = _mapper.Map(dto, cliente);

            await _context.SaveChangesAsync();

            var clienteDto = _mapper.Map<ClienteDto>(cliente);
            return clienteDto;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
