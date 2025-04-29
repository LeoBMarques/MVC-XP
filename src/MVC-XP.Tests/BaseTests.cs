using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_XP.Infra;
using MVC_XP.Model.Interfaces;
using MVC_XP.Model.Services;

namespace MVC_XP.Tests
{
    public class BaseTests
    {
        private ServiceProvider _serviceProvider;

        public BaseTests(string testNamespace)
        {
            var services = new ServiceCollection();
            ConfigureDbContext(services, testNamespace);
            ConfigureDI(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureDbContext(ServiceCollection services, string testNamespace)
        {
            services.AddDbContext<MVCXPContext>(options =>
            {
                options.UseInMemoryDatabase(testNamespace);
            });
        }

        private void ConfigureDI(ServiceCollection services)
        {
            // Configure Repository
            services.AddScoped<IRepository, MVCXPRepository>();
            // Configure Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
        }

        protected IClienteService GetClienteService()
        {
            return _serviceProvider.GetService<IClienteService>();
        }

        protected IPedidoService GetPedidoService()
        {
            return _serviceProvider.GetService<IPedidoService>();
        }

        protected IProdutoService GetProdutoService()
        {
            return _serviceProvider.GetService<IProdutoService>();
        }
    }
}
