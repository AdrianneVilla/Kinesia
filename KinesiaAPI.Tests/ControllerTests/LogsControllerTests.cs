using KinesiaAPI.Controllers;
using KinesiaAPI.Models.Entities;
using KinesiaAPI.Tests.DataTest;
using KinesiaLibrary;
using KinesiaLibrary.DTOs.LogDTOs;
using KinesiaLibrary.DTOs.ReportDTOs;
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

        [Fact]
        public async Task GetDashboardLogs_WhenLogsIsNotEmpty_ShouldReturnDisplayDashboardLogsDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetDashboardLogs_WhenLogsIsNotEmpty_ShouldReturnDisplayDashboardLogsDTO));
            var users = DataFactory.GenerateUsers(20);
            var logs = DataFactory.GenerateLogs(50, users);

            context.Users.AddRange(users);
            context.Logs.AddRange(logs);
            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetDashboardLogs();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<DisplayDashboardLogsDTO>>(okResult.Value);
        }

        [Fact]
        public async Task GetDashboardLogs_WhenLogsIsEmpty_ShouldReturnDisplayDashboardLogsDTOAndIsEmpty()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetDashboardLogs_WhenLogsIsEmpty_ShouldReturnDisplayDashboardLogsDTOAndIsEmpty));

            var controller = new LogsController(context);

            // Act
            var result = await controller.GetDashboardLogs();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<DisplayDashboardLogsDTO>>(okResult.Value);

            Assert.Empty(returnedLogs);
        }

        [Fact]
        public async Task GenerateTodayReport_ShouldReturnLogReportDTOAndTodayLogsOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateTodayReport_ShouldReturnLogReportDTOAndTodayLogsOnly));
            var users = DataFactory.GenerateUsers(20);
            context.Users.AddRange(users);

            var todayLogs = DataFactory.GenerateLogs(50, users);
            todayLogs.ForEach(logs => logs.LogDate = DateTime.Today);
            context.Logs.AddRange(todayLogs);

            var pastLogs = DataFactory.GenerateLogs(50, users);
            pastLogs.ForEach(logs => { logs.LogID += 100; logs.LogDate = DateTime.Today.AddDays(-1); });
            context.Logs.AddRange(pastLogs);
            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GenerateTodayReport();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<LogReportDTO>>(okResult.Value);

            var todayLogsCount = todayLogs.Count();
            Assert.Equal(todayLogsCount, returnedLogs.Count());
        }

        [Fact]
        public async Task GenerateWeeklyReport_ShouldReturnLogReportDTOAndWeekLogsOnly()
        {
            // Arrange 
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateWeeklyReport_ShouldReturnLogReportDTOAndWeekLogsOnly));
            var users = DataFactory.GenerateUsers(20);
            context.Users.AddRange(users);

            var thisWeekLogs = DataFactory.GenerateLogs(50, users);
            thisWeekLogs.ForEach(logs => logs.LogDate = DateTime.Today);
            context.Logs.AddRange(thisWeekLogs);

            var pastLogs = DataFactory.GenerateLogs(50, users);
            pastLogs.ForEach(logs => { logs.LogID += 100; logs.LogDate = DateTime.Today.AddDays(-9); });
            context.Logs.AddRange(pastLogs);
            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GenerateWeeklyReport(DateTime.Today.AddDays(-8), DateTime.Today.AddDays(+2));

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<LogReportDTO>>(okResult.Value);

            var thisWeekLogsCount = thisWeekLogs.Count();
            Assert.Equal(thisWeekLogsCount, returnedLogs.Count());
        }

        [Fact]
        public async Task GenerateMonthlyReport_ShouldReturnLogReportDTOAndMonthLogsOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateMonthlyReport_ShouldReturnLogReportDTOAndMonthLogsOnly));
            var users = DataFactory.GenerateUsers(20);
            context.Users.AddRange(users);

            var thisMonthLogs = DataFactory.GenerateLogs(50, users);
            thisMonthLogs.ForEach(logs => logs.LogDate = DateTime.Today);
            context.Logs.AddRange(thisMonthLogs);

            var pastLogs = DataFactory.GenerateLogs(50, users);
            pastLogs.ForEach(logs => { logs.LogID += 100; logs.LogDate = DateTime.Today.AddMonths(-1); });
            context.Logs.AddRange(pastLogs);
            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GenerateMonthlyReport(DateTime.Today.Month, DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<LogReportDTO>>(okResult.Value);

            var thisMonthLogsCount = thisMonthLogs.Count();
            Assert.Equal(thisMonthLogsCount, returnedLogs.Count());
        }

        [Fact]
        public async Task GenerateYearlyReport_ShouldReturnLogReportDTOAndYearLogsOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateYearlyReport_ShouldReturnLogReportDTOAndYearLogsOnly));
            var users = DataFactory.GenerateUsers(20);
            context.Users.AddRange(users);

            var thisYearLogs = DataFactory.GenerateLogs(50, users);
            thisYearLogs.ForEach(logs => logs.LogDate = DateTime.Today);
            context.Logs.AddRange(thisYearLogs);

            var pastLogs = DataFactory.GenerateLogs(50, users);
            pastLogs.ForEach(logs => { logs.LogID += 100; logs.LogDate = DateTime.Today.AddYears(-1); });
            context.Logs.AddRange(pastLogs);
            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.GenerateYearlyReport(DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLogs = Assert.IsAssignableFrom<IEnumerable<LogReportDTO>>(okResult.Value);

            var thisYearLogsCount = thisYearLogs.Count();
            Assert.Equal(thisYearLogsCount, returnedLogs.Count());
        }

        [Fact]
        public async Task DeleteLogs_WhenIdIsValid_ShouldReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DeleteLogs_WhenIdIsValid_ShouldReturnNoContent));
            var user = DataFactory.GenerateUsers(1);
            var log = DataFactory.GenerateLogs(1, user);
            log.First().LogID = "LOG123";

            context.Users.AddRange(user);
            context.Logs.AddRange(log);
            await context.SaveChangesAsync();

            var controller = new LogsController(context);

            // Act
            var result = await controller.DeleteLogs("LOG123");

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteLogs_WhenIdIsNullOrEmpty_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DeleteLogs_WhenIdIsNullOrEmpty_ShouldReturnBadRequest));

            var controller = new LogsController(context);

            // Act
            var result = await controller.DeleteLogs("");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteLogs_WhenIdIsInvalid_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DeleteLogs_WhenIdIsInvalid_ShouldReturnNotFound));

            var controller = new LogsController(context);

            // Act
            var result = await controller.DeleteLogs("LOG456");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
