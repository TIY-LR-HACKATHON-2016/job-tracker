using Faker;
using FizzWare.NBuilder;
using JobTracker.Web.Models;

namespace JobTracker.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JobTrackerWebDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JobTrackerWebDbContext context)
        {
       
            if (!context.Jobs.Any())
            {
                var jobs = Builder<Job>.CreateListOfSize(10)
                    .All()
                    .With(x => x.CompanyTitle = CompanyFaker.BS())
                    .With(x => x.JobTitle = CompanyFaker.Name())
                    .With(x => x.Address = Address.StreetAddress())
                    .With(x => x.Description = TextFaker.Sentences(3))
                    .With(x => x.PhoneNumber = PhoneFaker.Phone())
                    .With(x => x.Url = InternetFaker.Url())
                    .Build();
                context.Jobs.AddRange(jobs);

            
            }
        }
    }
}
