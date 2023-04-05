using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using Airbnb.Data;
using Airbnb.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Xml.Linq;

namespace AirbnbWebApp.Pages.bill
{
    using Airbnb.Models;
    public class DeleteModel : PageModel
    {

        public Airbnb bill = new();
        public string errorMessage = "";
        public string successMessage = "";

        /// <summary>
        /// Retrieving the Airbnb to delete from database
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
        /// Posting the update to the web app after deleting an item
        /// </summary>
        public async void OnPost()
        {
            bool isDeleted = false;
            int id = int.Parse(Request.Form["Id"]);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5289");

                var response = await client.DeleteAsync("/Airbnb/" + id);

                if (response.IsSuccessStatusCode)
                {
                    isDeleted = true;
                }
            }
            if (isDeleted)
            {
                successMessage = "Successfully deleted";
            }
            else
            {
                errorMessage = "Error deleting";
            }

        }
    }

}
