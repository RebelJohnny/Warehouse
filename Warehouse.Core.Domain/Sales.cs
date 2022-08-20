using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Core.Domain
{
    public class Sales
    {
        public int SalesId { get; set; }
        public int GoodsId { get; set; }
        public Goods Goods { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
    }
}
