using FirstMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace FirstMVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult User()
        {
            HttpClient httpClient = new HttpClient();
            UserModel users = new UserModel();
            httpClient.BaseAddress = new Uri("https://localhost:7177");
            int UserId = 1;
            var response = httpClient.GetAsync($"/api/Employee/GetEmployeeByUserId/?UserId={UserId}");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<UserModel>();
                display.Wait();
                users = display.Result;
            }
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}