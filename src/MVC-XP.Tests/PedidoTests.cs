using MVC_XP.Model.DTO;

namespace MVC_XP.Tests
{
    public class PedidoTests : BaseTests
    {
        public PedidoTests() : base("MVC_XP.Tests.PedidoTests")
        {
        }

        [Fact]
        public async Task DeveCadastrarPedidoComSucesso()
        {
            var service = GetPedidoService();
            var clienteNome = "ClientePedido";
            var clienteId = await AddClienteAsync(clienteNome);
            var produtoNome = "Bola";
            var produtoValor = 5;
            var produtoId = await AddProdutoAsync(produtoNome, produtoValor);
            var produtoQuantidade = 7;
            var pedidoValorTotal = produtoValor * produtoQuantidade;
            var pedido = new PedidoDto
            {
                ClienteId = clienteId,
                Items = new List<PedidoItemDto>
                {
                    new PedidoItemDto
                    {
                        ProdutoId = produtoId,
                        Quantidade = produtoQuantidade
                    }
                }
            };
            var id = await service.AddAsync(pedido);
            Assert.NotEqual(0, id);
            var pedidoSalvo = await service.GetByIdAsync(id);
            Assert.NotNull(pedidoSalvo);
            Assert.Equal(clienteNome, pedidoSalvo.Cliente);
            Assert.Equal(pedidoValorTotal, pedidoSalvo.ValorTotal);
            Assert.Contains(pedidoSalvo.Items, x => x.Produto == produtoNome);
        }

        [Fact]
        public async Task DeveRetornarListaDePedidosDeUmClienteComSucesso()
        {
            var service = GetPedidoService();
            var clienteId = await AddClienteAsync("ClientePedido2");
            var produtoId1 = await AddProdutoAsync("Carrinho", 1);
            var produtoId2 = await AddProdutoAsync("Boneca", 1);
            var pedido1 = new PedidoDto
            {
                ClienteId = clienteId,
                Items = new List<PedidoItemDto>
                {
                    new PedidoItemDto
                    {
                        ProdutoId = produtoId1,
                        Quantidade = 1
                    }
                }
            };
            var pedido2 = new PedidoDto
            {
                ClienteId = clienteId,
                Items = new List<PedidoItemDto>
                {
                    new PedidoItemDto
                    {
                        ProdutoId = produtoId2,
                        Quantidade = 1
                    }
                }
            };
            var pedidoId1 = await service.AddAsync(pedido1);
            var pedidoId2 = await service.AddAsync(pedido2);
            Assert.NotEqual(0, pedidoId1);
            Assert.NotEqual(0, pedidoId2);
            var listaPedidos = await service.GetByClientIdAsync(clienteId);
            Assert.NotEmpty(listaPedidos);
            Assert.Contains(listaPedidos, x => x.Id == pedidoId1);
            Assert.Contains(listaPedidos, x => x.Id == pedidoId2);
        }

        private async Task<long> AddClienteAsync(string nome)
        {
            var service = GetClienteService();
            var cliente = new ClienteDto
            {
                Nome = nome
            };
            return await service.AddAsync(cliente);
        }

        private async Task<long> AddProdutoAsync(string nome, decimal valor)
        {
            var service = GetProdutoService();
            var produto = new ProdutoDto
            {
                Nome = nome,
                Valor = valor
            };
            return await service.AddAsync(produto);
        }
    }
}
