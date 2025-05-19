using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IInventoryItemServices _inventoryItem;

        public ReportsController(IProductServices productServices, IInventoryItemServices inventoryItem)
        {
            _productServices = productServices;
            _inventoryItem = inventoryItem;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetRenevueProduct([FromQuery] ReportFilterModel filter)
        {
            var result = await _inventoryItem.CalculateRepostProduct(filter);
            return Ok(result);
        }

        [HttpGet("products/count")]
        public async Task<IActionResult> CountRenevueProduct([FromQuery] ReportFilterModel filter)
        {
            var result = await _inventoryItem.CountRepostProduct(filter);
            return Ok(result);
        }

        [HttpGet("staff")]
        public async Task<IActionResult> GetRenevueStaff([FromQuery] ReportFilterModel filter)
        {
            var result = await _inventoryItem.CalculateRepostStaff(filter);
            return Ok(result);
        }

        [HttpGet("staff/count")]
        public async Task<IActionResult> CountRenevueStaff([FromQuery] ReportFilterModel filter)
        {
            var result = await _inventoryItem.CountRepostStaff(filter);
            return Ok(result);
        }

        [HttpGet("staff/{id}")]
        public async Task<IActionResult> GetRenevueStaffById(string id, [FromQuery] ReportFilterModel filterModel)
        {
            var result = await _inventoryItem.CalculateRepostProduct(filterModel,id);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="id">accountId</param>
        /// <returns></returns>
        [HttpGet("staff/{id}/count")]
        public async Task<IActionResult> CountProductInDefatilStaff ([FromQuery] ReportFilterModel filter, string id)
        {
            var result = await _inventoryItem.CountRepostProduct(filter, id);
            return Ok(result);
        }
    }
}
