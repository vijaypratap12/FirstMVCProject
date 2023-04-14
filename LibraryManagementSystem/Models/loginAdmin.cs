namespace LibraryManagementSystem.Models
{
    public class loginAdmin
    {
        //public int AdminId { get; set; }
        public string? email { get; set; }
        public string? adminPassword { get; set; }
    }
    public class loginResponse
    {
        public string token { get; set; }
        public string expires { get; set; }
        public string email { get; set; }
    }
}
