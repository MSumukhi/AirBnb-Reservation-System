using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

///<summary>
///GetItem is to get the item with the given id. Here, the id is obtained from the user and is passed to the 
///GetItem method in the Controller to retrieve the data and the data is displayed in the frontend.
///</summary>
namespace WebApp.Pages.Bills
{
    public class GetItemModel : PageModel
    {
        public Bill bill = new();
        async void OnGet()
        {
            int Id = int.Parse(Request.Form["Id"]);
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync("http://localhost:5073/Bill/" + Id);
               
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    bill = JsonConvert.DeserializeObject<Bill>(readTask);
                }
            }
        }


    }
    }

