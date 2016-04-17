using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobTracker.Web.Models;

namespace JobTracker.Web.Controllers
{
    public class MvcJobsController : Controller
    {
        private readonly JobTrackerWebDbContext db = new JobTrackerWebDbContext();


        public ActionResult Index()
        {
            var model = db.Jobs.Select(j => new
            {
                j.Id,
                j.JobTitle,
                j.Address,
                j.CompanyTitle,
                j.Description,
                j.PhoneNumber,
                Status = j.Status.ToString(),
                j.Url,
                ApplicantName = j.User.FirstName + " " + j.User.LastName
                //Todo my need interviews here j.Interviews.Select()
            });
            return View();
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            var model = new
            {
                job.JobTitle,
                job.Address,
                job.CompanyTitle,
                job.Description,
                job.PhoneNumber,
                Status = job.Status.ToString(),
                job.Url,
                ApplicantName = $"{job.User.FirstName} {job.User.LastName}"
            };
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateJobVM vm)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();
                return View();
            }

            var newJob = new Job
            {
                JobTitle = vm.JobTitle,
                CompanyTitle = vm.CompanyTitle,
                Address = vm.Address,
                Status = JobStatus.Saved,
                Url = vm.Url,
                Description = vm.Description,
                PhoneNumber = vm.PhoneNumber,
                Created = DateTime.Now,
                StatusDate = DateTime.Now,
                User = db.Users.First()
            };

            db.Jobs.Add(newJob);
            db.SaveChanges();

            var model = new
            {
                vm.JobTitle,
                vm.CompanyTitle,
                vm.Address,
                Status = JobStatus.Saved,
                vm.Url,
                vm.Description,
                vm.PhoneNumber,
                Created = DateTime.Now,
                StatusDate = DateTime.Now
            };

            return View("Create");
        }


        [HttpPost]
        public ActionResult CreateInterview(CreateInterviewVM vm)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToList();
                return Json(errorList);
            }

            Job job = db.Jobs.Where(j => j.Id == vm.JobId).FirstOrDefault();
            var newInterview = new Interview()
            {
                Id = vm.JobId,
                Job = job,
                Date = vm.Date,
                User = db.Users.First()

            };
            db.Interviews.Add(newInterview);
            db.SaveChanges();

            var model = new
            {
                vm.Date

            };

            return View("CreateInterview");
        }
    }
}
