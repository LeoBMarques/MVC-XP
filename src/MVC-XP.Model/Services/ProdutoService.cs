using MVC_XP.Model.DTO;
using MVC_XP.Model.Entidades;
using MVC_XP.Model.Interfaces;

namespace MVC_XP.Model.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IRepository _repository;

        public ProdutoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> AddAsync(ProdutoDto produtoDto)
        {
            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Valor = produtoDto.Valor,
            };
            await _repository.AddAsync<Produto>(produto);
            await _repository.SaveChangesAsync();
            return produto.Id;
        }

        public async Task<int> CountAsync()
        {
            return await _repository.CountAsync<Produto>();
        }

        public async Task<int> DeleteAsync(long id)
        {
            await _repository.DeleteAsync<Produto>(id);
            return await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
        {
            var query = _repository.Query<Produto>();
            var dtoQuery = query.Select(x => new ProdutoDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Valor= x.Valor
            });
            return await _repository.ToListAsync(dtoQuery);
        }

        public async Task<ProdutoDto?> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync<Produto>(id);
            if (entity != null)
            {
                return new ProdutoDto
                {
                    Id = entity.Id,
                    Nome = entity.Nome,
                    Valor = entity.Valor
                };
            }
            return null;
        }

        public async Task<IEnumerable<ProdutoDto>> GetByNameAsync(string name)
        {
            var query = _repository.Query<Produto>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Nome.Contains(name));
            }
            var dtoQuery = query.Select(x => new ProdutoDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Valor = x.Valor
            });
            return await _repository.ToListAsync(dtoQuery);
        }

        public async Task<int> UpdateAsync(ProdutoDto produtoDto)
        {
            var produto = await _repository.GetByIdAsync<Produto>(produtoDto.Id);
            produto.Nome = produtoDto.Nome;
            produto.Valor = produtoDto.Valor;
            _repository.Update<Produto>(produto);
            return await _repository.SaveChangesAsync();
        }
    }
}
