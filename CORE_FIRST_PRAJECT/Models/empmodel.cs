using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_FIRST_PRAJECT.Models
{
    public class empmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public long? Contact { get; set; }
        public string City { get; set; }
    }
}
