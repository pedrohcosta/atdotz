using Domain.Interfaces.InterfaceAccount;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceAccount : IServiceAccount
    {
        private readonly IAccount _IAccount;
        private readonly IAccountCard _IAccountCard;
        private readonly IAccountExtract _IAccountExtract;


        public ServiceAccount(IAccount IAccount, IAccountCard IAccountCard, IAccountExtract IAccountExtract)
        {
            _IAccount = IAccount;
            _IAccountCard = IAccountCard;
            _IAccountExtract = IAccountExtract;
        }

        public async Task AddAccount(Account Account)
        {
            if (Account.IsValid())
            {
                if (_IAccount.GetEntityByMail(Account.Mail) == null)
                {
                    await _IAccount.Add(Account);
                }
                else
                {
                    Account.AddErro("Email", "E-mail já cadastrado.");
                }
            }
        }

        public async Task<Payment> Payment(Payment payment)
        {
            if (payment.IsValid())
            {
                Account Account = await _IAccount.GetEntityById(payment.AccountId);
                if (Account != null)
                {
                    Account.Payment(payment);
                    await _IAccountExtract.Add(Account.AccountExtract.First());//remover
                    Account.AccountExtract.Clear();//remover
                    await _IAccount.Update(Account);                 
                }
                else
                {
                    Account.AddErro("Conta", "Conta não encontrada.");
                }
            }
            return payment;
        }

        public async Task<Account> GetEntityByMail(string Mail)
        {
            return await _IAccount.GetEntityByMail(Mail);
        }
        

        public async Task UpdateAccount(Account Account)
        {
            if (Account.IsValid())
            {
                await _IAccount.Update(Account);
            }
        }

        public async Task<List<AccountExtract>> GetExtractAccountId(Guid AccountId)
        {
           return await _IAccountExtract.GetEntityByAccountId(AccountId);
        }

        public async Task<List<AccountCard>> GetCardByAccountId(Guid AccountId)
        {
            return await _IAccountCard.GetEntityByAccountId(AccountId);
        }
    }
}
