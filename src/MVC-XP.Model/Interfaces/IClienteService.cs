using MVC_XP.Model.DTO;

namespace MVC_XP.Model.Interfaces
{
    public interface IClienteService
    {
        Task<long> AddAsync(ClienteDto cliente);
        Task<int> CountAsync();
        Task<int> DeleteAsync(long id);
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(long id);
        Task<IEnumerable<ClienteDto>> GetByNameAsync(string name);
        Task<int> UpdateAsync(ClienteDto cliente);
    }
}
