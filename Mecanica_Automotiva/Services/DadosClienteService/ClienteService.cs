using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Exception;
using Mecanica_Automotiva.Interface.IDadosCliente;
using Mecanica_Automotiva.Models.DadosCliente;
using Microsoft.EntityFrameworkCore;

namespace Mecanica_Automotiva.Services.DadosClienteService
{
    public class ClienteService : ICliente
    {
        private readonly DataBase _context;
        private readonly IMapper _mapper;

        public ClienteService(DataBase context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            var clienteList = await _context.Clientes.ToListAsync();

            return clienteList;
        }
        public async Task<Cliente> GetByCpfAsync(string cpf)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);

            if (cliente == null) throw new NotFoundException("Cliente Não Encontrado");

            return cliente;
        }

        // fazer ele botar endereco tambem quando cria cliente
        public async Task<Cliente> AddAsync(ClienteDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);

            await _context.Clientes.AddAsync(cliente);

            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task<Cliente> UpdateAsync(ClienteDto dto, string cpf)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
            if (cliente == null) throw new NotFoundException("Cliente Não Encontrado");

            cliente = _mapper.Map(dto, cliente);

            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task<bool> DeleteAsync(string cpf)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
            if (cliente == null) throw new NotFoundException("Cliente Não Encontrado");

            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
