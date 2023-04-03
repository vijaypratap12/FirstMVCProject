using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystemMVC.Models;
using System.Diagnostics;
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
        [HttpGet]
        public IActionResult GetStudent()
        {
            HttpClient httpClient = new HttpClient();
            List<SchoolModel> students = new List<SchoolModel>();
            httpClient.BaseAddress = new Uri("https://localhost:7177");
            var response = httpClient.GetAsync($"/api/School/GetAllStudent");
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
            httpClient.BaseAddress = new Uri("https://localhost:7177");
            var response = httpClient.GetAsync($"/api/School/GetAllTeacher");
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
            httpClient.BaseAddress = new Uri("https://localhost:7177");
            var response = httpClient.GetAsync($"/api/School/GetAllCourse");
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
            client.BaseAddress = new Uri("https://localhost:7177");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("api/School/AddNewStudent", student);

            if (response.IsSuccessStatusCode == true)
                return View();
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
            client.BaseAddress = new Uri("https://localhost:7177");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.DeleteAsync($"api/School/DeleteNewStudent?StudentId={StudentId}");

            if (response.IsSuccessStatusCode == true)
                return View(response);
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
            client.BaseAddress = new Uri("https://localhost:7177");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.DeleteAsync($"api/School/DeleteTeacher?TeacherId={TeacherId}");

            if (response.IsSuccessStatusCode == true)
                return View(response);
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
            client.BaseAddress = new Uri("https://localhost:7177");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("api/School/AddNewTeacher", teacher);

            if (response.IsSuccessStatusCode == true)
                return View();
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
            client.BaseAddress = new Uri("https://localhost:7177");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("api/School/AddNewCourse", course);

            if (response.IsSuccessStatusCode == true)
                return View();
            else
                return View();
        }
        public IActionResult Index()
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