using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/inventory-items")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        private readonly IInventoryItemServices _inventoryItemServices;

        public InventoryItemsController(IInventoryItemServices inventoryItemServices)
        {
            _inventoryItemServices = inventoryItemServices;
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetAlls(string transactionId)
        {
            var filter = new InventoryItemFilterModel()
            {
                InventoryTransactionId = transactionId,
            };
            var list = await _inventoryItemServices.GetAlls(filter);
            return Ok(list);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetAllByProductId([FromQuery] InventoryItemFilterModel filter)
        {
            var count = await _inventoryItemServices.CountAll(filter);
            return Ok(count);
        }
    }
}
