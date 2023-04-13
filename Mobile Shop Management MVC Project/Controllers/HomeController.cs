//using FirstMVCProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Mobile_Shop_Management_MVC_Project.Common;
using Mobile_Shop_Management_MVC_Project.Models;
using NuGet.Packaging.Licenses;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Mobile_Shop_Management_MVC_Project.Controllers
{
    //public class JwtMiddleware
    //{
    //    private readonly RequestDelegate _next;

    //    public JwtMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }

    //    public async Task Invoke(HttpContext context)
    //    {
    //        string token = context.Request.Cookies["token"];

    //        if (!string.IsNullOrEmpty(token))
    //        {
    //            context.Request.Headers.Add("Authorization", $"Bearer {token}");
    //        }

    //        await _next(context);
    //    }
    //}

    public class HomeController : Controller
    {
        private readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private readonly ILogger<HomeController> _logger;

        //public string APIBaseUrl { get; private set; }

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
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            var newurl = CommonEntities.UserAsync(UserId);
            var response = httpClient.GetAsync(newurl);
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
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var newurl = CommonEntities.Products(ProductId);
            var response = httpClient.GetAsync(newurl);
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
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            //int UserId = 1;
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            var newurl = CommonEntities.Customers(CustomerId);
            var response = httpClient.GetAsync(newurl);
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
        [HttpPost]
        public IActionResult Index([FromForm] int CustomerId)
        {
            HttpClient httpClient = new HttpClient();
            GetCustomerModel users = new GetCustomerModel();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            
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
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            //int UserId = 1;
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            var newurl = CommonEntities.GetAllUsers(config.GetSection("APIBaseUrl").Value);
            var response = httpClient.GetAsync(newurl);
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




        public IActionResult LoginUserOrAdminAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUserOrAdmin([FromForm] LoginUser user)
        {
            HttpClient httpClient = new HttpClient();
            TokenModel token = new TokenModel();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);     
            var newurl = CommonEntities.LoginUrl("");
            var response = httpClient.PostAsJsonAsync(newurl,user);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<TokenModel>();
               
                display.Wait();
                token = display.Result;

                var token1 = token.token.ToString();
                HttpContext.Response.Cookies.Append("token", token1, new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddMinutes(10) });
            }
            return View(token);
        }

        public IActionResult NewUserOrAdminAdd()
        {
            return View();
        }
        [HttpPost]
       // [Route("NewUserOrAdminAdd")]
        public async Task<IActionResult> NewUserOrAdminAdd([FromForm] AddNewUserOrAdminModel employee)
        {
            
            
                HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            var newurl = CommonEntities.NewUserOrAdminAdd();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newurl, employee);
     if (response.IsSuccessStatusCode == true) 
                    return RedirectToAction("SuccessPage");
            else
                    return View();
            
        }

        [HttpGet]
            public IActionResult ShowAllCustomers()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<GetCustomerModel> users = new List<GetCustomerModel>();
            var tokenget = Request.Cookies["token"];
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            var newurl = CommonEntities.ShowAllCustomers();
            var response = httpClient.GetAsync(newurl);
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
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            var newurl = CommonEntities.UpdateUserOrAdmin();
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(newurl, mobileModels);
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
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);

            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            var newurl = CommonEntities.UpdateUserOrAdmin();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newurl, employee);

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
            
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            var newurl = CommonEntities.DeleteCustomerById(CustomerId);
            HttpResponseMessage response = await httpClient.DeleteAsync(newurl);

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
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            var newurl = CommonEntities.DeleteUserById(UserId);
            HttpResponseMessage response = await httpClient.DeleteAsync(newurl);

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