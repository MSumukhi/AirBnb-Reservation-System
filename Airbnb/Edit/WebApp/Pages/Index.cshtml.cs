using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

///<summary>
///This Index file behaves as the startup page and lists all the items from the Bill and displays options to create 
///new item, edit,delete and get mean of the amount and get maximum value.
///</summary>
namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Bill> Bills = new();
        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5073");
                var responseTask = client.GetAsync("Bill");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    Bills = JsonConvert.DeserializeObject<List<Bill>>(readTask);
                }
            }
        }
    }
}