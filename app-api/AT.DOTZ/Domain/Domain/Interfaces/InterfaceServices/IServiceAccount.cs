using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceAccount
    {
        Task AddAccount(Account account);
        Task UpdateAccount(Account account);

        Task<Account> GetEntityByMail(string Mail);

        Task<Payment> Payment(Payment account);

        Task<List<AccountExtract>> GetExtractAccountId(Guid AccountId);
        Task<List<AccountCard>> GetCardByAccountId(Guid AccountId);
    }
}
