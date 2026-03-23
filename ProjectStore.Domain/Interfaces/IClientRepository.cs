using ProjectStore.Domain.Entities;
using ProjectStore.Domain.Entities.ProjectStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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