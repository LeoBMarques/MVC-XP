using MVC_XP.Model.DTO;
using MVC_XP.Model.Entidades;
using MVC_XP.Model.Interfaces;

namespace MVC_XP.Model.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IRepository _repository;

        public PedidoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> AddAsync(PedidoDto pedidoDto)
        {
            var pedido = new Pedido
            {
                Data = DateTime.Now,
                ClienteId = pedidoDto.ClienteId
            };
            var produtos = await GetProducts(pedidoDto.Items.Select(x => x.ProdutoId).ToList());
            pedido.SetItems(pedidoDto.Items, produtos);
            await _repository.AddAsync<Pedido>(pedido);
            await _repository.SaveChangesAsync();
            return pedido.Id;
        }

        public async Task<int> CountAsync()
        {
            return await _repository.CountAsync<Pedido>();
        }

        public async Task<IEnumerable<PedidoViewDto>> GetByClientIdAsync(long clientId)
        {
            var query = _repository.Query<Pedido>();
            query = query.Where(x => x.ClienteId == clientId);
            var dtoQuery = query.Select(x => new PedidoViewDto
            {
                Id = x.Id,
                Cliente = x.Cliente.Nome,
                Data = x.Data,
                ValorTotal = x.ValorTotal,
                Items = x.Items.Select(x => new PedidoItemViewDto
                {
                    Produto = x.Produto.Nome,
                    Quantidade = x.Quantidade,
                    Valor = x.Valor
                })
            });
            return await _repository.ToListAsync(dtoQuery);
        }

        public async Task<PedidoViewDto?> GetByIdAsync(long id)
        {
            var pedido = await _repository.GetByIdAsync<Pedido>(id);
            if (pedido != null)
            {
                return new PedidoViewDto
                {
                    Id = id,
                    Cliente = pedido.Cliente.Nome,
                    Data = pedido.Data,
                    ValorTotal = pedido.ValorTotal,
                    Items = pedido.Items.Select(x => new PedidoItemViewDto
                    {
                        Produto = x.Produto.Nome,
                        Quantidade = x.Quantidade,
                        Valor = x.Valor
                    })
                };
            }
            return default;
        }

        private async Task<IEnumerable<Produto>> GetProducts(IEnumerable<long> ids)
        {
            var query = _repository.Query<Produto>().Where(x => ids.Contains(x.Id));
            return await _repository.ToListAsync(query);
        }
    }
}