using System.ComponentModel.DataAnnotations;

namespace Mobile_Shop_Management_MVC_Project.Models
{
    public class MobileModels
    {
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserType { get; set; }
        public string? Passwords { get; set; }
        public DateTime? RegisterDate { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
    }
    public class GetUsersModels
    {
        [Required(ErrorMessage = "Inter your User Id")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Inter your First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Inter your Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Inter your Address")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Inter your Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Inter Valid Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Inter Use Type")]
        public string? UserType { get; set; }

        [Required(ErrorMessage = "Inter your Password")]
        public string? Passwords { get; set; }

        //public DateTime? RegisterDate { get; set; }
        [Required(ErrorMessage = "Inter your Active status")]
        public int? IsActive { get; set; }
        //public int IsDeleted { get; set; }
    }

    public class AddNewUserOrAdminModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserType { get; set; }
        public string? Passwords { get; set; }
    }

    public class GetProductDetailModel
    {

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime ProductAddDate { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductCompanyName { get; set; }
        public string? ColorName { get; set; }
        public string? ProductSize { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }

    public class GetCustomerModel
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerMobileNumber { get; set; }
        public string? CustomerRegisterDate { get; set; }
        public string? Gender { get; set; }


    }

    public class AddCustomerModel
    {
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerMobileNumber { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }

    }
    public class LoginUser { 
    
        public int UserId { get; set; }
        public string? Passwords { get; set;}
        public string? Email { get; set; }
    
    }
    public class TokenModel
    {
        public string token { get; set; }
        public int UserId { get; set; }
        public DateTime expiry { get; set; }
    }


}
