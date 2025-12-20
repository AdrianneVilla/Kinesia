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
        public async Task GenerateTodayReport_ShouldReturnAssessmentReportDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateTodayReport_ShouldReturnAssessmentReportDTO));
            var patients = DataFactory.GeneratePatients(20);
            var assessments = DataFactory.GenerateAssessments(50, patients);
            assessments.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; });

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GenerateTodayReport();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<AssessmentReportDTO>>(okResult.Value);

            var todayAssessmentsCount = assessments.Count();
            Assert.Equal(todayAssessmentsCount, returnedAssessments.Count());
        }

        [Fact]
        public async Task GenerateWeeklyReport_ShouldReturnAssessmentReportDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateWeeklyReport_ShouldReturnAssessmentReportDTO));
            var patients = DataFactory.GeneratePatients(20);
            var assessments = DataFactory.GenerateAssessments(50, patients);
            assessments.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today.AddDays(-2); });

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GenerateWeeklyReport(DateTime.Today.AddDays(-7), DateTime.Today);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<AssessmentReportDTO>>(okResult.Value);

            var weekAssessmentsCount = assessments.Count();
            Assert.Equal(weekAssessmentsCount, returnedAssessments.Count());
        }

        [Fact]
        public async Task GenerateMonthlyReport_ShouldReturnAssessmentReportDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateMonthlyReport_ShouldReturnAssessmentReportDTO));
            var patients = DataFactory.GeneratePatients(20);
            var assessments = DataFactory.GenerateAssessments(50, patients);
            assessments.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; });

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GenerateMonthlyReport(DateTime.Today.Month, DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessments = Assert.IsAssignableFrom<IEnumerable<AssessmentReportDTO>>(okResult.Value);

            var monthAssessmentsCount = assessments.Count();
            Assert.Equal(monthAssessmentsCount, returnedAssessments.Count());
        }

        [Fact]
        public async Task GenerateYearlyReport_ShouldReturnAssessmentReportDTO()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GenerateYearlyReport_ShouldReturnAssessmentReportDTO));
            var patients = DataFactory.GeneratePatients(20);
            var assessments = DataFactory.GenerateAssessments(50, patients);
            assessments.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; });

            context.Patients.AddRange(patients);
            context.Assessments.AddRange(assessments);
            await context.SaveChangesAsync();

            var controller = new AssessmentsController(context);

            // Act
            var result = await controller.GenerateYearlyReport(DateTime.Today.Year);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedAssessment = Assert.IsAssignableFrom<IEnumerable<AssessmentReportDTO>>(okResult.Value);

            var yearAssessmentsCount = assessments.Count();
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
            Assert.True(result.Value);
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
            Assert.False(result.Value);
        }

        [Fact]
        public async Task GetTotalOngoingAssessments_ShouldReturnOngoingAssessmentsCountOfTheMonthOnly()
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext(nameof(GetTotalOngoingAssessments_ShouldReturnOngoingAssessmentsCountOfTheMonthOnly));
            var patientsOfThisMonth = DataFactory.GeneratePatients(5);
            var ongoingAssessmentsOfThisMonth = DataFactory.GenerateAssessments(20, patientsOfThisMonth);
            ongoingAssessmentsOfThisMonth.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; assessments.AssessmentStatus = 1; });
            context.Patients.AddRange(patientsOfThisMonth);
            context.Assessments.AddRange(ongoingAssessmentsOfThisMonth);

            var patientsOfPastMonth = DataFactory.GeneratePatients(5);
            patientsOfPastMonth.ForEach(p => p.PatientID += 100);
            var ongoingAssessmentsOfPastMonth = DataFactory.GenerateAssessments(20, patientsOfPastMonth);
            ongoingAssessmentsOfPastMonth.ForEach(assessments => { assessments.AssessmentID += 100; assessments.AssessmentDate = DateTime.Today.AddMonths(-1); assessments.AssessmentStatus = 1; });
            context.Patients.AddRange(patientsOfPastMonth);
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
            var patientsOfThisMonth = DataFactory.GeneratePatients(5);
            var ongoingAssessmentsOfThisMonth = DataFactory.GenerateAssessments(20, patientsOfThisMonth);
            ongoingAssessmentsOfThisMonth.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; });
            context.Patients.AddRange(patientsOfThisMonth);
            context.Assessments.AddRange(ongoingAssessmentsOfThisMonth);

            var patientsOfPastMonth = DataFactory.GeneratePatients(5);
            patientsOfPastMonth.ForEach(p => p.PatientID += 100);
            var ongoingAssessmentsOfPastMonth = DataFactory.GenerateAssessments(20, patientsOfPastMonth);
            ongoingAssessmentsOfPastMonth.ForEach(assessments => { assessments.AssessmentID += 100; assessments.AssessmentDate = DateTime.Today.AddMonths(-1); });
            context.Patients.AddRange(patientsOfPastMonth);
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
            var patientsOfThisMonth = DataFactory.GeneratePatients(5);
            var assessmentsOfThisMonth = DataFactory.GenerateAssessments(20, patientsOfThisMonth);
            assessmentsOfThisMonth.ForEach(assessments => { assessments.AssessmentDate = DateTime.Today; assessments.Joint = "Shoulder"; });
            context.Patients.AddRange(patientsOfThisMonth);
            context.Assessments.AddRange(assessmentsOfThisMonth);

            var patientsOfPastMonth = DataFactory.GeneratePatients(5);
            patientsOfPastMonth.ForEach(p => p.PatientID += 100);
            var assessmentsOfPastMonth = DataFactory.GenerateAssessments(20, patientsOfPastMonth);
            assessmentsOfPastMonth.ForEach(assessments => { assessments.AssessmentID += 100; assessments.Joint = "Elbow and Forearm"; });
            context.Patients.AddRange(patientsOfPastMonth);
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
    }
}
