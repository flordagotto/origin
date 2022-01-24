using AutoMapper;
using Origin.DataLayer.Repo;
using Origin.Dto;
using Origin.Services.Repo;
using System;
using System.Threading.Tasks;

namespace Origin.Services
{
    public class RetiroService : IRetiroService
    {
        private readonly IRetiroDao _retiroDao;
        private readonly IMapper _mapper;

        public RetiroService(IRetiroDao rDao, IMapper mapper)
        {
            _retiroDao = rDao;
            _mapper = mapper;
        }

        public async Task<TarjetaDto> RegisterOperation(string number, string amount)
        {
            var inserted = await _retiroDao.RegisterOperation(Convert.ToInt64(number), Convert.ToInt32(amount),  DateTime.Now);
            var insertedDto = _mapper.Map<TarjetaDto>(inserted);
            return insertedDto;
        }

        public async Task<bool> ExcedeBalance(string number, string amount)
        {
            return await _retiroDao.ExcedeBalance(Convert.ToInt64(number), Convert.ToInt32(amount));
        }
    }
}
