using AutoMapper;
using Mecanica_Automotiva.Context;
using Mecanica_Automotiva.Dtos.DtoCliente;
using Mecanica_Automotiva.Exception;
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

        public async Task<List<Endereco>> GetByCpfAsync(string cpf)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
            if (cliente == null) throw new NotFoundException("Cliente Não Encontrado");

            var enderecoList = await _context.Enderecos
                .Include(e => e.Cliente)
                .Where(e => e.Cliente.Cpf == cpf)
                .ToListAsync();

            if (!enderecoList.Any()) throw new NotFoundException("Cliente sem endereco");

            return enderecoList;
        }

        public async Task<Endereco> AddAsync(EnderecoDto dto)
        {

            var cliente = await _context.Clientes.Include(c=>c.Endereco).FirstOrDefaultAsync(c => dto.ClienteCpf == c.Cpf);
            if (cliente == null) throw new NotFoundException("cliente Não Encontrado");

            var endereco = _mapper.Map<Endereco>(dto);
            endereco.Cliente = cliente;
            cliente.QtdEnderecosCadastrados += 1;

            var contador = 1;
            //any verifica uma lista e retorna true ou false com base em uma condicao - quase um if
            while (cliente.Endereco.Any(e=> e.EnderecoSlug == $"{cliente.Cpf}-{contador}"))
            {
                contador++;
            }
            endereco.EnderecoSlug = $"{cliente.Cpf}-{contador}";

            await _context.Enderecos.AddAsync(endereco);

            await _context.SaveChangesAsync();
            return endereco;
        }
        public async Task<Endereco> UpdateAsync(EnderecoDto dto, string slug)
        {
            var endereco = await _context.Enderecos.Include(e => e.Cliente).FirstOrDefaultAsync(e => e.EnderecoSlug == slug);
            if (endereco == null) throw new NotFoundException("Endereco Não Encontrado");

            endereco = _mapper.Map(dto, endereco);
            //nao tem pq botar o cliente na atualizacao mas se tirar da dto da ruim arruma mais tarde

            await _context.SaveChangesAsync();
            return endereco;
        }
        public async Task<bool> DeleteAsync(string slug)
        {
            Endereco endereco = await _context.Enderecos
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(e => e.EnderecoSlug == slug);

            if (endereco == null) throw new NotFoundException("Endererco Não Encontrado");

            endereco.Cliente.QtdEnderecosCadastrados -= 1;

            _context.Enderecos.Remove(endereco);

            await _context.SaveChangesAsync();
            return true;
        }


    }
}
