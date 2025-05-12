using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Services;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Controllers
{
    [Route("api/warehouses")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseServices _warehouseServices;

        public WarehousesController(IWarehouseServices warehouseServices)
        {
            _warehouseServices = warehouseServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlls([FromQuery] FilterModel filter)
        {
            var list = await _warehouseServices.GetAlls(filter);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WarehouseRequest request)
        {
            var result = await _warehouseServices.Create(request);
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateById(string id, [FromBody] WarehouseRequest request)
        {
            var warehouse = await _warehouseServices.GetById(id);
            if (warehouse == null)
            {
                return NotFound($"Warehouse with id {id} not found");
            }
            var result = await _warehouseServices.Update(warehouse, request);
            if (result == 0)
            {
                return BadRequest("Update failed");
            }
            return Ok("Update success");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var warehouse = await _warehouseServices.GetById(id);
            if (warehouse == null)
            {
                return NotFound($"Warehouse with id {id} not found");
            }
            var result = await _warehouseServices.Delete(warehouse);
            if (result == 0)
            {
                return BadRequest("Delete failed");
            }
            return Ok("Delete success");
        }
    }
}
