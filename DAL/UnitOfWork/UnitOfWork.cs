using DAL.EF;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ControlContext _context;
        private bool _disposed = false;

        private IActualTimeRepository _actualTimeRepository;
        private ICardRepository _cardRepository;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;
        private IEntTaskRepository _entTaskRepository;
        private IFactoryRepository _factoryRepository;
        private IPositionRepository _positionRepository;
        private IScheduledTimeRepository _scheduledTimeRepository;
        private IWorkDayRepository _workDayRepository;
        public IDepartmentRepository DepartementRepository { get; }

        public IActualTimeRepository ActualTimeRepository
        {
            get
            {
                if (_actualTimeRepository == null)
                    _actualTimeRepository = new ActualTimeRepository(_context);

                return _actualTimeRepository;
            }
        }

        public ICardRepository CardRepository
        {
            get
            {
                if (_cardRepository == null)
                    _cardRepository = new CardRepository(_context);

                return _cardRepository;
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(_context);

                return _departmentRepository;
            }
        }
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_context);

                return _employeeRepository;
            }
        }
        public IEntTaskRepository EntTaskRepository
        {
            get
            {
                if (_entTaskRepository == null)
                    _entTaskRepository = new EntTaskRepository(_context);

                return _entTaskRepository;
            }
        }
        public IFactoryRepository FactoryRepository
        {
            get
            {
                if (_factoryRepository == null)
                    _factoryRepository = new FactoryRepository(_context);

                return _factoryRepository;
            }
        }
        public IPositionRepository PositionRepository
        {
            get
            {
                if (_positionRepository == null)
                    _positionRepository = new PositionRepository(_context);

                return _positionRepository;
            }
        }
        public IScheduledTimeRepository ScheduledTimeRepository
        {
            get
            {
                if (_scheduledTimeRepository == null)
                    _scheduledTimeRepository = new ScheduledTimeRepository(_context);

                return _scheduledTimeRepository;
            }
        }
        public IWorkDayRepository WorkDayRepository
        {
            get
            {
                if (_workDayRepository == null)
                    _workDayRepository = new WorkDayRepository(_context);

                return _workDayRepository;
            }
        }

        public UnitOfWork(ControlContext context)
        {
            _context = context;
        }


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
