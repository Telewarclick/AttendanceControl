using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class ControlContext : DbContext
    {
        public DbSet<ActualTime> ActualTimes { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EntTask> EntTasks { get; set; }
        public DbSet<Factory> Factorys { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ScheduledTime> ScheduledTimes { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }


        public ControlContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }

}

