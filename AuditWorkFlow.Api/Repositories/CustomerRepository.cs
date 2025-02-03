using AuditWorkFlow.Api.Data;
using AuditWorkFlow.Api.Models.Domain;
using AuditWorkFlow.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AuditWorkFlow.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AuditDbContext _auditDbContext;

        public CustomerRepository(AuditDbContext auditDbContext)
        {
            this._auditDbContext = auditDbContext;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _auditDbContext.Customers.Add(customer);
            await _auditDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> DeleteAsync(Guid id)
        {
            var existing = await _auditDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
            {
                return null;
            }
            _auditDbContext.Customers.Remove(existing);
            await _auditDbContext.SaveChangesAsync();

            return existing;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _auditDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _auditDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(Guid id, Customer customer)
        {
            var existingCustomer = await GetByIdAsync(id);

            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PanNumber = customer.PanNumber;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.CountryCode = customer.CountryCode;
            }
            await _auditDbContext.SaveChangesAsync();

            return existingCustomer;
        }
    }
}
