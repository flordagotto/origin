using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Services.Repo
{
    public interface IBalanceService
    {
        Task<bool> RegisterOperation(string number);
    }
}
