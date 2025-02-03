using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation
{
    public class MenuService
    {
        private readonly ICustomerRepository _customerRepository;

        public MenuService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Run()
        {
            Console.WriteLine("Hello World");
            Console.ReadKey();

            Console.Write("Ange customername: ");
            var customerName = Console.ReadLine();

            Console.Write("Ange phonenumnber: ");
            var phoneNumber = Console.ReadLine();


           
        }
    }
}
