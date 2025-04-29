using Microsoft.AspNetCore.Mvc;
using MVC_XP.Model.DTO;
using MVC_XP.Model.Interfaces;

namespace MVC_XP.Api.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("clientes")]
        public async Task<ActionResult> Get()
        {
            var result = await _clienteService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("clientes/count")]
        public async Task<ActionResult> GetCount()
        {
            var result = await _clienteService.CountAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("clientes/nome/{name}")]
        public async Task<ActionResult> GetByName(string name)
        {
            var result = await _clienteService.GetByNameAsync(name);
            return Ok(result);
        }

        [HttpGet]
        [Route("clientes/{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var result = await _clienteService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("clientes")]
        public async Task<ActionResult> Post(ClienteDto cliente)
        {
            await _clienteService.AddAsync(cliente);
            return new OkResult();
        }

        [HttpPut]
        [Route("clientes/{id}")]
        public async Task<ActionResult> Put(long id, ClienteDto cliente)
        {
            await _clienteService.UpdateAsync(cliente);
            return new OkResult();
        }

        [HttpDelete]
        [Route("clientes/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _clienteService.DeleteAsync(id);
            return new OkResult();
        }
    }
}