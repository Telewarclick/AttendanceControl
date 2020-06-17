using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; }
        public ICollection<Position> Positions { get; set; }
        public Department()
        {
            Positions = new Collection<Position>();
        }

    }
}
