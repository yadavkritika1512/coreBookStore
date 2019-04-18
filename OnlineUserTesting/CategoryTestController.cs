using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Controllers;
using OnlineBookStoreUser.Models;
using System;
using Xunit;

namespace OnlineBookStoreUserTesting
{
    public class CategoryTestController
    {

        private Book_Store_DbContext context;

        public static DbContextOptions<Book_Store_DbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-509;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static CategoryTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<Book_Store_DbContext>().UseSqlServer(connectionString).Options;
        }
        public CategoryTestController()
        {
            context = new Book_Store_DbContext(dbContextOptions);
        }


        [Fact]
        public void Task_Get_All_Category_Return_OkResult()
        {


            //Arrange
            var controller = new BookCategoryController(context);

            //Act
            var data = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(data);

        }


        [Fact]
        public void Task_GetBookById_Return_OkResult()
        {
            var controller = new BookCategoryController(context);
            var BookId = 8;
            var data = controller.Display(BookId);
            Assert.IsType<ViewResult>(data);
        }

    }
}
