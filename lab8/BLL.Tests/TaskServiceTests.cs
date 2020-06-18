using Catalog.BLL.Services.Impl;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.EF;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using Catalog.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using OSBB.Security;
using OSBB.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class TaskServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new TaskService(nullUnitOfWork));
        }

        [Fact]
        public void GetProducts_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            Client user = new CEO(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            ITaskService productService = new TaskService(mockUnitOfWork.Object);

            // Act
            // Assert
            //Assert.Throws<MethodAccessException>(() => productService.GetTasks(0));
        }

        [Fact]
        public void GetProducts_ProductFromDAL_CorrectMappingToProductDTO()
        {
            // Arrange
            Client user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var productService = GetTasks();

            // Act
            var actualproductDto = productService.GetTasks(0).First();

            // Assert
            Assert.True(
                actualproductDto.TaskID == 1
                && actualproductDto.Name == "testN"
                && actualproductDto.Description == "testD"
                );
        }

        ITaskService GetTasks()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedProduct = new Task() { TaskID = 1, Name = "testN", Description = "testD", CatalogID = 2};
            var mockDbSet = new Mock<TaskRepository>();
            mockDbSet.Setup(z => 
                z.Find(
                    It.IsAny<Func<Task, bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                  .Returns(
                    new List<Task>() { expectedProduct }
                    );
            mockContext
                .Setup(context =>
                    context.Tasks)
                .Returns(mockDbSet.Object);

            ITaskService productService = new TaskService(mockContext.Object);

            return productService;
        }
    }
}
