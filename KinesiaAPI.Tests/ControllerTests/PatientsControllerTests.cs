using KinesiaAPI.Controllers;
using KinesiaAPI.Data;
using KinesiaAPI.Models.Entities;
using KinesiaAPI.Tests.DataTest;
using KinesiaLibrary.DTOs.PatientDTOs;
using KinesiaLibrary.DTOs.ReportDTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
            var returnedPatientsNull = Assert.IsAssignableFrom<IEnumerable<object>>(okResultNull.Value);
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
        public async Task GetPatientBasicDetails_WhenIdIsValidAndPatientExists_ShouldReturnPatientBasicDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatientBasicDetails_WhenIdIsValidAndPatientExists_ShouldReturnPatientBasicDTO));
            var patient = DataFactory.GeneratePatients(1);
            patient.First().PatientID = "PATIENT123";

            context.Patients.AddRange(patient);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetPatientBasicDetails("PATIENT123");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatient = Assert.IsType<PatientBasicDTO>(okResult.Value);

            Assert.Equal("PATIENT123", returnedPatient.PatientID);
        }

        [Fact]
        public async Task GetPatientBasicDetails_WhenIdIsValidAndPatientDoesNotExists_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatientBasicDetails_WhenIdIsValidAndPatientDoesNotExists_ShouldReturnNotFound));
            
            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetPatientBasicDetails("PATIENT456");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetPatientBasicDetails_WhenIdIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetPatientBasicDetails_WhenIdIsNull_ShouldReturnBadRequest));

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetPatientBasicDetails("");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);   
        }

        [Fact]
        public async Task GetTotalPatientsByStatus_ShouldReturnActiveCountOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetTotalPatientsByStatus_ShouldReturnActiveCountOnly));
            var patients = DataFactory.GeneratePatients(50);

            context.Patients.AddRange(patients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetTotalPatientsByStatus(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatientsCount = Assert.IsType<int>(okResult.Value);

            var activePatientsCount = context.Patients.Count(p => p.Status == 1);
            Assert.Equal(activePatientsCount, returnedPatientsCount);
        }

        [Fact]
        public async Task GetTotalPatientsByStatus_ShouldReturnInactiveCountOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetTotalPatientsByStatus_ShouldReturnInactiveCountOnly));
            var patients = DataFactory.GeneratePatients(50);

            context.Patients.AddRange(patients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetTotalPatientsByStatus(0);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatientsCount = Assert.IsType<int>(okResult.Value);

            var inactivePatientsCount = context.Patients.Count(p => p.Status == 0);
            Assert.Equal(inactivePatientsCount, returnedPatientsCount);
        }

        [Fact]
        public async Task GetMostFieldOfWork_ShouldReturnOkResult()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetMostFieldOfWork_ShouldReturnOkResult));
            var patients = DataFactory.GeneratePatients(50);

            context.Patients.AddRange(patients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GetMostFieldOfWork();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMostFieldOfWork = Assert.IsType<string>(okResult.Value);

            var mostFieldOfWork = await context.Patients
                .GroupBy(p => p.Occupation)
                .Select(g => new
                {
                    Occupation = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .FirstOrDefaultAsync();

            Assert.Equal(mostFieldOfWork.Occupation, returnedMostFieldOfWork);
        }

        [Fact]
        public async Task GenerateTodayReport_ShouldReturnPatientReportDTOAndTodayPatientsOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateTodayReport_ShouldReturnPatientReportDTOAndTodayPatientsOnly));
            var todayPatients = DataFactory.GeneratePatients(50);
            todayPatients.ForEach(patients => patients.DateAdded = DateTime.Today);
            context.Patients.AddRange(todayPatients);

            var pastPatients = DataFactory.GeneratePatients(50);
            pastPatients.ForEach(patients => { patients.PatientID += 100; patients.DateAdded = DateTime.Today.AddDays(-1); });
            context.Patients.AddRange(pastPatients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GenerateTodayReport();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatients = Assert.IsAssignableFrom<IEnumerable<PatientReportDTO>>(okResult.Value);

            var todayPatientsCount = todayPatients.Count();
            Assert.Equal(todayPatientsCount, returnedPatients.Count());
        }

        [Fact]
        public async Task GenerateWeeklyReport_ShouldReturnPatientReportDTOAndWeekPatientsOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateWeeklyReport_ShouldReturnPatientReportDTOAndWeekPatientsOnly));
            var thisWeekPatients = DataFactory.GeneratePatients(50);
            thisWeekPatients.ForEach(patients => patients.DateAdded = DateTime.Today);
            context.Patients.AddRange(thisWeekPatients);

            var pastPatients = DataFactory.GeneratePatients(50);
            pastPatients.ForEach(patients => { patients.PatientID += 100; patients.DateAdded = DateTime.Today.AddDays(-9); });
            context.Patients.AddRange(pastPatients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GenerateWeeklyReport(DateTime.Today.AddDays(-7), DateTime.Today.AddDays(2));

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatients = Assert.IsAssignableFrom<IEnumerable<PatientReportDTO>>(okResult.Value);

            var thisWeekPatientsCount = thisWeekPatients.Count();
            Assert.Equal(thisWeekPatientsCount, returnedPatients.Count());
        }

        [Fact]
        public async Task GenerateMonthReport_ShouldReturnPatientReportDTOAndMonthPatientsOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateMonthReport_ShouldReturnPatientReportDTOAndMonthPatientsOnly));
            var thisMonthPatients = DataFactory.GeneratePatients(50);
            thisMonthPatients.ForEach(patients => patients.DateAdded = DateTime.Today);
            context.Patients.AddRange(thisMonthPatients);

            var pastPatients = DataFactory.GeneratePatients(50);
            pastPatients.ForEach(patients => { patients.PatientID += 100; patients.DateAdded = DateTime.Today.AddMonths(-1); });
            context.Patients.AddRange(pastPatients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GenerateMonthReport(DateTime.Today.Month, DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatients = Assert.IsAssignableFrom<IEnumerable<PatientReportDTO>>(okResult.Value);

            var thisMonthPatientsCount = thisMonthPatients.Count();
            Assert.Equal(thisMonthPatientsCount, returnedPatients.Count());
        }

        [Fact]
        public async Task GenerateYearlyReport_ShouldReturnPatientReportDTOAndYearPatientsOnly()
        {
            // Assert
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateYearlyReport_ShouldReturnPatientReportDTOAndYearPatientsOnly));
            var thisYearPatients = DataFactory.GeneratePatients(50);
            thisYearPatients.ForEach(patients => patients.DateAdded = DateTime.Today);
            context.Patients.AddRange(thisYearPatients);

            var pastPatients = DataFactory.GeneratePatients(50);
            pastPatients.ForEach(patients => { patients.PatientID += 100; patients.DateAdded = DateTime.Today.AddYears(-1); });
            context.Patients.AddRange(pastPatients);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.GenerateYearlyReport(DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPatients = Assert.IsAssignableFrom<IEnumerable<PatientReportDTO>>(okResult.Value);

            var thisYearPatientsCount = thisYearPatients.Count();
            Assert.Equal(thisYearPatientsCount, returnedPatients.Count());
        }

        [Fact]
        public async Task UpdatePatientStatus_WhenIdIsValidAndPatientExists_ShouldReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdatePatientStatus_WhenIdIsValidAndPatientExists_ShouldReturnNoContent));

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
        public async Task UpdatePatientStatus_WhenIdIsInvalid_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdatePatientStatus_WhenIdIsInvalid_ShouldReturnBadRequest));

            var updatedPatient = new PatientUpdateStatusDTO
            {
                PatientID = "PATIENT123",
                Status = 1
            };

            var controller = new PatientsController(context);

            // Act
            var result = await controller.UpdatePatientStatus("PATIENT456", updatedPatient);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdatePatientStatus_WhenIdIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdatePatientStatus_WhenIdIsNull_ShouldReturnBadRequest));

            var updatedPatient = new PatientUpdateStatusDTO
            {
                PatientID = "PATIENT123",
                Status = 1
            };

            var controller = new PatientsController(context);

            // Act
            var result = await controller.UpdatePatientStatus("", updatedPatient);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
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
            Assert.IsType<NotFoundObjectResult>(result);
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

        [Fact]
        public async Task DeletePatients_WhenPatientExists_ShouldReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DeletePatients_WhenPatientExists_ShouldReturnNoContent));

            var patient = DataFactory.GeneratePatients(1).First();
            patient.PatientID = "PATIENT123";

            context.Patients.Add(patient);
            await context.SaveChangesAsync();

            var controller = new PatientsController(context);

            // Act
            var result = await controller.DeletePatients("PATIENT123");

            // Assert
            Assert.IsType<NoContentResult>(result);

            var patientInDb = await context.Patients.FindAsync("PATIENT123");
            Assert.Null(patientInDb);
        }

        [Fact]
        public async Task DeletePatients_WhenPatientDoesNotExists_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DeletePatients_WhenPatientDoesNotExists_ShouldReturnNotFound));

            var controller = new PatientsController(context);

            // Act
            var result = await controller.DeletePatients("PATIENT123");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PatientToDTO_ShouldReturnPatientsDTO()
        {
            // Arrange
            var patient = DataFactory.GeneratePatients(1).First();

            // Act
            var result = PatientsController.PatientToDTO(patient);

            // Assert
            Assert.IsType<PatientsDTO>(result);
            Assert.Equal(patient.PatientID, result.PatientID);
            Assert.Equal(patient.FirstName, result.FirstName);
            Assert.Equal(patient.MiddleName, result.MiddleName);
            Assert.Equal(patient.LastName, result.LastName);
            Assert.Equal(patient.Contact, result.Contact);
            Assert.Equal(patient.Gender, result.Gender);
            Assert.Equal(patient.Address, result.Address);
            Assert.Equal(patient.Occupation, result.Occupation);
            Assert.Equal(patient.DateAdded, result.DateAdded);
            Assert.Equal(patient.Status, result.Status);
        }

        [Fact]
        public void PatientToDisplayPatientsDTO_ShouldReturnDisplayPatientsDTO()
        {
            // Arrange
            var patient = DataFactory.GeneratePatients(1).First();

            // Act
            var result = PatientsController.PatientToDisplayPatientsDTO(patient);

            // Assert
            Assert.IsType<DisplayPatientsDTO>(result);
            Assert.Equal(patient.PatientID, result.PatientID);
            Assert.Equal($"{patient.FirstName} {patient.MiddleName} {patient.LastName}", result.PatientName);
            Assert.Equal((int)((DateTime.Now - patient.Birthdate).TotalDays / 365.25), result.Age);
            Assert.Equal(patient.Contact, result.Contact);
        }

        [Fact]
        public void PatientToDisplayPatientSelectionDTO_ShouldReturnDisplayPatientSelectionDTO()
        {
            // Arrange
            var patient = DataFactory.GeneratePatients(1).First();

            // Act
            var result = PatientsController.PatientToDisplayPatientSelectionDTO(patient);

            // Assert
            Assert.IsType<DisplayPatientSelectionDTO>(result);
            Assert.Equal(patient.PatientID, result.PatientID);
            Assert.Equal($"{patient.FirstName} {patient.MiddleName} {patient.LastName}", result.PatientName);
            Assert.Equal((int)((DateTime.Now - patient.Birthdate).TotalDays / 365.25), result.Age);
            Assert.Equal(patient.Gender, result.Gender);
        }

        [Fact]
        public void PatientToPatientBasicDTO_ShouldReturnPatientBasicDTO()
        {
            // Arrange
            var patient = DataFactory.GeneratePatients(1).First();

            // Act
            var result = PatientsController.PatientToPatientBasicDTO(patient);

            // Assert
            Assert.IsType<PatientBasicDTO>(result);
            Assert.Equal(patient.PatientID, result.PatientID);
            Assert.Equal($"{patient.FirstName} {patient.MiddleName} {patient.LastName}", result.PatientName);
            Assert.Equal((int)((DateTime.Now - patient.Birthdate).TotalDays / 365.25), result.Age);
            Assert.Equal(patient.Gender, result.Gender);
        }

        [Fact]
        public void PatientToPatientReportDTO_ShouldReturnPatientReportDTO()
        {
            // Arrange
            var patient = DataFactory.GeneratePatients(1).First();

            // Act
            var result = PatientsController.PatientToPatientReportDTO(patient);

            // Assert
            Assert.IsType<PatientReportDTO>(result);
            Assert.Equal(patient.PatientID, result.PatientID);
            Assert.Equal($"{patient.FirstName} {patient.MiddleName} {patient.LastName}", result.PatientName);
            Assert.Equal((int)((DateTime.Now - patient.Birthdate).TotalDays / 365.25), result.Age);
            Assert.Equal(patient.Contact, result.Contact);
            Assert.Equal(patient.Gender, result.Gender);
            Assert.Equal(patient.Occupation, result.Occupation);
            Assert.Equal(patient.DateAdded.ToString("yyyy-MM-dd"), result.DateAdded);
        }
    }
}
