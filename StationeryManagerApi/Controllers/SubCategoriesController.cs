using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/subCategories")]
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
        public async Task<IActionResult> GetAlls([FromQuery] FilterModel filter)
        {
            var list = await _subCategoryServices.GetAlls(filter);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubCategoryRequest request)
        {
            var category = await _categoryService.GetById(request.CategoryId);
            if (category == null)
            {
                return BadRequest($"Category with id {request.CategoryId} not found");
            }

            var result = await _subCategoryServices.Create(request);
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] SubCategoryRequest request)
        {
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

            var result = await _subCategoryServices.Update(subCategory, request);
            if (result == 0)
            {
                return BadRequest("Update failed");
            }
            return Ok("Update success");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var subCategory = await _subCategoryServices.GetById(id);
            if (subCategory == null)
            {
                return NotFound($"SubCategory with id {id} not found");
            }
            var result = await _subCategoryServices.Delete(subCategory);
            if (result == 0)
            {
                return BadRequest("Delete failed");
            }
            return Ok("Delete success");
        }
    }
}
