using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace AirbnbWebApp.Pages.bill
{
    using Airbnb.Models;
    using Airbnb.Data;
    using Airbnb.Interfaces;
    using Airbnb.Repositories;
    using Airbnb.Controllers;
    public class EditModel : PageModel
    {
        public Airbnb bill = new();
        public string errorMessage = "";
        public string successMessage = "";

        /// <summary>
        /// Retrieving the airbnb details from database
        /// </summary>
        public async void OnGet()
        {
            string id = Request.Query["id"];


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5289");

                // HTTP GET
                var responseTask = client.GetAsync("Airbnb/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    bill = JsonConvert.DeserializeObject<Airbnb>(readTask);
                }

            }
        }

        /// <summary>
        /// Posting the chnages made to the particular Airbnb
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            bill.Id = int.Parse(Request.Query["id"]);
            bill.name = Request.Form["name"];
            bill.host_id = Request.Form["host_id"];
            bill.host_name = Request.Form["host_name"];
            bill.neighbourhood_group = Request.Form["neighbourhood_group"];
            bill.neighbourhood = Request.Form["neighbourhood"];
            bill.roomtype = Request.Form["roomtype"];
            bill.price = int.Parse(Request.Form["price"]);
            bill.minimum_nights = int.Parse(Request.Form["minimum_nights"]);
            bill.number_of_reviews = int.Parse(Request.Form["number_of_reviews"]);
            bill.reviews_per_month = double.Parse(Request.Form["reviews_per_month"]);
            bill.availability_365 = Request.Form["availability_365"];
            bill.reviews = Request.Form["reviews"];
            bill.max_people = int.Parse(Request.Form["max_people"]);
            bill.children_amenities = Request.Form["children_amenities"];

            if (bill.name.Length == 0)
            {
                errorMessage = "FirstName is required";
            }
            
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize<Airbnb>(bill, opt);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5289");

                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var result = await client.PutAsync("Airbnb", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode)
                    {
                        errorMessage = "Error editing";
                    }
                    else
                    {
                        successMessage = "Successfully editing";
                    }

                }
            }
            return RedirectToPage("Index");
        }
    }
}

