using MVC_XP.Model.DTO;

namespace MVC_XP.Model.Interfaces
{
    public interface IPedidoService
    {
        Task<long> AddAsync(PedidoDto pedido);
        Task<int> CountAsync();
        Task<IEnumerable<PedidoViewDto>> GetByClientIdAsync(long clientId);
        Task<PedidoViewDto?> GetByIdAsync(long id);
    }
}