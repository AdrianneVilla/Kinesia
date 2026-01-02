using KinesiaAPI.Controllers;
using KinesiaAPI.Models.Entities;
using KinesiaAPI.Tests.DataTest;
using KinesiaLibrary;
using KinesiaLibrary.DTOs.AssessmentDTOs;
using KinesiaLibrary.DTOs.AuthDTOs;
using KinesiaLibrary.DTOs.LogDTOs;
using KinesiaLibrary.DTOs.ReportDTOs;
using KinesiaLibrary.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KinesiaAPI.Tests.ControllerTests
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task Login_WhenAccountIsCorrect_ShouldReturnLoginResponseAndSuccessIsTrue()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(Login_WhenAccountIsCorrect_ShouldReturnLoginResponseAndSuccessIsTrue));
            var user = DataFactory.GenerateUsers(1);
            user.First().Username = "Test";
            var salt = CustomSecurity.GenerateSalt();
            user.First().Salt = salt;
            user.First().Password = CustomSecurity.HashPassword("Test", salt);

            context.Users.AddRange(user);
            await context.SaveChangesAsync();

            var loginRequest = new LoginRequest
            {
                Username = "Test",
                Password = "Test"
            };

            var controller = new AuthController(context);

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            Assert.IsType<LoginResponse>(result.Value);
            Assert.True(result.Value.Success);
        }

        [Fact]
        public async Task Login_WhenAccountIsIncorrect_ShouldReturnLoginResponseAndSuccessIsFalse()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(Login_WhenAccountIsIncorrect_ShouldReturnLoginResponseAndSuccessIsFalse));

            var loginRequest = new LoginRequest
            {
                Username = "Test",
                Password = "Test"
            };

            var controller = new AuthController(context);

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            Assert.IsType<LoginResponse>(result.Value);
            Assert.False(result.Value.Success);
        }
    }
}
