using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValoReal.Comuns.Application.Services.Interfaces;

namespace ValoReal.Comuns.Api.Controllers.Common
{
    [ApiController]
    public abstract class EntityReadController<T> : BaseController where T : class
    {
        protected readonly IServiceBase<T> _service;

        protected EntityReadController(IServiceBase<T> service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return FromResult(result);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return FromResult(result);
        }
    }
}
