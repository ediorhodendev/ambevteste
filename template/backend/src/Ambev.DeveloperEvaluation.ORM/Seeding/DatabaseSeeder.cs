using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Seeding;

public static class DatabaseSeeder
{
    public static async Task SeedDatabaseAsync(this DefaultContext context)
    {
        if (await context.Users.AnyAsync()) return;

        // Usuários
        var users = Enumerable.Range(1, 30).Select(i =>
            new User
            {
                Id = Guid.NewGuid(),
                Username = $"user{i}",
                Email = $"user{i}@example.com",
                Phone = $"555-010{i:D2}",
                Role = Domain.Enums.UserRole.Admin,
                Status = Domain.Enums.UserStatus.Active,
                Password = BCrypt.Net.BCrypt.HashPassword("password")
            }).ToList();
        await context.Users.AddRangeAsync(users);

        // Produtos
        var products = Enumerable.Range(1, 30).Select(i =>
            new Product
            {
                Id = Guid.NewGuid(),
                Name = $"Product {i}",
                Description = $"Description for product {i}",
                Price = 10 + i
            }).ToList();
        await context.Products.AddRangeAsync(products);

        // Filiais
        var branches = Enumerable.Range(1, 30).Select(i =>
            new Branch
            {
                Id = Guid.NewGuid(),
                Name = $"Branch {i}",
                Location = $"Location {i}"
            }).ToList();
        await context.Branches.AddRangeAsync(branches);

        // Clientes
        var customers = Enumerable.Range(1, 30).Select(i =>
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = $"Customer {i}",
                Email = $"customer{i}@example.com",
                Phone = $"555-020{i:D2}"
            }).ToList();
        await context.Customers.AddRangeAsync(customers);

        // Vendas
        var sales = Enumerable.Range(1, 30).Select(i =>
        {
            var customer = customers[i % customers.Count];
            var branch = branches[i % branches.Count];
            var product = products[i % products.Count];

            return new Sale
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                BranchId = branch.Id,
                Date = DateTime.UtcNow.AddDays(-i),
                Cancelled = false,
                Items = new List<SaleItem>
                {
                    new SaleItem
                    {
                        ProductId = product.Id,
                        Quantity = i % 5 + 1,
                        UnitPrice = product.Price,
                        Discount = 0.1m
                    }
                }
            };
        }).ToList();
        await context.Sales.AddRangeAsync(sales);

        await context.SaveChangesAsync();
    }
}
