using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValoReal.Comuns.Application.Services.Interfaces;

namespace ValoReal.Comuns.Api.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityWriteController<T> : BaseController where T : class
    {
        private readonly IServiceBase<T> _service;

        public EntityWriteController(IServiceBase<T> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] T entidade)
        {
            var result = await _service.AddAsync(entidade);
            return FromResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] T entidade)
        {
            var result = await _service.UpdateAsync(entidade);
            return FromResult(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] T entidade)
        {
            var result = _service.Delete(entidade);
            return FromResult(result);
        }
    }
}
