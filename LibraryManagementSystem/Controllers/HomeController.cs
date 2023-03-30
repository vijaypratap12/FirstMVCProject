using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LibraryManagementSystem.Controllers
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
            HttpClient httpclient = new HttpClient();
            IEnumerable<Category> obj = new List<Category>();
            httpclient.BaseAddress = new Uri("https://localhost:7071");
            //int categoryId = 1;
            var response = httpclient.GetAsync($"/api/Library/GetAllCategory");
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
            HttpClient httpClient = new HttpClient();
            IEnumerable<book> obj = new List<book>();
            httpClient.BaseAddress = new Uri("https://localhost:7071");
            //int bookid = 1;
            var response = httpClient.GetAsync($"/api/Library/GetAllBookDetail");
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
            HttpClient httpClient = new HttpClient();
            IEnumerable<IssueBook> obj = new List<IssueBook>();
            httpClient.BaseAddress = new Uri("https://localhost:7071");
            //int bookid = 1;
            var response = httpClient.GetAsync($"/api/Library/GetissueBookDetail");
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
            HttpClient httpClient = new HttpClient();
            IEnumerable<publisherT> obj = new List<publisherT>();
            httpClient.BaseAddress = new Uri("https://localhost:7071");
            //int bookid = 1;
            var response = httpClient.GetAsync($"/api/Library/GetAllPublisher");
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
            HttpClient httpClient = new HttpClient();
            IEnumerable<Author> obj = new List<Author>();
            httpClient.BaseAddress = new Uri("https://localhost:7071");
            //int bookid = 1;
            var response = httpClient.GetAsync($"/api/Library/GetAllAuthor");
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
            HttpClient httpClient = new HttpClient();
            IEnumerable<Member> obj = new List<Member>();
            httpClient.BaseAddress = new Uri("https://localhost:7071");
            //int bookid = 1;
            var response = httpClient.GetAsync($"/api/Library/GetAllMemberDetail");
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7071");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("/api/Library/AddBook", objbook);

            if (response.IsSuccessStatusCode == true)
            {
                return View();
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7071");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.PostAsJsonAsync("/api/Library/AddMember", objbook);

            if (response.IsSuccessStatusCode == true)
            {
                return View();
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
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071");
			//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			//client.DefaultRequestHeaders.Accept.Clear();

			HttpResponseMessage response = await client.PostAsJsonAsync("/api/Library/AddCategory", objbook);

			if (response.IsSuccessStatusCode == true)
			{
				return View();
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
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071");
			//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			//client.DefaultRequestHeaders.Accept.Clear();

			HttpResponseMessage response = await client.PostAsJsonAsync("/api/Library/AddAuthor", objbook);

			if (response.IsSuccessStatusCode == true)
			{
				return View();
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
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071");
			//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			//client.DefaultRequestHeaders.Accept.Clear();

			HttpResponseMessage response = await client.PostAsJsonAsync("/api/Library/AddPublisher", objbook);

			if (response.IsSuccessStatusCode == true)
			{
				return View();
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
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071");
			//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			//client.DefaultRequestHeaders.Accept.Clear();

			HttpResponseMessage response = await client.PostAsJsonAsync("api/Library/Addissuebook", objbook);

			if (response.IsSuccessStatusCode == true)
			{
				return View();
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
            HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071");

			HttpResponseMessage response = await client.DeleteAsync($"/api/Library/DeleteMember?Id={Id}");

            if(response.IsSuccessStatusCode == true)
            {
                return View();
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
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071");

			HttpResponseMessage response = await client.DeleteAsync($"/api/Library/DeleteCategory?categoryId={categoryId}");
			if (response.IsSuccessStatusCode == true)
			{
				return View();
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
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071");

			HttpResponseMessage response = await client.DeleteAsync($"/api/Library/DeleteAuthor?authorId={authorId}");

			if (response.IsSuccessStatusCode == true)
			{
				return View();
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
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071");

			HttpResponseMessage response = await client.DeleteAsync($"/api/Library/DeletePublisher?id={id}");

			if (response.IsSuccessStatusCode == true)
			{
				return View();
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7071");

            HttpResponseMessage response = await client.DeleteAsync($"/api/Library/DeleteBook?bookId={bookId}");

            if (response.IsSuccessStatusCode == true)
            {
                return View();
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
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071");

			HttpResponseMessage response = await client.DeleteAsync($"/api/Library/DeleteIssueBook?Id={Id}");

			if (response.IsSuccessStatusCode == true)
			{
				return View();
			}
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