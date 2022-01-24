using AutoMapper;
using Origin.DataContext;
using Origin.DataLayer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.DataLayer
{
    public class BalanceDao : IBalanceDao
    {
        #region Data members
        private readonly OriginContext _dataContext;
        private readonly IMapper _mapper;

        public BalanceDao(OriginContext dbContext, IMapper mapper)
        {
            _dataContext = dbContext;
            _mapper = mapper;
        }
        #endregion

        public async Task<bool> RegisterOperation(long number, DateTime date)
        {
            var balance = new Balance
            {
                IdTarjeta = number,
                Hora = date
            };

            await _dataContext.Balance.AddAsync(balance);
            return await _dataContext.SaveChangesAsync() > 0;
        }

    }
}
