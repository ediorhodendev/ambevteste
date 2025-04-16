using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken);
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Customer customer, CancellationToken cancellationToken);
    }
}
