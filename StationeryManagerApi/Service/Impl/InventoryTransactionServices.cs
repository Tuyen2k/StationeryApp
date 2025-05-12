using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service.Impl
{
    public class InventoryTransactionServices : IInventoryTransactionServices
    {
        private readonly IInventoryTransactionRepositories _repositories;

        public InventoryTransactionServices(IInventoryTransactionRepositories repositories) {
            _repositories = repositories;
        }

        public Task<InventoryTransactionModel> Create(InventoryTransactionModel account)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(InventoryTransactionModel account)
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryTransactionModel>> GetAlls(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public Task<InventoryTransactionModel?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(InventoryTransactionModel account)
        {
            throw new NotImplementedException();
        }
    }
}
