using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface IAccountServices
    {
        Task<AccountModel?> GetAccountById(string id);
        Task<List<AccountModel>> GetAllAccounts(FilterModel filter);
        Task<AccountModel> CreateAccount(CreateAccountRequest account);
        Task<int> UpdateAccount(AccountModel account, UpdateAccountRequest update);
        Task<int> DeleteAccount(AccountModel account);
    }
}
