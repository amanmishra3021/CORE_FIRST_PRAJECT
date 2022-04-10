using System;
using System.Collections.Generic;

#nullable disable

namespace CORE_FIRST_PRAJECT.DB_context
{
    public partial class EmpDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public long? Contact { get; set; }
        public string City { get; set; }
    }
}
