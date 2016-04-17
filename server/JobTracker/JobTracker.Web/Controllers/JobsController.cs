using System.Linq;
using System.Net;
using System.Web.Mvc;
using JobTracker.Web.Models;

namespace JobTracker.Web.Controllers

{
    public class JobsController : Controller
    {
        private readonly JobTrackerWebDbContext db = new JobTrackerWebDbContext();

        public ActionResult Index()
        {
            var model = db.Jobs.Select(j => new
            {
                j.JobTitle,
                j.Address,
                j.CompanyTitle,
                j.Description,
                j.PhoneNumber,
                j.Status,
                j.Url,
                j.Applied,
                j.Interviewed,
                j.Saved,
                j.Scheduled,
                j.UserId
                //Todo my need interviews here j.Interviews.Select()
            });
            return Json(model, JsonRequestBehavior.AllowGet);
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
                job.Status,
                job.Url,
                job.Applied,
                job.Interviewed,
                job.Saved,
                job.Scheduled,
                job.UserId
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(CreateJobVM vm)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                    where item.Value.Errors.Any()
                    select item.Value.Errors[0].ErrorMessage).ToList();
                return Json(errorList);
            }

            var newJob = new Job
            {
                JobTitle = vm.JobTitle,
                CompanyTitle = vm.CompanyTitle,
                Address = vm.Address,
                Status = vm.Status,
                Url = vm.Url,
                Description = vm.Description,
                PhoneNumber = vm.PhoneNumber
            };

            db.Jobs.Add(newJob);
            db.SaveChanges();

            return Json(newJob);
        }


        [HttpPut]
        public ActionResult Edit(EditJobVM vm)
        {
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                    where item.Value.Errors.Any()
                    select item.Value.Errors[0].ErrorMessage).ToList();
                return Json(errorList);
            }

            var job = db.Jobs.Find(vm.JobId);
            if (job == null)
            {
                return HttpNotFound();
            }

            job.JobTitle = vm.JobTitle;
            job.CompanyTitle = vm.CompanyTitle;
            job.Address = vm.Address;
            job.Status = vm.Status;
            job.Url = vm.Url;
            job.Description = vm.Description;
            job.PhoneNumber = vm.PhoneNumber;


            db.SaveChanges();
            return Json(job);
        }


        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return Content("OK!");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}