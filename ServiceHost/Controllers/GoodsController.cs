using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Models;
using Warehouse.Core.Contracts.Facade;
using Warehouse.Core.Domain;

namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsFacade goodsFacade;

        public GoodsController(IGoodsFacade goodsFacade)
        {
            this.goodsFacade = goodsFacade;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ResponseViewModel<IEnumerable<Goods>> model = new ResponseViewModel<IEnumerable<Goods>>();
            try
            {
                model.Data = goodsFacade.GetAll();
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }
            return Ok(model);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            ResponseViewModel<Goods> model = new ResponseViewModel<Goods>();
            try
            {
                model.Data = goodsFacade.GetGoods(id);
            }
            catch (InvalidOperationException)
            {

                model.AddError("کالا وجود ندارد");
                return NotFound(model);
            }
            return Ok(model);
        }
        [HttpPost]
        public IActionResult PostGoods(Goods goods)
        {
            ResponseViewModel<int> model = new ResponseViewModel<int>();
            try
            {
                model.Data = goodsFacade.CreateGoods(goods);
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }

            return Created($"/api/goods/{model.Data}", model);
        }


        [HttpPut]
        public IActionResult PutGoods(Goods goods)
        {
            if (goods.GoodsId == 0)
            {

                return BadRequest("بده به کیومرث idت را");
            }
            goodsFacade.UpdateGoods(goods);
            return Ok(goods);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Goods deleted = goodsFacade.GetGoods(id);
            if (deleted.GoodsId == 0)
            {
                return BadRequest("کیو حذف کنم آقا سید؟");
            }
            goodsFacade.DeleteGoods(id);
            return Ok(deleted);
        }
    }
}

