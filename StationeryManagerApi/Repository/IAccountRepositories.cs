﻿using StationeryManagerLib.Entities;
using StationeryManagerLib.RequestModel;

namespace StationeryManagerApi.Repository
{
    public interface IAccountRepositories
    {
        Task<AccountModel?> GetAccountById(Guid id);
        Task<AccountModel?> GetAccountByEmail(string email);
        Task<List<AccountModel>> GetAllAccounts(FilterModel filter);
        Task<int> CountAll(FilterModel filter);
        Task<AccountModel> CreateAccount(AccountModel account);
        Task<int> UpdateAccount(AccountModel account);
        Task<int> DeleteAccount(AccountModel account);
        Task<int> ResetPassword(AccountModel account);
    }
}
