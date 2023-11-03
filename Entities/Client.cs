using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobLinq.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}