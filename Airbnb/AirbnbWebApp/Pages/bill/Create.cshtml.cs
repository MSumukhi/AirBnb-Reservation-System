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
    public class CreateModel : PageModel
    {

        public Airbnb bill = new();
        public string errorMessage = "";
        public string successMessage = "";

        /// <summary>
        /// Posting a new Airbnb with each attribute of the airbnb structure
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            //bill.Id = int.Parse(Request.Form["Id"]);
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

            //checking if firstname is empty and notifying that it is required
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
                    var result = await client.PostAsync("Airbnb", content);
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
            return RedirectToPage("Index");


        }
    }
}
