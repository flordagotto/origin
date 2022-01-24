using Origin.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Services.Repo
{
    public interface ITarjetaService
    {
        Task<List<TarjetaDto>> GetAll();
        Task<TarjetaDto> GetByNumber(string id);
        Task<int> IsCorrectPin(long num, int pin);
        Task<bool> BlockCard(long num);
    }
}
