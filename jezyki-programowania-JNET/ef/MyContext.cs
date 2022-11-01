 
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using proj;
using Unix.Terminal;

public class MyContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ItemsOrders> ItemsOrders { get; set; }

    public string DbPath { get; }

    public MyContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemsOrders>()
            .HasKey(x => new { x.OrderId, x.ItemId });

        //modelBuilder.Entity<ItemsOrders>()
        //    .HasOne(itemsOrders => itemsOrders.Order)
        //    .WithMany(order => order.ItemsOrders)
        //    .HasForeignKey(itemsOrders => itemsOrders.OrderId);

        //modelBuilder.Entity<ItemsOrders>()
        //   .HasOne(itemsOrders => itemsOrders.Item)
        //   .WithMany(item => item.ItemsOrders)
        //   .HasForeignKey(itemsOrders => itemsOrders.ItemId);
    }
}
