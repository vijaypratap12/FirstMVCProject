//using FirstMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Mobile_Shop_Management_MVC_Project.Models;
using System.Diagnostics;

namespace Mobile_Shop_Management_MVC_Project.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult User()
        {
            HttpClient httpClient = new HttpClient();
            MobileModels users = new MobileModels();
            httpClient.BaseAddress = new Uri("https://localhost:7001");
            int UserId = 1;
            var response = httpClient.GetAsync($"/api/MobileShop/GetAllUser?UserId={UserId}");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display =  result.Content.ReadAsAsync<MobileModels>();
                display.Wait();
                users = display.Result;
            }
            return View(users);
            //return View();
        }
        public IActionResult Products()
        {
            HttpClient httpClient = new HttpClient();
            GetProductDetailModel users = new GetProductDetailModel();
            httpClient.BaseAddress = new Uri("https://localhost:7001");
            int UserId = 1;
            var response = httpClient.GetAsync($"/api/MobileShop/GetProductDetailbyId?ProductId={UserId}");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<GetProductDetailModel>();
                display.Wait();
                users = display.Result;
            }
            return View(users);
            //return View();
        }


        public IActionResult Customers()
        {
            HttpClient httpClient = new HttpClient();
            GetCustomerModel users = new GetCustomerModel();
            httpClient.BaseAddress = new Uri("https://localhost:7001");
            int UserId = 1;
            var response = httpClient.GetAsync($"/api/MobileShop/GetCustomerDetailbyId?CustomerId={UserId}");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<GetCustomerModel>();
                display.Wait();
                users = display.Result;
            }
            return View(users);
            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}