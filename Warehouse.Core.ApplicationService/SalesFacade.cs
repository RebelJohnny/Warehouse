using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Core.Contracts.Facade;
using Warehouse.Core.Contracts.Repository;
using Warehouse.Core.Domain;

namespace Warehouse.Core.ApplicationService
{
    public class SalesFacade : ISalesFacade
    {
        private readonly ISalesRepository salesRepository;

        public SalesFacade(ISalesRepository goodsRepository)
        {
            this.salesRepository = goodsRepository;
        }

        public Sales GetSales(int id)
        {
            Sales sales = salesRepository.GetSales(id);
            return sales;
        }
        public int CreateSales(Sales sales)
        {
            salesRepository.CreateSales(sales);
            return sales.SalesId;
        }
        public void DeleteSales(int id)
        {
            salesRepository.DeleteSales(id);
        }
        public Sales UpdateSales(Sales sales)
        {
            return salesRepository.UpdateSales(sales);
        }
        public IEnumerable<Sales> GetAll()
        {
            return salesRepository.GetAll();
        }
    }
}
