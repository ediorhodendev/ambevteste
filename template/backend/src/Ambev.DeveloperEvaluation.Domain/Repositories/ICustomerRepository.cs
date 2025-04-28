using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<Customer>> GetAllIncludingAsync(CancellationToken cancellationToken = default); // ✅ Ajustado

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Customer customer, CancellationToken cancellationToken = default); // ✅ Ajustado
        Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default); // ✅ Ajustado
    }
}
