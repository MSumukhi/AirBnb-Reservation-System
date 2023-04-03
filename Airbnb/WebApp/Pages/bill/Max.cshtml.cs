using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AirbnbWebApp.Pages.bill
{
    public class MaxModel : PageModel
    {
        public int max = new();
        public async void OnGet()
        {
            var client = new HttpClient();

            var responseTask = client.GetAsync("https://localhost:7001/Airbnb/Analysis-GetHighestAmount");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();


                max = JsonConvert.DeserializeObject<int>(content);

            }
        }
    }
}
