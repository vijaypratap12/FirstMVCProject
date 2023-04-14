namespace SchoolManagementSystemMVC.Models
{
    public class SchoolModel
    {    
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public string Age { get; set; }
            public string Contact { get; set; }
        }
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Age { get; set; }
        public string Department { get; set; }
    }
    public class CourseModel
    {
        public int courseid { get; set; }
        public string CourseName { get; set; }
        public string AffiliatedBY { get; set; }
    }
    public class AddCourseModel
    {
        public string CourseName { get; set; }
        public string AffiliatedBY { get; set; }
    }
    public class AddStudentModel
    {
        public string? StudentName { get; set; }
        public int? Age { get; set; }
        public string?Contact { get; set; }
     }
    public class AddTeacherModel
    {
        public string? TeacherName { get; set; }
        public int? Age { get; set; }
        public string? Department { get; set; }
    }
    public class loginAdmin
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class loginresponse
    {
        public string token { get; set; }
        public string expiryDate { get; set; }
        public string userName { get; set; }
    }
}
