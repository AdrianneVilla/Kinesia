using Xunit;
using KinesiaAPI.Controllers;
using KinesiaAPI.Data;
using KinesiaAPI.Tests.DataTest;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using KinesiaLibrary.DTOs.PatientDTOs;

namespace KinesiaAPI.Tests.ControllerTests
{
    public class PatientsControllerTests
    {
        [Fact]
        public async Task GetPatients_ShouldReturnActivePatientsOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatients_ShouldReturnActivePatientsOnly));
            var patients = DataFactory.GeneratePatients(20);
            context.Patients.AddRange(patients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetPatients(currentTab: "Active");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatients = okResult.Value as IEnumerable<object>;

            // Only those with Status == 1 should be counted
            var expectedCount = patients.Count(p => p.Status == 1);
            Assert.Equal(expectedCount, returnedPatients.Count());
        }

        [Fact]
        public async Task GetPatients_ShouldReturnInactivePatientsOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatients_ShouldReturnInactivePatientsOnly));
            var patients = DataFactory.GeneratePatients(20);
            context.Patients.AddRange(patients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetPatients(currentTab: "Inactive");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatients = okResult.Value as IEnumerable<object>;

            // Only those with Status == 1 should be counted
            var expectedCount = patients.Count(p => p.Status == 0);
            Assert.Equal(expectedCount, returnedPatients.Count());
        }

        [Fact]
        public async Task GetPatients_ShouldReturnAllPatientsWhenTabIsInvalid()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatients_ShouldReturnAllPatientsWhenTabIsInvalid));
            var patients = DataFactory.GeneratePatients(20);
            context.Patients.AddRange(patients);

            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var resultNullTab = await controller.GetPatients(currentTab: null);
            var resultOtherTab = await controller.GetPatients(currentTab: "All");

            // Assert
            var okResultNull = Assert.IsType<OkObjectResult>(resultNullTab.Result);
            var returnedPatientsNull = okResultNull.Value as IEnumerable<DisplayPatientsDTO>;
            Assert.Equal(20, returnedPatientsNull.Count());

            var okResultOther = Assert.IsType<OkObjectResult>(resultOtherTab.Result);
            var returnedPatientsOther = okResultOther.Value as IEnumerable<DisplayPatientsDTO>;
            Assert.Equal(20, returnedPatientsOther.Count());
        }
    }
}
