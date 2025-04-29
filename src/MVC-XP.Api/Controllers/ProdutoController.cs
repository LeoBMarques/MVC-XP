using Microsoft.AspNetCore.Mvc;
using MVC_XP.Model.DTO;
using MVC_XP.Model.Interfaces;

namespace MVC_XP.Api.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("produtos")]
        public async Task<ActionResult> Get()
        {
            var result = await _produtoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("produtos/count")]
        public async Task<ActionResult> GetCount()
        {
            var result = await _produtoService.CountAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("produtos/nome/{name}")]
        public async Task<ActionResult> GetByName(string name)
        {
            var result = await _produtoService.GetByNameAsync(name);
            return Ok(result);
        }

        [HttpGet]
        [Route("produtos/{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var result = await _produtoService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("produtos")]
        public async Task<ActionResult> Post(ProdutoDto produto)
        {
            await _produtoService.AddAsync(produto);
            return new OkResult();
        }

        [HttpPut]
        [Route("produtos/{id}")]
        public async Task<ActionResult> Put(long id, ProdutoDto produto)
        {
            await _produtoService.UpdateAsync(produto);
            return new OkResult();
        }

        [HttpDelete]
        [Route("produtos/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _produtoService.DeleteAsync(id);
            return new OkResult();
        }
    }
}
