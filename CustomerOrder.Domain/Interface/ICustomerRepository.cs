using CustomerOrder.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Domain.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerByCustomerId(string id);
        Task<Customer> GetCustomerByCustomerName(string name);
        Task<Customer> AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        //Task<bool> Completed();
    }
}
