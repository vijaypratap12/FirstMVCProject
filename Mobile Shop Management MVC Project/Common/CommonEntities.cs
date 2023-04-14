using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Mobile_Shop_Management_MVC_Project.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Mobile_Shop_Management_MVC_Project.Common
{
    public static class AddHeaderToken
    {
        public static void AddTokenValue(string tokenget, HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenget);
            return;
        }
    }
    public static class CommonEntities
    {
      public static string GetAllUsers(string baseUri) => $"{baseUri}/api/MobileShop/GetAllUsers";
      public static string LoginUrl(string baseUri)=>$"{baseUri}/api/MobileShop/LoginUserOrAdmin";

      public static string Customers(int CustomerId) => $"/api/MobileShop/GetCustomerDetailbyId?CustomerId={CustomerId}";
      public static string Products(int ProductId) => $"/api/MobileShop/GetProductDetailbyId?ProductId={ProductId}";
      public static string UserAsync(int UserId) => $"/api/MobileShop/GetAllUser?UserId={UserId}";
      public static string NewUserOrAdminAdd() => $"/api/MobileShop/AddUserOrAdmin";
      public static string ShowAllCustomers() => $"/api/MobileShop/GetAllCustomers";
      public static string UpdateUserOrAdmin() => $"api/MobileShop/UpdateUserOrAdmin";
      public static string AddCustomers() => $"/api/MobileShop/AddNewCustomer";
      public static string DeleteCustomerById(int CustomerId) => $"api/MobileShop/DeleteCustomerById?CustomerId={CustomerId}";
      public static string DeleteUserById(int UserId) => $"api/MobileShop/DeleteUserById?UserId={UserId}";

    }
}
