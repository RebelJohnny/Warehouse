using System;
using System.Collections.Generic;
using Warehouse.Core.Domain;
namespace PresentationHost.Models
{
    public class GoodsResponseModel
    {
        public int StatusCode { get; set; }
        public List<Goods> Data { get; set; }
        public DateTime Time { get; private set; }
        public List<string> ErrorList { get; private set; }

        public bool IsSuccess { get; set; }
    }
}
