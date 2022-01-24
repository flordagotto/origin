using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Origin.DataContext;
using Origin.DataLayer.Repo;
using Origin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.DataLayer
{
    public class TarjetaDao : ITarjetaDao
    {
        #region Data members
        private readonly OriginContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IPinIncorrectTries _pinTries;

        public TarjetaDao(OriginContext dbContext, IMapper mapper, IPinIncorrectTries pinTries)
        {
            _dataContext = dbContext;
            _mapper = mapper;
            _pinTries = pinTries;
        }
        #endregion

        public async Task<List<Tarjeta>> GetAll()
        {
            var result = await _dataContext.Tarjeta.Select(x => new Tarjeta
            {
                Numero = x.Numero,
                Balance = x.Balance,
                Bloqueada =x.Bloqueada,
                Pin = x.Pin
            }).ToListAsync();
            return result;
        }

        public async Task<Tarjeta> GetByNumber(long number)
        {
            var entity = await _dataContext.Tarjeta.AsNoTracking().SingleOrDefaultAsync(data => data.Numero == number && data.Bloqueada == false);
            return entity;
        }

        public async Task<int> IsCorrectPin(long number, int pin)
        {
            var entity = await _dataContext.Tarjeta.AsNoTracking().SingleOrDefaultAsync(data => data.Numero == number && data.Bloqueada == false && data.Pin == pin);
            if (entity != null) return -1;
            _pinTries.AnotherTry();
            return _pinTries.GetTries();
        }

        public async Task<bool> BlockCard(long number)
        {
            var _toUpdate = await _dataContext.Tarjeta.SingleOrDefaultAsync(data => data.Numero == number);
            _toUpdate.Bloqueada = true;
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

    }
}
