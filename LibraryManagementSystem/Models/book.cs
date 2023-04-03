namespace LibraryManagementSystem.Models
{
    public class book
    {
        public int bookId { get; set; }
        public string? bookName { get; set; }
        public string? edition { get; set; }
        public int? categoryId { get; set; }
        public int? authorId { get; set; }
        public int? publisherId { get; set; }


    }

}
