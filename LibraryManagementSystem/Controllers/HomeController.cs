using LibraryManagementSystem.Common;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
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
        public IActionResult About()
        {
            return View();
        }
        /// <summary>
        /// Get All category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Category()
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            IEnumerable<Category> obj = new List<Category>();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token =  HttpContext.Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.GetAllCategory(config.GetSection("APIBaseURL").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<Category>>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);
        }
        /// <summary>
        /// Get All Books Detail
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Book()
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            IEnumerable<book> obj = new List<book>();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = HttpContext.Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.GetAllBook(config.GetSection("APIBaseURL").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode) 
            {
                var display = result.Content.ReadAsAsync<IEnumerable<book>>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);
        }
        /// <summary>
        /// Get All Issue Book Detail
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult IssueBook()
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            IEnumerable<IssueBook> obj = new List<IssueBook>();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = HttpContext.Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.GetissueBookDetail(config.GetSection("APIBaseURL").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<IssueBook>>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);

        }
        /// <summary>
        /// Get all publisher
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult publisherT()
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            IEnumerable<publisherT> obj = new List<publisherT>();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = HttpContext.Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.GetAllPublisher(config.GetSection("APIBaseURL").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<publisherT>>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);
        }
        /// <summary>
        /// Get All Author
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Author()
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            IEnumerable<Author> obj = new List<Author>();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token =  HttpContext.Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.GetAllAuthor(config.GetSection("APIBaseURL").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<Author>>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);
        }
        /// <summary>
        /// Get all member
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Member()
        {
            //token = HttpContext.Request.Cookies.TryGetValue("token", out token).ToString();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            IEnumerable<Member> obj = new List<Member>();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = HttpContext.Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.GetAllMember(config.GetSection("APIBaseURL").Value);
            var response = httpClient.GetAsync(newurl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<IEnumerable<Member>>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);
        }
        /// <summary>
        /// Adding books detail on table
        /// </summary>
        /// <param name="objbook"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromForm] book objbook)
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.AddBook(config.GetSection("APIBaseURL").Value);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newurl, objbook);

            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("book");
            }
            return View();
        }
        /// <summary>
        /// Adding Member detail on table
        /// </summary>
        /// <param name="objbook"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddMemberAsync([FromForm] Member objbook)
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.AddMember(config.GetSection("APIBaseURL").Value);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newurl, objbook);

            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("Member");
            }
            return View();
        }
        /// <summary>
        /// Adding Category detail on table
        /// </summary>
        /// <param name="objbook"></param>
        /// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddCategoryAsync([FromForm] Category objbook)
		{
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.AddCategory(config.GetSection("APIBaseURL").Value);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newurl, objbook);

			if (response.IsSuccessStatusCode == true)
			{
				return RedirectToAction("Category");
			}
			return View();
		}

        /// <summary>
        /// Adding Author detail
        /// </summary>
        /// <param name="objbook"></param>
        /// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddAuthorAsync([FromForm] Author objbook)
		{
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.AddAuthor(config.GetSection("APIBaseURL").Value);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newurl, objbook);

			if (response.IsSuccessStatusCode == true)
			{
				return RedirectToAction("Author");
			}
			return View();
		}
        /// <summary>
        /// Adding Publisher Detail
        /// </summary>
        /// <param name="objbook"></param>
        /// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddpublisherAsync([FromForm] publisherT objbook)
		{
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.AddPublisher(config.GetSection("APIBaseURL").Value);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newurl, objbook);

			if (response.IsSuccessStatusCode == true)
			{
				return RedirectToAction("publisherT");
			}
			return View();
		}
        /// <summary>
        /// Add Issue Book Detail
        /// </summary>
        /// <param name="objbook"></param>
        /// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddIssueBookAsync([FromForm] IssueBook objbook)
		{
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.Addissuebook(config.GetSection("APIBaseURL").Value);
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(newurl, objbook);

			if (response.IsSuccessStatusCode == true)
			{
				return RedirectToAction("IssueBook");
			}
			return View();
		}
		/// <summary>
		/// Deleting Member Detail on table 
		/// </summary>
		/// <returns></returns>
		[HttpPost]
        public async Task<IActionResult> DeleteMember([FromForm] int Id)
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.DeleteMemberDetail(config.GetSection("APIBaseURL").Value, Id);
            HttpResponseMessage response = await httpClient.DeleteAsync(newurl);

            if(response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("Member");
            }
            return View();

		}
        /// <summary>
        /// Deleting Category Detail on table
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> DeleteCategory([FromForm] int categoryId)
		{
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.DeleteCategoryDetail(config.GetSection("APIBaseURL").Value, categoryId);
            HttpResponseMessage response = await httpClient.DeleteAsync(newurl);
			if (response.IsSuccessStatusCode == true)
			{
				return RedirectToAction("Category");
			}
			return View();

		}
        /// <summary>
        /// Deteting Author Detail on table
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> DeleteAuthor([FromForm] int authorId)
		{
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.DeleteAuthorDetail(config.GetSection("APIBaseURL").Value, authorId);
            HttpResponseMessage response = await httpClient.DeleteAsync(newurl);

			if (response.IsSuccessStatusCode == true)
			{
				return RedirectToAction("Author");
			}
			return View();

		}
        /// <summary>
        /// Deleting Publisher Detail on table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Deletepublisher([FromForm] int id)
		{
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.DeletePublisherDetail(config.GetSection("APIBaseURL").Value, id);
            HttpResponseMessage response = await httpClient.DeleteAsync(newurl);

			if (response.IsSuccessStatusCode == true)
			{
				return RedirectToAction("publisherT");
			}
			return View();

		}
        /// <summary>
        /// Deleting book on record
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteBook([FromForm] int bookId)
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.DeleteBookDetail(config.GetSection("APIBaseURL").Value, bookId);
            HttpResponseMessage response = await httpClient.DeleteAsync(newurl);

            if (response.IsSuccessStatusCode == true)
            {
                return RedirectToAction("Book");
            }
            return View();

        }
        /// <summary>
        /// Deleting Issue book 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> DeleteIssueBook([FromForm] int Id)
		{
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var token = Request.Cookies["token"];
            AddHeaderToken.AddTokenValue(token, httpClient);
            var newurl = CommonEntities.DeleteIssueBookDetail(config.GetSection("APIBaseURL").Value,Id);
            HttpResponseMessage response = await httpClient.DeleteAsync(newurl);

			if (response.IsSuccessStatusCode == true)
			{
				return RedirectToAction("IssueBook");
			}
			return View();

		}
        public IActionResult loginAdmin()
        { 
            return View(); 
        }
        /// <summary>
        /// login detail
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> loginAdmin([FromForm] loginAdmin admin)
        {
            loginResponse loginresponse = new loginResponse();
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(config.GetSection("APIBaseURL").Value);
            var newurl = CommonEntities.LoginUrl("");
            var response = httpClient.PostAsJsonAsync(newurl, admin).Result;
            loginresponse =  response.Content.ReadAsAsync<loginResponse>().Result;
            if (response.IsSuccessStatusCode == true)
            {
                var token = loginresponse.token.ToString();
                HttpContext.Response.Cookies.Append("token", token,
                new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddMinutes(20) });
                return RedirectToAction("Member");
            }
                
            else
                return View();
        }

            public IActionResult DeleteBook()
        {
            return View();
        }
        public IActionResult DeleteCategory()
		{
			return View();
		}
		public IActionResult Deletepublisher()
		{
			return View();
		}
		public IActionResult DeleteAuthor()
		{
			return View();
		}
		public IActionResult DeleteMember()
        {
            return View();
        }
        public IActionResult DeleteIssueBook()
        {
            return View();
        }
        public IActionResult AddMember()
        {
            return View();
        }
		public IActionResult AddAuthor()
		{
			return View();
		}
		public IActionResult Addpublisher()
		{
			return View();
		}
		public IActionResult AddCategory()
		{
			return View();
		}
		public IActionResult AddBook()
		{
			return View();
		}
        public IActionResult AddIssueBook()
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