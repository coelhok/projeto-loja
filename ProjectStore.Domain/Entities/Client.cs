using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStore.Domain.Entities
{
    namespace ProjectStore.Domain.Entities
    {
        public class Client
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public DateTime DataCadastro { get; set; }
        }
    }
}
