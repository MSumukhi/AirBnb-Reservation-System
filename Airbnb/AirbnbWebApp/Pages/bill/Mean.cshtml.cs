using Airbnb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AirbnbWebApp.Pages.bill
{
    public class MeanModel : PageModel
    {
        public int mean = new();
        /// <summary>
        /// Retreiving the avaerage price for Airbnb
        /// </summary>
        public async void OnGet()
        {
            var client = new HttpClient();
            var responseTask = client.GetAsync("https://localhost:7001/Airbnb/Analysis-GetMean");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                //var data = JsonConvert.DeserializeObject<dynamic>(content);

                mean = JsonConvert.DeserializeObject<int>(content);
                // Use the response data here
                //var message = data.Message;
            }
        }
    }
}
