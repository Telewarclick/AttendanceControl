using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string IdPassword { get; set; }
        public int Diploma { get; set; }
        public int WorkExperience { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }

        public Card Card { get; set; }
        public ICollection<WorkDay> WorkDays { get; set; }
        public Employee()
        {
            WorkDays = new Collection<WorkDay>();
        }
    }
}
