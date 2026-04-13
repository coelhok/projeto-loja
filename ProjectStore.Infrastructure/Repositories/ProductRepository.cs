using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using ProjectStore.Domain.Entities;
using ProjectStore.Domain.Interfaces;

namespace ProjectStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<Product>("SELECT * FROM Products");
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Product>(
                "SELECT * FROM Products WHERE Id = @Id",
                new { Id = id }
            );
        }

        public async Task CreateAsync(Product product)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync(
                @"INSERT INTO Products (Name, Description, Price, StockQuantity) 
                  VALUES (@Name, @Description, @Price, @StockQuantity)",
                product
            );
        }

        public async Task UpdateAsync(Product product)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync(
                @"UPDATE Products SET 
                    Name = @Name, 
                    Description = @Description, 
                    Price = @Price,
                    StockQuantity = @StockQuantity
                  WHERE Id = @Id",
                product
            );
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync(
                "DELETE FROM Products WHERE Id = @Id",
                new { Id = id }
            );
        }
    }
}