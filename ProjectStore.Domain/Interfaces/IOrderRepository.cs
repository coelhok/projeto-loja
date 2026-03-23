using System;
using System.Collections.Generic;
using System.Text;

using ProjectStore.Domain.Entities;

namespace ProjectStore.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task CreateAsync(Order Order);
        Task UpdateAsync(Order Order);
        Task DeleteAsync(int id);
    }
}