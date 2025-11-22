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
        public async Task GetUsers_ShouldReturnUsersSortedByName()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUsers_ShouldReturnUsersSortedByName));

            var users = new List<Users>
            {
                DataFactory.GenerateUsers(1).First(u => { u.FirstName = "Charlie"; u.UserID = "U1"; return true; }),
                DataFactory.GenerateUsers(1).First(u => { u.FirstName = "Alice"; u.UserID = "U2"; return true; }),
                DataFactory.GenerateUsers(1).First(u => { u.FirstName = "Bob"; u.UserID = "U3"; return true; })
            };

            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetUsers(sortColumn: "Alphabetic (Name)");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<DisplayUsersDTO>>(okResult.Value);

            var userList = returnedUsers.ToList();

            Assert.Equal(3, userList.Count());
            Assert.Equal("Alice", userList[0].UserName.Split(' ')[0]);
            Assert.Equal("Bob", userList[1].UserName.Split(' ')[0]);
            Assert.Equal("Charlie", userList[2].UserName.Split(' ')[0]);
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

        [Fact]
        public async Task GetUsers_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUsers_WithInvalidId_ShouldReturnNotFound));

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetUsers("USER999");

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task UpdateUserStatus_WhenUserExists_ShouldReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdateUserStatus_WhenUserExists_ShouldReturnNoContent));

            var users = DataFactory.GenerateUsers(1).First();
            users.UserID = "USER123";
            users.Status = 1;

            context.Users.Add(users);
            await context.SaveChangesAsync();

            var updatedUser = new UserUpdateStatusDTO
            {
                UserID = "USER123",
                Status = 0
            };

            var controller = new UsersController(context);

            // Act
            var result = await controller.UpdateUserStatus("USER123", updatedUser);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var userInDb = await context.Users.FindAsync("USER123");

            Assert.NotNull(userInDb);
            Assert.Equal(0, userInDb.Status);
            Assert.NotNull(userInDb.LastArchiveDate);
        }

        [Fact]
        public async Task UpdateUserStatus_WhenUserDoesNotExists_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdateUserStatus_WhenUserDoesNotExists_ShouldReturnNotFound));

            var updatedUser = new UserUpdateStatusDTO
            {
                UserID = "USER123",
                Status = 1
            };

            var controller = new UsersController(context);

            // Act
            var result = await controller.UpdateUserStatus("USER123", updatedUser);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutUsers_WhenUserExistsAndIdsMatch_ShouldReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(PutUsers_WhenUserExistsAndIdsMatch_ShouldReturnNoContent));

            var originalUser = DataFactory.GenerateUsers(1).First();
            originalUser.UserID = "USER123";
            originalUser.FirstName = "Test";
            originalUser.Contact = "+639285321382";

            context.Users.Add(originalUser);
            await context.SaveChangesAsync();

            var updatedUser = new UpdateUserDTO
            {
                UserID = "USER123",
                FirstName = "Test123",
                Contact = null
            };

            var controller = new UsersController(context);

            // Act
            var result = await controller.PutUsers("USER123", updatedUser);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var userInDb = await context.Users.FindAsync("USER123");

            Assert.NotNull(userInDb);
            Assert.Equal("Test123", userInDb.FirstName);
            Assert.Equal("+639285321382", userInDb.Contact);
        }

        [Fact]
        public async Task PutPatients_WhenIdsMismatch_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(PutPatients_WhenIdsMismatch_ShouldReturnBadRequest));

            var updatedUser = new UpdateUserDTO
            {
                UserID = "USER123"
            };

            var controller = new UsersController(context);

            // Act
            var result = await controller.PutUsers("USER456", updatedUser);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult);
        }

        [Fact]
        public async Task CheckExistingUser_WhenUserDoesNotExists_ShouldReturnOkResult()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(CheckExistingUser_WhenUserDoesNotExists_ShouldReturnOkResult));

            var nonExistingUser = new CheckExistingUserDTO
            {
                FirstName = "Sample",
                LastName = "Sample",
                MiddleName = "Sample"
            };

            var controller = new UsersController(context);

            // Act
            var result = await controller.CheckExistingUser(nonExistingUser);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task CheckExistingUser_WhenUserExists_ShouldReturnConflict()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(CheckExistingUser_WhenUserExists_ShouldReturnConflict));

            var user = DataFactory.GenerateUsers(1).First();
            user.FirstName = "Exists";
            user.LastName = "Exists";
            user.MiddleName = "Exists";

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var existingUser = new CheckExistingUserDTO
            {
                FirstName = "Exists",
                LastName = "Exists",
                MiddleName = "Exists"
            };

            var controller = new UsersController(context);

            // Act
            var result = await controller.CheckExistingUser(existingUser);

            // Assert
            Assert.IsType<ConflictResult>(result);
        }

        [Fact]
        public async Task DeleteUsers_WhenUserExists_ShouldReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DeleteUsers_WhenUserExists_ShouldReturnNoContent));

            var user = DataFactory.GenerateUsers(1).First();
            user.UserID = "USER123";

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.DeleteUsers("USER123");

            // Assert
            Assert.IsType<NoContentResult>(result);

            var patientInDb = await context.Users.FindAsync("USER123");
            Assert.Null(patientInDb);
        }
    }
}
