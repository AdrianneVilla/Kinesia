using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KinesiaAPI.Models.Entities;
using KinesiaLibrary.DTOs.UserDTOs;
using KinesiaAPI.Tests.DataTest;
using Xunit;
using KinesiaAPI.Controllers;

namespace KinesiaAPI.Tests.ControllerTests
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task GetUsers_ShouldReturnActiveUsersOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUsers_ShouldReturnActiveUsersOnly));

            var users = DataFactory.GenerateUsers(20);
            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetUsers(currentTab: "Active");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            // Only those with Status == 1 should be counted
            var expectedCount = users.Count(u => u.Status == 1);
            Assert.Equal(expectedCount, returnedUsers.Count());
        }

        [Fact]
        public async Task GetUsers_ShouldReturnInactiveUsersOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUsers_ShouldReturnInactiveUsersOnly));

            var users = DataFactory.GenerateUsers(20);
            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetUsers(currentTab: "Inactive");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            // Only those with Status == 0 should be counted
            var expectedCount = users.Count(u => u.Status == 0);
            Assert.Equal(expectedCount, returnedUsers.Count());
        }
    }
}
