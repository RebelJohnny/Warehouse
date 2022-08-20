using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Core.Contracts.Facade;
using Warehouse.Core.Contracts.Repository;
using Warehouse.Core.Domain;

namespace Warehouse.Core.ApplicationService
{
    public class GoodsFacade : IGoodsFacade
    {
        private readonly IGoodsRepository goodsRepository;

        public GoodsFacade(IGoodsRepository goodsRepository)
        {
            this.goodsRepository = goodsRepository;
        }

        public Goods GetGoods(int id)
        {
            Goods goods = goodsRepository.GetGoods(id);
            return goods;
        }
        public int CreateGoods(Goods goods)
        {
            goodsRepository.CreateGoods(goods);
            return goods.GoodsId;
        }
        public void DeleteGoods(int id)
        {
            goodsRepository.DeleteGoods(id);
        }
        public Goods UpdateGoods(Goods goods)
        {
            return goodsRepository.UpdateGoods(goods);
        }
        public IEnumerable<Goods> GetAll()
        {
            return goodsRepository.GetAll();
        }
    }
}
