using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceAccount;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppAccount : InterfaceAccountApp
    {
        IAccount _IAccount;

        IServiceAccount _IServiceAccount;

        public AppAccount(IAccount IAccount, IServiceAccount IServiceAccount)
        {
            _IAccount = IAccount;
            _IServiceAccount = IServiceAccount;
        }

        public async Task Add(Account Objeto)
        {
            await _IAccount.Add(Objeto);
        }



        public async Task Delete(Account Objeto)
        {
            await _IAccount.Delete(Objeto);
        }

        public async Task<Account> GetEntityById(Guid Id)
        {
            return await _IAccount.GetEntityById(Id);
        }

        public async Task<List<Account>> List()
        {
            return await _IAccount.List();
        }

        public async Task Update(Account Objeto)
        {
            await _IAccount.Update(Objeto);
        }


        #region Métodos customizados
        public async Task AddAccount(Account Account)
        {
            await _IServiceAccount.AddAccount(Account);
        }

        public async Task UpdateAccount(Account Account)
        {
            await _IServiceAccount.UpdateAccount(Account);
        }

        public async Task<Payment> Payment(Payment Payment)
        {
            return await _IServiceAccount.Payment(Payment);
        }

        public async Task<List<AccountExtract>> GetExtractAccountId(Guid AccountId)
        {
            return await _IServiceAccount.GetExtractAccountId(AccountId);
        }

        public async Task<List<AccountCard>> GetCardByAccountId(Guid AccountId)
        {
            return await _IServiceAccount.GetCardByAccountId(AccountId);
        }

        public async Task<Account> AccountById(Guid Id)
        {
            return await _IAccount.GetEntityById(Id); 
        }

        public async Task<Account> AccountByMail(string Mail)
        {
            return await _IServiceAccount.GetEntityByMail(Mail);
        }

        #endregion
    }
}
