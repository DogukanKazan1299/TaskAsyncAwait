using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebMvcServer.Helper;
using WebMvcServer.Models;

namespace WebMvcServer.Controllers
{
    public class HomeController : Controller
    {
        //api instancena bağlı
        ProductAPI _api = new ProductAPI();
        //all 
        public async Task<IActionResult> Index()
        {
            List<ProductData> products = new List<ProductData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/products/getall");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductData>>(results);
            }
            return View(products);
        }
        //detaylar
        public async Task<IActionResult> Details(int Id)
        {
            var product = new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/products/getbyid/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductData>(results);
            }
            return View(product);
        }
        //get create
        public ActionResult Create()
        {
            return View();
        }
        //post create
        [HttpPost]
        public IActionResult Create(ProductData product)
        {
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<ProductData>("api/products/add", product);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //id'ye göre sil
        public async Task<IActionResult> Delete(int Id)
        {
            var product = new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/products/{Id}");
            return RedirectToAction("Index");
        }

        
        
       

    }
}
