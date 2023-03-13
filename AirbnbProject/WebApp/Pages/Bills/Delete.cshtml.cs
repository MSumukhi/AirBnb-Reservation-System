using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

///<summary>
///In Delete file, the item is deleted by id. Id is retrieved from the item and is passed to the controller
///to delete the particular item corresponding to that id
///</summary>
namespace WebApp.Pages.Bills
{
    public class DeleteModel : PageModel
    {
        public Bill bill = new();
        public string errorMessage = "";
        public string successMessage = "";

        public async void OnGet()
        {
            string id = Request.Query["Id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5073");
              
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
            bool isDeleted = false;
            int id = int.Parse(Request.Form["Id"]);
            using (var client = new HttpClient())
            {
                 client.BaseAddress = new Uri("http://localhost:5073");
              
                //var response = await client.DeleteAsync(id);
                string Url = "http://localhost:5073/Bill/";
                var uri = new Uri(string.Format(Url, id));
                var response = await client.DeleteAsync(uri);
                // var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                //var response = await client.DeleteAsync("/Bill/"+id);
                //  string resultContent = await result.Content.ReadAsStringAsync();
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
                errorMessage = "Error Deleting";
            }
        }
    }
}
