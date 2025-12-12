using KinesiaAPI.Controllers;
using KinesiaAPI.Models.Entities;
using KinesiaAPI.Tests.DataTest;
using KinesiaLibrary;
using KinesiaLibrary.DTOs.LogDTOs;
using KinesiaLibrary.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KinesiaAPI.Tests.ControllerTests
{
    public class LogsControllerTests
    {
        [Fact]
        public async Task GetLogs_ShouldReturnSessionsOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetLogs_ShouldReturnSessionsOnly));
            var users = DataFactory.GenerateUsers(20);
            var logs = DataFactory.GenerateLogs(50, users);

            context.Users.AddRange(users);
            context.Logs.AddRange(logs);

            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetLogs(currentTab: "Sessions");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = logs.Count(l => l.LogType == "Sessions");
            Assert.Equal(expectedCount, returnedLogs.Count());
        }

        [Fact]
        public async Task GetLogs_ShouldReturnPatientOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetLogs_ShouldReturnPatientOnly));
            var users = DataFactory.GenerateUsers(20);
            var logs = DataFactory.GenerateLogs(50, users);

            context.Users.AddRange(users);
            context.Logs.AddRange(logs);

            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetLogs(currentTab: "Patient");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = logs.Count(l => l.LogType == "Patient");
            Assert.Equal(expectedCount, returnedLogs.Count());
        }

        [Fact]
        public async Task GetLogs_ShouldReturnUserOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetLogs_ShouldReturnUserOnly));
            var users = DataFactory.GenerateUsers(20);
            var logs = DataFactory.GenerateLogs(50, users);

            context.Users.AddRange(users);
            context.Logs.AddRange(logs);

            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetLogs(currentTab: "User");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = logs.Count(l => l.LogType == "User");
            Assert.Equal(expectedCount, returnedLogs.Count());
        }

        [Fact]
        public async Task GetLogs_ShouldReturnAssessmentOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetLogs_ShouldReturnAssessmentOnly));
            var users = DataFactory.GenerateUsers(20);
            var logs = DataFactory.GenerateLogs(50, users);

            context.Users.AddRange(users);
            context.Logs.AddRange(logs);

            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetLogs(currentTab: "Assessment");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = logs.Count(l => l.LogType == "Assessment");
            Assert.Equal(expectedCount, returnedLogs.Count());
        }

        [Fact]
        public async Task GetLogs_ShouldReturnROMOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetLogs_ShouldReturnROMOnly));
            var users = DataFactory.GenerateUsers(20);
            var logs = DataFactory.GenerateLogs(50, users);

            context.Users.AddRange(users);
            context.Logs.AddRange(logs);

            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetLogs(currentTab: "ROM");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = logs.Count(l => l.LogType == "ROM");
            Assert.Equal(expectedCount, returnedLogs.Count());
        }

        [Fact]
        public async Task GetLogs_ShouldReturnAllLogs()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetLogs_ShouldReturnAllLogs));
            var users = DataFactory.GenerateUsers(20);
            var logs = DataFactory.GenerateLogs(50, users);

            context.Users.AddRange(users);
            context.Logs.AddRange(logs);

            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetLogs(currentTab: "All");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            Assert.Equal(50, returnedLogs.Count());
        }

        [Fact]
        public async Task GetLogs_ShouldReturnAllLogsWhenCurrentTabIsNull()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetLogs_ShouldReturnAllLogsWhenCurrentTabIsNull));
            var users = DataFactory.GenerateUsers(20);
            var logs = DataFactory.GenerateLogs(50, users);

            context.Users.AddRange(users);
            context.Logs.AddRange(logs);

            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetLogs(currentTab: null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            Assert.Equal(50, returnedLogs.Count());
        }

        [Fact]
        public async Task GetLogs_ShouldReturnSearchedLog()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetLogs_ShouldReturnSearchedLog));
            var user = DataFactory.GenerateUsers(1);
            var log = DataFactory.GenerateLogs(1, user).First();

            log.LogID = "LOG123";

            context.Users.AddRange(user);
            context.Logs.AddRange(log);

            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetLogs(searchData: "LOG123");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLog = Assert.IsAssignableFrom<IEnumerable<LogDTO>>(okResult.Value);

            Assert.Single(returnedLog);
            Assert.Equal("LOG123", returnedLog.First().LogID);
        }
    }
}
