using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository
{
    public interface IProductRepositories
    {
        Task<ProductModel?> GetById(Guid id);
        Task<ProductModel?> GetBySku(string sku);
        Task<List<ProductModel>> GetAlls(ProductFilterModel filter);
        Task<List<ProductModel>> GetAllByIds(List<string> ids);
        Task<int> CountAll(ProductFilterModel filter);
        Task<ProductModel> Create(ProductModel product);
        Task<int> Update(ProductModel product);
        Task<int> Delete(ProductModel product);
    }
}
