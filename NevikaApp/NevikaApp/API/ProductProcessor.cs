using NevikaApp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NevikaApp.API
{
    public static class ProductProcessor
    {
        public static async Task<Product> RequestProductInfo(string ean_code = "")
        {
            Console.WriteLine($"RequestProductInfo, code: {ean_code}");

            // httpClient.GetAsync(ApiUrl).ConfigureAwait(false).GetAwaiter().GetResult();
            // await ApiHelper.ApiClient.GetAsync(ean_code))

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ean_code))
            {

                Console.WriteLine("Waiting for response");

                if (response.IsSuccessStatusCode)
                {
                    Product myProduct = JsonConvert.DeserializeObject<Product>(
                        await response.Content.ReadAsStringAsync());

                    Console.WriteLine("Returning something");

                    return myProduct;
                }
                else
                {
                    Console.WriteLine("Returning null");
                    return null;
                }

            }
            
        }
    }
}
