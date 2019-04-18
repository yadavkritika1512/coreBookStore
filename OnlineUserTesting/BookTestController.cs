using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Controllers;
using OnlineBookStoreUser.Models;
using System;
using Xunit;

namespace OnlineUserTesting
{
   public class BookTestController
    {

        private Book_Store_DbContext context;

        public static DbContextOptions<Book_Store_DbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-509;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static BookTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<Book_Store_DbContext>().UseSqlServer(connectionString).Options;
        }
        public BookTestController()
        {
            context = new Book_Store_DbContext(dbContextOptions);
        }


        [Fact]
        public void Task_Get_All_Book_Return_OkResult()
        {


            //Arrange
            var controller = new BookController(context);

            //Act
            var data = controller.BookCategoryIndex();

            //Assert
            Assert.IsType<ViewResult>(data);

        }


        [Fact]
        public void Task_GetBookById_Return_OkResult()
        {
            var controller = new BookController(context);
            var BookId = 1;
            var data = controller.Display(BookId);
            Assert.IsType<ViewResult>(data);
        }

    }
}
