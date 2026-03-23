using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStore.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
    }
}
