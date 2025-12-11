using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static List<Users> GenerateUsers(int count)
        {
            var fakeUsers = new Faker<Users>()
                .RuleFor(u => u.UserID, f => $"U{f.IndexFaker + 1}")
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.MiddleName, f => f.Name.FirstName().Substring(0, 1))
                .RuleFor(u => u.Status, f => f.Random.Bool() ? 1 : 0)
                .RuleFor(u => u.Contact, f =>
                {
                    // Generate a PH mobile number starting with 09
                    var prefix = f.PickRandom(new[] { "0905", "0917", "0921", "0936", "0947", "0956", "0963", "0975", "0981", "0999" });
                    var rest = f.Random.Number(0_000_000, 9_999_999).ToString("D7");
                    return $"{prefix}{rest}";
                })
                .RuleFor(u => u.Birthdate, f => f.Date.Past(30, DateTime.Now.AddYears(-20)))
                .RuleFor(u => u.Gender, f => f.PickRandom(new[] { "Male", "Female" }))
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .RuleFor(u => u.Role, f => f.PickRandom(new[] { "Admin", "Therapist" }))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.DateAdded, f => f.Date.Past(2))
                .RuleFor(u => u.LastArchiveDate, f => f.Random.Bool() ? f.Date.Recent() : null)
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Salt, f => Convert.ToBase64String(f.Random.Bytes(16)))
                .RuleFor(u => u.Password, (f, u) =>
                {
                    string fakePlainTextPassword = f.Internet.Password(10);
                    string saltedPassword = fakePlainTextPassword + u.Salt;

                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                        StringBuilder builder = new StringBuilder();
                        foreach (byte b in bytes)
                        {
                            builder.Append(b.ToString("x2"));
                        }
                        return builder.ToString();
                    }
                });

            return fakeUsers.Generate(count);
        }   

        public static List<Logs> GenerateLogs(int count, List<Users> existingUsers)
        {
            var fakeLogs = new Faker<Logs>()
                .RuleFor(l => l.LogID, f => $"LOG{f.IndexFaker + 1}")
                .RuleFor(l => l.UserID, f => f.PickRandom(existingUsers).UserID)
                .RuleFor(l => l.LogType, f => f.PickRandom(new[]
                {
                    "Sessions", "Patients", "Users", "Assessment", "ROM",
                }))
                .RuleFor(l => l.Description, f => f.Lorem.Sentence())
                .RuleFor(l => l.LogDate, f => f.Date.Past(2));

            return fakeLogs.Generate(count);
        }

        public static List<Assessments> GenerateAssessments(int count, List<Patients> existingPatients)
        {
            var fakeAssessments = new Faker<Assessments>()
                .RuleFor(a => a.AssessmentID, f => $"ASSESSMENT{f.IndexFaker + 1}")
                .RuleFor(a => a.PatientID, f => f.PickRandom(existingPatients).PatientID)
                .RuleFor(a => a.Extremity, f => f.PickRandom(new[] { "Upper Extremity", "Lower Extremity" }))
                .RuleFor(a => a.Joint, f => f.PickRandom(new[] { "Elbow and Forearm", "Shoulder", "Hip", "Knee" }))
                .RuleFor(a => a.JointSide, f => f.PickRandom(new[] { "Left", "Right" }))
                .RuleFor(a => a.AssessmentStatus, f => f.Random.Bool() ? 1 : 0)
                .RuleFor(a => a.AssessmentDate, f => f.Date.Past(2))
                .RuleFor(a => a.AssessmentEndDate, f => f.Random.Bool() ? f.Date.Recent() : null);

            return fakeAssessments.Generate(count);
        }
    }
}
