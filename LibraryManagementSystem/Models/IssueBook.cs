namespace LibraryManagementSystem.Models
{
    public class IssueBook
    {
        public int Id { get; set; }
        public int? memberId{ get; set; }
        public int? bookId{ get; set; }
        public DateTime? Idate { get; set; }
        public DateTime? Rdate { get; set; }

    }
}
