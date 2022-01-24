using Origin.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.DataLayer.Repo
{
    public interface IRetiroDao
    {
        Task<Tarjeta> RegisterOperation(long number, int amount, DateTime date);
        Task<bool> ExcedeBalance(long number, int amount);
    }
}
