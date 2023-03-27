namespace FirstMVCProject.Models
{
    public class UserModel
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
            public string email { get; set; }
        public DateTime updatedDate { get; set; }
        public string isActive { get; set; }
        public string isDelete { get; set; }
    }
}
