using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DefaultContext _context;

        public BranchRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default)
        {
            await _context.Branches.AddAsync(branch, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return branch;
        }

        public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Branches.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        public async Task<List<Branch>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Branches.ToListAsync(cancellationToken);
        }

        public async Task<List<Branch>> GetAllIncludingAsync(CancellationToken cancellationToken = default)
        {
            // Pode usar Include se tiver filhos relacionados
            return await _context.Branches.ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateAsync(Branch branch, CancellationToken cancellationToken = default)
        {
            _context.Branches.Update(branch);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var branch = await GetByIdAsync(id, cancellationToken);
            if (branch == null) return false;

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
