using Assessment5.Entities;
using Assessment5.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierAsyncRepository _supplierAsyncRepository;
        public SupplierController(ISupplierAsyncRepository supplierAsyncRepository)
        {
            this._supplierAsyncRepository = supplierAsyncRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _supplierAsyncRepository.GetAllAsync());
        }
        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _supplierAsyncRepository.GetById(id));
        }
        [HttpPut, Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] Supplier supplier)
        {
            await _supplierAsyncRepository.Update(supplier);
            return Ok(supplier);
        }
        [HttpPost, Route("AddSupplier")]
        public async Task<IActionResult> Add([FromBody]Supplier supplier)
        {
            await _supplierAsyncRepository.Add(supplier);
            return Ok(supplier);
        }
        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _supplierAsyncRepository.DeleteById(id);
            return Ok();
        }
    }
}
