using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManager.Services
{
    public interface IAccountServices
    {
        Task<List<AccountModel>> GetAllAccounts(FilterModel? filter);
        Task<int> CountAll(FilterModel? filter);
        Task<AccountModel?> GetAccountById(string id);
        Task<bool> CreateAccount(CreateAccountRequest account);
        Task<bool> UpdateAccount(string id, UpdateAccountRequest account);
        Task<bool> DeleteAccount(string id);

    }
}
