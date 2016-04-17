using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Faker;
using FizzWare.NBuilder;
using JobTracker.Web.Models;

namespace JobTracker.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<JobTrackerWebDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JobTrackerWebDbContext context)
        {

            var user = new User
            {
                FirstName = "Nancy",
                LastName = "Majors",
                Email = "nmajors@gmail.com",
                PhoneNum = Phone.Number(),
                Address = Address.StreetAddress(),
                Resume = TextFaker.Sentences(20)
            };

            context.Users.AddOrUpdate(x => x.Email,
                user);

            if (!context.Jobs.Any())
            {
                var jobs = Builder<Job>.CreateListOfSize(20)
                    .All()
                    .With(x => x.User = user)
                    .With(x => x.CompanyTitle = CompanyFaker.BS())
                    .With(x => x.JobTitle = CompanyFaker.Name())
                    .With(x => x.Address = Address.StreetAddress())
                    .With(x => x.Description = TextFaker.Sentences(3))
                    .With(x => x.PhoneNumber = PhoneFaker.Phone())
                    .With(x => x.Url = InternetFaker.Url())
                    .With(x => x.Status = EnumFaker.SelectFrom<JobStatus>())
                    .With(x => x.StatusDate = DateTimeFaker.DateTime(DateTime.Now.AddMonths(-2), DateTime.Now))
                    .With(x => x.Created = DateTimeFaker.DateTime(DateTime.Now.AddMonths(-2), DateTime.Now))
                    .Build();
                context.Jobs.AddRange(jobs);
            }
        }
    }
}