namespace RESTAURANT_MANAGEMENT.Models
{
    public class AllCustomerDetails
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerContact { get; set; }
        public string? CustomerAddress { get; set; }

    }

    public class AddCustomer
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerContact { get; set; }
        public string? CustomerAddress { get; set; }

    }

    public class DeleteCustomer
    {
        public int CustomerId { get; set; }
    }

    public class AllStaffList
    {
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public string? StaffContact { get; set; }
        public string? StaffCategory { get; set; }
        public string? StaffAddress { get; set; }
    }
    public class AddStaff
    {
        public int StaffId { get; private set; }
        public string? StaffName { get; set; }
        public string? StaffContact { get; set; }
        public string? StaffCategory { get; set; }
        public string? StaffAddress { get; set; }

    }
    public class DeleteStaff
    {
        public int StaffId { get; set; }
    }
    public class FoodList
    {
        public int FoodId { get; set; }
        public string? FoodName { get; set; }
        public string? FoodPrice { get; set; }
    
    }
}