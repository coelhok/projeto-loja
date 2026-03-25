
namespace ProjectStore.Domain.Entities
{    

    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal ValueTotal { get; set; }
        public string Status { get; set; }
    }
}
