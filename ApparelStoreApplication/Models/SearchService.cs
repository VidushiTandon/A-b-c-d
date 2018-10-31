using ApparelStoreWebService.Models.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApparelStoreApplication.Models
{
    public class SearchService
    {
        HttpClient client;
        public SearchService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50821/");
        }

        public List<Category> GetCategories()
        {
            HttpResponseMessage response = client.GetAsync("/SearchService/Categories").Result;
            string json=response.Content.ReadAsStringAsync().Result;
            List<Category>  categories=JsonConvert.DeserializeObject<List<Category>>(json);
            return categories;
            
        }
        
        public List<Product> GetProducts(SubCategory S)
        {
            string json = JsonConvert.SerializeObject(S);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/SearchService/GetProducts",content).Result;
            json = response.Content.ReadAsStringAsync().Result;
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
            return products;
        }

    }
}
