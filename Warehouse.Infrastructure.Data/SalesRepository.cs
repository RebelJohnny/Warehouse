using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Warehouse.Core.Contracts.Repository;
using Warehouse.Core.Domain;
using Warehouse.Infrastructure.EF;

namespace Warehouse.Infrastructure.Data
{
    public class SalesRepository : ISalesRepository
    {
        private readonly WarehouseContext context;

        public SalesRepository(WarehouseContext context)
        {
            this.context = context;
        }
        public int CreateSales(Sales sales)
        {
            context.Sales.Add(sales);
            context.SaveChanges();
            return sales.SalesId;
        }
        public Sales UpdateSales(Sales sales)
        {
            context.Sales.Update(sales);
            context.SaveChanges();
            return sales;
        }

        public Sales GetSales(int id)
        {
            return context.Sales.FirstOrDefault(a => a.SalesId == id);
        }
        public void DeleteSales(int id)
        {
            Sales sales = GetSales(id);
            context.Sales.Remove(sales);
            context.SaveChanges();
        }
        public IEnumerable<Sales> GetAll()
        {
            return context.Sales.ToList();
        }
        //public List<Goods> GoodsSearch(string search)
        //{
        //    return context.Goods.Where
        //        (a => a.GoodsId.Contains(search)).ToList();
        //}
    }
}
