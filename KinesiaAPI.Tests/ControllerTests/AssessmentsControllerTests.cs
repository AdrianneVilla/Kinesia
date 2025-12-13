using KinesiaAPI.Controllers;
using KinesiaAPI.Models.Entities;
using KinesiaAPI.Tests.DataTest;
using KinesiaLibrary;
using KinesiaLibrary.DTOs.AssessmentDTOs;
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
    public class AssessmentsControllerTests
    {
        [Fact]
        public async Task GetAssessments_ShouldReturnUpperExtremityOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetAssessments_ShouldReturnUpperExtremityOnly));
            var patients = DataFactory.GeneratePatients(20);
            var assessments = DataFactory.GenerateAssessments(50, patients);

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);

            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetAssessments(currentExtremityTab: "Upper Extremity");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = assessments.Count(a => a.Extremity == "Upper Extremity");
            Assert.Equal(expectedCount, returnedAssessments.Count());
        }

        [Fact]
        public async Task GetAssessments_ShouldReturnLowerExtremityOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetAssessments_ShouldReturnLowerExtremityOnly));
            var patients = DataFactory.GeneratePatients(20);
            var assessments = DataFactory.GenerateAssessments(50, patients);

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);

            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetAssessments(currentExtremityTab: "Lower Extremity");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = assessments.Count(a => a.Extremity == "Lower Extremity");
            Assert.Equal(expectedCount, returnedAssessments.Count());
        }

        [Fact]
        public async Task GetAssessments_ShouldReturnOngoingOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetAssessments_ShouldReturnOngoingOnly));
            var patients = DataFactory.GeneratePatients(20);
            var assessments = DataFactory.GenerateAssessments(50, patients);

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);

            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetAssessments(currentStatusTab: "Ongoing");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = assessments.Count(a => a.AssessmentStatus == 1);
            Assert.Equal(expectedCount, returnedAssessments.Count());
        }

        [Fact]
        public async Task GetAssessments_ShouldReturnFinishedOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetAssessments_ShouldReturnFinishedOnly));
            var patients = DataFactory.GeneratePatients(20);
            var assessments = DataFactory.GenerateAssessments(50, patients);

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);

            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetAssessments(currentStatusTab: "Finished");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = assessments.Count(a => a.AssessmentStatus == 2);
            Assert.Equal(expectedCount, returnedAssessments.Count());
        }

        [Fact]
        public async Task GetAssessments_ShouldReturnArchivedOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetAssessments_ShouldReturnArchivedOnly));
            var patients = DataFactory.GeneratePatients(20);
            var assessments = DataFactory.GenerateAssessments(50, patients);

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);

            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetAssessments(currentStatusTab: "Archived");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            var expectedCount = assessments.Count(a => a.AssessmentStatus == 0);
            Assert.Equal(expectedCount, returnedAssessments.Count());
        }
    }
}
