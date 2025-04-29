using Microsoft.AspNetCore.Mvc;
using MVC_XP.Model.DTO;
using MVC_XP.Model.Interfaces;

namespace MVC_XP.Api.Controllers
{
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService produtoService)
        {
            _pedidoService = produtoService;
        }

        [HttpGet]
        [Route("pedidos/count")]
        public async Task<ActionResult> GetCount()
        {
            var result = await _pedidoService.CountAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("pedidos/{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var result = await _pedidoService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("pedidos/cliente/{clientId}")]
        public async Task<ActionResult> GetByClientId(long clientId)
        {
            var result = await _pedidoService.GetByClientIdAsync(clientId);
            return Ok(result);
        }

        [HttpPost]
        [Route("pedidos")]
        public async Task<ActionResult> Post(PedidoDto pedido)
        {
            await _pedidoService.AddAsync(pedido);
            return new OkResult();
        }
    }
}