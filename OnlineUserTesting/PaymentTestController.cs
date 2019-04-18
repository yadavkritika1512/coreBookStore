using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Controllers;
using OnlineBookStoreUser.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlineUserTesting
{
   public class PaymentTestController
    {
        private Book_Store_DbContext context;

        public static DbContextOptions<Book_Store_DbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-509;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static PaymentTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<Book_Store_DbContext>().UseSqlServer(connectionString).Options;
        }
        public PaymentTestController()
        {
            context = new Book_Store_DbContext(dbContextOptions);
        }


        [Fact]
        public void Task_Index_Return_View()
        {

         
                //Arrange
                var controller = new PaymentController(context);

                //Act
                var data = controller.Index();

                //Assert
                Assert.IsType<ViewResult>(data);
            
        }

        [Fact]
        public void Task_Error_Return_OkResult()
        {

           
                //Arrange
                var controller = new PaymentController(context);

                //Act
                var data = controller.Index();

                //Assert
                Assert.IsType<ViewResult>(data);
            
        }
    }
}
