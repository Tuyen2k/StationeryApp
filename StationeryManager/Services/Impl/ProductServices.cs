using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public class ProductServices : IProductServices {
        private readonly HttpClient _httpClient;

        public ProductServices(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public Task<int> CountAllAsync(FilterModel? filter) {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(ProductRequest subCategory) {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id) {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetAllAsync(FilterModel? filter) {
            throw new NotImplementedException();
        }

        public Task<ProductModel?> GetByIdAsync(string id) {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(string id, ProductRequest subCategory) {
            throw new NotImplementedException();
        }
    }
}
