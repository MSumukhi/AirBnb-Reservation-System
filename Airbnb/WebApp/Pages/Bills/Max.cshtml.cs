using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

///<summary>
///In Max, the data analysis is done by obtaining the Maximum amount of the bill list and is displayed in the 
///front-end
///</summary>
namespace WebApp.Pages.Bills
{
    public class MaxModel : PageModel
    {
        public int max = new();
        public async void OnGet()
        {
            var client = new HttpClient();
            
            var responseTask = client.GetAsync("https://localhost:7135/Bill/Analysis-GetHighestAmount");
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
