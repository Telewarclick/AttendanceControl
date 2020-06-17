using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<EntTask> EntTasks { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public Position()
        {
            EntTasks = new Collection<EntTask>();
            Employees = new Collection<Employee>();
        }
    }
}
