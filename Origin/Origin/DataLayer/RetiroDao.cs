using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Origin.DataContext;
using Origin.DataLayer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.DataLayer
{
    public class RetiroDao : IRetiroDao
    {
        #region Data members
        private readonly OriginContext _dataContext;
        private readonly IMapper _mapper;

        public RetiroDao(OriginContext dbContext, IMapper mapper)
        {
            _dataContext = dbContext;
            _mapper = mapper;
        }
        #endregion

        public async Task<Tarjeta> RegisterOperation(long number, int amount, DateTime date)
        {
            var retiro = new Retiro
            {
                IdTarjeta = number,
                Cantidad = amount,
                Hora = date
            };

            await _dataContext.Retiro.AddAsync(retiro);

            var _toUpdate = await _dataContext.Tarjeta.SingleOrDefaultAsync(data => data.Numero == number);
            _toUpdate.Balance = _toUpdate.Balance - amount;
            var updated = await _dataContext.SaveChangesAsync();

            return _toUpdate;
        }

        public async Task<bool> ExcedeBalance(long number, int amount)
        {
            var entity = await _dataContext.Tarjeta.AsNoTracking().SingleOrDefaultAsync(data => data.Numero == number);
            if (entity.Balance >= amount) return false;
            return true;
        }
    }
}
