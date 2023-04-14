using RESTAURANT_MANAGEMENT.Models;
using System.Net.Http.Headers;

namespace RESTAURANT_MANAGEMENT.CommonEntities
{
    public static class AddHeaderToken
    {
        public static void HeaderToken(string token, HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return;
        }
    }
    public static class CommmonEntities
    {
        public static string LoginCustomerUrl(string baseUri) => $"{baseUri}/api/Restaurant/LoginCustomer";
        public static string AllCustomerUrl (string baseUri) => $"{baseUri}/api/Restaurant/AllCustomerDetails";
        public static string AddCustomerUrl(string baseUri) => $"{baseUri}/api/Restaurant/AddCustomer";
        public static string DeleteCustomerUrl(string baseUri, object CustomerId) => $"{baseUri}/api/Restaurant/DeleteCustomer?CustomerId={CustomerId}";
        public static string AllStaffUrl(string baseUri) => $"{baseUri}/api/Restaurant/AllStaffList";
        public static string AddStaffUrl(string baseUri) => $"{baseUri}/api/Restaurant/AddStaff";
        public static string DeleteStaffUrl(string baseUri, object StaffId) => $"{baseUri}/api/Restaurant/DeleteStaff?StaffId={StaffId}";
        public static string AllFoodUrl (string baseUri) => $"{baseUri}/api/Restaurant/AllFoodList";
        public static string AllFeedbackUrl (string baseUri)=> $"{baseUri}/api/Restaurant/GetFeedbackList";
        public static string AddFeedbackUrl(string baseUri) => $"{baseUri}/api/Restaurant/AddingFeedback";

    }
}
