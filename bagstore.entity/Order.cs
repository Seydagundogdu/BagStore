using System.Collections.Generic;

namespace bagstore.entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note{ get; set; }

        public EnumOrderState OrderState { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }

    public enum EnumOrderState //sparişin durumu
    {
        waiting=0,
        unpaid=1,
        completed=2
    }
}