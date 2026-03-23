using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using ProjectStore.Domain.Entities;
using ProjectStore.Domain.Interfaces;

namespace ProjectStore.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<Client>("SELECT * FROM Clients");
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Client>(
                "SELECT * FROM Clients WHERE Id = @Id",
                new { Id = id }
            );
        }

        public async Task CreateAsync(Client client)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync(
                @"INSERT INTO Clients (Name, Email, Phone, RegistrationDate) 
                  VALUES (@Name, @Email, @Phone, @RegistrationDate)",
                client
            );
        }

        public async Task UpdateAsync(Client client)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync(
                @"UPDATE Clients SET 
                    Name = @Name, 
                    Email = @Email, 
                    Phone = @Phone 
                  WHERE Id = @Id",
                client
            );
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync(
                "DELETE FROM Clients WHERE Id = @Id",
                new { Id = id }
            );
        }
    }
}