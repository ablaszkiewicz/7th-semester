﻿using System;
namespace proj
{
    public class ItemsOrders
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}

