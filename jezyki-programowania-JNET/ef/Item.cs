using System;
using System.Collections.Generic;
using proj;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Count { get; set; }
    public ICollection<ItemsOrders> ItemsOrders { get; set; }
}