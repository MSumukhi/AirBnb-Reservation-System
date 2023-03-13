using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

///<summary>
///Edit is to update the values in the bill. Here, the values for the item are obtained from the 
///front-end and are passed to the Put method in the controller
///</summary>
namespace WebApp.Pages.Bills
{
    public class EditModel : PageModel
    {
        public Bill bill = new();
        public string errorMessage = "";
        public string successMessage = "";
        public async void OnGet()
        {
            string id = Request.Query["id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5073");
                //HTTP GET
                var responseTask = client.GetAsync("Bill/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    bill = JsonConvert.DeserializeObject<Bill>(readTask);

                }
            }  
        }

        public async void OnPost()
        {
            bill.Id = int.Parse(Request.Form["id"]);
            bill.Category = Request.Form["category"];
            bill.Amount =int.Parse(Request.Form["amount"]);
            bill.Date = Request.Form["date"];

            if (bill.Category.Length == 0)
            {
                errorMessage = "Category is required";
            }
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize<Bill>(bill, opt);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5073");
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("Bill", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode)
                    {
                        errorMessage = "Error editing";
                    }
                    else
                    {
                        successMessage = "Successfully edited";
                    }
                }
            }
        }
    }
}
