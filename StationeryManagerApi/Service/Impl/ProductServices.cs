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

        public async Task<int> CountAll(ProductFilterModel filter)
        {
            return await _repositories.CountAll(filter);
        }

        public async Task<ProductModel> Create(ProductRequest request)
        {
            var sku = string.IsNullOrEmpty(request.Sku) ? await GenerateSku() : request.Sku;

            var product = new ProductModel
            {
                Name = request.Name,
                Price = request.Price,
                SubCategoryId = request.SubCategoryId,
                Description = request.Description ?? "",
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                ImageUrl = request.ImageUrl,
                Sku = sku,
                
            };

            return await _repositories.Create(product);
        }

        public async Task<int> Delete(ProductModel account)
        {
            account.IsDeleted = true;
            account.DeletedAt = DateTime.UtcNow;
            return await _repositories.Delete(account);
        }

        public async Task<List<ProductModel>> GetAllByIds(List<string> ids)
        {
            return await _repositories.GetAllByIds(ids);
        }

        public async Task<List<ProductModel>> GetAlls(ProductFilterModel filter)
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

        public async Task<ProductModel?> GetBySku(string sku)
        {
            return await _repositories.GetBySku(sku);
        }

        public async Task<int> Update(ProductModel product, ProductRequest request)
        {
            product.Name = request.Name;
            product.Price = request.Price;
            product.SubCategoryId = request.SubCategoryId;
            product.Description = request.Description ?? "";
            product.ImageUrl = request.ImageUrl;
            if(!string.IsNullOrEmpty(request.Sku) && request.Sku != product.Sku)
            {
                product.Sku = request.Sku;
            }
            product.UpdatedAt = DateTime.UtcNow;

            return await _repositories.Update(product);
        }

        private async Task<string> GenerateSku()
        {
            var fromDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0,0,0);
            var sku = $"SKU-{fromDate.ToString("yyyyMMdd")}";
            var countInDate = await _repositories.CountAll(new ProductFilterModel
            {
                FromTime = fromDate,
                ToTime = fromDate.AddDays(1),
            });

            var countNumber = (countInDate + 1).ToString("D6");
            sku += $"-{countNumber}";

            return sku;
        }
    }
}
