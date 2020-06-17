using System;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class ActualTimeService : IActualTimeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualTimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(
                              nameof(unitOfWork));
        }

        public async Task<ActualTimeDTO> GetActualTimeAsync(int id)
        {
            var actualTime = await GetByIdAsync(id);

            return new ActualTimeDTO()
            {
                Id = actualTime.Id,
                TimeEnter = actualTime.TimeEnter,
                TimeExit = actualTime.TimeExit,
                WorkDayId = actualTime.WorkDayId
            };
        }

        public async Task AddActualTimeAsync(ActualTimeDTO actualTime)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var entity = new ActualTime()
            {
                TimeEnter = actualTime.TimeEnter,
                TimeExit = actualTime.TimeExit,
                WorkDayId = actualTime.WorkDayId
            };

            await _unitOfWork.ActualTimeRepository.AddAsync(entity);
            await _unitOfWork.Complete();
        }

        public async Task RemoveActualTimeAsync(int id)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var actualTime = await GetByIdAsync(id);
            _unitOfWork.ActualTimeRepository.Remove(actualTime);
            await _unitOfWork.Complete();
        }

        private async Task<ActualTime> GetByIdAsync(int id)
        {
            var region = await _unitOfWork.ActualTimeRepository.GetAsync(id);

            if (region == null)
            {
                throw new Exception("Region with following id was not found");
            }

            return region;
        }
    }
}