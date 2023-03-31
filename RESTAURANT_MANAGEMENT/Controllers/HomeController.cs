using Microsoft.AspNetCore.Mvc;
using RESTAURANT_MANAGEMENT.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace RESTAURANT_MANAGEMENT.Controllers
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



        [HttpGet]
        public IActionResult AllCustomer()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<AllCustomerDetails> allCustomerDetails = new List<AllCustomerDetails>();
            httpClient.BaseAddress = new Uri("https://localhost:7177/");

            var response = httpClient.GetAsync($"/api/Restaurant/AllCustomerDetails");
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



        //in the first this add will render 
        public IActionResult AddCustomer()
        {
            return View();
        }
        //adding more customers
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromForm] AddCustomer customer)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7177/");
            
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await Client.PostAsJsonAsync($"/api/Restaurant/AddCustomer", customer);
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
        public async Task<IActionResult> DeleteCustomer([FromForm]int CustomerId)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7177/");

            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await Client.DeleteAsync($"api/Restaurant/DeleteCustomer?CustomerId={CustomerId}");
            if (response.IsSuccessStatusCode == true)
            {
                  return RedirectToAction("AllCustomer");
                //return RedirectToAction("DeleteCustomer");
            }
            return View();
        }
       

        // staff list
        [HttpGet]
        public IActionResult AllStaffList()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<AllStaffList> allStaffList = new List<AllStaffList>();
            httpClient.BaseAddress = new Uri("https://localhost:7177/");

            var response = httpClient.GetAsync($"/api/Restaurant/AllStaffList");
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
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7177/");

           
            HttpResponseMessage response = await Client.PostAsJsonAsync($"/api/Restaurant/AddStaff", addStaff);
            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("AllStaffList");
            }
            return View();
        }

        public IActionResult DeleteStaff()
        //delete customer
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStaff([FromForm] int StaffId)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7177/");

            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await Client.DeleteAsync($"/api/Restaurant/DeleteStaff?StaffId={StaffId}");
            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("AllStaffList");
                //return RedirectToAction("DeleteCustomer");
            }
            return View();
        }


        [HttpGet]
        public IActionResult FoodList()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<FoodList> foodlist = new List<FoodList>();
            httpClient.BaseAddress = new Uri("https://localhost:7177/");
            var response = httpClient.GetAsync($"/api/Restaurant/AllFoodList");
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
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7177/");

            HttpResponseMessage response = await Client.PostAsJsonAsync($"/api/Restaurant/AddingFeedback", feedback);
            if (response.IsSuccessStatusCode == true)
            {
                return View();

            }
            return View();
        }


        [HttpGet]
        public IActionResult FeedbackList()
        {
            HttpClient httpClient = new HttpClient();
            IEnumerable<FeedbackList> feedbacklist = new List<FeedbackList>();
            httpClient.BaseAddress = new Uri("https://localhost:7177/");
            var response = httpClient.GetAsync($"/api/Restaurant/GetFeedbackList");
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }


}