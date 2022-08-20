using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationHost.Models;
using PresentationHost.Services;
using Warehouse.Core.Domain;

namespace PresentationHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IAPIService aPIService;

        public GoodsController(IAPIService aPIService)
        {
            this.aPIService = aPIService;
        }

        [Route("~/api/goods/GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var res = await aPIService.ForGetting("https://localhost:44328/api/goods");
            GoodsResponseModel goodsResponseModel = JsonConvert.DeserializeObject<GoodsResponseModel>(res);

            GoodsViewModel goodsViewModel = new GoodsViewModel()
            {
                Goods = goodsResponseModel.Data
            };

            return Ok(goodsViewModel.Goods);
        }

        [Route("~/api/goods/create")]
        [HttpPost]
        public async Task<IActionResult> Create(Goods goods)
        {

            var json = JsonConvert.SerializeObject(goods);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await aPIService.ForCreating("https://localhost:44328/api/goods", data);

            var result = await response.Content.ReadAsStringAsync();

            return RedirectToAction("index");
        }

        [Route("~/api/goods/update")]
        [HttpPut]
        public async Task<IActionResult> Update(Goods goods)
        {
            var json = JsonConvert.SerializeObject(goods);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await aPIService.ForUpdating("https://localhost:44328/api/goods", data);

            var result = await response.Content.ReadAsStringAsync();

            return RedirectToAction("index");
        }

        [Route("~/api/goods/destroy/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await aPIService.ForDeleting($"https://localhost:44328/api/goods/?id={id}");
            return RedirectToAction("index");
        }
    }
}
