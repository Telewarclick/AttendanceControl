using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ActualTime
    {
        public int Id { get; set; }
        public DateTime TimeEnter { get; set; }
        public DateTime TimeExit { get; set; }
        public int WorkDayId { get; set; }
        public WorkDay WorkDay { get; set; }


    }
}
