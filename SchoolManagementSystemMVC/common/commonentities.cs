using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using SchoolManagementSystemMVC.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;



namespace commonentities
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
        public static string LoginUrl(string baseUri) => $"{baseUri}/api/School/loginAdmin";
        public static string GetStudent(string baseUri) => $"{baseUri}/api/School/GetAllStudent";
        public static string GetTeacher(string baseUri) => $"{baseUri}/api/School/GetAllTeacher";
        public static string GetCourse(string baseUri) => $"{baseUri}/api/School/GetAllCourse";
        public static string AddNewStudent(string baseUri) => $"/api/School/AddNewStudent";
        public static string AddNewTeacher(string baseUri) => $"/api/School/AddNewTeacher";
        public static string AddNewCourse(string baseUri) => $"/api/School/AddNewCourse";
        public static string DeleteNewStudent(int StudentId) => $"api/School/DeleteNewStudent?StudentId={StudentId}";
        public static string DeleteTeacher(int TeacherId) => $"api/School/DeleteTeacher?TeacherId={TeacherId}";



    }
}