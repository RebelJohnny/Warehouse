using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Core.Domain
{
    public class Goods
    {
        public int GoodsId { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
    }
}
