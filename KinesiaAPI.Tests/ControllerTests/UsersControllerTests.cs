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
using KinesiaLibrary;
using KinesiaLibrary.DTOs.ReportDTOs;

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
        public async Task GetUserToEdit_WithValidId_ShouldReturnUserToEditDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUserToEdit_WithValidId_ShouldReturnUserToEditDTO));
            var user = DataFactory.GenerateUsers(1);
            user.First().UserID = "USER123";

            context.Users.AddRange(user);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetUserToEdit("USER123");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUser = Assert.IsAssignableFrom<UserToEditDTO>(okResult.Value);

            Assert.Equal("USER123", returnedUser.UserID);
        }

        [Fact]
        public async Task GetUserToEdit_WhenIdIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUserToEdit_WhenIdIsNull_ShouldReturnBadRequest));

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetUserToEdit("");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetUserToEdit_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetUserToEdit_WithInvalidId_ShouldReturnNotFound));

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetUserToEdit("USER456");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetTotalUsersByStatus_ShouldOnlyReturnActiveUsersCount()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetTotalUsersByStatus_ShouldOnlyReturnActiveUsersCount));
            var users = DataFactory.GenerateUsers(50);

            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetTotalUsersByStatus(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsType<int>(okResult.Value);

            var activeUsersCount = users.Count(u => u.Status == 1);
            Assert.Equal(activeUsersCount, returnedUsers);
        }

        [Fact]
        public async Task GetTotalUsersByStatus_ShouldOnlyReturnInactiveUsersCount()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetTotalUsersByStatus_ShouldOnlyReturnInactiveUsersCount));
            var users = DataFactory.GenerateUsers(50);

            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GetTotalUsersByStatus(0);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsType<int>(okResult.Value);

            var inactiveUsersCount = users.Count(u => u.Status == 0);
            Assert.Equal(inactiveUsersCount, returnedUsers);
        }

        [Fact]
        public async Task GenerateTodayReport_ShouldReturnUsersReportDTOAndTodayUsersOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateTodayReport_ShouldReturnUsersReportDTOAndTodayUsersOnly));
            var todayUsers = DataFactory.GenerateUsers(50);
            todayUsers.ForEach(users => users.DateAdded = DateTime.Today);
            context.Users.AddRange(todayUsers);

            var pastUsers = DataFactory.GenerateUsers(50);
            pastUsers.ForEach(users => { users.UserID += 100; users.DateAdded = DateTime.Today.AddDays(-1); });
            context.Users.AddRange(pastUsers);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GenerateTodayReport();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<UsersReportDTO>>(okResult.Value);

            var todayUsersCount = todayUsers.Count();
            Assert.Equal(todayUsersCount, returnedUsers.Count());
        }

        [Fact]
        public async Task GenerateWeeklyReport_ShouldReturnUsersReportDTOAndWeekUsersOnly()
        {
            // Assert
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateWeeklyReport_ShouldReturnUsersReportDTOAndWeekUsersOnly));
            var thisWeekUsers = DataFactory.GenerateUsers(50);
            thisWeekUsers.ForEach(users => users.DateAdded = DateTime.Today);
            context.Users.AddRange(thisWeekUsers);

            var pastUsers = DataFactory.GenerateUsers(50);
            pastUsers.ForEach(users => { users.UserID += 100; users.DateAdded = DateTime.Today.AddDays(-9); });
            context.Users.AddRange(pastUsers);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GenerateWeeklyReport(DateTime.Today.AddDays(-7), DateTime.Today.AddDays(2));

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<UsersReportDTO>>(okResult.Value);

            var thisWeekUsersCount = thisWeekUsers.Count();
            Assert.Equal(thisWeekUsersCount, returnedUsers.Count());
        }

        [Fact]
        public async Task GenerateMonthlyReport_ShouldReturnUsersReportDTOAndMonthUsersOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateMonthlyReport_ShouldReturnUsersReportDTOAndMonthUsersOnly));
            var thisMonthUsers = DataFactory.GenerateUsers(50);
            thisMonthUsers.ForEach(users => users.DateAdded = DateTime.Today);
            context.Users.AddRange(thisMonthUsers);

            var pastUsers = DataFactory.GenerateUsers(50);
            pastUsers.ForEach(users => { users.UserID += 100; users.DateAdded = DateTime.Today.AddMonths(-1); });
            context.Users.AddRange(pastUsers);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GenerateMonthlyReport(DateTime.Today.Month, DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<UsersReportDTO>>(okResult.Value);

            var thisMonthUsersCount = thisMonthUsers.Count();
            Assert.Equal(thisMonthUsersCount, returnedUsers.Count());
        }

        [Fact]
        public async Task GenerateYearlyReport_ShouldReturnUsersReportDTOAndYearUsersOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateYearlyReport_ShouldReturnUsersReportDTOAndYearUsersOnly));
            var thisYearUsers = DataFactory.GenerateUsers(50);
            thisYearUsers.ForEach(users => users.DateAdded = DateTime.Today);
            context.Users.AddRange(thisYearUsers);

            var pastUsers = DataFactory.GenerateUsers(50);
            pastUsers.ForEach(users => { users.UserID += 100; users.DateAdded = DateTime.Today.AddYears(-1); });
            context.Users.AddRange(pastUsers);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.GenerateYearlyReport(DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<UsersReportDTO>>(okResult.Value);

            var thisYearUsersCount = thisYearUsers.Count();
            Assert.Equal(thisYearUsersCount, returnedUsers.Count());
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

        [Fact]
        public async Task DeleteUsers_WhenUserDoesNotExists_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DeleteUsers_WhenUserDoesNotExists_ShouldReturnNotFound));

            var controller = new UsersController(context);

            // Act
            var result = await controller.DeleteUsers("USER123");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task ChangePassword_WhenUserExistsAndOldPasswordMatch_ShouldReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(ChangePassword_WhenUserExistsAndOldPasswordMatch_ShouldReturnNoContent));

            var user = DataFactory.GenerateUsers(1).First();
            user.UserID = "USER123";
            var salt = CustomSecurity.GenerateSalt();
            user.Salt = salt;
            user.Password = CustomSecurity.HashPassword("Password", salt);

            context.Add(user);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.ChangePassword("USER123", "NewPassword", "Password");

            // Assert
            Assert.IsType<NoContentResult>(result);

            var userInDb = await context.Users.FindAsync("USER123");

            Assert.Equal(userInDb.Password, CustomSecurity.HashPassword("NewPassword", userInDb.Salt));
        }

        [Fact]
        public async Task ChangePassword_WhenUserDoesNotExists_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(ChangePassword_WhenUserDoesNotExists_ShouldReturnNotFound));

            var controller = new UsersController(context);

            // Act
            var result = await controller.ChangePassword("USER123", "NewPassword", "Password");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task ChangePassword_WhenIdIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(ChangePassword_WhenIdIsNull_ShouldReturnBadRequest));

            var controller = new UsersController(context);

            // Act
            var result = await controller.ChangePassword("", "NewPassword", "Password");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task ChangePassword_WhenUserExistsAndOldPasswordMismatch_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(ChangePassword_WhenUserExistsAndOldPasswordMismatch_ShouldReturnBadRequest));

            var user = DataFactory.GenerateUsers(1).First();
            user.UserID = "USER123";
            var salt = CustomSecurity.GenerateSalt();
            user.Salt = salt;
            user.Password = CustomSecurity.HashPassword("Password", salt);

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.ChangePassword("USER123", "NewPassword", "Passwurd");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task ResetPassword_WhenUserExists_ShouldReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(ResetPassword_WhenUserExists_ShouldReturnNoContent));

            var user = DataFactory.GenerateUsers(1).First();
            user.UserID = "USER123";
            user.Username = "USER";
            user.Birthdate = DateTime.Now;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = controller.ResetPassword("USER123");

            // Assert
            Assert.IsType<NoContentResult>(result.Result);

            var userInDb = await context.Users.FindAsync("USER123");

            Assert.Equal(userInDb.Password, CustomSecurity.HashPassword($"USER.{DateTime.Now.ToString("yyyyMMdd")}", userInDb.Salt));
        }

        [Fact]
        public async Task ResetPassword_WhenUserDoesNotExists_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(ResetPassword_WhenUserDoesNotExists_ShouldReturnNotFound));

            var controller = new UsersController(context);

            // Act
            var result = await controller.ResetPassword("USER123");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task ResetPassword_WhenIdIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(ResetPassword_WhenIdIsNull_ShouldReturnBadRequest));

            var controller = new UsersController(context);

            // Act
            var result = await controller.ResetPassword("");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CheckExistingAccount_WhenAccountDoesNotExistsAndUsernameIsValid_ShouldReturnOkResult()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(CheckExistingAccount_WhenAccountDoesNotExistsAndUsernameIsValid_ShouldReturnOkResult));

            var controller = new UsersController(context);

            // Act
            var result = await controller.CheckExistingAccount("USER123");

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task CheckExistingAccount_WhenAccountExistsAndUsernameIsValid_ShouldReturnConflictResult()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(CheckExistingAccount_WhenAccountExistsAndUsernameIsValid_ShouldReturnConflictResult));
            var user = DataFactory.GenerateUsers(1);
            user.First().Username = "USER123";

            context.Users.AddRange(user);
            await context.SaveChangesAsync();

            var controller = new UsersController(context);

            // Act
            var result = await controller.CheckExistingAccount("USER123");

            // Assert
            Assert.IsType<ConflictResult>(result);
        }

        [Fact]
        public async Task CheckExistingAccount_WhenUsernameIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(CheckExistingAccount_WhenUsernameIsNull_ShouldReturnBadRequest));

            var controller = new UsersController(context);

            // Act
            var result = await controller.CheckExistingAccount("");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UsersToDTO_ShouldReturnUsersDTO()
        {
            // Arrange
            var user = DataFactory.GenerateUsers(1).First();

            // Act
            var result = UsersController.UsersToDTO(user);

            // Assert
            Assert.IsType<UsersDTO>(result);
            Assert.Equal(user.UserID, result.UserID);
            Assert.Equal(user.FirstName, result.FirstName);
            Assert.Equal(user.LastName, result.LastName);
            Assert.Equal(user.MiddleName, result.MiddleName);
            Assert.Equal(user.Birthdate, result.Birthdate);
            Assert.Equal((int)((DateTime.Now - user.Birthdate).TotalDays / 365.25), result.Age);
            Assert.Equal(user.Gender, result.Gender);
            Assert.Equal(user.Contact, result.Contact);
            Assert.Equal(user.Address, result.Address);
            Assert.Equal(user.Role, result.Role);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.Username, result.Username);
            Assert.Equal(user.DateAdded, result.DateAdded);
            Assert.Equal(user.Status, result.Status);
        }

        [Fact]
        public void UsersToDisplayUsersDTO_ShouldReturnDisplayUsersDTO()
        {
            // Arrange
            var user = DataFactory.GenerateUsers(1).First();

            // Act
            var result = UsersController.UsersToDisplayUsersDTO(user);

            // Assert
            Assert.IsType<DisplayUsersDTO>(result);
            Assert.Equal(user.UserID, result.UserID);
            Assert.Equal($"{user.FirstName} {user.MiddleName} {user.LastName}", result.UserName);
            Assert.Equal(user.Role, result.Role);
        }

        [Fact]
        public void UsersToUsersReportDTO_ShouldReturnUsersReportDTO()
        {
            // Arrange
            var user = DataFactory.GenerateUsers(1).First();

            // Act
            var result = UsersController.UsersToUsersReportDTO(user);

            // Assert
            Assert.IsType<UsersReportDTO>(result);
            Assert.Equal(user.UserID, result.UserID);
            Assert.Equal($"{user.FirstName} {user.MiddleName} {user.LastName}", result.Name);
            Assert.Equal(user.Contact, result.Contact);
            Assert.Equal(user.Role, result.Role);
            Assert.Equal(user.DateAdded.ToString("yyyy-MM-dd"), result.DateAdded);
        }

        [Fact]
        public void UserToUserEditDTO_ShouldReturnUserToEditDTO()
        {
            // Arrange
            var user = DataFactory.GenerateUsers(1).First();

            // Act
            var result = UsersController.UserToUserEditDTO(user);

            // Assert
            Assert.IsType<UserToEditDTO>(result);
            Assert.Equal(user.UserID, result.UserID);
            Assert.Equal(user.FirstName, result.FirstName);
            Assert.Equal(user.LastName, result.LastName);
            Assert.Equal(user.MiddleName, result.MiddleName);
            Assert.Equal(user.Birthdate, result.Birthdate);
            Assert.Equal(user.Gender, result.Gender);
            Assert.Equal(user.Contact, result.Contact);
            Assert.Equal(user.Address, result.Address);
            Assert.Equal(user.Role, result.Role);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.Username, result.Username);
        }
    }
}
