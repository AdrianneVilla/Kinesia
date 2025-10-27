using Xunit;
using KinesiaAPI.Controllers;
using KinesiaAPI.Data;
using KinesiaAPI.Tests.DataTest;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace KinesiaAPI.Tests.ControllerTests
{
    public class PatientsControllerTests
    {
        public class RandomPatientData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var random = new Random();
                for (int i = 0; i <= 20; i++)
                    yield return new object[] { random.Next(10, 200) };
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(RandomPatientData))]
        public async Task GetPatients_ShouldReturnActivePatientsOnly(int count)
        {
            // Arrange
            var context = TestDbContextFactory.CreateDbContext($"ActivePatients_{count}");
            var patients = DataFactory.GeneratePatients(count);
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
    }
}
