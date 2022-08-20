using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Core.Domain;

namespace Warehouse.Core.Contracts.Repository
{
    public interface ISalesRepository
    {
        int CreateSales(Sales sales);
        void DeleteSales(int id);
        IEnumerable<Sales> GetAll();
        Sales GetSales(int id);
        Sales UpdateSales(Sales sales);
    }
}
