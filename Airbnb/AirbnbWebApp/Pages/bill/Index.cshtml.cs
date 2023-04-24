using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Airbnb.Interfaces;
using Microsoft.OpenApi.Models;


namespace AirbnbWebApp.Pages.bill
{
    using Airbnb.Models;
    public class IndexModel : PageModel
    {
        public List<Airbnb> bill = new();

        /// <summary>
        /// Retrieving Airbnb list from the database
        /// </summary>
        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5289");
                var responseTask = client.GetAsync("Airbnb");
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