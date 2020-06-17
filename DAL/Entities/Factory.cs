using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL.Entities
{
    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Factory> Factorys { get; set; }
        public Factory()
        {
            Factorys = new Collection<Factory>();
        }
    }
}
