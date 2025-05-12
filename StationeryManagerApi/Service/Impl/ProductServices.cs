using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service.Impl
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepositories _repositories;

        public ProductServices(IProductRepositories repositories) {
            _repositories = repositories;
        }

        public async Task<ProductModel> Create(ProductRequest request)
        {
            var product = new ProductModel
            {
                Name = request.Name,
                Price = request.Price,
                SubCategoryId = request.SubCategoryId,
                Description = request.Description,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
            };

            return await _repositories.Create(product);
        }

        public async Task<int> Delete(ProductModel account)
        {
            account.IsDeleted = true;
            account.DeletedAt = DateTime.UtcNow;
            return await _repositories.Delete(account);
        }

        public async Task<List<ProductModel>> GetAlls(FilterModel filter)
        {
            return await _repositories.GetAlls(filter);
        }

        public async Task<ProductModel?> GetById(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return null;
            }
            return await _repositories.GetById(guid);
        }

        public async Task<int> Update(ProductModel account, ProductRequest request)
        {
            account.Name = request.Name;
            account.Price = request.Price;
            account.SubCategoryId = request.SubCategoryId;
            account.Description = request.Description;
            account.UpdatedAt = DateTime.UtcNow;
            return await _repositories.Update(account);
        }
    }
}
