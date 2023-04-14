using LibraryManagementSystem.Models;
using System.Net;
using System.Net.Http.Headers;

namespace LibraryManagementSystem.Common
{
    public static class AddHeaderToken
    {
        public static void AddTokenValue(string token, HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return;
        }
    }
    public class CommonEntities
    {
        public static string LoginUrl(string baseUri) => $"{baseUri}/api/LoginAdmin/loginAdmin";
        public static string GetAllMember(string baseUri) => $"{baseUri}/api/Library/GetAllMemberDetail";
        public static string GetAllAuthor(string baseUri) => $"{baseUri}/api/Library/GetAllAuthor";
        public static string GetAllPublisher(string baseUri) => $"{baseUri}/api/Library/GetAllPublisher";
        public static string GetissueBookDetail(string baseUri) => $"{baseUri}/api/Library/GetissueBookDetail";
        public static string GetAllBook(string baseUri) => $"{baseUri}/api/Library/GetAllBookDetail";
        public static string GetAllCategory(string baseUri) => $"{baseUri}/api/Library/GetAllCategory";
        public static string AddBook(string baseUri) => $"{baseUri}/api/Library/AddBook";
        public static string AddMember(string baseUri) => $"{baseUri}/api/Library/AddMember";
        public static string AddCategory(string baseUri) => $"{baseUri}/api/Library/AddCategory";
        public static string AddAuthor(string baseUri) => $"{baseUri}/api/Library/AddAuthor";
        public static string AddPublisher(string baseUri) => $"{baseUri}/api/Library/AddPublisher";
        public static string Addissuebook(string baseUri) => $"{baseUri}/api/Library/Addissuebook";
        public static string DeleteMemberDetail(string baseUri, object Id) => $"{baseUri}/api/Library/DeleteMember?Id={Id}";
        public static string DeleteCategoryDetail(string baseUri, object categoryId) => $"{baseUri}/api/Library/DeleteCategory?categoryId={categoryId}";
        public static string DeleteAuthorDetail(string baseUri, object authorId) => $"{baseUri}/api/Library/DeleteAuthor?authorId={authorId}";
        public static string DeletePublisherDetail(string baseUri, object id) => $"{baseUri}/api/Library/DeletePublisher?id={id}";
        public static string DeleteBookDetail(string baseUri, object bookId) => $"{baseUri}/api/Library/DeleteBook?bookId={bookId}";
        public static string DeleteIssueBookDetail(string baseUri, object Id) => $"{baseUri}/api/Library/DeleteIssueBook?Id={Id}";
    }
}
