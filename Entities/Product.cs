using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobLinq.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Amount { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
    }
}