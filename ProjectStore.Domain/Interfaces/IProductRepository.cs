using ProjectStore.Domain.Entities;
using ProjectStore.Domain.Entities.ProjectStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStore.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task CreateAsync(Product produto);
        Task UpdateAsync(Product produto);
        Task DeleteAsync(int id);
    }
}