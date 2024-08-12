using Assessment5.Entities;
using Assessment5.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAsyncController : ControllerBase
    {
        private readonly IItemAsyncRepository _repository;
        public ItemAsyncController(IItemAsyncRepository itemAsyncRepository)
        {
            _repository = itemAsyncRepository;
        }
        [HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }
        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _repository.GetById(id));
        }
        [HttpGet, Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] Item item)
        {
            await _repository.Update(item);
            return Ok(item);
        }
        [HttpPost, Route("AddItem")]
        public async Task<IActionResult> Add([FromBody] Item item)
        {
            await _repository.Add(item);
            return Ok(item);
        }
        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _repository.DeleteById(id);
            return Ok();
        }
    }
}
