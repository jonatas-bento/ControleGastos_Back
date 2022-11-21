using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Revenue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Recurrence { get; set; }
        public double Value { get; set; }
        public string Classification { get; set; }
    }
}
