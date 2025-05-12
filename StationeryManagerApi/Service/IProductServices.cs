using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface IProductServices
    {
        Task<ProductModel?> GetById(string id);
        Task<List<ProductModel>> GetAlls(FilterModel filter);
        Task<ProductModel> Create(ProductRequest request);
        Task<int> Update(ProductModel account, ProductRequest request);
        Task<int> Delete(ProductModel account);
    }
}
