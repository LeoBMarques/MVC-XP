using MVC_XP.Model.DTO;
using MVC_XP.Model.Entidades;
using MVC_XP.Model.Interfaces;

namespace MVC_XP.Model.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository _repository;

        public ClienteService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> AddAsync(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Nome = clienteDto.Nome
            };
            await _repository.AddAsync<Cliente>(cliente);
            await _repository.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task<int> CountAsync()
        {
            return await _repository.CountAsync<Cliente>();
        }

        public async Task<int> DeleteAsync(long id)
        {
            await _repository.DeleteAsync<Cliente>(id);
            return await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var query = _repository.Query<Cliente>();
            var dtoQuery = query.Select(x => new ClienteDto
            {
                Id = x.Id,
                Nome = x.Nome
            });
            return await _repository.ToListAsync(dtoQuery);
        }

        public async Task<ClienteDto?> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync<Cliente>(id);
            if (entity != null)
            {
                return new ClienteDto
                {
                    Id = entity.Id,
                    Nome = entity.Nome
                };
            }
            return null;
        }

        public async Task<IEnumerable<ClienteDto>> GetByNameAsync(string name)
        {
            var query = _repository.Query<Cliente>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Nome.Contains(name));
            }
            var dtoQuery = query.Select(x => new ClienteDto
            {
                Id = x.Id,
                Nome = x.Nome
            });
            return await _repository.ToListAsync(dtoQuery);
        }

        public async Task<int> UpdateAsync(ClienteDto clienteDto)
        {
            var cliente = await _repository.GetByIdAsync<Cliente>(clienteDto.Id);
            cliente.Nome = clienteDto.Nome;
            _repository.Update<Cliente>(cliente);
            return await _repository.SaveChangesAsync();
        }
    }
}
