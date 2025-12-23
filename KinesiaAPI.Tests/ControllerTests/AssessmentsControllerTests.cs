using KinesiaAPI.Controllers;
using KinesiaAPI.Models.Entities;
using KinesiaAPI.Tests.DataTest;
using KinesiaLibrary;
using KinesiaLibrary.DTOs.AssessmentDTOs;
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

        [Fact]
        public async Task GetAssessments_WithValidAssessmentId_ShouldReturnAssessmentDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetAssessments_WithValidAssessmentId_ShouldReturnAssessmentDTO));
            var patients = DataFactory.GeneratePatients(1);
            var assessments = DataFactory.GenerateAssessments(1, patients).First();

            assessments.AssessmentID = "ASSESSMENT1";

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetAssessments("ASSESSMENT1");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessment = Assert.IsAssignableFrom<AssessmentDTO>(okResult.Value);

            Assert.Equal("ASSESSMENT1", returnedAssessment.AssessmentID);
        }

        [Fact]
        public async Task GetAssessments_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetAssessments_WithInvalidId_ShouldReturnNotFound));

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetAssessments("ASSESSMENT1");

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task DisplayPatientAssessments_WithValidId_ShouldDisplayPatientAssessmentsDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DisplayPatientAssessments_WithValidId_ShouldDisplayPatientAssessmentsDTO));
            var patient = DataFactory.GeneratePatients(1);
            patient.First().PatientID = "PATIENT123";
            var assessment = DataFactory.GenerateAssessments(1, patient);
            assessment.First().AssessmentID = "ASSESSMENT123";

            context.Patients.AddRange(patient);
            context.Assessments.AddRange(assessment);

            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.DisplayPatientAssessments("PATIENT123");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessment = Assert.IsAssignableFrom<IEnumerable<DisplayPatientAssessmentsDTO>>(okResult.Value);

            Assert.Equal("ASSESSMENT123", returnedAssessment.First().AssessmentID);
        }

        [Fact]
        public async Task DisplayPatientAssessments_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DisplayPatientAssessments_WithInvalidId_ShouldReturnNotFound));

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.DisplayPatientAssessments("PATIENT123");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task DisplayPatientAssessments_WithNullInput_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(DisplayPatientAssessments_WithNullInput_ShouldReturnBadRequest));

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.DisplayPatientAssessments("");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GenerateAssessmentReport_WithValidId_ShouldReturnAssessmentReportDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateAssessmentReport_WithValidId_ShouldReturnAssessmentReportDTO));
            var patient = DataFactory.GeneratePatients(1);
            var assessment = DataFactory.GenerateAssessments(1, patient);
            assessment.First().AssessmentID = "ASSESSMENT123";

            context.Patients.AddRange(patient);
            context.Assessments.AddRange(assessment);

            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GenerateAssessmentReport("ASSESSMENT123");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessment = Assert.IsAssignableFrom<AssessmentReportDTO>(okResult.Value);

            Assert.Equal("ASSESSMENT123", returnedAssessment.AssessmentID);
        }

        [Fact]
        public async Task GenerateAssessmentReport_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateAssessmentReport_WithInvalidId_ShouldReturnNotFound));

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GenerateAssessmentReport("ASSESSMENT123");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GenerateTodayReport_ShouldReturnAssessmentReportDTOAndAssessmentsTodayOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateTodayReport_ShouldReturnAssessmentReportDTOAndAssessmentsTodayOnly));
            var patients = DataFactory.GeneratePatients(20);
            context.Patients.AddRange(patients);

            var todayAssessments = DataFactory.GenerateAssessments(50, patients);
            todayAssessments.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; });
            context.Assessments.AddRange(todayAssessments);

            var pastAssessments = DataFactory.GenerateAssessments(50, patients);
            pastAssessments.ForEach(assessments => { assessments.AssessmentID += 100; assessments.AssessmentDate = DateTime.Today.AddDays(-1); });
            context.Assessments.AddRange(pastAssessments);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GenerateTodayReport();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<AssessmentReportDTO>>(okResult.Value);

            var todayAssessmentsCount = todayAssessments.Count();
            Assert.Equal(50, returnedAssessments.Count());
        }

        [Fact]
        public async Task GenerateWeeklyReport_ShouldReturnAssessmentReportDTOAndAssessmentsOfTheWeekOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateWeeklyReport_ShouldReturnAssessmentReportDTOAndAssessmentsOfTheWeekOnly));
            var patients = DataFactory.GeneratePatients(20);
            context.Patients.AddRange(patients);

            var thisWeekAssessments = DataFactory.GenerateAssessments(50, patients);
            thisWeekAssessments.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; });
            context.Assessments.AddRange(thisWeekAssessments);

            var pastAssessments = DataFactory.GenerateAssessments(50, patients);
            pastAssessments.ForEach(assessments => { assessments.AssessmentID += 100; assessments.AssessmentDate = DateTime.Today.AddDays(-9); });
            context.Assessments.AddRange(pastAssessments);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);


            // Act
            var result = await controller.GenerateWeeklyReport(DateTime.Today.AddDays(-7), DateTime.Today.AddDays(1));

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<AssessmentReportDTO>>(okResult.Value);

            var weekAssessmentsCount = thisWeekAssessments.Count();
            Assert.Equal(weekAssessmentsCount, returnedAssessments.Count());
        }

        [Fact]
        public async Task GenerateMonthlyReport_ShouldReturnAssessmentReportDTOAndAssessmentsOfTheMonthOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateMonthlyReport_ShouldReturnAssessmentReportDTOAndAssessmentsOfTheMonthOnly));
            var patients = DataFactory.GeneratePatients(20);
            context.Patients.AddRange(patients);

            var thisMonthAssessments = DataFactory.GenerateAssessments(50, patients);
            thisMonthAssessments.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; });
            context.Assessments.AddRange(thisMonthAssessments);

            var pastAssessments = DataFactory.GenerateAssessments(50, patients);
            pastAssessments.ForEach(assessments => { assessments.AssessmentID += 100; assessments.AssessmentDate = DateTime.Today.AddMonths(-1); });
            context.Assessments.AddRange(pastAssessments);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GenerateMonthlyReport(DateTime.Today.Month, DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<AssessmentReportDTO>>(okResult.Value);

            var monthAssessmentsCount = thisMonthAssessments.Count();
            Assert.Equal(monthAssessmentsCount, returnedAssessments.Count());
        }

        [Fact]
        public async Task GenerateYearlyReport_ShouldReturnAssessmentReportDTOAndAssessmentsOfTheYearOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateYearlyReport_ShouldReturnAssessmentReportDTOAndAssessmentsOfTheYearOnly));
            var patients = DataFactory.GeneratePatients(20);
            context.Patients.AddRange(patients);

            var thisYearAssessments = DataFactory.GenerateAssessments(50, patients);
            thisYearAssessments.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; });
            context.Assessments.AddRange(thisYearAssessments);

            var pastAssessments = DataFactory.GenerateAssessments(50, patients);
            pastAssessments.ForEach(assessments => { assessments.AssessmentID += 100; assessments.AssessmentDate = DateTime.Today.AddYears(-1); });
            context.Assessments.AddRange(pastAssessments);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GenerateYearlyReport(DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessment = Assert.IsAssignableFrom<IEnumerable<AssessmentReportDTO>>(okResult.Value);

            var yearAssessmentsCount = thisYearAssessments.Count();
            Assert.Equal(yearAssessmentsCount, returnedAssessment.Count())  ;
        }

        [Fact]
        public async Task CheckOngoingAssessment_ShouldReturnTrue()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(CheckOngoingAssessment_ShouldReturnTrue));
            var patient = DataFactory.GeneratePatients(1);
            patient.First().PatientID = "PATIENT123";
            var assessment = DataFactory.GenerateAssessments(1, patient);
            assessment.First().AssessmentStatus = 1;
            assessment.First().Joint = "Shoulder";
            assessment.First().JointSide = "Left";

            context.Patients.AddRange(patient);
            context.Assessments.AddRange(assessment);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.CheckOngoingAssessment("PATIENT123", "Shoulder", "Left");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var boolResult = Assert.IsType<bool>(okResult.Value);

            Assert.True(boolResult);
        }

        [Fact]
        public async Task CheckOngoingAssessment_ShouldReturnFalse()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(CheckOngoingAssessment_ShouldReturnFalse));
            var patient = DataFactory.GeneratePatients(1);
            patient.First().PatientID = "PATIENT123";
            var assessment = DataFactory.GenerateAssessments(1, patient);
            assessment.First().AssessmentStatus = 2;
            assessment.First().Joint = "Shoulder";
            assessment.First().JointSide = "Left";

            context.Patients.AddRange(patient);
            context.Assessments.AddRange(assessment);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.CheckOngoingAssessment("PATIENT123", "Shoulder", "Left");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var boolResult = Assert.IsType<bool>(okResult.Value);

            Assert.False(boolResult);
        }

        [Fact]
        public async Task GetTotalOngoingAssessments_ShouldReturnOngoingAssessmentsCountOfTheMonthOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetTotalOngoingAssessments_ShouldReturnOngoingAssessmentsCountOfTheMonthOnly));
            var patients = DataFactory.GeneratePatients(5);
            context.Patients.AddRange(patients);

            var ongoingAssessmentsOfThisMonth = DataFactory.GenerateAssessments(20, patients);
            ongoingAssessmentsOfThisMonth.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; assessments.AssessmentStatus = 1; });
            context.Assessments.AddRange(ongoingAssessmentsOfThisMonth);

            var ongoingAssessmentsOfPastMonth = DataFactory.GenerateAssessments(20, patients);
            ongoingAssessmentsOfPastMonth.ForEach(assessments => { assessments.AssessmentID += 100; assessments.AssessmentDate = DateTime.Today.AddMonths(-1); assessments.AssessmentStatus = 1; });
            context.Assessments.AddRange(ongoingAssessmentsOfPastMonth);
                
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetTotalOngoingAssessments(DateTime.Today.Month, DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualCount = Assert.IsType<int>(okResult.Value);

            Assert.Equal(ongoingAssessmentsOfThisMonth.Count, actualCount);
        }

        [Fact]
        public async Task GetTotalAssessments_ShouldReturnTotalAssessmentsCountOfTheMonthOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetTotalAssessments_ShouldReturnTotalAssessmentsCountOfTheMonthOnly));
            var patients = DataFactory.GeneratePatients(5);
            context.Patients.AddRange(patients);

            var ongoingAssessmentsOfThisMonth = DataFactory.GenerateAssessments(20, patients);
            ongoingAssessmentsOfThisMonth.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; });
            context.Assessments.AddRange(ongoingAssessmentsOfThisMonth);

            var ongoingAssessmentsOfPastMonth = DataFactory.GenerateAssessments(20, patients);
            ongoingAssessmentsOfPastMonth.ForEach(assessments => { assessments.AssessmentID += 100; assessments.AssessmentDate = DateTime.Today.AddMonths(-1); });
            context.Assessments.AddRange(ongoingAssessmentsOfPastMonth);

            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetTotalAssessments(DateTime.Today.Month, DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualCount = Assert.IsType<int>(okResult.Value);

            Assert.Equal(ongoingAssessmentsOfThisMonth.Count, actualCount);
        }

        [Fact]
        public async Task GetMostTrackedJoint_ShouldReturnMostTrackedJointOfTheMonthOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetMostTrackedJoint_ShouldReturnMostTrackedJointOfTheMonthOnly));
            var patients = DataFactory.GeneratePatients(5);
            context.Patients.AddRange(patients);

            var assessmentsOfThisMonth = DataFactory.GenerateAssessments(20, patients);
            assessmentsOfThisMonth.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; assessments.Joint = "Shoulder"; });
            context.Assessments.AddRange(assessmentsOfThisMonth);

            var assessmentsOfPastMonth = DataFactory.GenerateAssessments(20, patients);
            assessmentsOfPastMonth.ForEach(assessments => { assessments.AssessmentID += 100; assessments.Joint = "Elbow and Forearm"; });
            context.Assessments.AddRange(assessmentsOfPastMonth);

            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GetMostTrackedJoint(DateTime.Today.Month, DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var mostTrackedJoint = Assert.IsType<string>(okResult.Value);

            Assert.Equal("Shoulder", mostTrackedJoint);
        }

        [Fact]
        public async Task UpdateAssessmentStatus_WhenIdIsValidAndAssessmentExists_ShouldReturnNoContent()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdateAssessmentStatus_WhenIdIsValidAndAssessmentExists_ShouldReturnNoContent));
            var patient = DataFactory.GeneratePatients(1);
            var assessment = DataFactory.GenerateAssessments(1, patient);
            assessment.First().AssessmentID = "ASSESSMENT123";
            assessment.First().AssessmentStatus = 1;

            context.Patients.AddRange(patient);
            context.Assessments.AddRange(assessment);
            await context.SaveChangesAsync();

            var updatedAssessment = new AssessmentUpdateStatusDTO
            {
                AssessmentID = "ASSESSMENT123",
                AssessmentStatus = 2,
                AssessmentEndDate = DateTime.Now
            };

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.UpdateAssessmentStatus("ASSESSMENT123", updatedAssessment);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var assessmentInDb = await context.Assessments.FindAsync("ASSESSMENT123");

            Assert.NotNull(assessmentInDb);
            Assert.Equal(2, assessmentInDb.AssessmentStatus);
            Assert.NotNull(assessmentInDb.AssessmentEndDate);
        }

        [Fact]
        public async Task UpdateAssessmentStatus_WhenIdIsInvalid_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdateAssessmentStatus_WhenIdIsInvalid_ShouldReturnBadRequest));
            
            var updatedAssessment = new AssessmentUpdateStatusDTO
            {
                AssessmentID = "ASSESSMENT456",
                AssessmentStatus = 2
            };

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.UpdateAssessmentStatus("ASSESSMENT123", updatedAssessment);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateAssessmentStatus_WhenIdIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdateAssessmentStatus_WhenIdIsNull_ShouldReturnBadRequest));

            var updatedAssessment = new AssessmentUpdateStatusDTO
            {
                AssessmentID = "ASSESSMENT456",
                AssessmentStatus = 2
            };

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.UpdateAssessmentStatus("", updatedAssessment);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateAssessmentStatus_WhenAssessmentDoesNotExists_ShouldReturnNotFound()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(UpdateAssessmentStatus_WhenAssessmentDoesNotExists_ShouldReturnNotFound));

            var updatedAssessment = new AssessmentUpdateStatusDTO
            {
                AssessmentID = "ASSESSMENT456",
                AssessmentStatus = 2
            };

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.UpdateAssessmentStatus("ASSESSMENT456", updatedAssessment);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
