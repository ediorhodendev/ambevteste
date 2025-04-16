using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchRepository
    {
        Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken);
        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Branch>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Branch branch, CancellationToken cancellationToken);
    }
}
