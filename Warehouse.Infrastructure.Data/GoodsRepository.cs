using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Warehouse.Core.Contracts;
using Warehouse.Core.Contracts.Repository;
using Warehouse.Core.Domain;
using Warehouse.Infrastructure.EF;

namespace Warehouse.Infrastructure.Data
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly WarehouseContext context;

        public GoodsRepository(WarehouseContext context)
        {
            this.context = context;
        }
        public int CreateGoods(Goods goods)
        {
            context.Goods.Add(goods);
            context.SaveChanges();
            return goods.GoodsId;
        }
        public Goods UpdateGoods(Goods goods)
        {
            context.Goods.Update(goods);
            context.SaveChanges();
            return goods;
        }

        public Goods GetGoods(int id)
        {
            return context.Goods.FirstOrDefault(a => a.GoodsId == id);
        }
        public void DeleteGoods(int id)
        {
            Goods goods = GetGoods(id);
            context.Goods.Remove(goods);
            context.SaveChanges();
        }
        public IEnumerable<Goods> GetAll()
        {
            return context.Goods.ToList();
        }
        //public List<Goods> GoodsSearch(string search)
        //{
        //    return context.Goods.Where
        //        (a => a.GoodsId.Contains(search)).ToList();
        //}
    }
}
