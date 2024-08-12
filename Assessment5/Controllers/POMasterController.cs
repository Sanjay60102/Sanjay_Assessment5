using Assessment5.Entities;
using Assessment5.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POMasterController : ControllerBase
    {
        private readonly IPOMasterAsyncRepository _repository;
        public POMasterController(IPOMasterAsyncRepository repository)
        {
            _repository = repository;
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
        public async Task<IActionResult> Edit([FromBody] POMaster pOMaster)
        {
            await _repository.Update(pOMaster);
            return Ok(pOMaster);
        }
        [HttpPost, Route("AddItem")]
        public async Task<IActionResult> Add([FromBody] POMaster pOMaster)
        {
            await _repository.Add(pOMaster);
            return Ok(pOMaster);
        }
        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _repository.DeleteById(id);
            return Ok();
        }
    }
}
