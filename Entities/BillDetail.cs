using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobLinq.Entities
{
    public class BillDetail : BaseEntity
    {
        public int IdBill { get; set; }
        public Bill Bills { get; set; }
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double Value { get; set; }
    }
}