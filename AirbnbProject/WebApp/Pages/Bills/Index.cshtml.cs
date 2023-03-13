using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApp.Pages.Bills
{
    public class IndexModel : PageModel
    {

        public List<Bill> Bills = new();
        public async void OnGet()
        {
           using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5073");
                var responseTask = client.GetAsync("Bill");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask=await result.Content.ReadAsStringAsync();
                    Bills = JsonConvert.DeserializeObject<List<Bill>>(readTask);
                }
            }
        }
    }
}
