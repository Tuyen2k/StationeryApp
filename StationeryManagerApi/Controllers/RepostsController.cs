using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/reposts")]
    [ApiController]
    public class RepostsController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IInventoryItemServices _inventoryItem;

        public RepostsController(IProductServices productServices, IInventoryItemServices inventoryItem)
        {
            _productServices = productServices;
            _inventoryItem = inventoryItem;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetRenevueProduct([FromQuery] ReportFilterModel filter)
        {
            var productFilter = new ProductFilterModel
            {
                Limit = filter.Limit,
                Page = filter.Page,
                Name = filter.Name
            };

            var time = new FromToFilterModel
            {
                FromTime = filter.FromTime,
                ToTime = filter.ToTime
            };

            var products = await _productServices.GetAlls(productFilter);
            var result = await _inventoryItem.CalculateRepostProduct(products, time);
            return Ok(result);
        }
    }
}
