using System;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IActualTimeService
    {
        Task<ActualTimeDTO> GetActualTimeAsync(int id);
        Task AddActualTimeAsync(ActualTimeDTO actualTime);
        Task RemoveActualTimeAsync(int id);
    }
}