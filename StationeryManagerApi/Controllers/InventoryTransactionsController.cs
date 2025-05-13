using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.Enum;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/inventories")]
    [ApiController]
    public class InventoryTransactionsController : ControllerBase
    {
        private readonly IInventoryTransactionServices _inventoryTransactionServices;
        private readonly IProductServices _productServices;
        private readonly IWarehouseServices _warehouseServices;

        public InventoryTransactionsController(
            IInventoryTransactionServices transactionServices, 
            IProductServices productServices, 
            IWarehouseServices warehouseServices)
        {
            _inventoryTransactionServices = transactionServices;
            _productServices = productServices;
            _warehouseServices = warehouseServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlls([FromQuery] InventoryTransactionFilterModel filter)
        {
            var list = await _inventoryTransactionServices.GetAlls(filter);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryTransactionRequest request)
        {
            if(Enum.TryParse<TransactionTypeEnum>(request.TransactionType, true, out TransactionTypeEnum type) == false)
            {
                return BadRequest("Transaction type is invalid");
            }

            var warehouse = await _warehouseServices.GetById(request.WarehouseId);
            if (warehouse == null)
            {
                return BadRequest("Warehouse not found");
            }

            //var product = await _productServices.GetById(request.ProductId);
            //if (product == null)
            //{
            //    return BadRequest("Product not found");
            //}

            //request.ProductName = product.Name;
            var result = await _inventoryTransactionServices.Create(request);
            if (result == null)
            {
                return BadRequest("Create failed");
            }
            return Ok("Create success");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var transaction = await _inventoryTransactionServices.GetById(id);
            if (transaction == null)
            {
                return NotFound($"Transaction with id {id} not found");
            }
            return Ok(transaction);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] InventoryTransactionRequest request)
        {
            var transaction = await _inventoryTransactionServices.GetById(id);
            if (transaction == null)
            {
                return NotFound($"Transaction with id {id} not found");
            }

            if (Enum.TryParse<TransactionTypeEnum>(request.TransactionType, true, out TransactionTypeEnum type) == false)
            {
                return BadRequest("Transaction type is invalid");
            }

            var warehouse = await _warehouseServices.GetById(request.WarehouseId);
            if (warehouse == null)
            {
                return BadRequest("Warehouse not found");
            }

            //var product = await _productServices.GetById(request.ProductId);
            //if (product == null)
            //{
            //    return BadRequest("Product not found");
            //}

            //request.ProductName = product.Name;

            var result = await _inventoryTransactionServices.Update(transaction, request);
            if (result == 0)
            {
                return BadRequest("Update failed");
            }
            return Ok("Update success");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var transaction = await _inventoryTransactionServices.GetById(id);
            if (transaction == null)
            {
                return NotFound($"Transaction with id {id} not found");
            }
            var result = await _inventoryTransactionServices.Delete(transaction);
            if (result == 0)
            {
                return BadRequest("Delete failed");
            }
            return Ok("Delete success");
        }
    }
}
