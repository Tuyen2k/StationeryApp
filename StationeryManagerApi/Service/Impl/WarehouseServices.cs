using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service.Impl
{
    public class WarehouseServices : IWarehouseServices
    {
        private readonly IWarehouseRepositories _repositories;

        public WarehouseServices(IWarehouseRepositories repositories) {
            _repositories = repositories;
        }

        public async Task<WarehouseModel> Create(WarehouseRequest request)
        {
            var warehouse = new WarehouseModel
            {
                Name = request.Name,
                Location = request.Location,
                CreatedAt = DateTime.UtcNow,
                Description = request.Description,
                IsDeleted = false,
            };
            return await _repositories.Create(warehouse);
        }

        public async Task<int> Delete(WarehouseModel warehouse)
        {
            warehouse.IsDeleted = true;
            warehouse.DeletedAt = DateTime.UtcNow;
            return await _repositories.Delete(warehouse);
        }

        public async Task<List<WarehouseModel>> GetAlls(FilterModel filter)
        {
            return await _repositories.GetAlls(filter);
        }

        public async Task<WarehouseModel?> GetById(string id)
        {
            if(!Guid.TryParse(id, out var guid))
            {
                return null;
            }
            return await _repositories.GetById(guid);
        }

        public async Task<int> Update(WarehouseModel warehouse, WarehouseRequest request)
        {
            warehouse.Name = request.Name;
            warehouse.Location = request.Location ?? warehouse.Name;
            warehouse.Description = request.Description ?? warehouse.Description;
            warehouse.UpdatedAt = DateTime.UtcNow;
            
            return await _repositories.Update(warehouse);
        }
    }
}
