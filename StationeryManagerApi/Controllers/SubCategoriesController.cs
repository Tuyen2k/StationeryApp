using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Extentions;
using StationeryManagerApi.Service.Impl;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/subcategories")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryServices _subCategoryServices;
        private readonly ICategoryServices _categoryService;

        public SubCategoriesController(ISubCategoryServices subCategoryServices, ICategoryServices categoryServices) {
            _subCategoryServices = subCategoryServices;
            _categoryService = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlls([FromQuery] SubCategoryFilterModel filter)
        {
            var list = await _subCategoryServices.GetAlls(filter);
            return Ok(list);
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAll([FromQuery] SubCategoryFilterModel filter) {
            var count = await _subCategoryServices.CountAll(filter);
            return Ok(count);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubCategoryRequest request)
        {
            var user = HttpContext.User.ToClaimModel();
            var category = await _categoryService.GetById(request.CategoryId);
            if (category == null)
            {
                return BadRequest($"Category with id {request.CategoryId} not found");
            }

            var result = await _subCategoryServices.Create(request, user);
            if (result == null)
            {
                return BadRequest("Create failed");
            }
            return Ok("Create success");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIds(string id)
        {
            var subCategory = await _subCategoryServices.GetById(id);
            if (subCategory == null)
            {
                return NotFound($"SubCategory with id {id} not found");
            }
            return Ok(subCategory);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] SubCategoryRequest request)
        {
            var user = HttpContext.User.ToClaimModel();
            var subCategory = await _subCategoryServices.GetById(id);
            if (subCategory == null)
            {
                return NotFound($"SubCategory with id {id} not found");
            }

            if(subCategory.CategoryId != request.CategoryId)
            {
                var category = await _categoryService.GetById(request.CategoryId);
                if (category == null)
                {
                    return BadRequest($"Category with id {request.CategoryId} not found");
                }
            }

            var result = await _subCategoryServices.Update(subCategory, request, user);
            if (result == 0)
            {
                return BadRequest("Update failed");
            }
            return Ok("Update success");
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var user = HttpContext.User.ToClaimModel();
            var subCategory = await _subCategoryServices.GetById(id);
            if (subCategory == null)
            {
                return NotFound($"SubCategory with id {id} not found");
            }
            var result = await _subCategoryServices.Delete(subCategory, user);
            if (result == 0)
            {
                return BadRequest("Delete failed");
            }
            return Ok("Delete success");
        }
    }
}
