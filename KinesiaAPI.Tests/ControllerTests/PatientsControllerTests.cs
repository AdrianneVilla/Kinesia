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

        [Fact]
        public async Task UpdatePatientStatus_WhenPatientExists_ShouldUpdateStatusAndReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdatePatientStatus_WhenPatientExists_ShouldUpdateStatusAndReturnNoContent));

            var patientToUpdate = DataFactory.GeneratePatients(1).First();
            patientToUpdate.PatientID = "PATIENT123";
            patientToUpdate.Status = 1;

            context.Patients.Add(patientToUpdate);
            await context.SaveChangesAsync();

            var updatedPatient = new PatientUpdateStatusDTO
            {
                PatientID = "PATIENT123",
                Status = 0
            };

            var controller = new PatientsController(context);

            // Act
            var result = await controller.UpdatePatientStatus("PATIENT123", updatedPatient);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var patientInDb = await context.Patients.FindAsync("PATIENT123");

            Assert.NotNull(patientInDb);
            Assert.Equal(0, patientInDb.Status);
            Assert.NotNull(patientInDb.LastArchiveDate);
        }

        [Fact]
        public async Task UpdatePatientStatus_WhenPatientDoesNotExists_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdatePatientStatus_WhenPatientDoesNotExists_ShouldReturnNotFound));

            var updatedPatient = new PatientUpdateStatusDTO
            {
                PatientID = "PATIENT123",
                Status = 1
            };

            var controller = new PatientsController(context);

            // Act
            var result = await controller.UpdatePatientStatus("PATIENT123", updatedPatient);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutPatients_WhenPatientExistsAndIdsMatch_ShouldUpdatePatientAndReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(PutPatients_WhenPatientExistsAndIdsMatch_ShouldUpdatePatientAndReturnNoContent));

            var originalPatient = DataFactory.GeneratePatients(1).First();
            originalPatient.PatientID = "PATIENT123";
            originalPatient.FirstName = "Test";
            originalPatient.Contact = "+639285321382";

            context.Patients.Add(originalPatient);
            await context.SaveChangesAsync();

            var updatedPatient = new UpdatedPatientDTO
            {
                PatientID = "PATIENT123",
                FirstName = "UpdatedFirstName",
                Contact = null
            };

            var controller = new PatientsController(context);

            // Act
            var result = await controller.PutPatients("PATIENT123", updatedPatient);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var patientInDb = await context.Patients.FindAsync("PATIENT123");

            Assert.NotNull(patientInDb);
            Assert.Equal("UpdatedFirstName", patientInDb.FirstName);
            Assert.Equal("+639285321382", patientInDb.Contact);
        }

        [Fact]
        public async Task PutPatients_WhenPatientDoesNotExist_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(PutPatients_WhenPatientDoesNotExist_ShouldReturnNotFound));

            var updatedPatient = new UpdatedPatientDTO
            {
                PatientID = "P999"
            };

            var controller = new PatientsController(context);

            // Act
            var result = await controller.PutPatients("P999", updatedPatient);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.NotNull(notFoundResult.Value);
        }

        [Fact]
        public async Task PutPatients_WhenIdMismatch_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(PutPatients_WhenIdMismatch_ShouldReturnBadRequest));

            var updatedPatient = new UpdatedPatientDTO
            {
                PatientID = "P999"
            };

            var controller = new PatientsController(context);

            // Act
            var result = await controller.PutPatients("P33", updatedPatient);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(badRequestResult.Value);
        }

        [Fact]
        public async Task CheckExistingPatient_WhenPatientDoesNotExists_ShouldReturnOkResult()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(CheckExistingPatient_WhenPatientDoesNotExists_ShouldReturnOkResult));

            var nonExistingPatient = new CheckExistingPatientDTO
            {
                FirstName = "Sample",
                LastName = "Sample",
                MiddleName = "Sample"
            };

            var controller = new PatientsController(context);

            // Act
            var result = await controller.CheckExistingPatient(nonExistingPatient);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task CheckExistingPatient_WhenPatientExists_ShouldReturnConflict()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(CheckExistingPatient_WhenPatientExists_ShouldReturnConflict));

            var patient = DataFactory.GeneratePatients(1).First();
            patient.FirstName = "Exist";
            patient.MiddleName = "Exist";
            patient.LastName = "Exist";

            context.Patients.Add(patient);
            await context.SaveChangesAsync();

            var existingPatient = new CheckExistingPatientDTO
            {
                FirstName = "Exist",
                LastName = "Exist",
                MiddleName = "Exist"
            };

            var controller = new PatientsController(context);

            // Act
            var result = await controller.CheckExistingPatient(existingPatient);

            // Assert
            Assert.IsType<ConflictResult>(result);
        }
    }
}
