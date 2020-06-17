using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public bool Activation { get; set; }
        public Employee Employee { get; set; }
    }
}
