using commonentities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SchoolManagementSystemMVC.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SchoolManagementSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        [HttpGet]
        public IActionResult GetStudent()
        {
            HttpClient httpClient = new HttpClient();
            List<SchoolModel> students = new List<SchoolModel>();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            var newurl = CommonEntities.GetStudent(config.GetSection("APIBaseUrl").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<List<SchoolModel>>();
                display.Wait();
                students = display.Result;
            }
            return View(students);
        }
        [HttpGet]
        public IActionResult GetTeacher()
        {
            HttpClient httpClient = new HttpClient();
            List<TeacherModel> teachers = new List<TeacherModel>();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
           var newurl= CommonEntities.GetTeacher(config.GetSection("APIBaseUrl").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<List<TeacherModel>>();
                display.Wait();
                teachers = display.Result;
            }
            return View(teachers);
        }
        [HttpGet]
        public IActionResult GetCourse()
        {
            HttpClient httpClient = new HttpClient();
            List<CourseModel> teachers = new List<CourseModel>();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, httpClient);
            var newurl = CommonEntities.GetCourse(config.GetSection("APIBaseUrl").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<List<CourseModel>>();
                display.Wait();
                teachers = display.Result;
            }
            return View(teachers);
        }

        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudentAsync([FromForm] AddStudentModel student)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, client);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            var newurl = CommonEntities.AddNewStudent(config.GetSection("APIBaseUrl").Value);
            HttpResponseMessage response = await client.PostAsJsonAsync(newurl,student);

            if (response.IsSuccessStatusCode == true)
               return RedirectToAction("GetStudent");
            else
                return View();
        }
        public IActionResult DeleteStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStudent([FromForm] int StudentId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, client);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            var newurl = CommonEntities.DeleteNewStudent(StudentId);
            HttpResponseMessage response = await client.DeleteAsync(newurl);

            if (response.IsSuccessStatusCode == true)
                return RedirectToAction("GetStudent"); 
            else
                return View();
        }
        public IActionResult DeleteTeacher()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTeacher([FromForm] int TeacherId)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, client);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            var newurl = CommonEntities.DeleteTeacher(TeacherId);
            HttpResponseMessage response = await client.DeleteAsync(newurl);


            if (response.IsSuccessStatusCode == true)
                return RedirectToAction("GetTeacher"); 
            else
                return View();
        }
        public IActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeacherAsync([FromForm] AddTeacherModel teacher)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, client);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            var newurl = CommonEntities.AddNewTeacher(config.GetSection("APIBaseUrl").Value);
            HttpResponseMessage response = await client.PostAsJsonAsync(newurl, teacher);

            if (response.IsSuccessStatusCode == true)
                return RedirectToAction("GetTeacher");
            else
                return View();
        }
        public IActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCourseAsync([FromForm] AddCourseModel course)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(config.GetSection("APIBaseUrl").Value);
            var tokenget = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(tokenget, client);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            var newurl = CommonEntities.AddNewCourse(config.GetSection("APIBaseUrl").Value);
            HttpResponseMessage response = await client.PostAsJsonAsync(newurl, course);
            if (response.IsSuccessStatusCode == true)
                return RedirectToAction("GetCourse"); 
            else
                return View();
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> loginAsync([FromForm] loginAdmin admin)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7177");
            loginresponse loginresponse = new loginresponse();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();
            var newurl= CommonEntities.LoginUrl("");
            //HttpResponseMessage response = await client.PostAsJsonAsync("api/School/loginAdmin",admin);
            var response = client.PostAsJsonAsync(newurl, admin).Result;
            loginresponse = response.Content.ReadAsAsync<loginresponse>().Result;
            if (response.IsSuccessStatusCode == true)
            {
                var token = loginresponse.token.ToString();
                HttpContext.Response.Cookies.Append("token", token,
               new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddMinutes(15) });
                return RedirectToAction("GetStudent");
            }
            else
                return View();
        }        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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