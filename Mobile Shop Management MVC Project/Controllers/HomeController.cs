//using FirstMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Mobile_Shop_Management_MVC_Project.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

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
        public IActionResult SuccessPage()
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


        public IActionResult Products() { 
        return View();  
        }
        [HttpPost]
        public IActionResult ProductsAsync([FromForm] int ProductId)
        {
            HttpClient httpClient = new HttpClient();
            GetProductDetailModel users = new GetProductDetailModel();
            httpClient.BaseAddress = new Uri("https://localhost:7001");
            //int UserId = 1;
            var response = httpClient.GetAsync($"/api/MobileShop/GetProductDetailbyId?ProductId={ProductId}");
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
            return View();
        }
        [HttpPost]
        public IActionResult Customers([FromForm] int CustomerId)
        {
            HttpClient httpClient = new HttpClient();
            GetCustomerModel users = new GetCustomerModel();
            httpClient.BaseAddress = new Uri("https://localhost:7001");
            //int UserId = 1;
            var response = httpClient.GetAsync($"/api/MobileShop/GetCustomerDetailbyId?CustomerId={CustomerId}");
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



                HttpResponseMessage response = await client.PostAsJsonAsync($"/api/MobileShop/AddUserOrAdmin", employee);



            if (response.IsSuccessStatusCode == true) 
                    return RedirectToAction("SuccessPage");
            else
                    return View();
            
        }

        //public IActionResult ShowAllCustomers()
        //{
        //    return View();
        //}


        [HttpGet]
            public IActionResult ShowAllCustomers()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<GetCustomerModel> users = new List<GetCustomerModel>();
            httpClient.BaseAddress = new Uri("https://localhost:7001");
            //int UserId = 1;
            var response = httpClient.GetAsync($"/api/MobileShop/GetAllCustomers");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<GetCustomerModel>>();
                display.Wait();
                users = display.Result;
            }
            return View(users);
        }

        public IActionResult UpdateUserOrAdmin()
        { 
        return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserOrAdminAsync([FromForm] GetUsersModels mobileModels)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7001");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();



            HttpResponseMessage response = await client.PutAsJsonAsync("api/MobileShop/UpdateUserOrAdmin", mobileModels);



            if (response.IsSuccessStatusCode == true)
                return RedirectToAction("SuccessPage");
            else
                return View();
        }
        public IActionResult AddCustomers(int UserId)
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

            HttpResponseMessage response = await client.PostAsJsonAsync($"/api/MobileShop/AddNewCustomer", employee);

            if (response.IsSuccessStatusCode == true)
                return RedirectToAction("SuccessPage");
            else
                return View();
        }

        public IActionResult DeleteCustomerById()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomerById([FromForm] int CustomerId)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7001");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.DeleteAsync($"api/MobileShop/DeleteCustomerById?CustomerId={CustomerId}");

            if (response.IsSuccessStatusCode==true)
            {
                return RedirectToAction("SuccessPage");
            }
            else
            {
                return View();
            }


        }

        public IActionResult DeleteUserById()
        {
            return View();
        }
        //public IActionResult ShowAllCustomers() {

        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> DeleteUserById([FromForm] int UserId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7001");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.DeleteAsync($"api/MobileShop/DeleteUserById?UserId={UserId}");

            if (response.IsSuccessStatusCode == true)
                return RedirectToAction("SuccessPage");
            else
                return View();


        }

        public IActionResult UpdateUserById()
        {
            return View();
        }

        //public IActionResult UpdateUserById()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}