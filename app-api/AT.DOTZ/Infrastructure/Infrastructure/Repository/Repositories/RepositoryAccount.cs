using Domain.Interfaces.InterfaceAccount;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryAccount: RepositoryGenerics<Account>, IAccount
    {
        public RepositoryAccount(ContextBase context) : base(context) { 
        
        }

        public async Task<Account> GetEntityByMail(string Mail)
        {
            return await _context.Account.FirstOrDefaultAsync(x => x.Mail.ToLower().Equals(Mail.ToLower()));
        }
    }
}
