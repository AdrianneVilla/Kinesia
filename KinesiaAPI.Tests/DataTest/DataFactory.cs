using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using KinesiaAPI.Models.Entities;

namespace KinesiaAPI.Tests.DataTest
{
    public static class DataFactory
    {
        public static List<Patients> GeneratePatients(int count)
        {
            var fakePatients = new Faker<Patients>()
                .RuleFor(p => p.PatientID, f => $"P{f.IndexFaker + 1}")
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.MiddleName, f => f.Name.FirstName().Substring(0, 1))
                .RuleFor(p => p.Status, f => f.Random.Bool() ? 1 : 0)
                .RuleFor(p => p.Contact, f =>
                {
                    // Generate a PH mobile number starting with 09
                    var prefix = f.PickRandom(new[] { "0905", "0917", "0921", "0936", "0947", "0956", "0963", "0975", "0981", "0999" });
                    var rest = f.Random.Number(0_000_000, 9_999_999).ToString("D7");
                    return $"{prefix}{rest}";
                })
                .RuleFor(p => p.Birthdate, f => f.Date.Past(30, DateTime.Now.AddYears(-20)))
                .RuleFor(p => p.Gender, f => f.PickRandom(new[] { "Male", "Female" }))
                .RuleFor(p => p.Address, f => f.Address.FullAddress())
                .RuleFor(p => p.Occupation, f => f.Name.JobTitle())
                .RuleFor(p => p.DateAdded, f => f.Date.Past(2))
                .RuleFor(p => p.LastArchiveDate, f => f.Random.Bool() ? f.Date.Recent() : null);

            return fakePatients.Generate(count);
        }
    }
}
