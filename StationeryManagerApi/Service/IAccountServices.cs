using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Services
{
    public interface IAccountServices
    {
        Task<AccountModel?> GetAccountById(string id);
        Task<AccountModel?> GetAccountByEmail(string email);
        Task<List<AccountModel>> GetAllAccounts(FilterModel filter);
        Task<int> CountAll(FilterModel filter);
        Task<AccountModel> CreateAccount(CreateAccountRequest account, ClaimModel claim);
        Task<int> UpdateAccount(AccountModel account, UpdateAccountRequest update, ClaimModel claim);
        Task<int> DeleteAccount(AccountModel account, ClaimModel claim);
    }
}
