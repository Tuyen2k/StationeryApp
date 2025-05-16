using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StationeryManagerApi.Extentions;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
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

        [HttpPost("ids")]
        public async Task<IActionResult> GetAllByIds([FromBody] List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return BadRequest("Ids cannot be null or empty");
            }
            var result = await _productServices.GetAllByIds(ids);
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRequest product)
        {
            var user = HttpContext.User.ToClaimModel();
            var subCategory = await _subCategoryServices.GetById(product.SubCategoryId);
            if (subCategory == null)
            {
                return NotFound($"SubCategory with id {product.SubCategoryId} not found");
            }

            if(!string.IsNullOrEmpty(product.Sku))
            {
                var productExist = await _productServices.GetBySku(product.Sku);
                if (productExist != null)
                {
                    return BadRequest($"Product with sku {product.Sku} already exists");
                }
            }

            var result = await _productServices.Create(product, user);
            if (result == null)
            {
                return BadRequest("Failed to create product");
            }
            return Ok("Create success");
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] ProductRequest request)
        {
            var user = HttpContext.User.ToClaimModel();
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

            if (!string.IsNullOrEmpty(request.Sku) && productExist.Sku != request.Sku)
            {
                var productSkuExist = await _productServices.GetBySku(request.Sku);
                if (productSkuExist != null)
                {
                    return BadRequest($"Product with sku {request.Sku} already exists");
                }
            }

            var result = await _productServices.Update(productExist, request, user);

            return result > 0 ? Ok($"Update {request.Name} success") : BadRequest("Update failed");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var user = HttpContext.User.ToClaimModel();
            var product = await _productServices.GetById(id);
            if (product == null)
            {
                return NotFound($"Product with id {id} not found");
            }
            var result = await _productServices.Delete(product, user);
            return result > 0 ? Ok($"Delete {product.Name} success") : BadRequest("Delete failed");
        }
    }
}
