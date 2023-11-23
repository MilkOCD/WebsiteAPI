using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopfinAPI.Authorization;
using TopfinAPI.Customers;
using TopfinAPI.EmailSenders;

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
            return await _customerRepository.GetAll().Where(customer => (customer.isDelete == null || customer.isDelete == false)).ToListAsync();
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

                string emailSubject = "Người dùng mới đã đăng ký tài khoản";
                string userName = input.UserName;
                string emailMessage = input.Email;
                string htmlInput = "<div><h1>Người dùng mới đã đăng ký tài khoản<h1></div>" +
                    "<div>Tên người dùng: <b>" + input.UserName + "</b></div>" +
                    "<div>Email: <b>" + input.Email + "</b></div>" +
                    "<div>SĐT: <b>" + input.PhoneNumber + "</b></div>" +
                    "<div>Mã giới thiệu: <b>" + input.ReferralCode + "</b></div>";

                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail(emailSubject, "trantrungoh@gmail.com", userName, emailMessage, htmlInput).Wait();

                return await _customerRepository.InsertAsync(customer);
            }
            catch (Exception exception)
            {
                throw new UserFriendlyException("Đã xảy lỗi trong quá trình tạo tài khoản!\n" + exception);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_AnalysisCenters)]
        public async Task<Customer> SoftDelete(int id)
        {
            var entity = await _customerRepository.FirstOrDefaultAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(Customer), id);
            }

            entity.isDelete = true;

            await _customerRepository.UpdateAsync(entity);

            return entity;
        }
    }
}
