using ApplicationApp.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceAccountApp : InterfaceGenericaApp<Account>
    {
        Task AddAccount(Account account);
        Task UpdateAccount(Account account);

        Task<Payment> Payment(Payment account);

        Task<List<AccountExtract>> GetExtractAccountId(Guid AccountId);
        Task<List<AccountCard>> GetCardByAccountId(Guid AccountId);

        Task<Account> AccountById(Guid Id);

        Task<Account> AccountByMail(string Mail);
    }
}
