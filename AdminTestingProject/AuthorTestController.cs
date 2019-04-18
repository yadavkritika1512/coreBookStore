using coreBookStore.Controllers;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdminTestingProject
{
    public class AuthorTestController
    {
        private BookStoreDbContext context;

        public static DbContextOptions<BookStoreDbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-509;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static AuthorTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public AuthorTestController()
        {
            context = new BookStoreDbContext();
        }

        [Fact]
        public void Task_Get_All_Author_Return_OkResult()
        {


            //Arrange
            var controller = new AuthorController(context);

            //Act
            var data = controller.Details();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Create_Author_Return_OkResult()
        {


            //Arrange
            var controller = new AuthorController(context);

            //Act
            var data = controller.Details();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Details_Author_Return_OkResult()
        {


            //Arrange
            var controller = new AuthorController(context);

            //Act
            var data = controller.Details();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_DeleteAuthor_Return_View()
        {
            //Arrange
            var controller = new AuthorController(context);
            var id = 1;
            //Act
            var data = controller.Delete(id);

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Edit_Author_Return_View()
        {

            Assert.Throws<NotImplementedException>(() =>
            {
                //Arrange
                var controller = new AuthorController(context);
                int id = 1;


                var auth = new Author()
                {
                    AuthorId = 1,
                    AuthorName = "saraswati",
                    AuthorDescription = "description",
                    AuthorImage = "image",
                   
                };

                //Act

                var EditData = controller.Edit(id, auth);

                //Assert
                Assert.IsType<ViewResult>(EditData);
            });
        }

    }
}
