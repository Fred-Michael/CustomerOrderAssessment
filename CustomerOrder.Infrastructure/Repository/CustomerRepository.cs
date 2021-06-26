using CustomerOrder.Domain.Interface;
using CustomerOrder.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrder.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _ctx;

        public CustomerRepository(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await _ctx.Customers.AddAsync(customer);
            return result.Entity;
        }

        //public async Task<bool> Completed()
        //{
        //    return await _ctx.SaveChangesAsync() > 0;
        //}

        public void DeleteCustomer(Customer customer)
        {
            _ctx.Customers.Remove(customer);
        }

        public async Task<Customer> GetCustomerByCustomerId(string id)
        {
            return await _ctx.Customers.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
        }

        public async Task<Customer> GetCustomerByCustomerName(string name)
        {
            return await _ctx.Customers.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _ctx.Customers.ToListAsync();
        }

        public void UpdateCustomer(Customer customer)
        {
            _ctx.Customers.Update(customer);
        }
    }
}
