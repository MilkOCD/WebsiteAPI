using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Extensions;
using System;

namespace TopfinAPI.Customers
{
    public class Customer: Entity<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string HashPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string ReferralCode { get; set; }
        public string CustomerType { get; set; }
    }
}
