using AuditWorkFlow.Api.Data;
using AuditWorkFlow.Api.Models.Domain;

namespace AuditWorkFlow.Api.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();

        Task<Customer> AddCustomerAsync(Customer customer);

        Task<Customer> UpdateCustomerAsync(Guid id, Customer customer);

        Task<Customer> GetByIdAsync(Guid id);

        Task<Customer> DeleteAsync(Guid id);
    }
}
