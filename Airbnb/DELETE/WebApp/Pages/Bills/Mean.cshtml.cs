using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

///<summary>
///In Mean , the average value of the total bill amount is calculated and it displayed in the front-end.
///The value is obtained by calling the GetMean method in the controller.
///</summary>
namespace WebApp.Pages.Bills
{
    public class MeanModel : PageModel
    {
        public int mean=new();
        public async void OnGet()
        {
            var client = new HttpClient();
            var responseTask = client.GetAsync("https://localhost:7135/Bill/Analysis-GetMean");
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
