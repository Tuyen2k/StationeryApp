using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.Dtos;
using StationeryManagerLib.Enum;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/inventories")]
    [ApiController]
    public class InventoryTransactionsController : ControllerBase
    {
        private readonly IInventoryTransactionServices _inventoryTransactionServices;
        private readonly IInventoryItemServices _inventoryItemServices;
        private readonly IProductServices _productServices;
        private readonly IWarehouseServices _warehouseServices;

        public InventoryTransactionsController(
            IInventoryTransactionServices transactionServices,
            IInventoryItemServices inventoryItemServices,
            IProductServices productServices,
            IWarehouseServices warehouseServices)
        {
            _inventoryTransactionServices = transactionServices;
            _inventoryItemServices = inventoryItemServices;
            _productServices = productServices;
            _warehouseServices = warehouseServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlls([FromQuery] InventoryTransactionFilterModel filter)
        {
            var products = await _productServices.GetAlls(new ProductFilterModel() { 
                Limit = filter.Limit, 
                Page = filter.Page,
                Name = filter.Name
            });

            var productIds = products.Select(e => e.Id.ToString()).ToList();
            var items = await _inventoryItemServices.CalculateStockByProductIds(productIds);

            var list = from p in products
                       join i in items on p.Id.ToString() equals i.ProductId into pi
                       from i in pi.DefaultIfEmpty()
                       select new ProductStockModel()
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Stock = i != null ? i.Stock : 0,
                           ExportQuantity = i != null ? i.ExportQuantity : 0,
                           ImportQuantity = i != null ? i.ImportQuantity : 0,
                           CreatedAt = p.CreatedAt,
                           UpdatedAt = p.UpdatedAt,
                           IsDeleted = p.IsDeleted,
                           Description = p.Description,
                           ImageUrl = p.ImageUrl,
                           SubCategoryId = p.SubCategoryId,
                       };
            return Ok(list);
        }

        [HttpGet("transaction")]
        public async Task<IActionResult> GetAllTransactions([FromQuery] InventoryTransactionFilterModel filter)
        {
            var list = await _inventoryTransactionServices.GetAlls(filter);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryTransactionRequest request)
        {
            //if (!request.Items.Any())
            //{
            //    return BadRequest("Transaction type is invalid");
            //}

            var warehouse = await _warehouseServices.GetById(request.WarehouseId);
            if (warehouse == null)
            {
                return BadRequest("Warehouse not found");
            }

            var productIds = request.Items.Select(e => e.ProductId).ToList();
            var products = await _productServices.GetAllByIds(productIds);
            if (products.Count != productIds.Count)
            {
                return BadRequest("Some product not found in bill");
            }

            var result = await _inventoryTransactionServices.Create(request, products);
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

            //if (!request.Items.Any())
            //{
            //    return BadRequest("Transaction type is invalid");
            //}

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
