using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMvc.Helper;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class ProductsController : Controller
    {
        ProductAPI _api = new ProductAPI();
        public async Task<IActionResult> Index()
        {
            List<ProductData> products = new List<ProductData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Products/getall");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductData>>(result);
            }
            return View(products);
            
        }
    }
}
