using AuditWorkFlow.Core.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;

namespace AuditWorkFlow.Mvc.Controllers
{
    public class CustomersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            
            //client.BaseAddress = new System.Uri("https://localhost:7233/Customers");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //var response = client.GetAsync("https://localhost:7233/Customers");

            var response = await client.GetAsync("https://localhost:7233/api/Customers");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                
                var customersViewModel = JsonConvert.DeserializeObject<List<CustomerDto>>(result); 

                return View(customersViewModel);
            }

            return View();
        }
    }
}
