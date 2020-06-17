using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL.Entities
{
    public class WorkDay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PayHour { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<ScheduledTime> ScheduledTimes { get; set; }
        public ICollection<ActualTime> ActuralTimes { get; set; }
        public WorkDay()
        {
            ScheduledTimes = new Collection<ScheduledTime>();
            ActuralTimes = new Collection<ActualTime>();
        }

    }
}
