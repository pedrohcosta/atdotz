using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceAccount
{
    public interface IAccountExtract : IGeneric<AccountExtract>
    {
        Task<List<AccountExtract>> GetEntityByAccountId(Guid AcoountId);
    }
}
