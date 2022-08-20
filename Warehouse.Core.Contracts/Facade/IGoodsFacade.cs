using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Core.Domain;

namespace Warehouse.Core.Contracts.Facade
{
    public interface IGoodsFacade
    {
        int CreateGoods(Goods goods);
        void DeleteGoods(int id);
        IEnumerable<Goods> GetAll();
        Goods GetGoods(int id);
        Goods UpdateGoods(Goods goods);
    }
}
