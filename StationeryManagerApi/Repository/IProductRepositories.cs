using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository
{
    public interface IProductRepositories
    {
        Task<ProductModel?> GetById(Guid id);
        Task<List<ProductModel>> GetAlls(FilterModel filter);
        Task<ProductModel> Create(ProductModel product);
        Task<int> Update(ProductModel product);
        Task<int> Delete(ProductModel product);
    }
}
