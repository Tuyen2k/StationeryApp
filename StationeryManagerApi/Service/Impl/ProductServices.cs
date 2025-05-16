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

        public async Task<ProductModel> Create(ProductRequest request, ClaimModel user)
        {
            var sku = string.IsNullOrEmpty(request.Sku) ? await GenerateSku() : request.Sku;

            var product = new ProductModel
            {
                Name = request.Name,
                Price = request.Price,
                PriceSale = request.PriceSale,
                SubCategoryId = request.SubCategoryId,
                Description = request.Description ?? "",
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                ImageUrl = request.ImageUrl,
                Sku = sku,
                CreatedByAccountId = user.UserId,
                CreatedByAccountName = user.UserName,
                CreatedByAccountEmail = user.Email,

            };

            return await _repositories.Create(product);
        }

        public async Task<int> Delete(ProductModel account, ClaimModel user)
        {
            account.IsDeleted = true;
            account.DeletedAt = DateTime.UtcNow;
            account.DeletedByAccountId = user.UserId;
            account.DeletedByAccountName = user.UserName;
            account.DeletedByAccountEmail = user.Email;


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

        public async Task<int> Update(ProductModel product, ProductRequest request, ClaimModel user)
        {
            product.Name = request.Name;
            product.Price = request.Price;
            product.PriceSale = request.PriceSale;
            product.SubCategoryId = request.SubCategoryId;
            product.Description = request.Description ?? "";
            product.ImageUrl = request.ImageUrl;
            if(!string.IsNullOrEmpty(request.Sku) && request.Sku != product.Sku)
            {
                product.Sku = request.Sku;
            }
            product.UpdatedAt = DateTime.UtcNow;

            product.UpdatedByAccountId = user.UserId;
            product.UpdatedByAccountName = user.UserName;
            product.UpdatedByAccountEmail = user.Email;

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
                FilterDeleted = false
            });

            var countNumber = (countInDate + 1).ToString("D6");
            sku += $"-{countNumber}";

            return sku;
        }
    }
}
