using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface IProductServices
    {
        Task<ProductModel?> GetById(string id);
        Task<ProductModel?> GetBySku(string sku);
        Task<List<ProductModel>> GetAlls(ProductFilterModel filter);
        Task<List<ProductModel>> GetAllByIds(List<string> ids);
        Task<int> CountAll(ProductFilterModel filter);
        Task<ProductModel> Create(ProductRequest request, ClaimModel user);
        Task<int> Update(ProductModel account, ProductRequest request, ClaimModel user);
        Task<int> Delete(ProductModel account, ClaimModel user);
    }
}
