using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices ) {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlls([FromQuery] FilterModel filter) {
            var list = await _categoryServices.GetAlls(filter);
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequest request) {
            var result = await _categoryServices.Create(request);
            if(result == null)
            {
                return BadRequest("Create failed");
            }
            return Ok("Create success");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) {
            var category = await _categoryServices.GetById(id);
            if (category == null) {
                return NotFound($"Category with id {id} not found");
            }
            return Ok(category);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] CategoryRequest request) {
            var category = await _categoryServices.GetById(id);
            if (category == null)
            {
                return NotFound($"Category with id {id} not found");
            }

            var result = await _categoryServices.Update(category, request);
            if(result == 0)
            {
                return BadRequest("Update failed");
            }
            return Ok("Update success");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id) {
            var category = await _categoryServices.GetById(id);
            if (category == null)
            {
                return NotFound($"Category with id {id} not found");
            }

            var result = await _categoryServices.Delete(category);
            if (result == 0)
            {
                return BadRequest("Delete failed");
            }
            return Ok("Delete success");
        }
    }
}
