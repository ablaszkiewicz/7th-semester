using System;
using System.Collections.Generic;

namespace proj
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public ICollection<ItemsOrders> ItemsOrders { get; set; }

        public bool Accepted { get; set; }
    }
}