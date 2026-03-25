using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStore.Domain.Entities
{
    namespace ProjectStore.Domain.Entities
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int QuantityStock { get; set; }
        }
    }
}
