using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopfinAPI.Authorization;
using TopfinAPI.Customers;

namespace TopfinAPI.CustomUsers
{
    public class AuthenticationAppService : ApplicationService
    {
        private readonly IRepository<Customer> _customerRepository;

        public AuthenticationAppService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Boolean> Login(AuthenticateInputDto input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(c => c.Email == input.Email && c.Password == input.Password);

            if (customer != null) return true;

            return false;
        }

        [AbpAuthorize(PermissionNames.Pages_Customers)]
        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAllListAsync();
        }

        public async Task<Customer> CreateCustomer(RegisterInputDto input)
        {
            var existingEmail = await _customerRepository.FirstOrDefaultAsync(c => c.Email == input.Email);
            var existingPhoneNumber = await _customerRepository.FirstOrDefaultAsync(c => c.PhoneNumber == input.PhoneNumber);

            if (existingEmail != null)
            {
                throw new UserFriendlyException("Email đã được đăng ký trước đây!");
            }
            else if (existingPhoneNumber != null)
            {
                throw new UserFriendlyException("Số điện thoại đã được đăng ký trước đây!");
            }

            try
            {
                var customer = new Customer
                {
                    UserName = input.UserName,
                    Email = input.Email,
                    Password = input.Password,
                    HashPassword = "",
                    PhoneNumber = input.PhoneNumber,
                    ReferralCode = input.ReferralCode,
                    CustomerType = "0"
                };

                return await _customerRepository.InsertAsync(customer);
            }
            catch (Exception exception)
            {
                throw new UserFriendlyException("Đã xảy lỗi trong quá trình tạo tài khoản!\n" + exception);
            }
        }
    }
}
