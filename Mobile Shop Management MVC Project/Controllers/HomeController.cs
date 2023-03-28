//using FirstMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Mobile_Shop_Management_MVC_Project.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

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
            return View();
        }
        [HttpPost]
        public IActionResult UserAsync(int UserId)
        {
            HttpClient httpClient = new HttpClient();
            MobileModels users = new MobileModels();
            httpClient.BaseAddress = new Uri("https://localhost:7001");
           // int UserId = 1;
            var response = httpClient.GetAsync($"/api/MobileShop/GetAllUser?UserId={UserId}");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<MobileModels>();
                display.Wait();
                users = display.Result;
            }
            return View(users);
            //return View("User",UserId);
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

        public IActionResult AllUsers()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<MobileModels> users = new List<MobileModels>();
            httpClient.BaseAddress = new Uri("https://localhost:7001");
            //int UserId = 1;
            var response = httpClient.GetAsync($"/api/MobileShop/GetAllUsers");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<MobileModels>>();
                display.Wait();
                users = display.Result;
            }
            return View(users);
            //return View();
        }

        public IActionResult NewUserOrAdminAdd()
        {
            return View();
        }
        [HttpPost]
       // [Route("NewUserOrAdminAdd")]
        public async Task<IActionResult> NewUserOrAdminAdd([FromForm] AddNewUserOrAdminModel employee)
        {
            
            
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7001");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();



                HttpResponseMessage response = await client.PostAsJsonAsync("api/MobileShop/AddUserOrAdmin", employee);



            if (response.IsSuccessStatusCode == true) 
                    return View(response);
            else
                    return View();
            
        }

        public IActionResult AddCustomers()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomersAsync([FromForm] AddCustomerModel employee)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7001");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();



            HttpResponseMessage response = await client.PostAsJsonAsync("api/MobileShop/AddNewCustomer", employee);



            if (response.IsSuccessStatusCode == true)
                return View(response);
            else
                return View();
        }

        [HttpDelete]
        public async Task<IActionResult> User([FromForm] int UserId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7001");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();



            HttpResponseMessage response = await client.PostAsJsonAsync("api/MobileShop/DeleteUserById", UserId);



            if (response.IsSuccessStatusCode == true)
                return View(response);
            else
                return View();


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}