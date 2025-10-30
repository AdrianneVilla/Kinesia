using Xunit;
using KinesiaAPI.Controllers;
using KinesiaAPI.Data;
using KinesiaAPI.Tests.DataTest;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using KinesiaLibrary.DTOs.PatientDTOs;
using KinesiaAPI.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

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
            var returnedPatients = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

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
            var returnedPatients = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

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
            var returnedPatientsNull = Assert.IsAssignableFrom<IEnumerable<DisplayPatientsDTO>>(okResultNull.Value);
            Assert.Equal(20, returnedPatientsNull.Count());

            var okResultOther = Assert.IsType<OkObjectResult>(resultOtherTab.Result);
            var returnedPatientsOther = Assert.IsAssignableFrom<IEnumerable<DisplayPatientsDTO>>(okResultOther.Value);
            Assert.Equal(20, returnedPatientsOther.Count());
        }

        [Fact]
        public async Task GetPatients_ShouldReturnSearchedPatient()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatients_ShouldReturnSearchedPatient));
            var patients = DataFactory.GeneratePatients(20);

            patients.Add(new Patients
            {
                PatientID = "P123",
                FirstName = "Search",
                LastName = "Tester",
                MiddleName = "Searchs",
                Contact = "09285321382",
                Gender = "Male",
                Birthdate = DateTime.Now.AddYears(-30),
                Address = "123 street",
                Occupation = "Sample",
                DateAdded = DateTime.Now,
            });

            context.Patients.AddRange(patients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var  result = await controller.GetPatients(searchData: "Search");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatients = Assert.IsAssignableFrom<IEnumerable<DisplayPatientsDTO>>(okResult.Value);
            Assert.Single(returnedPatients);
            Assert.Contains("Search", returnedPatients.First().PatientName);
        }

        [Fact]
        public async Task GetPatients_ShouldReturnSortedPatientsByName()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatients_ShouldReturnSortedPatientsByName));

            var patients = new List<Patients>
            {
                DataFactory.GeneratePatients(1).First(p => { p.FirstName = "Charlie"; p.PatientID = "P1"; return true; }),
                DataFactory.GeneratePatients(1).First(p => { p.FirstName = "Alice"; p.PatientID = "P2"; return true; }),
                DataFactory.GeneratePatients(1).First(p => { p.FirstName = "Bob"; p.PatientID = "P3"; return true; })
            };

            context.Patients.AddRange(patients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetPatients(sortColumn: "Alphabetic (Name)");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnedPatients = Assert.IsAssignableFrom<IEnumerable<DisplayPatientsDTO>>(okResult.Value);

            var patientList = returnedPatients.ToList();

            Assert.Equal(3, patientList.Count);
            Assert.Equal("Alice", patientList[0].PatientName.Split(' ')[0]);
            Assert.Equal("Bob", patientList[1].PatientName.Split(' ')[0]);
            Assert.Equal("Charlie", patientList[2].PatientName.Split(' ')[0]);
        }

        [Fact]
        public async Task GetPatients_WithValidId_ShouldReturnPatientDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatients_WithValidId_ShouldReturnPatientDTO));
            var patients = DataFactory.GeneratePatients(20);
            var targetPatient = patients.First();

            context.Patients.AddRange(patients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetPatients(targetPatient.PatientID);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatient = Assert.IsType<PatientsDTO>(okResult.Value);

            Assert.Equal(targetPatient.PatientID, returnedPatient.PatientID);
            Assert.Equal(targetPatient.FirstName, returnedPatient.FirstName);
        }

        [Fact]
        public async Task GetPatients_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatients_WithInvalidId_ShouldReturnNotFound));

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetPatients("PATIENT999");

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
