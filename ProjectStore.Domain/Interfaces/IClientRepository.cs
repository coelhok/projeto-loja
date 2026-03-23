using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStore.Domain.Entities;

namespace ProjectStore.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task CreateAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
}