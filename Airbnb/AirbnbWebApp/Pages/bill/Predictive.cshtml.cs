using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Airbnb.Interfaces;
using Microsoft.OpenApi.Models;

namespace AirbnbWebApp.Pages.bill
{

    using Airbnb.Models;
    public class  PredictiveModel : PageModel
    {
        public int group = new();
        /// <summary>
        /// Retreving the list of airbnb that accomodat the number of people from the database
        /// </summary>
        public async void OnGet()
        {

            string grp = Request.Query["grp"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5289");
                //HTTP GET
                var responseTask = client.GetAsync("Airbnb/Predictive-Analysis?grp=" + grp);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    group = JsonConvert.DeserializeObject<int>(readTask);
                }
            }
        }
    }

}
