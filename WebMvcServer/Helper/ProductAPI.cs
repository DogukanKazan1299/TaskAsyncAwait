using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMvcServer.Helper
{
    public class ProductAPI
    {
        public HttpClient Initial()//kullanılacak api hostu
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44378/");
            return client;
        }
    }
}
