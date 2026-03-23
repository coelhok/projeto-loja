using System;
using System.Collections.Generic;
using System.Text;

using ProjectStore.Domain.Entities;

namespace ProjectStore.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int pedidoId);
        Task CreateAsync(OrderItem item);
        Task DeleteByPedidoIdAsync(int pedidoId);
    }
}
