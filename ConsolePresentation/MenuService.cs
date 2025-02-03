using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation
{
    public class MenuService(ICustomerRepository customerRepository, IPhoneNumberRepository phoneNumberRepository)
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IPhoneNumberRepository _phoneNumberRepository = phoneNumberRepository;

        public async Task Run()
        {
            var customer = new CustomerEntity()
            {
                CustomerName = "Test"
            };

            var customer1 = await _customerRepository.CreateAsync(customer);


            var phone = new PhoneNumberEntity()
            {
                PhoneNumber = "071-2345678",
                CustomerId = customer.Id
            };

            var phoneNumber = await _phoneNumberRepository.CreateAsync(phone);

            Console.WriteLine($"{customer1.CustomerName} + {phoneNumber.CustomerId}, {phoneNumber.PhoneNumber}");
            Console.ReadKey();
        }
    }
}
