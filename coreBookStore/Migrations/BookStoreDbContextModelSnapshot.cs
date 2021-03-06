﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using coreBookStore.Models;

namespace coreBookStore.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    partial class BookStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("coreBookStore.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorDescription")
                        .IsRequired();

                    b.Property<string>("AuthorImage")
                        .IsRequired();

                    b.Property<string>("AuthorName")
                        .IsRequired();

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("coreBookStore.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<int>("BookCategoryId");

                    b.Property<string>("BookDescription");

                    b.Property<string>("BookImage");

                    b.Property<string>("BookName");

                    b.Property<string>("BookPdf");

                    b.Property<float>("BookPrice");

                    b.Property<string>("BookType");

                    b.Property<int>("PublicationId");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookCategoryId");

                    b.HasIndex("PublicationId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("coreBookStore.Models.BookCategory", b =>
                {
                    b.Property<int>("BookCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookCategoryDescription")
                        .IsRequired();

                    b.Property<string>("BookCategoryImage")
                        .IsRequired();

                    b.Property<string>("BookCategoryName")
                        .IsRequired();

                    b.HasKey("BookCategoryId");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("coreBookStore.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<bool>("BillingAddress");

                    b.Property<string>("City");

                    b.Property<long>("Contact");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("NewPassword");

                    b.Property<string>("OldPassword");

                    b.Property<bool>("PaymentType");

                    b.Property<bool>("SaveInformation");

                    b.Property<bool>("ShippingAddress");

                    b.Property<string>("UserName");

                    b.Property<long>("ZipCode");

                    b.HasKey("CustomerId");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("coreBookStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<float>("OrderAmount");

                    b.Property<DateTime>("OrderDate");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("coreBookStore.Models.OrderBook", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("BookId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "BookId");

                    b.HasAlternateKey("BookId", "OrderId");

                    b.ToTable("OrderBooks");
                });

            modelBuilder.Entity("coreBookStore.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CardLastDigit");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("DateOfPayment");

                    b.Property<int>("OrderId");

                    b.Property<float>("PaymentAmount");

                    b.Property<string>("PaymentDescription");

                    b.Property<string>("StripePaymentId");

                    b.HasKey("PaymentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("coreBookStore.Models.Publication", b =>
                {
                    b.Property<int>("PublicationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PublicationDescription")
                        .IsRequired();

                    b.Property<string>("PublicationImage")
                        .IsRequired();

                    b.Property<string>("PublicationName")
                        .IsRequired();

                    b.HasKey("PublicationId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("coreBookStore.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("ReviewMessage");

                    b.Property<string>("ReviewSubject");

                    b.HasKey("ReviewId");

                    b.HasIndex("BookId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("coreBookStore.Models.Book", b =>
                {
                    b.HasOne("coreBookStore.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreBookStore.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("BookCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreBookStore.Models.Publication", "Publication")
                        .WithMany("Books")
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreBookStore.Models.Order", b =>
                {
                    b.HasOne("coreBookStore.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreBookStore.Models.OrderBook", b =>
                {
                    b.HasOne("coreBookStore.Models.Book", "Book")
                        .WithMany("OrderBook")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreBookStore.Models.Order", "Order")
                        .WithMany("OrderBook")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreBookStore.Models.Payment", b =>
                {
                    b.HasOne("coreBookStore.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("coreBookStore.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("coreBookStore.Models.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreBookStore.Models.Review", b =>
                {
                    b.HasOne("coreBookStore.Models.Book", "Book")
                        .WithMany("Review")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreBookStore.Models.Customer", "Customer")
                        .WithMany("Review")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
