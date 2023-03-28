using FirstMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;

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
            List<UserModel> users = new List<UserModel>();
            httpClient.BaseAddress = new Uri("https://localhost:7177");
            var response = httpClient.GetAsync($"/api/Employee/GetAllEmployee");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<List<UserModel>>();
                display.Wait();
                users = display.Result;
            }
            return View(users);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync([FromForm] EmployeeModel employee)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7177");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("/api/Employee/AddNewEmployee", employee);

            if (response.IsSuccessStatusCode == true)
            {
                return View();
            }
            return View();
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