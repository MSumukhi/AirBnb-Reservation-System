using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

///<summary>
///Here in the Create file, we are creating a new item of bill which gets all the attributes
///from the user from the front-emd and passes it to the controller which then adds it to the database
///</summary>
namespace WebApp.Pages.Bills
{
    public class CreateModel : PageModel
    {
        public HWK4.Models.Bill bill = new();
        public string errorMessage = "";
        public string successMessage = "";

        public async void OnPost()
        {
            bill.Id = int.Parse(Request.Form["Id"]);
            bill.Category = Request.Form["category"];
            bill.Amount = int.Parse(Request.Form["amount"]);
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
                    var result = await client.PostAsync("Bill", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode)
                    {
                        errorMessage = "Error adding";
                    }
                    else
                    {
                        successMessage = "Successfully added";
                    }
                }
            }

           
        }
    }
}
