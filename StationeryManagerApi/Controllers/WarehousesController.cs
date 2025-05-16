using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StationeryManagerApi.Extentions;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/warehouses")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseServices _warehouseServices;
        private readonly StationeryDBContext _context;

        public WarehousesController(IWarehouseServices warehouseServices, StationeryDBContext context)
        {
            _warehouseServices = warehouseServices;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlls([FromQuery] FilterModel filter)
        {
            var list = await _warehouseServices.GetAlls(filter);
            return Ok(list);
        }

        [Authorize] 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WarehouseRequest request)
        {
            var user = HttpContext.User.ToClaimModel();
            var result = await _warehouseServices.Create(request, user);
            if (result == null)
            {
                return BadRequest("Create failed");
            }
            return Ok("Create success");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var warehouse = await _warehouseServices.GetById(id);
            if (warehouse == null)
            {
                return NotFound($"Warehouse with id {id} not found");
            }
            return Ok(warehouse);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] WarehouseRequest request)
        {
            var user = HttpContext.User.ToClaimModel();
            var warehouse = await _warehouseServices.GetById(id);
            if (warehouse == null)
            {
                return NotFound($"Warehouse with id {id} not found");
            }
            var result = await _warehouseServices.Update(warehouse, request, user);
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
            var warehouse = await _warehouseServices.GetById(id);
            if (warehouse == null)
            {
                return NotFound($"Warehouse with id {id} not found");
            }
            var result = await _warehouseServices.Delete(warehouse, user);
            if (result == 0)
            {
                return BadRequest("Delete failed");
            }
            return Ok("Delete success");
        }

        //[HttpGet("fill-sku")]
        //public async Task<IActionResult> FillProductSku()
        //{
        //    var items = await _context.InventoryItems.ToListAsync();
        //    var products = await _context.Products.ToListAsync();
        //    foreach (var item in items)
        //    {
        //        var product = products.FirstOrDefault(e => e.Id.ToString() == item.ProductId);
        //        if (product != null)
        //        {
        //            item.ProductSku = product.Sku;
        //            _context.InventoryItems.Update(item);
        //        }
        //    }
        //    await _context.SaveChangesAsync();
        //    return Ok("Fill product sku success");
        //}
    }
}
