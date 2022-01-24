using Origin.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.DataLayer.Repo
{
    public interface ITarjetaDao
    {
        Task<List<Tarjeta>> GetAll();
        Task<Tarjeta> GetByNumber(long id);
        Task<int> IsCorrectPin(long number, int pin);
        Task<bool> BlockCard(long number);
    }
}
