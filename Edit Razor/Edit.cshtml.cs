using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

///<summary>
///Edit is to update the values in the bill.
///Here, the values for the item are obtained from the front-end and are passed 
  ///  to the Put method in the controller
///</summary>
namespace WebApp.Pages.Bills
{
    public class EditModel : PageModel
    {
        //Declaring the variables for success messages amd creating a new reference
        //variables.
        public Bill bill = new();
        public string errorMessage = "";
        public string successMessage = "";
        //Getting the order values based on the ID.
        public async void OnGet()
        {
            //Declaring the ID value.
            string id = Request.Query["id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5073");
                //HTTP GET
                var responseTask = client.GetAsync("Bill/" + id);
                responseTask.Wait();
                //Checking the status code 
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    bill = JsonConvert.DeserializeObject<Bill>(readTask);

                }
            }  
        }

		///<summary>
		///Updating the ID value,category,amount and Date
		///And making category value as mandatory  
		///</summary>
		public async void OnPost()
        {
            //Updating the values
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
                //making the Http request and handling the errors
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
