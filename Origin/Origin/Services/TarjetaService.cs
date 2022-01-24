using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Origin.DataLayer.Repo;
using Origin.Dto;
using Origin.Helpers;
using Origin.Services.Repo;

namespace Origin.Services
{
    public class TarjetaService : ITarjetaService
    {
        private readonly ITarjetaDao _tarjetaDao;
        private readonly IMapper _mapper;

        public TarjetaService(ITarjetaDao tDao, IMapper mapper)
        {
            _tarjetaDao = tDao;
            _mapper = mapper;
        }

        public async Task<List<TarjetaDto>> GetAll()
        {
            var result = await _tarjetaDao.GetAll();
            var resultDto = ServiceHelper.Mapper(_mapper, result, new TarjetaDto());

            return resultDto;
        }

        public async Task<TarjetaDto> GetByNumber(string number)
        {
            //if (num.Length != 19)
            //    return null;
            if (number.Length != 16)
                    return null;
            //var numSplit = num.Split('-');
            //var number = Convert.ToInt32(numSplit[0] + numSplit[1] + numSplit[2] + numSplit[3]);
            var entity = await _tarjetaDao.GetByNumber(Convert.ToInt64(number));
            var entityDto = _mapper.Map<TarjetaDto>(entity);

            return entityDto;
        }

        public async Task<int> IsCorrectPin(long num, int pin)
        {
            return await _tarjetaDao.IsCorrectPin(num, pin);
        }
        
        public async Task<bool> BlockCard(long num)
        {
            return await _tarjetaDao.BlockCard(num);
        }
    }
}
