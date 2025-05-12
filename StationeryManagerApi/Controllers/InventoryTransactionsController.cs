using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/inventories")]
    [ApiController]
    public class InventoryTransactionsController : ControllerBase
    {
        private readonly IInventoryTransactionServices _inventoryTransactionServices;

        public InventoryTransactionsController(IInventoryTransactionServices transactionServices)
        {
            _inventoryTransactionServices = transactionServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlls([FromQuery] FilterModel filter)
        {
            var list = await _inventoryTransactionServices.GetAlls(filter);
            return Ok(list);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] InventoryTransactionRequest request)
        //{
        //    var result = await _inventoryTransactionServices.Create(request);
        //    if (result == null)
        //    {
        //        return BadRequest("Create failed");
        //    }
        //    return Ok("Create success");
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(string id)
        //{
        //    var transaction = await _inventoryTransactionServices.GetById(id);
        //    if (transaction == null)
        //    {
        //        return NotFound($"Transaction with id {id} not found");
        //    }
        //    return Ok(transaction);
        //}

        //[HttpPatch("{id}")]
        //public async Task<IActionResult> UpdateById(string id, [FromBody] InventoryTransactionRequest request)
        //{
        //    var transaction = await _inventoryTransactionServices.GetById(id);
        //    if (transaction == null)
        //    {
        //        return NotFound($"Transaction with id {id} not found");
        //    }
        //    var result = await _inventoryTransactionServices.Update(transaction, request);
        //    if (result == 0)
        //    {
        //        return BadRequest("Update failed");
        //    }
        //    return Ok("Update success");
        //}
    }
}
