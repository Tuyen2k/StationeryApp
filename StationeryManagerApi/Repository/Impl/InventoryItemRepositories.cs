using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository.Impl
{
    public class InventoryItemRepositories : IInventoryItemRepositories
    {
        private readonly StationeryDBContext _context;

        public InventoryItemRepositories(StationeryDBContext context)
        {
            _context = context;
        }

        
    }
}
