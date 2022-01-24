using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.DataLayer.Repo
{
    public interface IBalanceDao
    {
        Task<bool> RegisterOperation(long number, DateTime date);
    }
}
