using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AirbnbWebApp.Pages.bill
{
    using Airbnb.Models;
    public class ChildModel : PageModel
    {
        public List<Airbnb> bill = new();

        /// <summary>
        /// Retrieving billdata from database
        /// </summary>
        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync("https://localhost:7001/Airbnb/Child-Amenities");
                // client.BaseAddress = new Uri("http://localhost:5289");
                //  var responseTask = client.GetAsync("Airbnb");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    bill = JsonConvert.DeserializeObject<List<Airbnb>>(readTask);
                }
            }
        }
    }
}
