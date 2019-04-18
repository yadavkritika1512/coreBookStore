﻿using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreBookStore.Models
{
    public class BookStoreDbContext : DbContext
    {
        private object b;

        public BookStoreDbContext()
        {
        }
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
           : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<OrderBook> OrderBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=TRD-509;Initial Catalog=Book_Store_Db;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder
                .Entity<Customer>()
                .HasIndex(u => u.UserName)
                .IsUnique();


            modelBuilder.Entity<OrderBook>
                (build =>
                {
                    build.HasKey(b => new { b.OrderId, b.BookId });
                }
                );
            modelBuilder.Entity<Payment>()
        .HasOne(p => p.Order)
        .WithOne(b => b.Payment)
        .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Review>()
        .HasOne(b => b.Book)
        .WithMany(r => r.Review)
        .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
