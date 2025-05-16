using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Extentions;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequest request) {
            var user = HttpContext.User.ToClaimModel();
            var result = await _categoryServices.Create(request, user);
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

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] CategoryRequest request) {

            var user = HttpContext.User.ToClaimModel();

            var category = await _categoryServices.GetById(id);
            if (category == null)
            {
                return NotFound($"Category with id {id} not found");
            }

            var result = await _categoryServices.Update(category, request, user);
            if(result == 0)
            {
                return BadRequest("Update failed");
            }
            return Ok("Update success");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id) {
            var user = HttpContext.User.ToClaimModel();
            var category = await _categoryServices.GetById(id);
            if (category == null)
            {
                return NotFound($"Category with id {id} not found");
            }

            var result = await _categoryServices.Delete(category, user);
            if (result == 0)
            {
                return BadRequest("Delete failed");
            }
            return Ok("Delete success");
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAll([FromQuery] FilterModel filter)
        {
            var count = await _categoryServices.CountAll(filter);
            return Ok(count);
        }
    }
}
