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
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [Fact]
        public async Task GetUsers_ShouldReturnAllUsersWhenTabIsInvalid()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUsers_ShouldReturnAllUsersWhenTabIsInvalid));

            var users = DataFactory.GenerateUsers(20);
            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var resultNullTab = await controller.GetUsers(currentTab: null);
            var resultOtherTab = await controller.GetUsers(currentTab: "All");

            // Assert
            var okResultNull = Assert.IsType<OkObjectResult>(resultNullTab.Result);
            var returnedUsersNull = Assert.IsAssignableFrom<IEnumerable<DisplayUsersDTO>>(okResultNull.Value);
            Assert.Equal(20, returnedUsersNull.Count());

            var okResultOther = Assert.IsType<OkObjectResult>(resultOtherTab.Result);
            var returnedUsersOther = Assert.IsAssignableFrom<IEnumerable<DisplayUsersDTO>>(okResultOther.Value);
            Assert.Equal(20, returnedUsersOther.Count());
        }

        [Fact]
        public async Task GetUsers_ShouldReturnSearchedUser()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUsers_ShouldReturnSearchedUser));
            
            var users = DataFactory.GenerateUsers(20);
            users.First().FirstName = "Search";

            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetUsers(searchData: "Search");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUser = Assert.IsAssignableFrom<IEnumerable<DisplayUsersDTO>>(okResult.Value);
            Assert.Single(returnedUser);
            Assert.Contains("Search", returnedUser.First().UserName);
        }

        [Fact]
        public async Task GetUsers_WithValidId_ShouldReturnUserDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUsers_WithValidId_ShouldReturnUserDTO));

            var users = DataFactory.GenerateUsers(20);
            var targetUser = users.First();

            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetUsers(targetUser.UserID);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUser = Assert.IsType<UsersDTO>(okResult.Value);

            Assert.Equal(targetUser.UserID, returnedUser.UserID);
            Assert.Equal(targetUser.FirstName, returnedUser.FirstName);
        }
    }
}
