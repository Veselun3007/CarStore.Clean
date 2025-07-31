using CarStore.Clean.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Clean.WebApi.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CrudController<IEntity, OEntity, TKey> : Controller
        where IEntity : class
        where OEntity : class
    {
        private readonly IService<IEntity, OEntity, TKey> _service;

        protected CrudController(IService<IEntity, OEntity, TKey> service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(TKey id)
        {
            var entity = await _service.GetByIdAsync(id);
            if(entity == null)
                return NotFound();
            return Ok(entity);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] IEntity entity)
        {
            var createdEntity = await _service.CreateAsync(entity);
            return Ok(createdEntity);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(TKey id, [FromBody] IEntity entity)
        {
            var updatedEntity = await _service.UpdateAsync(id, entity);
            return Ok(updatedEntity);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(TKey id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
