using System.Threading.Tasks;
using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.Enum;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service.Impl
{
    public class InventoryItemServices : IInventoryItemServices
    {
        private readonly IInventoryTransactionRepositories _repositories;
        private readonly IInventoryItemRepositories _inventoryItemRepositories;

        public InventoryItemServices(IInventoryTransactionRepositories repositories, IInventoryItemRepositories inventoryItemRepositories)
        {
            _repositories = repositories;
            _inventoryItemRepositories = inventoryItemRepositories;
        }

        
    }
}
