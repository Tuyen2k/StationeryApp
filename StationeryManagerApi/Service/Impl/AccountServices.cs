using StationeryManagerApi.Repository;
using StationeryManagerApi.Services;
using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Service.Impl
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepositories _repositories;
        private readonly IPasswordServices _passwordServices;

        public AccountServices(IAccountRepositories repositories, IPasswordServices passwordServices) {
            _repositories = repositories;
            _passwordServices = passwordServices;
        }

        public async Task<int> CountAll(FilterModel filter)
        {
            return await _repositories.CountAll(filter);
        }

        public async Task<AccountModel> CreateAccount(CreateAccountRequest account, ClaimModel claim)
        {
            var paswordHash = _passwordServices.HashPassword(account.Password);
            var accountCreate = new AccountModel()
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Email = account.Email,
                IsActive = true,
                IsDeleted = false,
                Name = account.Name,
                Phone = account.Phone,
                PaswordHash = paswordHash,

                CreatedByAccountId = claim.UserId,
                CreatedByAccountName = claim.UserName,
                CreatedByAccountEmail = claim.Email,

            };
            var result = await _repositories.CreateAccount(accountCreate);
            return result;
        }

        public async Task<int> DeleteAccount(AccountModel account, ClaimModel claim)
        {
            account.IsDeleted = true;
            account.DeletedAt = DateTime.UtcNow;

            account.DeletedByAccountId = claim.UserId;
            account.DeletedByAccountName = claim.UserName;
            account.DeletedByAccountEmail = claim.Email;

            var result = await _repositories.DeleteAccount(account);
            return result;
        }

        public async Task<AccountModel?> GetAccountByEmail(string email)
        {
            return await _repositories.GetAccountByEmail(email);
        }

        public async Task<AccountModel?> GetAccountById(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return null; 
            }
            var result = await _repositories.GetAccountById(guidId);
            return result;
        }

        public async Task<List<AccountModel>> GetAllAccounts(FilterModel filter)
        {
            var list = await _repositories.GetAllAccounts(filter);
            return list;
        }

        public async Task<int> UpdateAccount(AccountModel account, UpdateAccountRequest request, ClaimModel claim)
        {

            account.UpdatedAt = DateTime.UtcNow;
            account.Email = request.Email;
            account.Name = request.Name;
            account.Phone = request.Phone;

            account.UpdatedByAccountId = claim.UserId;
            account.UpdatedByAccountName = claim.UserName;
            account.UpdatedByAccountEmail = claim.Email;

            var result = await _repositories.UpdateAccount(account);
            return result;
        }

    }
}
