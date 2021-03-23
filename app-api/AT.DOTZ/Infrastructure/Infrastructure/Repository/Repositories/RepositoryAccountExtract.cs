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
    public class RepositoryAccountExtract : RepositoryGenerics<AccountExtract>, IAccountExtract
    {
        public RepositoryAccountExtract(ContextBase context) : base(context)
        {

        }
        public async Task<List<AccountExtract>> GetEntityByAccountId(Guid AccountId)
        {
            return await _context.AccountExtract.Where(x => x.AccountId.Equals(AccountId)).ToListAsync();
        }
    }
}
