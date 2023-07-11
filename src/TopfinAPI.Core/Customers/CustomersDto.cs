using System.ComponentModel.DataAnnotations;

namespace TopfinAPI.Customers
{
    public class AuthenticateInputDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
    }

    public class RegisterInputDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string ReferralCode { get; set; }
    }

    public class CustomerDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ReferralCode { get; set; }
    }
}

