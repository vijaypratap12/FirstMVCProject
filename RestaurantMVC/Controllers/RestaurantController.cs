using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;

namespace RestaurantMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ILogger<RestaurantController> _logger;

        public RestaurantController(ILogger<RestaurantController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult staff()
        {
            HttpClient httpClient = new HttpClient();
            StaffDetails staff = new StaffDetails();
            httpClient.BaseAddress = new Uri("https://localhost:7177/");
            
            var response = httpClient.GetAsync($"api/Restaurant/getStaffDetails?StaffId=1&StaffName=Vinod");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<StaffDetails>();
                display.Wait();
                staff = display.Result;
            }
            return View(staff);
        }
        public IActionResult Privacy()
        {
            return View();
        }
       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new StaffDetails { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}