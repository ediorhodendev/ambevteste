using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchRepository
    {
        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Branch>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<Branch>> GetAllIncludingAsync(CancellationToken cancellationToken = default);
        Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Branch branch, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
