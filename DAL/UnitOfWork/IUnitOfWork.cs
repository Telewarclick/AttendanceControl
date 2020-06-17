using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IActualTimeRepository ActualTimeRepository { get; }
        ICardRepository CardRepository { get; }
        IDepartmentRepository DepartementRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IEntTaskRepository EntTaskRepository { get; }
        IFactoryRepository FactoryRepository { get; }
        IPositionRepository PositionRepository { get; }
        IScheduledTimeRepository ScheduledTimeRepository { get; }
        IWorkDayRepository WorkDayRepository { get; }

        Task<int> Complete();
    }
}
