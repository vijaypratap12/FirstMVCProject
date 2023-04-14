//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTAURANT_MANAGEMENT.Models;
using System.Configuration;
using System.Diagnostics;
using RESTAURANT_MANAGEMENT.CommonEntities;
using System.Reflection.PortableExecutable;

namespace RESTAURANT_MANAGEMENT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult AllCustomer()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<AllCustomerDetails> allCustomerDetails = new List<AllCustomerDetails>();                       
            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var token = HttpContext.Request.Cookies["token"];
            AddHeaderToken.HeaderToken(token, httpClient);
            var newUrl = CommmonEntities.AllCustomerUrl(config.GetSection("ApiBaseUrl").Value);
            var response = httpClient.GetAsync(newUrl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<AllCustomerDetails>>();
                display.Wait();
                allCustomerDetails = display.Result;
            }
            return View(allCustomerDetails);
        }



        //in the first this add will be render 
        public IActionResult AddCustomer()
        {
            return View();
        }
        //adding more customers
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromForm] AddCustomer customer)
        {
            HttpClient httpClient = new HttpClient();                       
            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.HeaderToken(token, httpClient);
            var newUrl = CommmonEntities.AddCustomerUrl(config.GetSection("ApiBaseUrl").Value);
            //var response = httpClient.GetAsync(newUrl);
            //response.Wait();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newUrl, customer);
            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("AllCustomer");
            }
             return View();
        }
        public IActionResult DeleteCustomer()
        //delete customer
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCustomer([FromForm] int CustomerId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.HeaderToken(token, httpClient);
            var newUrl = CommmonEntities.DeleteCustomerUrl(config.GetSection("ApiBaseUrl").Value, CustomerId);
          
            HttpResponseMessage response = await httpClient.DeleteAsync(newUrl);
            
            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("AllCustomer");  
            }
            return View();
        }



        // staff list
        [HttpGet]
        public IActionResult AllStaffList()
        {
            HttpClient httpClient = new HttpClient();           
            IEnumerable<AllStaffList> allStaffList = new List<AllStaffList>();

            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var token = HttpContext.Request.Cookies["token"];
            AddHeaderToken.HeaderToken(token, httpClient);
            var newurl = CommmonEntities.AllStaffUrl(config.GetSection("ApiBaseUrl").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<AllStaffList>>();
                display.Wait();
                allStaffList = display.Result;
            }
            return View(allStaffList);
        }

        // show staff form 
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        //adding more customers
        [HttpPost]
        public async Task<IActionResult> AddStaff([FromForm] AddStaff addStaff)
        {
            HttpClient httpClient = new HttpClient();            
            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.HeaderToken(token, httpClient);
            var newUrl = CommmonEntities.AddStaffUrl(config.GetSection("ApiBaseUrl").Value);            
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newUrl, addStaff);
            
            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("AllStaffList");
            }
            return View();
        }
        public IActionResult DeleteStaff()
        
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> DeleteStaff([FromForm] int StaffId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.HeaderToken(token, httpClient);

            var newUrl = CommmonEntities.DeleteStaffUrl(config.GetSection("ApiBaseUrl").Value, StaffId);
            HttpResponseMessage response = await httpClient.DeleteAsync(newUrl);            
            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("AllStaffList");                
            }
            return View();
        }



        [HttpGet]
        public IActionResult FoodList()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<FoodList> foodlist = new List<FoodList>();
            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var token = HttpContext.Request.Cookies["token"];
            AddHeaderToken.HeaderToken(token, httpClient);
            var newUrl = CommmonEntities.AllFoodUrl(config.GetSection("ApiBaseUrl").Value);
            var response = httpClient.GetAsync(newUrl);            
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<FoodList>>();
                display.Wait();
                foodlist = display.Result;
            }
            return View(foodlist);
        }


        [HttpGet]
        public IActionResult AddFeedback()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback([FromForm] AddFeedback feedback)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.HeaderToken(token, httpClient);
            var newUrl = CommmonEntities.AddFeedbackUrl(config.GetSection("ApiBaseUrl").Value);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync($"/api/Restaurant/AddingFeedback", feedback);
            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("FeedbackList");
            }
            return View();
        }


        [HttpGet]
        public IActionResult FeedbackList()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<FeedbackList> feedbacklist = new List<FeedbackList>();
            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var token = HttpContext.Request.Cookies["token"];
            AddHeaderToken.HeaderToken(token, httpClient);
            var newUrl = CommmonEntities.AllFeedbackUrl(config.GetSection("ApiBaseUrl").Value);
            var response = httpClient.GetAsync(newUrl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<FeedbackList>>();
                display.Wait();
                feedbacklist = display.Result;
            }
            return View(feedbacklist);
        }

        public IActionResult LoginCustomer()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> loginCustomerAsync([FromForm] LoginCustomer admin)
        {
            TokenResponse tokenResponse = new TokenResponse();
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("ApiBaseUrl").Value);
            var newUrl = CommmonEntities.LoginCustomerUrl("");
           
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newUrl, admin);
            
            tokenResponse = response.Content.ReadAsAsync<TokenResponse>().Result;
            if (response.IsSuccessStatusCode == true)
            {
                var token = tokenResponse.token.ToString();
                HttpContext.Response.Cookies.Append("token", token,
                new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(20)
                });
                return RedirectToAction("LoginSuccess");
            }
            else
                return View();
        }
       
        public IActionResult LoginSuccess()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About ()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }

    }


}