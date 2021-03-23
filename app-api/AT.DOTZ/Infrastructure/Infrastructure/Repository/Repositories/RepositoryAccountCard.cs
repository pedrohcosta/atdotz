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
    public class RepositoryAccountCard: RepositoryGenerics<AccountCard>, IAccountCard
    {
        public RepositoryAccountCard(ContextBase context) : base(context) { 
        
        }
        public async Task<List<AccountCard>> GetEntityByAccountId(Guid AccountId)
        {
            return await _context.AccountCard.Where(x=>x.AccountId.Equals(AccountId)).ToListAsync();
        }   
    }
}
