using MVC_XP.Model.DTO;

namespace MVC_XP.Model.Interfaces
{
    public interface IProdutoService
    {
        Task<long> AddAsync(ProdutoDto produto);
        Task<int> CountAsync();
        Task<int> DeleteAsync(long id);
        Task<IEnumerable<ProdutoDto>> GetAllAsync();
        Task<ProdutoDto> GetByIdAsync(long id);
        Task<IEnumerable<ProdutoDto>> GetByNameAsync(string name);
        Task<int> UpdateAsync(ProdutoDto produto);
    }
}