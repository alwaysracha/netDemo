using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
//using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace netDemo.Pages
{
    public class Input
    {
        public string name {get;set;}
    }

    public class IndexModel : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //HttpWebRequest req = new HttpWebRequest();
            //req.Address = "https://azuredemoyash.azurewebsites.net/api/HttpTrigger1?code=ezPvfC5kvjX3vCf7Ne9X9kCyzjUTAroeOX83EtnUn7aYYm/NPj2CQw==";

        }

        public static async void RunAsync()
        {
            HttpClient client = new HttpClient();

            // Update port # in the following line.
            client.BaseAddress = new Uri("https://azuredemoyash.azurewebsites.net/api/HttpTrigger1?code=ezPvfC5kvjX3vCf7Ne9X9kCyzjUTAroeOX83EtnUn7aYYm/NPj2CQw==");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                Input input = new Input
                {
                    name = "Gizmo"
                };

                HttpResponseMessage response = await client.GetAsync(input.ToString());
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    //var dataObjects = response.Content.ReadAsAsync<String>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    //return dataObjects;
                }
            }
            catch (Exception e)
            {
                //resultLabel.text=e.Message;
            }

            Console.ReadLine();
        }
    }
}
