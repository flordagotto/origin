using Origin.Dto;
using System.Threading.Tasks;

namespace Origin.Services.Repo
{
    public interface IRetiroService
    {
        Task<TarjetaDto> RegisterOperation(string number, string amount);
        Task<bool> ExcedeBalance(string number, string amount);
    }
}
