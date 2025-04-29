using MVC_XP.Model.DTO;

namespace MVC_XP.Tests
{
    public class ProdutoTests : BaseTests
    {
        public ProdutoTests() : base("MVC_XP.Tests.ProdutoTests")
        {
        }

        [Fact]
        public async Task DeveCadastrarProdutoComSucesso()
        {
            var service = GetProdutoService();
            var produto = new ProdutoDto
            {
                Nome = "Teste",
                Valor = 1
            };
            var id = await service.AddAsync(produto);
            Assert.NotEqual(0, id);
            var produtoSalvo = await service.GetByIdAsync(id);
            Assert.NotNull(produtoSalvo);
            Assert.Equal(produto.Nome, produtoSalvo.Nome);
        }

        [Fact]
        public async Task DeveRetornarListaDeProdutosComSucesso()
        {
            var service = GetProdutoService();
            var lista = new List<ProdutoDto>
            {
                new ProdutoDto
                {
                    Nome = "Teste2",
                    Valor = 2
                },
                new ProdutoDto
                {
                    Nome = "Teste3",
                    Valor = 3
                }
            };
            foreach (var produto in lista)
            {
                await service.AddAsync(produto);
            }
            var listaSalva = await service.GetAllAsync();
            Assert.NotEmpty(listaSalva);
            foreach (var produto in lista)
            {
                Assert.Contains(listaSalva, x => x.Nome == produto.Nome);
            }
        }
    }
}
