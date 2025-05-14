using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly ISubCategoryServices _subCategoryServices;

        public ProductsController(IProductServices productServices, ISubCategoryServices subCategoryServices)
        {
            _productServices = productServices;
            _subCategoryServices = subCategoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductFilterModel filter)
        {
            var result = await _productServices.GetAlls(filter);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAll([FromQuery] ProductFilterModel filter)
        {
            var result = await _productServices.CountAll(filter);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _productServices.GetById(id);
            if (result == null)
            {
                return NotFound($"Product with id {id} not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRequest product)
        {
            var subCategory = await _subCategoryServices.GetById(product.SubCategoryId);
            if (subCategory == null)
            {
                return NotFound($"SubCategory with id {product.SubCategoryId} not found");
            }

            var result = await _productServices.Create(product);
            if (result == null)
            {
                return BadRequest("Failed to create product");
            }
            return Ok("Create success");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] ProductRequest request)
        {

            var productExist = await _productServices.GetById(id);
            if (productExist == null)
            {
                return NotFound($"Product with id {id} not found");
            }

            if (productExist.SubCategoryId != request.SubCategoryId)
            {
                var subCategory = await _subCategoryServices.GetById(request.SubCategoryId);
                if (subCategory == null)
                {
                    return NotFound($"SubCategory with id {request.SubCategoryId} not found");
                }
            }

            var result = await _productServices.Update(productExist, request);

            return result > 0 ? Ok($"Update {request.Name} success") : BadRequest("Update failed");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var product = await _productServices.GetById(id);
            if (product == null)
            {
                return NotFound($"Product with id {id} not found");
            }
            var result = await _productServices.Delete(product);
            return result > 0 ? Ok($"Delete {product.Name} success") : BadRequest("Delete failed");
        }
    }
}
