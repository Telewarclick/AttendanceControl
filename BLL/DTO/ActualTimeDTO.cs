using System;

namespace BLL.DTO
{
    public class ActualTimeDTO
    {
        public int Id { get; set; }
        public DateTime TimeEnter { get; set; }
        public DateTime TimeExit { get; set; }
        public int WorkDayId { get; set; }
        public WorkDayDTO WorkDay { get; set; }
    }
}