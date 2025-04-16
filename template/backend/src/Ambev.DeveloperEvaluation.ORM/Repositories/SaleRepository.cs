using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sales.Include(x => x.Items).ToListAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<Sale>> GetAllIncludingAsync(CancellationToken cancellationToken)
        {
            return await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Branch)
                .Include(s => s.Items)
                    .ThenInclude(i => i.Product)
                .AsNoTracking() // Opcional, para melhorar performance
                .ToListAsync(cancellationToken);
        }



    }
}
