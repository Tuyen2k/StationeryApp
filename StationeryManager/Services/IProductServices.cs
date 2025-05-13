using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface IProductServices
    {
        Task<List<ProductModel>> GetAllAsync(FilterModel? filter);
        Task<int> CountAllAsync(FilterModel? filter);
        Task<ProductModel?> GetByIdAsync(string id);
        Task<bool> CreateAsync(ProductRequest product);
        Task<bool> UpdateAsync(string id, ProductRequest product);
        Task<bool> DeleteAsync(string id);
    }
}
