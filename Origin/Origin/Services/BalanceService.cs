using AutoMapper;
using Origin.DataLayer.Repo;
using Origin.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceDao _balanceDao;
        private readonly IMapper _mapper;

        public BalanceService(IBalanceDao bDao, IMapper mapper)
        {
            _balanceDao = bDao;
            _mapper = mapper;
        }

        public async Task<bool> RegisterOperation(string number)
        {
            return await _balanceDao.RegisterOperation(Convert.ToInt64(number), DateTime.Now);
        }

    }
}
