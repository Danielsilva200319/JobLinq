using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobLinq.Entities
{
    public class Bill : BaseEntity
    {
        public DateOnly Date { get; set; }
        public int IdClient { get; set; }
        public Client Clients { get; set; }
        public double TotalBill { get; set; }
    }
}