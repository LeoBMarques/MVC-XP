using MVC_XP.Model.DTO;

namespace MVC_XP.Tests
{
    public class ClienteTests : BaseTests
    {
        public ClienteTests() : base("MVC_XP.Tests.ClienteTests")
        {
        }

        [Fact]
        public async Task DeveCadastrarClienteComSucesso()
        {
            var service = GetClienteService();
            var cliente = new ClienteDto
            {
                Nome = "Teste"
            };
            var id = await service.AddAsync(cliente);
            Assert.NotEqual(0, id);
            var clienteSalvo = await service.GetByIdAsync(id);
            Assert.NotNull(clienteSalvo);
            Assert.Equal(cliente.Nome, clienteSalvo.Nome);
        }

        [Fact]
        public async Task DeveRetornarListaDeClientesComSucesso()
        {
            var service = GetClienteService();
            var lista = new List<ClienteDto>
            {
                new ClienteDto
                {
                    Nome = "Teste2"
                },
                new ClienteDto
                {
                    Nome = "Teste3"
                }
            };
            foreach (var cliente in lista)
            {
                await service.AddAsync(cliente);
            }
            var listaSalva = await service.GetAllAsync();
            Assert.NotEmpty(listaSalva);
            foreach (var cliente in lista)
            {
                Assert.Contains(listaSalva, x => x.Nome == cliente.Nome);
            }
        }
    }
}
