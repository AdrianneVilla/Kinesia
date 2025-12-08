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
    }
}
